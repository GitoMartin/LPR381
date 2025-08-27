using Lpr381back;
using LPR381Project.Model.Sensitivity_analysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPR381Project.Controller.Sensitivity_Analysis
{
    internal class NewConstraintAnalyzer
    {
        private readonly LPModel _originalModel;
        private readonly SimplexTableau _optimalTableau;

        public NewConstraintAnalyzer(LPModel model, SimplexTableau optimalTableau)
        {
            _originalModel = model;
            _optimalTableau = optimalTableau;
        }

        /// <summary>
        /// Analyzes the new constraint and if the solution is no longer feasible,
        /// it continues with the dual simplex method to find and display the new optimal solution.
        /// Assumes the new constraint is of the form <= (less than or equal to).
        /// </summary>
        public string AnalyzeAndReoptimize(List<double> newConstrCoeffs, double newRhs)
        {
            int numConstraints = _originalModel.Rhs.Count;
            int n = _originalModel.ObjectiveFunction.Count; // Number of original variables

            // Compute LHS = sum (newConstrCoeffs[i] * x_i*) at current optimal solution
            double lhs = 0;
            for (int i = 0; i < numConstraints; i++)
            {
                int basicVar = _optimalTableau.BasicVariables[i];
                if (basicVar < n)
                {
                    lhs += newConstrCoeffs[basicVar] * _optimalTableau.Tableau[i, _optimalTableau.Tableau.GetLength(1) - 1];
                }
            }

            string result = $"--- Initial Analysis ---\n" +
                            $"Computed LHS at current optimal: {lhs:F2}\n" +
                            $"New RHS: {newRhs:F2}\n\n";

            // For <= constraint, if LHS <= newRhs, current solution remains feasible and optimal
            if (lhs <= newRhs + 1e-9)
            {
                result += "The current solution SATISFIES the new constraint. The optimal solution remains unchanged.";
                return result;
            }

            result += "The current solution VIOLATES the new constraint. Re-optimizing using dual simplex...\n\n";

            // --- Re-optimization ---
            double[,] augmentedTableau = AugmentTableau(newConstrCoeffs, newRhs);
            int[] basicVariables = new int[numConstraints + 1];
            for (int i = 0; i < numConstraints; i++)
            {
                basicVariables[i] = _optimalTableau.BasicVariables[i];
            }
            int newSlackIndex = n + numConstraints;
            basicVariables[numConstraints] = newSlackIndex;

            // Perform dual simplex pivots until feasible again
            int zRow = augmentedTableau.GetLength(0) - 1;
            while (true)
            {
                int pivotRow = FindDualPivotRow(augmentedTableau, zRow);
                if (pivotRow == -1) break; // Feasible

                int pivotCol = FindDualPivotColumn(augmentedTableau, pivotRow, zRow);
                if (pivotCol == -1)
                {
                    result += "ERROR: The problem became infeasible after adding the new constraint.";
                    return result;
                }

                basicVariables[pivotRow] = pivotCol;
                PerformPivoting(ref augmentedTableau, pivotRow, pivotCol);
            }

            result += GetNewOptimalSolutionString(augmentedTableau, basicVariables);
            return result;
        }

        private double[,] AugmentTableau(List<double> newConstrCoeffs, double newRhs)
        {
            int oldRows = _optimalTableau.Tableau.GetLength(0);
            int oldCols = _optimalTableau.Tableau.GetLength(1);
            int numConstraints = oldRows - 1;
            int n = _originalModel.ObjectiveFunction.Count;
            double[,] newTableau = new double[oldRows + 1, oldCols + 1];

            // Copy old body rows
            for (int i = 0; i < numConstraints; i++)
            {
                for (int j = 0; j < oldCols - 1; j++)
                {
                    newTableau[i, j] = _optimalTableau.Tableau[i, j];
                }
                newTableau[i, oldCols - 1] = 0; // New slack column
                newTableau[i, oldCols] = _optimalTableau.Tableau[i, oldCols - 1]; // Old RHS
            }

            // Compute new row (inserted before z-row)
            int newRow = numConstraints;
            for (int j = 0; j < oldCols - 1; j++)
            {
                double cj = (j < n) ? newConstrCoeffs[j] : 0;
                double sum = 0;
                for (int k = 0; k < numConstraints; k++)
                {
                    int basicVar = _optimalTableau.BasicVariables[k];
                    double cb = (basicVar < n) ? newConstrCoeffs[basicVar] : 0;
                    sum += cb * _optimalTableau.Tableau[k, j];
                }
                newTableau[newRow, j] = sum - cj;
            }
            newTableau[newRow, oldCols - 1] = 1; // New slack
            double newRhsVal = newRhs;
            for (int k = 0; k < numConstraints; k++)
            {
                int basicVar = _optimalTableau.BasicVariables[k];
                double cb = (basicVar < n) ? newConstrCoeffs[basicVar] : 0;
                newRhsVal -= cb * _optimalTableau.Tableau[k, oldCols - 1];
            }
            newTableau[newRow, oldCols] = newRhsVal;

            // Copy z-row
            for (int j = 0; j < oldCols - 1; j++)
            {
                newTableau[newRow + 1, j] = _optimalTableau.Tableau[numConstraints, j];
            }
            newTableau[newRow + 1, oldCols - 1] = 0; // New slack obj coeff
            newTableau[newRow + 1, oldCols] = _optimalTableau.Tableau[numConstraints, oldCols - 1];

            return newTableau;
        }

        private int FindDualPivotRow(double[,] tableau, int zRow)
        {
            int numCols = tableau.GetLength(1);
            int pivotRow = -1;
            double minVal = -1e-9;
            for (int i = 0; i < zRow; i++)
            {
                if (tableau[i, numCols - 1] < minVal)
                {
                    minVal = tableau[i, numCols - 1];
                    pivotRow = i;
                }
            }
            return pivotRow;
        }

        private int FindDualPivotColumn(double[,] tableau, int pivotRow, int zRow)
        {
            int numCols = tableau.GetLength(1);
            int pivotCol = -1;
            double minRatio = double.PositiveInfinity;
            for (int j = 0; j < numCols - 1; j++)
            {
                double a_rj = tableau[pivotRow, j];
                if (a_rj < -1e-9)
                {
                    double ratio = tableau[zRow, j] / (-a_rj);
                    if (ratio < minRatio)
                    {
                        minRatio = ratio;
                        pivotCol = j;
                    }
                }
            }
            return pivotCol;
        }

        private void PerformPivoting(ref double[,] tableau, int pivotRow, int pivotCol)
        {
            int numRows = tableau.GetLength(0);
            int numCols = tableau.GetLength(1);
            double pivotElement = tableau[pivotRow, pivotCol];

            for (int j = 0; j < numCols; j++)
            {
                tableau[pivotRow, j] /= pivotElement;
            }

            for (int i = 0; i < numRows; i++)
            {
                if (i != pivotRow)
                {
                    double factor = tableau[i, pivotCol];
                    for (int j = 0; j < numCols; j++)
                    {
                        tableau[i, j] -= factor * tableau[pivotRow, j];
                    }
                }
            }
        }

        private string GetNewOptimalSolutionString(double[,] finalTableau, int[] basicVariables)
        {
            var sb = new StringBuilder("--- New Optimal Solution ---\n");
            int numRows = finalTableau.GetLength(0);
            int numCols = finalTableau.GetLength(1);

            sb.AppendLine($"New Optimal Objective Value: {finalTableau[numRows - 1, numCols - 1]:F2}");

            for (int i = 0; i < basicVariables.Length; i++)
            {
                int varIndex = basicVariables[i];
                string varName;
                int n = _originalModel.ObjectiveFunction.Count;
                int oldM = _originalModel.Rhs.Count;
                if (varIndex < n)
                    varName = $"x{varIndex + 1}";
                else if (varIndex < n + oldM)
                    varName = $"s{varIndex - n + 1}";
                else
                    varName = $"s{oldM + 1} (new)";

                sb.AppendLine($"{varName} = {finalTableau[i, numCols - 1]:F2}");
            }
            return sb.ToString();
        }
    }
}
