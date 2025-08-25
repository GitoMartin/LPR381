using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Lpr381back
{
    public class BranchAndBoundSolver
    {
        private static readonly CultureInfo Inv = CultureInfo.InvariantCulture;

        private readonly LPModel _model;

        // label, solution, objective, tableau sequence, infeasible?, integer?
        private readonly List<(string label, Dictionary<int, double> solution, double obj,
                               List<List<List<double>>> tableau, bool infeasible, bool isInteger)> _nodes;

        public BranchAndBoundSolver(LPModel model)
        {
            _model = model;
            _nodes = new List<(string, Dictionary<int, double>, double,
                               List<List<List<double>>>, bool, bool)>();
        }

        // ===================== PUBLIC API (string outputs) =====================

        /// <summary>
        /// Solves the root relaxed LP, then branches from the optimal root solution.
        /// Returns a full report of all explored nodes as a string (for UI TextBox).
        /// </summary>
        public string ShowAllNodes()
        {
            _nodes.Clear();
            var sb = new StringBuilder();

            // 1) Solve the ROOT RELAXED LP ONCE
            var rootSolver = new DualSimplex(_model);
            var rootIters = rootSolver.Solve();
            var rootTableau = rootIters.Last();
            var rootSolution = ExtractSolution(rootTableau, _model.ObjectiveFunction.Count);
            var rootObj = rootTableau.Last().Last();

            // Store root as RELAXED (not integer)
            _nodes.Add(("Root (relaxed optimum)", rootSolution, rootObj, rootIters, false, false));

            // 2) Branch FROM THE OPTIMAL ROOT SOLUTION (not from iteration 0)
            BranchFromSolution(_model.Clone(), "Root", rootSolution);

            // 3) Build report
            foreach (var node in _nodes)
            {
                sb.AppendLine($"\r\n--- Node {node.label} ---");
                if (node.infeasible)
                {
                    sb.AppendLine("Infeasible.");
                    continue;
                }

                sb.AppendLine($"Objective = {node.obj.ToString("0.###", Inv)}");
                foreach (var kv in node.solution.OrderBy(k => k.Key))
                    sb.AppendLine($"x{kv.Key + 1} = {kv.Value.ToString("0.###", Inv)}");

                if (node.tableau != null)
                {
                    var simplex = new DualSimplex(_model);
                    sb.AppendLine(simplex.GetIterationsString(node.tableau, $"Tableau for {node.label}"));
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Picks the best integer/binary solution found among the explored nodes and returns it as a string.
        /// If nodes were not computed yet, it computes them first.
        /// </summary>
        public string ShowBestSolution()
        {
            if (_nodes.Count == 0)
                ShowAllNodes();

            var sb = new StringBuilder();

            var feasibleIntegers = _nodes.Where(n => !n.infeasible && n.isInteger).ToList();

            if (feasibleIntegers.Count == 0)
            {
                sb.AppendLine("No integer/binary solutions found.");
                return sb.ToString();
            }

            bool isMax = !(_model.Type != null &&
                           _model.Type.Equals("Min", StringComparison.OrdinalIgnoreCase));

            var best = isMax
                ? feasibleIntegers.OrderByDescending(n => n.obj).First()
                : feasibleIntegers.OrderBy(n => n.obj).First();

            sb.AppendLine("=== Best Integer/Binary Solution ===");
            sb.AppendLine($"From Node: {best.label}");
            sb.AppendLine($"Objective Value = {best.obj.ToString("0.###", Inv)}");
            foreach (var kv in best.solution.OrderBy(k => k.Key))
                sb.AppendLine($"x{kv.Key + 1} = {kv.Value.ToString("0.###", Inv)}");

            if (best.tableau != null)
            {
                var simplex = new DualSimplex(_model);
                sb.AppendLine(simplex.GetIterationsString(best.tableau, $"Final tableau for {best.label}"));
            }

            return sb.ToString();
        }

        // ===================== CORE LOGIC =====================

        /// <summary>
        /// Branch using a given (already optimal relaxed) solution for the current model.
        /// This prevents starting from iteration-0; we branch from optimal.
        /// </summary>
        private void BranchFromSolution(LPModel baseModel, string label, Dictionary<int, double> solution)
        {
            int fracVar = FindFirstFractionalVar(solution, baseModel.Signs);
            if (fracVar == -1)
            {
                // The relaxed solution is already integer/binary → record as integer and stop
                // (We still need objective/tableau to record it; solve once for this node.)
                try
                {
                    var iters = new DualSimplex(baseModel).Solve();
                    var tab = iters.Last();
                    var obj = tab.Last().Last();
                    var sol = ExtractSolution(tab, baseModel.ObjectiveFunction.Count);
                    _nodes.Add(($"{label} (integer)", sol, obj, iters, false, true));
                }
                catch
                {
                    _nodes.Add(($"{label} (integer?)", null, double.NaN, null, true, false));
                }
                return;
            }

            // fractional → create branches: x_frac <= floor, x_frac >= ceil
            double val = solution[fracVar];
            int floorVal = (int)Math.Floor(val);
            int ceilVal = (int)Math.Ceiling(val);

            // Avoid useless branching if floor==ceil (numeric noise)
            if (floorVal == ceilVal)
            {
                try
                {
                    var iters = new DualSimplex(baseModel).Solve();
                    var tab = iters.Last();
                    var obj = tab.Last().Last();
                    var sol = ExtractSolution(tab, baseModel.ObjectiveFunction.Count);
                    _nodes.Add(($"{label} (degenerate)", sol, obj, iters, false, false));
                }
                catch
                {
                    _nodes.Add(($"{label} (degenerate)", null, double.NaN, null, true, false));
                }
                return;
            }

            // LEFT: x_fracVar <= floorVal
            var left = baseModel.Clone();
            AddUnitLeConstraint(left, fracVar, floorVal);
            SolveAndMaybeRecurse(left, $"{label} -> x{fracVar + 1}<={floorVal}");

            // RIGHT: x_fracVar >= ceilVal
            var right = baseModel.Clone();
            AddUnitGeConstraint(right, fracVar, ceilVal);
            SolveAndMaybeRecurse(right, $"{label} -> x{fracVar + 1}>={ceilVal}");
        }

        /// <summary>
        /// Solve a node; record it; if relaxed and fractional, recurse branching from its optimal relaxed solution.
        /// </summary>
        private void SolveAndMaybeRecurse(LPModel model, string label)
        {
            try
            {
                var iters = new DualSimplex(model).Solve();
                var tab = iters.Last();
                var obj = tab.Last().Last();
                var sol = ExtractSolution(tab, model.ObjectiveFunction.Count);

                int fracVar = FindFirstFractionalVar(sol, model.Signs);
                if (fracVar == -1)
                {
                    // Integer node
                    _nodes.Add((label, sol, obj, iters, false, true));
                }
                else
                {
                    // Relaxed, fractional → record and branch FROM THIS OPTIMAL relaxed solution
                    _nodes.Add((label, sol, obj, iters, false, false));
                    BranchFromSolution(model, label, sol);
                }
            }
            catch
            {
                _nodes.Add((label, null, double.NaN, null, true, false));
            }
        }

        // ===================== Helpers =====================

        private static void AddUnitLeConstraint(LPModel m, int varIndex, int rhs)
        {
            // Prevent duplicate constraints that can cause infinite recursion
            if (!HasUnitLE(m, varIndex, rhs))
            {
                m.ConstraintCoefficients.Add(CreateUnitRow(m.ObjectiveFunction.Count, varIndex));
                m.ConstraintInequalities.Add("<=" + rhs.ToString(Inv));
            }
        }

        private static void AddUnitGeConstraint(LPModel m, int varIndex, int rhs)
        {
            if (!HasUnitGE(m, varIndex, rhs))
            {
                m.ConstraintCoefficients.Add(CreateUnitRow(m.ObjectiveFunction.Count, varIndex));
                m.ConstraintInequalities.Add(">=" + rhs.ToString(Inv));
            }
        }

        private static bool HasUnitLE(LPModel m, int varIndex, int rhs)
        {
            for (int i = 0; i < m.ConstraintCoefficients.Count; i++)
            {
                var row = m.ConstraintCoefficients[i];
                var ineq = (m.ConstraintInequalities[i] ?? "").Trim();
                bool isLE = ineq.StartsWith("<=") || ineq.StartsWith("≤");
                if (isLE && IsUnitColumn(row, varIndex) && EndsWithNumber(ineq, rhs)) return true;
            }
            return false;
        }

        private static bool HasUnitGE(LPModel m, int varIndex, int rhs)
        {
            for (int i = 0; i < m.ConstraintCoefficients.Count; i++)
            {
                var row = m.ConstraintCoefficients[i];
                var ineq = (m.ConstraintInequalities[i] ?? "").Trim();
                bool isGE = ineq.StartsWith(">=") || ineq.StartsWith("≥");
                if (isGE && IsUnitColumn(row, varIndex) && EndsWithNumber(ineq, rhs)) return true;
            }
            return false;
        }

        private static bool EndsWithNumber(string ineq, int rhs)
        {
            string tail = ineq.Replace("≥", ">=").Replace("≤", "<=").Trim();
            int p = tail.IndexOf('=');
            if (p >= 0 && p < tail.Length - 1)
            {
                var s = tail.Substring(p + 1).Trim();
                if (int.TryParse(s, NumberStyles.Integer, Inv, out int v)) return v == rhs;
                if (double.TryParse(s, NumberStyles.Float, Inv, out double dv)) return Math.Abs(dv - rhs) < 1e-9;
            }
            return false;
        }

        private static bool IsUnitColumn(List<double> row, int j)
        {
            for (int k = 0; k < row.Count; k++)
            {
                double v = row[k];
                if (k == j)
                {
                    if (Math.Abs(v - 1.0) > 1e-9) return false;
                }
                else
                {
                    if (Math.Abs(v) > 1e-12) return false;
                }
            }
            return true;
        }

        private static List<double> CreateUnitRow(int nVars, int index)
        {
            var row = new List<double>(new double[nVars]);
            row[index] = 1.0;
            return row;
        }

        private Dictionary<int, double> ExtractSolution(List<List<double>> tableau, int nVars)
        {
            var x = Enumerable.Range(0, nVars).ToDictionary(j => j, j => 0.0);
            for (int j = 0; j < nVars; j++)
            {
                int row = FindUnitColumnRow(tableau, j);
                if (row >= 0) x[j] = tableau[row].Last();
            }
            return x;
        }

        private static int FindUnitColumnRow(List<List<double>> tableau, int col)
        {
            int row = -1;
            for (int i = 0; i < tableau.Count - 1; i++)
            {
                double v = tableau[i][col];
                if (Math.Abs(v - 1.0) < 1e-7)
                {
                    if (row != -1) return -1; // multiple 1s in column → not basic
                    row = i;
                }
                else if (Math.Abs(v) > 1e-7)
                {
                    return -1; // nonzero elsewhere → not unit column
                }
            }
            return row;
        }

        private static int FindFirstFractionalVar(Dictionary<int, double> solution, List<string> signs)
        {
            foreach (var kv in solution.OrderBy(k => k.Key))
            {
                int j = kv.Key;
                double val = kv.Value;

                bool mustBeInt = signs != null && j < signs.Count &&
                    (signs[j]?.Equals("Bin", StringComparison.OrdinalIgnoreCase) == true ||
                     signs[j]?.Equals("Binary", StringComparison.OrdinalIgnoreCase) == true ||
                     signs[j]?.Equals("Int", StringComparison.OrdinalIgnoreCase) == true ||
                     signs[j]?.Equals("Integer", StringComparison.OrdinalIgnoreCase) == true);

                if (mustBeInt)
                {
                    if (Math.Abs(val - Math.Round(val)) > 1e-5) // tolerance
                        return j;
                }
            }
            return -1;
        }
    }
}





