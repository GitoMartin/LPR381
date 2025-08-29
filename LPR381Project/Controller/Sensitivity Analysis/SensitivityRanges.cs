
using LPR381Project.Model.Sensitivity_analysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPR381Project.Controller.Sensitivity_Analysis
{
    internal class SensitivityRanges
    {
        private readonly SimplexTableau _tableau;
        private readonly int _n; // num decision vars
        private readonly int _m; // num constraints (slacks)
        private readonly double[,] _tab; // shorthand
        private readonly int[] _basicVars;
        private List<int> _nonBasics;

        public SensitivityRanges(SimplexTableau tableau)
        {
            _tableau = tableau;
            _tab = tableau.Tableau;
            _n = tableau.NumVariables;
            _m = tableau.NumSlackSurplus;
            _basicVars = tableau.BasicVariables;
            _nonBasics = GetNonBasics();
        }

        private List<int> GetNonBasics()
        {
            var nonBasics = new List<int>();
            var basicSet = new HashSet<int>(_basicVars);
            for (int c = 0; c < _n + _m; c++)
            {
                if (!basicSet.Contains(c))
                {
                    nonBasics.Add(c);
                }
            }
            return nonBasics;
        }

        /// <summary>
        /// Gets the allowable range for delta in c_j + delta for objective coefficient of decision variable j (0-based).
        /// Returns (min_delta, max_delta) where the current basis remains optimal.
        /// </summary>
        public (double minDelta, double maxDelta) GetObjectiveCoefRange(int j)
        {
            if (j < 0 || j >= _n)
            {
                throw new ArgumentOutOfRangeException(nameof(j), "Must be a decision variable index.");
            }

            bool isBasic = Array.IndexOf(_basicVars, j) >= 0;

            if (!isBasic)
            {
                // For non-basic: delta <= tableau[m, j], min = -inf
                double bottomJ = _tab[_m, j];
                return (double.NegativeInfinity, bottomJ);
            }
            else
            {
                // For basic: find row r
                int r = Array.IndexOf(_basicVars, j);
                if (r == -1) throw new InvalidOperationException("Basic variable not found.");

                var lowers = new List<double>();
                var uppers = new List<double>();

                foreach (int nb in _nonBasics)
                {
                    double a = _tab[r, nb];
                    if (Math.Abs(a) < 1e-9) continue;

                    double bound = -_tab[_m, nb] / a;

                    if (a > 0)
                    {
                        lowers.Add(bound);
                    }
                    else
                    {
                        uppers.Add(bound);
                    }
                }

                double minD = lowers.Count > 0 ? lowers.Max() : double.NegativeInfinity;
                double maxD = uppers.Count > 0 ? uppers.Min() : double.PositiveInfinity;

                return (minD, maxD);
            }
        }

        /// <summary>
        /// Gets the allowable range for gamma in b_i + gamma for RHS of constraint i (0-based).
        /// Returns (min_gamma, max_gamma) where the current basis remains optimal and feasible.
        /// </summary>
        public (double minGamma, double maxGamma) GetRHSRange(int i)
        {
            if (i < 0 || i >= _m)
            {
                throw new ArgumentOutOfRangeException(nameof(i), "Must be a constraint index.");
            }

            int slackCol = _n + i;

            var lowers = new List<double>();
            var uppers = new List<double>();

            for (int k = 0; k < _m; k++)
            {
                double a = _tab[k, slackCol];
                if (Math.Abs(a) < 1e-9) continue;

                double rhsK = _tab[k, _n + _m];
                double bound = -rhsK / a;

                if (a > 0)
                {
                    lowers.Add(bound);
                }
                else
                {
                    uppers.Add(bound);
                }
            }

            double minG = lowers.Count > 0 ? lowers.Max() : double.NegativeInfinity;
            double maxG = uppers.Count > 0 ? uppers.Min() : double.PositiveInfinity;

            return (minG, maxG);
        }

        /// <summary>
        /// Gets the allowable range for delta in a_{i,j} + delta for matrix coefficient of constraint i, variable j (0-based),
        /// where j must be non-basic.
        /// Returns (min_delta, max_delta) where the current basis remains optimal.
        /// </summary>
        public (double minDelta, double maxDelta) GetMatrixCoefRange(int i, int j)
        {
            if (i < 0 || i >= _m)
            {
                throw new ArgumentOutOfRangeException(nameof(i), "Must be a constraint index.");
            }
            if (j < 0 || j >= _n)
            {
                throw new ArgumentOutOfRangeException(nameof(j), "Must be a decision variable index.");
            }
            if (Array.IndexOf(_basicVars, j) >= 0)
            {
                throw new InvalidOperationException("Matrix coefficient range is only supported for non-basic variables.");
            }

            int slackCol = _n + i;
            double pi = _tab[_m, slackCol]; // shadow price
            double bottomJ = _tab[_m, j];

            if (Math.Abs(pi) < 1e-9)
            {
                return (double.NegativeInfinity, double.PositiveInfinity);
            }

            double bound = -bottomJ / pi;

            if (pi > 0)
            {
                return (bound, double.PositiveInfinity);
            }
            else
            {
                return (double.NegativeInfinity, bound);
            }
        }

        // Utility to format range for display
        public string FormatRange(double min, double max, double current = 0)
        {
            string minStr = double.IsNegativeInfinity(min) ? "-∞" : (current + min).ToString("F4");
            string maxStr = double.IsPositiveInfinity(max) ? "+∞" : (current + max).ToString("F4");
            return $"Range: [{minStr}, {maxStr}] (delta: [{(double.IsNegativeInfinity(min) ? "-∞" : min.ToString("F4"))}, {(double.IsPositiveInfinity(max) ? "+∞" : max.ToString("F4"))}])";
        }
    
}
}
