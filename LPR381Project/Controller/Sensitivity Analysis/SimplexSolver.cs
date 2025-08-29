
using Lpr381back;
using LPR381Project.Model.Sensitivity_analysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPR381Project.Controller.Sensitivity_Analysis
{
    internal class SimplexSolver
    {
        private readonly LPModel _model;
        private double[,] _tableau;
        private int _numRows, _numCols;
        private int[] _basicVariables;

        public SimplexSolver(LPModel model)
        {
            _model = model;
        }

        /// <summary>
        /// Solves the LP problem and returns the optimal tableau.
        /// </summary>
        public SimplexTableau Solve()
        {
            InitializeTableau();

            while (IsOptimal() == false)
            {
                int pivotCol = FindPivotColumn();
                int pivotRow = FindPivotRow(pivotCol);

                if (pivotRow == -1)
                {
                    throw new InvalidOperationException("The problem is unbounded.");
                }

                _basicVariables[pivotRow] = pivotCol;
                PerformPivoting(pivotRow, pivotCol);
            }

            return CreateOptimalTableau();
        }

        private void InitializeTableau()
        {
            int numDecisionVars = _model.ObjectiveFunction.Count;
            int numConstraints = _model.Rhs.Count;
            _numRows = numConstraints + 1; // +1 for the Z-row
            _numCols = numDecisionVars + numConstraints + 1; // +1 for the RHS

            _tableau = new double[_numRows, _numCols];
            _basicVariables = new int[numConstraints];

            // Fill in constraint coefficients
            for (int i = 0; i < numConstraints; i++)
            {
                for (int j = 0; j < numDecisionVars; j++)
                {
                    _tableau[i, j] = _model.ConstraintCoefficients[i][j];
                }
            }

            // Fill in slack variables and RHS
            for (int i = 0; i < numConstraints; i++)
            {
                _tableau[i, numDecisionVars + i] = 1; // Slack variable
                _tableau[i, _numCols - 1] = _model.Rhs[i];
                _basicVariables[i] = numDecisionVars + i; // Initially, slack variables are basic
            }

            // Fill in Z-row (Cj-Zj row)
            for (int j = 0; j < numDecisionVars; j++)
            {
                _tableau[_numRows - 1, j] = -_model.ObjectiveFunction[j];
            }
        }

        private bool IsOptimal()
        {
            for (int j = 0; j < _numCols - 1; j++)
            {
                if (_tableau[_numRows - 1, j] < 0)
                {
                    return false; // Not optimal if any value in Z-row is negative
                }
            }
            return true;
        }

        private int FindPivotColumn()
        {
            int pivotCol = -1;
            double minVal = 0;
            for (int j = 0; j < _numCols - 1; j++)
            {
                if (_tableau[_numRows - 1, j] < minVal)
                {
                    minVal = _tableau[_numRows - 1, j];
                    pivotCol = j;
                }
            }
            return pivotCol;
        }

        private int FindPivotRow(int pivotCol)
        {
            int pivotRow = -1;
            double minRatio = double.PositiveInfinity;
            for (int i = 0; i < _numRows - 1; i++)
            {
                if (_tableau[i, pivotCol] > 1e-9) // If the element is positive
                {
                    double ratio = _tableau[i, _numCols - 1] / _tableau[i, pivotCol];
                    if (ratio < minRatio)
                    {
                        minRatio = ratio;
                        pivotRow = i;
                    }
                }
            }
            return pivotRow;
        }

        private void PerformPivoting(int pivotRow, int pivotCol)
        {
            double pivotElement = _tableau[pivotRow, pivotCol];

            // Normalize the pivot row
            for (int j = 0; j < _numCols; j++)
            {
                _tableau[pivotRow, j] /= pivotElement;
            }

            // Make other elements in pivot column zero
            for (int i = 0; i < _numRows; i++)
            {
                if (i != pivotRow)
                {
                    double factor = _tableau[i, pivotCol];
                    for (int j = 0; j < _numCols; j++)
                    {
                        _tableau[i, j] -= factor * _tableau[pivotRow, j];
                    }
                }
            }
        }

        private SimplexTableau CreateOptimalTableau()
        {
            return new SimplexTableau
            {
                Tableau = _tableau,
                NumVariables = _model.ObjectiveFunction.Count,
                NumSlackSurplus = _model.Rhs.Count,
                BasicVariables = _basicVariables,
                ObjectiveValue = _tableau[_numRows - 1, _numCols - 1]
            };
        }
    }
}
