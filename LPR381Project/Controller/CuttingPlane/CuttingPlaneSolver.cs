using Lpr381back;
using LPR381Project.Model.CuttingPlane;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPR381Project.Controller.CuttingPlane
{
    internal class CuttingPlaneSolver
    {
        private readonly LPModel _model;
        private double[,] _tableau;
        private int[] _basis; // Stores the index of the variable in the basis for each row
        private int _numVariables;
        private int _numConstraints;
        private int _numSlackVars;
        private const double Epsilon = 1e-9; // Tolerance for floating point comparisons
        public StringBuilder canonical = new System.Text.StringBuilder();
        public CuttingPlaneSolver(LPModel model)
        {
            _model = model;
        }

        public string Solve()
        {
            var log = new System.Text.StringBuilder();
            log.AppendLine("--- Initial Problem Setup ---");
            InitializeTableau();
            log.Append(TableauViewer.DisplayString(_tableau, _numVariables, _basis));
            canonical.AppendLine("Initial Tableau:");
            canonical.Append(TableauViewer.DisplayString(_tableau, _numVariables, _basis));

            int iteration = 0;
            while (iteration < 20) // Safety break to prevent infinite loops
            {
                log.AppendLine($"--- Starting Iteration {iteration + 1} ---");

                // Solve the current LP relaxation
                log.Append(RunSimplex());
                log.AppendLine("Optimal LP Tableau for this iteration:");
                log.Append(TableauViewer.DisplayString(_tableau, _numVariables, _basis));

                // Check if the solution is all integers
                if (IsIntegerSolution())
                {
                    log.AppendLine(">>> Integer solution found! <<<");
                    log.Append(GetSolutionString());
                    return log.ToString();
                }

                // If not integer, generate and add a Gomory cut
                log.AppendLine("Solution is not integer. Generating Gomory cut.");
                int cutRowIndex = SelectCutRow();
                if (cutRowIndex == -1)
                {
                    log.AppendLine("Could not find a valid row to generate a cut. Stopping.");
                    break;
                }

                AddGomoryCut(cutRowIndex);
                log.AppendLine("Tableau after adding new cut (s" + _numSlackVars + "):");
                log.Append(TableauViewer.DisplayString(_tableau, _numVariables, _basis));

                // The new tableau is infeasible, so re-optimize using Dual Simplex
                log.AppendLine("Re-optimizing with Dual Simplex...");
                log.Append(RunDualSimplex());

                iteration++;
            }

            log.AppendLine("Solver stopped. Final (possibly non-integer or infeasible) state:");
            log.Append(GetSolutionString());
            return log.ToString();
        }

        /// <summary>
        /// Sets up the initial simplex tableau from the model.
        /// Assumes a maximization problem with all <= constraints.
        /// </summary>
        private void InitializeTableau()
        {
            _numVariables = _model.ObjectiveFunction.Count;
            _numConstraints = _model.ConstraintCoefficients.Count;

            // Find binary variable indices
            var binIdx = Enumerable.Range(0, _numVariables)
                .Where(j => _model.Signs != null && j < _model.Signs.Count &&
                            (_model.Signs[j]?.Equals("Bin", StringComparison.OrdinalIgnoreCase) == true ||
                             _model.Signs[j]?.Equals("Binary", StringComparison.OrdinalIgnoreCase) == true))
                .ToList();

            int numBinConstraints = binIdx.Count;
            _numSlackVars = _numConstraints + numBinConstraints;

            // Tableau dimensions: 1 for Z-row, constraints + bin constraints for rows
            // Columns: 1 for Z, numVariables, numSlacks, 1 for RHS
            int rows = _numConstraints + numBinConstraints + 1;
            int cols = 1 + _numVariables + _numSlackVars + 1;
            _tableau = new double[rows, cols];
            _basis = new int[rows];

            // --- Initialize Z-Row (Row 0) ---
            _tableau[0, 0] = 1; // Z column
            for (int i = 0; i < _numVariables; i++)
            {
                // Assumes maximization, so coefficients are negated
                _tableau[0, i + 1] = -_model.ObjectiveFunction[i];
            }

            // --- Initialize Constraint Rows ---
            for (int i = 0; i < _numConstraints; i++)
            {
                // Coefficients
                for (int j = 0; j < _numVariables; j++)
                {
                    _tableau[i + 1, j + 1] = _model.ConstraintCoefficients[i][j];
                }
                // RHS
                _tableau[i + 1, cols - 1] = _model.Rhs[i];

                // Check constraint sign and add slack/surplus
                string ineq = _model.ConstraintInequalities[i].Trim();
                if (ineq.StartsWith("<="))
                {
                    _tableau[i + 1, 1 + _numVariables + i] = 1; // slack
                }
                else if (ineq.StartsWith(">="))
                {
                    _tableau[i + 1, 1 + _numVariables + i] = -1; // surplus
                }
                else if (ineq.StartsWith("="))
                {
                    // For equality, treat as slack (or could add artificial if needed)
                    _tableau[i + 1, 1 + _numVariables + i] = 1;
                }
                else
                {
                    throw new Exception($"Invalid constraint inequality: {ineq}");
                }
                // Set initial basis variable (slack/surplus)
                _basis[i + 1] = _numVariables + 1 + i;
            }

            // --- Add binary constraints x_j <= 1 ---
            for (int b = 0; b < numBinConstraints; b++)
            {
                int rowIdx = _numConstraints + 1 + b;
                int varIdx = binIdx[b];
                // Set x_j coefficient
                _tableau[rowIdx, 1 + varIdx] = 1.0;
                // Add slack for this binary constraint
                _tableau[rowIdx, 1 + _numVariables + _numConstraints + b] = 1.0;
                // RHS = 1
                _tableau[rowIdx, cols - 1] = 1.0;
                // Set basis
                _basis[rowIdx] = _numVariables + 1 + _numConstraints + b;
            }
        }

        /// <summary>
        /// Runs the standard Simplex algorithm to find the optimal solution for the current tableau.
        /// </summary>
        

        private string RunSimplex()
        {
            var log = new System.Text.StringBuilder();
            while (true)
            {
                int pivotCol = FindPivotColumn();
                if (pivotCol == -1) break; // Optimal

                int pivotRow = FindPivotRow(pivotCol);
                if (pivotRow == -1)
                {
                    log.AppendLine("Unbounded solution detected.");
                    return log.ToString();
                }

                log.AppendLine($"Simplex Pivot: Entering: Var {pivotCol}, Leaving: Var {_basis[pivotRow]}");
                Pivot(pivotRow, pivotCol);
                _basis[pivotRow] = pivotCol; // Update basis
                log.Append(TableauViewer.DisplayString(_tableau, _numVariables, _basis));
            }
            return log.ToString();
        }

        /// <summary>
        /// Finds the pivot column (entering variable) for the Simplex method.
        /// This is the column with the most negative coefficient in the Z-row.
        /// </summary>
        private int FindPivotColumn()
        {
            int pivotCol = -1;
            double minVal = -Epsilon;
            for (int j = 1; j < _tableau.GetLength(1) - 1; j++)
            {
                if (_tableau[0, j] < minVal)
                {
                    minVal = _tableau[0, j];
                    pivotCol = j;
                }
            }
            return pivotCol;
        }

        /// <summary>
        /// Finds the pivot row (leaving variable) using the minimum ratio test.
        /// </summary>
        private int FindPivotRow(int pivotCol)
        {
            int pivotRow = -1;
            double minRatio = double.MaxValue;
            for (int i = 1; i < _tableau.GetLength(0); i++)
            {
                if (_tableau[i, pivotCol] > Epsilon)
                {
                    double ratio = _tableau[i, _tableau.GetLength(1) - 1] / _tableau[i, pivotCol];
                    if (ratio < minRatio)
                    {
                        minRatio = ratio;
                        pivotRow = i;
                    }
                }
            }
            return pivotRow;
        }

        /// <summary>
        /// Runs the Dual Simplex algorithm. Used after adding a cut.
        /// </summary>
        

        private string RunDualSimplex()
        {
            var log = new System.Text.StringBuilder();
            while (true)
            {
                int pivotRow = FindDualPivotRow();
                if (pivotRow == -1) break; // Feasible and optimal

                int pivotCol = FindDualPivotColumn(pivotRow);
                if (pivotCol == -1)
                {
                    log.AppendLine("Infeasible solution detected in Dual Simplex.");
                    return log.ToString();
                }

                log.AppendLine($"Dual Simplex Pivot: Leaving: Var {_basis[pivotRow]}, Entering: Var {pivotCol}");
                Pivot(pivotRow, pivotCol);
                _basis[pivotRow] = pivotCol; // Update basis
                log.Append(TableauViewer.DisplayString(_tableau, _numVariables, _basis));
            }
            return log.ToString();
        }

        /// <summary>
        /// Finds the pivot row for Dual Simplex (most negative RHS).
        /// </summary>
        private int FindDualPivotRow()
        {
            int pivotRow = -1;
            double minRhs = -Epsilon;
            for (int i = 1; i < _tableau.GetLength(0); i++)
            {
                if (_tableau[i, _tableau.GetLength(1) - 1] < minRhs)
                {
                    minRhs = _tableau[i, _tableau.GetLength(1) - 1];
                    pivotRow = i;
                }
            }
            return pivotRow;
        }

        /// <summary>
        /// Finds the pivot column for Dual Simplex (min ratio test on Z-row).
        /// </summary>
        private int FindDualPivotColumn(int pivotRow)
        {
            int pivotCol = -1;
            double minRatio = double.MaxValue;
            for (int j = 1; j < _tableau.GetLength(1) - 1; j++)
            {
                if (_tableau[pivotRow, j] < -Epsilon)
                {
                    double ratio = Math.Abs(_tableau[0, j] / _tableau[pivotRow, j]);
                    if (ratio < minRatio)
                    {
                        minRatio = ratio;
                        pivotCol = j;
                    }
                }
            }
            return pivotCol;
        }


        /// <summary>
        /// Performs the pivot operation on the tableau.
        /// </summary>
        private void Pivot(int pivotRow, int pivotCol)
        {
            double pivotElement = _tableau[pivotRow, pivotCol];
            int cols = _tableau.GetLength(1);

            // Normalize the pivot row
            for (int j = 0; j < cols; j++)
            {
                _tableau[pivotRow, j] /= pivotElement;
            }

            // Clear other entries in the pivot column
            for (int i = 0; i < _tableau.GetLength(0); i++)
            {
                if (i != pivotRow)
                {
                    double multiplier = _tableau[i, pivotCol];
                    for (int j = 0; j < cols; j++)
                    {
                        _tableau[i, j] -= multiplier * _tableau[pivotRow, j];
                    }
                }
            }
        }

        /// <summary>
        /// Checks if the current solution in the tableau is all-integer.
        /// </summary>
        private bool IsIntegerSolution()
        {
            for (int i = 1; i < _tableau.GetLength(0); i++)
            {
                double val = _tableau[i, _tableau.GetLength(1) - 1];
                if (Math.Abs(val - Math.Round(val)) > Epsilon)
                {
                    return false; // Found a non-integer value
                }
            }
            return true;
        }

        /// <summary>
        /// Selects a row with a non-integer RHS to generate a Gomory cut.
        /// A common heuristic is to choose the one with the largest fractional part.
        /// </summary>
        private int SelectCutRow()
        {
            int cutRow = -1;
            double maxFraction = -1.0;
            for (int i = 1; i < _tableau.GetLength(0); i++)
            {
                double rhs = _tableau[i, _tableau.GetLength(1) - 1];
                double fractionalPart = rhs - Math.Floor(rhs);
                if (fractionalPart > Epsilon && fractionalPart > maxFraction)
                {
                    maxFraction = fractionalPart;
                    cutRow = i;
                }
            }
            return cutRow;
        }

        /// <summary>
        /// Generates a Gomory cut from the selected row and adds it to the tableau.
        /// </summary>
        private void AddGomoryCut(int cutRowIndex)
        {
            _numSlackVars++;
            int oldRows = _tableau.GetLength(0);
            int oldCols = _tableau.GetLength(1);

            // Create a new, larger tableau
            double[,] newTableau = new double[oldRows + 1, oldCols + 1];
            int[] newBasis = new int[oldRows + 1];

            // Copy old tableau, inserting a new column for the new slack variable
            for (int i = 0; i < oldRows; i++)
            {
                for (int j = 0; j < oldCols; j++)
                {
                    if (j < oldCols - 1)
                        newTableau[i, j] = _tableau[i, j];
                    else // RHS column
                        newTableau[i, oldCols] = _tableau[i, j];
                }
                newBasis[i] = _basis[i];
            }

            // --- Create the new cut row ---
            int newRow = oldRows;
            for (int j = 1; j < oldCols - 1; j++) // For each variable column
            {
                double val = _tableau[cutRowIndex, j];
                // The cut constraint is -f_j <= -f_0
                newTableau[newRow, j] = -(val - Math.Floor(val));
            }
            // RHS of the cut
            double rhs = _tableau[cutRowIndex, oldCols - 1];
            newTableau[newRow, oldCols] = -(rhs - Math.Floor(rhs));

            // Add the new slack variable for this cut
            newTableau[newRow, oldCols - 1] = 1.0;
            newBasis[newRow] = _numVariables + _numSlackVars;

            _tableau = newTableau;
            _basis = newBasis;
        }

        private string GetSolutionString()
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine("\n--- Solution ---");
            sb.AppendLine($"Optimal Z = {_tableau[0, _tableau.GetLength(1) - 1]:F2}");

            // Create an array to hold variable values, initialized to 0
            double[] varValues = new double[_numVariables + 1];

            for (int i = 1; i < _basis.Length; i++)
            {
                // If the basis variable is one of our original decision variables (x_j)
                if (_basis[i] <= _numVariables)
                {
                    varValues[_basis[i]] = _tableau[i, _tableau.GetLength(1) - 1];
                }
            }

            for (int i = 1; i <= _numVariables; i++)
            {
                sb.AppendLine($"x{i} = {Math.Round(varValues[i])}");
            }
            sb.AppendLine("---------------\n");
            return sb.ToString();
        }

        // Builds the canonical form matrix for the LP, including binary constraints, correct signs, and min/max support
        private List<List<double>> BuildCanonicalForm()
        {
            int m = _model.ConstraintCoefficients.Count;
            int n = _model.ObjectiveFunction.Count;
            bool isMax = true;
            if (!string.IsNullOrEmpty(_model.Type))
                isMax = _model.Type.Trim().ToLowerInvariant().StartsWith("max");

            var binIdx = Enumerable.Range(0, n)
                .Where(j => _model.Signs != null && j < _model.Signs.Count &&
                            (_model.Signs[j]?.Equals("Bin", StringComparison.OrdinalIgnoreCase) == true ||
                             _model.Signs[j]?.Equals("Binary", StringComparison.OrdinalIgnoreCase) == true))
                .ToList();

            int totalConstraints = m + binIdx.Count;
            var T = new List<List<double>>();
            var rhsList = new List<double>();
            var signList = new List<string>();

            // Constraint rows + slack/surplus block + RHS
            for (int i = 0; i < m; i++)
            {
                var row = new List<double>(_model.ConstraintCoefficients[i]);

                string ineq = _model.ConstraintInequalities[i].Trim();
                double rhs;
                string sign;
                if (ineq.StartsWith("<="))
                {
                    rhs = double.Parse(ineq.Substring(2), CultureInfo.InvariantCulture);
                    sign = "<=";
                }
                else if (ineq.StartsWith(">="))
                {
                    rhs = double.Parse(ineq.Substring(2), CultureInfo.InvariantCulture);
                    sign = ">=";
                }
                else if (ineq.StartsWith("="))
                {
                    rhs = double.Parse(ineq.Substring(1), CultureInfo.InvariantCulture);
                    sign = "=";
                }
                else
                    throw new Exception($"Invalid inequality format: {ineq}");

                for (int s = 0; s < totalConstraints; s++)
                {
                    double val = 0.0;
                    if (s == i)
                    {
                        if (sign == "<=") val = 1.0;      // slack
                        else if (sign == ">=") val = -1.0; // surplus
                    }
                    row.Add(val);
                }

                row.Add(rhs);
                T.Add(row);
                rhsList.Add(rhs);
                signList.Add(sign);
            }

            // Binary constraints x_j <= 1
            for (int b = 0; b < binIdx.Count; b++)
            {
                int j = binIdx[b];
                var row = new List<double>();
                for (int k = 0; k < n; k++) row.Add(k == j ? 1.0 : 0.0);
                for (int s = 0; s < totalConstraints; s++)
                    row.Add(s == (m + b) ? 1.0 : 0.0);
                row.Add(1.0);
                T.Add(row);
                rhsList.Add(1.0);
                signList.Add("<=");
            }

            // Objective row (use -c for max, +c for min)
            var obj = new List<double>(_model.ObjectiveFunction.Select(c => isMax ? -c : c));
            obj.AddRange(Enumerable.Repeat(0.0, totalConstraints));
            obj.Add(0.0);
            T.Add(obj);

            // Optionally, you can store rhsList and signList for further use
            // (e.g., for display or for use in other methods)

            return T;
        }
    }
}
