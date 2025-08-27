using Lpr381back;
using LPR381Project.Model.Sensitivity_analysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPR381Project.Controller.Sensitivity_Analysis
{
    internal class NewActivityAnalyzer
    {
        private readonly LPModel _originalModel;
        private readonly SimplexTableau _optimalTableau;

        public NewActivityAnalyzer(LPModel model, SimplexTableau optimalTableau)
        {
            _originalModel = model;
            _optimalTableau = optimalTableau;
        }

        /// <summary>
        /// Analyzes the new activity and if the solution is no longer optimal,
        /// it continues the simplex method to find and display the new optimal solution.
        /// </summary>
        public string AnalyzeAndReoptimize(double newVarObjective, List<double> newVarCoeffs)
        {
            int numConstraints = _originalModel.Rhs.Count;

            // B_inv is the matrix formed by the slack variable columns in the final tableau
            double[,] b_inv = new double[numConstraints, numConstraints];
            for (int i = 0; i < numConstraints; i++)
            {
                for (int j = 0; j < numConstraints; j++)
                {
                    b_inv[i, j] = _optimalTableau.Tableau[i, _optimalTableau.NumVariables + j];
                }
            }

            // Calculate the new column in the tableau: P_new = B_inv * a_new
            double[] newTableauCol = new double[numConstraints];
            for (int i = 0; i < numConstraints; i++)
            {
                for (int j = 0; j < newVarCoeffs.Count; j++)
                {
                    newTableauCol[i] += b_inv[i, j] * newVarCoeffs[j];
                }
            }

            // Calculate Zj for the new variable using the objective coefficients of the basic variables (Cb)
            double zj = 0;
            for (int i = 0; i < numConstraints; i++)
            {
                int basicVarIndex = _optimalTableau.BasicVariables[i];
                double cb = (basicVarIndex < _originalModel.ObjectiveFunction.Count)
                            ? _originalModel.ObjectiveFunction[basicVarIndex]
                            : 0; // Slack variables have a Cb of 0
                zj += cb * newTableauCol[i];
            }

            // Using the Z-row convention from the solver (Zj - Cj)
            double zRowValue = zj - newVarObjective;

            string result = $"--- Initial Analysis ---\n" +
                            $"New Column in Tableau Body: [{string.Join(", ", newTableauCol.Select(v => v.ToString("F2")))}]\n" +
                            $"Cj (Objective Coeff): {newVarObjective}\n" +
                            $"Zj (Calculated): {zj:F2}\n" +
                            $"Resulting Zj-Cj for Z-Row: {zRowValue:F2}\n\n";

            // For maximization, if Zj-Cj is negative, the solution is no longer optimal.
            if (zRowValue >= -1e-9)
            {
                result += "The current solution REMAINS optimal. The new activity would not improve the objective value.";
                return result;
            }

            result += "The current solution is NO LONGER optimal. Re-optimizing...\n\n";

            // --- Re-optimization ---
            double[,] augmentedTableau = AugmentTableau(newTableauCol, zRowValue);
            int[] basicVariables = (int[])_optimalTableau.BasicVariables.Clone();
            int newVarIndex = _optimalTableau.Tableau.GetLength(1) - 1;

            // Perform simplex pivots until optimal again
            while (true)
            {
                int pivotCol = FindPivotColumn(augmentedTableau);
                if (pivotCol == -1) break; // Optimal

                int pivotRow = FindPivotRow(augmentedTableau, pivotCol);
                if (pivotRow == -1)
                {
                    result += "ERROR: The problem became unbounded after adding the new activity.";
                    return result;
                }

                basicVariables[pivotRow] = pivotCol == newVarIndex ? (_originalModel.ObjectiveFunction.Count + _originalModel.Rhs.Count) : pivotCol;
                PerformPivoting(ref augmentedTableau, pivotRow, pivotCol);
            }

            result += GetNewOptimalSolutionString(augmentedTableau, basicVariables);
            return result;
        }

        private double[,] AugmentTableau(double[] newColumn, double zRowValue)
        {
            int oldRows = _optimalTableau.Tableau.GetLength(0);
            int oldCols = _optimalTableau.Tableau.GetLength(1);
            double[,] newTableau = new double[oldRows, oldCols + 1];

            for (int i = 0; i < oldRows; i++)
            {
                for (int j = 0; j < oldCols - 1; j++)
                {
                    newTableau[i, j] = _optimalTableau.Tableau[i, j];
                }
                // Add the new column before the RHS
                newTableau[i, oldCols - 1] = (i < oldRows - 1) ? newColumn[i] : zRowValue;
                // Add the old RHS column at the end
                newTableau[i, oldCols] = _optimalTableau.Tableau[i, oldCols - 1];
            }
            return newTableau;
        }

        private int FindPivotColumn(double[,] tableau)
        {
            int numRows = tableau.GetLength(0);
            int numCols = tableau.GetLength(1);
            int pivotCol = -1;
            double minVal = -1e-9;
            for (int j = 0; j < numCols - 1; j++)
            {
                if (tableau[numRows - 1, j] < minVal)
                {
                    minVal = tableau[numRows - 1, j];
                    pivotCol = j;
                }
            }
            return pivotCol;
        }

        private int FindPivotRow(double[,] tableau, int pivotCol)
        {
            int numRows = tableau.GetLength(0);
            int numCols = tableau.GetLength(1);
            int pivotRow = -1;
            double minRatio = double.PositiveInfinity;
            for (int i = 0; i < numRows - 1; i++)
            {
                if (tableau[i, pivotCol] > 1e-9)
                {
                    double ratio = tableau[i, numCols - 1] / tableau[i, pivotCol];
                    if (ratio < minRatio)
                    {
                        minRatio = ratio;
                        pivotRow = i;
                    }
                }
            }
            return pivotRow;
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
                if (varIndex < _originalModel.ObjectiveFunction.Count)
                    varName = $"x{varIndex + 1}";
                else if (varIndex < _originalModel.ObjectiveFunction.Count + _originalModel.Rhs.Count)
                    varName = $"s{varIndex - _originalModel.ObjectiveFunction.Count + 1}";
                else
                    varName = "New Variable";

                sb.AppendLine($"{varName} = {finalTableau[i, numCols - 1]:F2}");
            }
            return sb.ToString();
        }
    }
}
