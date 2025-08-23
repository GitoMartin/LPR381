using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;


    namespace Lpr381back
    {
    internal class DualSimplex
    {
        private readonly LPModel _model;
        private readonly List<List<List<double>>> _iterations;
        private const double Eps = 1e-9;

        public DualSimplex(LPModel model)
        {
            _model = model;
            _iterations = new List<List<List<double>>>();
        }

        // ========== PUBLIC API ==========

        // Solve relaxed problem and keep all tableaus
        public List<List<List<double>>> Solve()
        {
            _iterations.Clear();

            var tableau = BuildCanonicalForm();
            _iterations.Add(CloneTableau(tableau));

            while (!IsOptimal(tableau))
            {
                int pivotCol = ChooseEnteringVariable(tableau);
                int pivotRow = ChooseLeavingVariable(tableau, pivotCol);
                Pivot(tableau, pivotRow, pivotCol);
                _iterations.Add(CloneTableau(tableau));
            }

            return _iterations;
        }

        // Show the optimal tableau from the *last* Solve() call


        // Branch-and-Bound over Bin/Int variables. Prints every node’s iterations with labels.



        // ========== INTERNALS ==========

        private void TryEnqueue(LPModel model, string label,
                                    Queue<(LPModel model, string label, List<List<List<double>>> iters)> queue)
        {
            try
            {
                var solver = new DualSimplex(model);
                var iters = solver.Solve();
                queue.Enqueue((model, label, iters));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Node {label} infeasible: {ex.Message}");
            }
        }

        // Build tableau (keeps your handling; adds x_j <= 1 rows for Bin vars)
        private List<List<double>> BuildCanonicalForm()
        {
            int m = _model.ConstraintCoefficients.Count;
            int n = _model.ObjectiveFunction.Count;

            var binIdx = Enumerable.Range(0, n)
                .Where(j => _model.Signs != null && j < _model.Signs.Count &&
                            (_model.Signs[j]?.Equals("Bin", StringComparison.OrdinalIgnoreCase) == true ||
                             _model.Signs[j]?.Equals("Binary", StringComparison.OrdinalIgnoreCase) == true))
                .ToList();

            int totalConstraints = m + binIdx.Count;
            var T = new List<List<double>>();

            // Constraint rows + slack/surplus block + RHS
            for (int i = 0; i < m; i++)
            {
                var row = new List<double>(_model.ConstraintCoefficients[i]);

                string ineq = _model.ConstraintInequalities[i].Trim();
                double rhs;
                if (ineq.StartsWith("<="))
                    rhs = double.Parse(ineq.Substring(2), CultureInfo.InvariantCulture);
                else if (ineq.StartsWith(">="))
                    rhs = double.Parse(ineq.Substring(2), CultureInfo.InvariantCulture);
                else if (ineq.StartsWith("="))
                    rhs = double.Parse(ineq.Substring(1), CultureInfo.InvariantCulture);
                else
                    throw new Exception($"Invalid inequality format: {ineq}");

                for (int s = 0; s < totalConstraints; s++)
                {
                    double val = 0.0;
                    if (s == i)
                    {
                        if (ineq.StartsWith("<=")) val = 1.0;      // slack
                        else if (ineq.StartsWith(">=")) val = -1.0; // surplus
                    }
                    row.Add(val);
                }

                row.Add(rhs);
                T.Add(row);
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
            }

            // Objective row (use -c for max)
            var obj = new List<double>(_model.ObjectiveFunction.Select(c => -c));
            obj.AddRange(Enumerable.Repeat(0.0, totalConstraints));
            obj.Add(0.0);
            T.Add(obj);

            return T;
        }

        // Optimal if last row reduced costs >= 0
        private bool IsOptimal(List<List<double>> T)
        {
            var z = T.Last();
            for (int j = 0; j < z.Count - 1; j++)
                if (z[j] < -Eps) return false;
            return true;
        }

        private int ChooseEnteringVariable(List<List<double>> T)
        {
            var z = T.Last();
            int pivotCol = -1;
            double minVal = -Eps;
            for (int j = 0; j < z.Count - 1; j++)
            {
                if (z[j] < minVal)
                {
                    minVal = z[j];
                    pivotCol = j;
                }
            }
            if (pivotCol == -1) throw new Exception("No entering variable found (optimal).");
            return pivotCol;
        }

        private int ChooseLeavingVariable(List<List<double>> T, int col)
        {
            int rowIndex = -1;
            double best = double.PositiveInfinity;

            for (int i = 0; i < T.Count - 1; i++)
            {
                double a = T[i][col];
                if (a > Eps)
                {
                    double ratio = T[i].Last() / a;
                    if (ratio < best - Eps)
                    {
                        best = ratio;
                        rowIndex = i;
                    }
                }
            }
            if (rowIndex == -1) throw new Exception("Unbounded (no leaving row).");
            return rowIndex;
        }

        private void Pivot(List<List<double>> T, int r, int c)
        {
            double p = T[r][c];
            for (int j = 0; j < T[r].Count; j++) T[r][j] /= p;

            for (int i = 0; i < T.Count; i++)
            {
                if (i == r) continue;
                double f = T[i][c];
                if (Math.Abs(f) < Eps) continue;
                for (int j = 0; j < T[i].Count; j++)
                    T[i][j] -= f * T[r][j];
            }
        }

        private static List<List<double>> CloneTableau(List<List<double>> T)
            => T.Select(row => row.ToList()).ToList();

        // --------- solution extraction ---------

        private Dictionary<int, double> ExtractSolution(List<List<double>> T, int nVars)
        {
            var x = Enumerable.Range(0, nVars).ToDictionary(j => j, j => 0.0);

            for (int j = 0; j < nVars; j++)
            {
                int basisRow = FindUnitColumnRow(T, j);
                if (basisRow >= 0)
                    x[j] = T[basisRow].Last();
            }
            return x;
        }

        private double ExtractObjectiveValue(List<List<double>> T)
            => T.Last().Last();

        private int FindUnitColumnRow(List<List<double>> T, int col)
        {
            int row = -1;
            for (int i = 0; i < T.Count - 1; i++)
            {
                double v = T[i][col];
                if (Math.Abs(v - 1.0) <= 1e-7)
                {
                    if (row != -1) return -1; // more than one 1 → not unit
                    row = i;
                }
                else if (Math.Abs(v) > 1e-7)
                {
                    return -1; // nonzero elsewhere → not unit
                }
            }
            return row;
        }

        private int FindFirstFractionalVar(Dictionary<int, double> x, List<string> signs)
        {
            int n = x.Count;
            for (int j = 0; j < n; j++)
            {
                bool requiresInteger = signs != null && j < signs.Count &&
                    (signs[j].Equals("Bin", StringComparison.OrdinalIgnoreCase) ||
                     signs[j].Equals("Binary", StringComparison.OrdinalIgnoreCase) ||
                     signs[j].Equals("Int", StringComparison.OrdinalIgnoreCase) ||
                     signs[j].Equals("Integer", StringComparison.OrdinalIgnoreCase));

                if (!requiresInteger) continue;

                double v = x[j];
                if (Math.Abs(v - Math.Round(v)) > 1e-7) return j;
            }
            return -1;
        }

        // --------- display ---------

        public string GetIterationsString()
        {
            if (_iterations.Count == 0)
            {
                return "No iterations to display. Run Solve() first.";
            }
            return GetIterationsString(_iterations, "Iterations");
        }

        public string GetIterationsString(List<List<List<double>>> iterations, string title)
        {
            if (iterations == null || iterations.Count == 0)
            {
                return $"{title}: no iterations.";
            }

            int n = _model.ObjectiveFunction.Count;
            int cols = iterations[0][0].Count;

            var headers = new List<string>();
            for (int j = 0; j < n; j++) headers.Add($"x{j + 1}");
            int slackCount = cols - n - 1;
            for (int s = 0; s < slackCount; s++) headers.Add($"s{s + 1}");
            headers.Add("RHS");

            int[] w = new int[headers.Count];
            for (int j = 0; j < headers.Count; j++)
            {
                int max = headers[j].Length;
                foreach (var tab in iterations)
                    foreach (var row in tab)
                    {
                        if (j < row.Count)
                        {
                            int len = row[j].ToString("0.###").Length;
                            if (len > max) max = len;
                        }
                    }
                w[j] = max + 2;
            }

            var sb = new System.Text.StringBuilder();

            sb.AppendLine($"\n--- {title} ---");
            for (int k = 0; k < iterations.Count; k++)
            {
                sb.AppendLine($"Iteration {k}:");

                for (int j = 0; j < headers.Count; j++)
                    sb.Append(headers[j].PadLeft(w[j]));
                sb.AppendLine();

                // Z row (objective) first
                var z = iterations[k].Last();
                for (int j = 0; j < z.Count; j++)
                    sb.Append(z[j].ToString("0.###").PadLeft(w[j]));
                sb.AppendLine();

                // Constraints
                for (int i = 0; i < iterations[k].Count - 1; i++)
                {
                    var row = iterations[k][i];
                    for (int j = 0; j < row.Count; j++)
                        sb.Append(row[j].ToString("0.###").PadLeft(w[j]));
                    sb.AppendLine();
                }

                sb.AppendLine(new string('=', w.Sum()));
            }

            return sb.ToString();
        }
        public string GetInitialCanonicalString(string title = "Initial Canonical Form")
        {
            if (_iterations == null || _iterations.Count == 0)
                return $"{title}: no data. Run Solve() first.";

            var tableau = _iterations[0]; // iteration 0

            int n = _model.ObjectiveFunction.Count;
            int cols = tableau[0].Count;

            var headers = new List<string>();
            for (int j = 0; j < n; j++) headers.Add($"x{j + 1}");
            int slackCount = cols - n - 1;
            for (int s = 0; s < slackCount; s++) headers.Add($"s{s + 1}");
            headers.Add("RHS");

            int[] w = new int[headers.Count];
            for (int j = 0; j < headers.Count; j++)
            {
                int max = headers[j].Length;
                foreach (var row in tableau)
                {
                    if (j < row.Count)
                    {
                        int len = row[j].ToString("0.###").Length;
                        if (len > max) max = len;
                    }
                }
                w[j] = max + 2;
            }

            var sb = new System.Text.StringBuilder();
            sb.AppendLine($"\n--- {title} ---");

            // Headers
            for (int j = 0; j < headers.Count; j++)
                sb.Append(headers[j].PadLeft(w[j]));
            sb.AppendLine();

            // Z row (objective) is last
            var z = tableau.Last();
            for (int j = 0; j < z.Count; j++)
                sb.Append(z[j].ToString("0.###").PadLeft(w[j]));
            sb.AppendLine();

            // Constraints
            for (int i = 0; i < tableau.Count - 1; i++)
            {
                var row = tableau[i];
                for (int j = 0; j < row.Count; j++)
                    sb.Append(row[j].ToString("0.###").PadLeft(w[j]));
                sb.AppendLine();
            }

            sb.AppendLine(new string('=', w.Sum()));
            return sb.ToString();
        }
    }
    }






