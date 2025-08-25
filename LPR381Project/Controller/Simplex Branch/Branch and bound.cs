using System;
using System.Collections.Generic;
using System.Linq;

namespace Lpr381back
{
    public class BranchAndBoundSolver
    {
        private readonly LPModel _model;

        // label, solution vector, objective, tableau sequence, infeasible?, integer?
        private readonly List<(string label, Dictionary<int, double> solution, double obj,
                               List<List<List<double>>> tableau, bool infeasible, bool isInteger)> _nodes;

        public BranchAndBoundSolver(LPModel model)
        {
            _model = model;
            _nodes = new List<(string, Dictionary<int, double>, double,
                               List<List<List<double>>>, bool, bool)>();
        }

        // ========== PUBLIC API ==========

        public string ShowAllNodes()
        {
            _nodes.Clear();

            var sb = new System.Text.StringBuilder();

            // Solve root relaxed LP
            var rootSolver = new DualSimplex(_model);
            var rootIterations = rootSolver.Solve();
            var rootTableau = rootIterations.Last();
            var rootSolution = ExtractSolution(rootTableau, _model.ObjectiveFunction.Count);
            var rootObj = rootTableau.Last().Last();

            // Record root (not integer-feasible yet)
            _nodes.Add(("Root (relaxed)", rootSolution, rootObj, rootIterations, false, false));

            // Branch from root
            ExploreNode(_model.Clone(), "Root", rootSolution, rootObj);

            // Build output for each node
            foreach (var node in _nodes)
            {
                sb.AppendLine($"\n--- Node {node.label} ---");
                if (node.infeasible)
                {
                    sb.AppendLine("Infeasible.");
                    continue;
                }

                sb.AppendLine($"Objective = {node.obj:0.###}");
                foreach (var kv in node.solution)
                    sb.AppendLine($"x{kv.Key + 1} = {kv.Value:0.###}");

                if (node.tableau != null)
                {
                    var simplex = new DualSimplex(_model);
                    sb.AppendLine(simplex.GetIterationsString(node.tableau, $"Tableau for {node.label}"));
                }
            }

            return sb.ToString();
        }

        public string ShowBestSolution()
        {
            var sb = new System.Text.StringBuilder();

            var feasibleIntegers = _nodes.Where(n => !n.infeasible && n.isInteger).ToList();

            if (feasibleIntegers.Count == 0)
            {
                sb.AppendLine("No integer/binary solutions found.");
                return sb.ToString();
            }

            // detect Max/Min (default Max)
            bool isMax = true;
            if (_model.Type != null &&
                _model.Type.Equals("Min", StringComparison.OrdinalIgnoreCase))
            {
                isMax = false;
            }

            var best = isMax
                ? feasibleIntegers.OrderByDescending(n => n.obj).First()
                : feasibleIntegers.OrderBy(n => n.obj).First();

            sb.AppendLine("\n=== Best Integer/Binary Solution ===");
            sb.AppendLine($"From Node: {best.label}");
            sb.AppendLine($"Objective Value = {best.obj:0.###}");

            foreach (var kv in best.solution)
                sb.AppendLine($"x{kv.Key + 1} = {kv.Value:0.###}");

            if (best.tableau != null)
            {
                var simplex = new DualSimplex(_model);
                sb.AppendLine(simplex.GetIterationsString(best.tableau, $"Final Tableau for {best.label}"));
            }

            return sb.ToString();
        }

        // ========== INTERNALS ==========

        private void ExploreNode(LPModel model, string label,
                                 Dictionary<int, double> parentSolution, double parentObj)
        {
            try
            {
                var solver = new DualSimplex(model);
                var iterations = solver.Solve();
                var finalTableau = iterations.Last();
                var solution = ExtractSolution(finalTableau, model.ObjectiveFunction.Count);
                var obj = finalTableau.Last().Last();

                int fracVar = FindFirstFractionalVar(solution, model.Signs);
                if (fracVar == -1)
                {
                    // Integer-feasible solution
                    _nodes.Add((label, solution, obj, iterations, false, true));
                }
                else
                {
                    // Fractional → keep as relaxed, not integer
                    _nodes.Add((label, solution, obj, iterations, false, false));

                    double val = solution[fracVar];
                    int floorVal = (int)Math.Floor(val);
                    int ceilVal = (int)Math.Ceiling(val);

                    if (floorVal == ceilVal) return;

                    // Left branch: x_fracVar <= floorVal
                    var left = model.Clone();
                    left.ConstraintCoefficients.Add(CreateUnitRow(model.ObjectiveFunction.Count, fracVar));
                    left.ConstraintInequalities.Add($"<={floorVal}");
                    ExploreNode(left, $"{label} -> x{fracVar + 1}<={floorVal}", solution, obj);

                    // Right branch: x_fracVar >= ceilVal
                    var right = model.Clone();
                    right.ConstraintCoefficients.Add(CreateUnitRow(model.ObjectiveFunction.Count, fracVar));
                    right.ConstraintInequalities.Add($">={ceilVal}");
                    ExploreNode(right, $"{label} -> x{fracVar + 1}>={ceilVal}", solution, obj);
                }
            }
            catch
            {
                _nodes.Add((label, null, double.NaN, null, true, false));
            }
        }

        private static List<double> CreateUnitRow(int nVars, int index)
        {
            var row = new List<double>(new double[nVars]); // zeros
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
                    if (row != -1) return -1;
                    row = i;
                }
                else if (Math.Abs(v) > 1e-7)
                {
                    return -1;
                }
            }
            return row;
        }

        private static int FindFirstFractionalVar(Dictionary<int, double> solution, List<string> signs)
        {
            foreach (var kv in solution)
            {
                int j = kv.Key;
                double val = kv.Value;
                if (signs != null && j < signs.Count &&
                   (signs[j].Equals("Bin", StringComparison.OrdinalIgnoreCase) ||
                    signs[j].Equals("Binary", StringComparison.OrdinalIgnoreCase) ||
                    signs[j].Equals("Int", StringComparison.OrdinalIgnoreCase) ||
                    signs[j].Equals("Integer", StringComparison.OrdinalIgnoreCase)))
                {
                    if (Math.Abs(val - Math.Round(val)) > 1e-5) // tolerance
                        return j;
                }
            }
            return -1;
        }
    }
}





