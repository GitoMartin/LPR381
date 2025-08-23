using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lpr381back
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    namespace Lpr381back.LinearProgramming
    {
        public class LpResult
        {
            public string Status { get; set; } = "";
            public double ObjectiveValue { get; set; }
            public double[] PrimalSolution { get; set; } = Array.Empty<double>();
            public List<string> IterationLog { get; set; } = new List<string>();
            public int Iterations { get; set; }
        }

        internal class RevisedSimplexSolver
        {
            private readonly LPModel model;
            private readonly bool isMax;
            private const double TOL = 1e-9;
            private const double BIGM = 1e6;

            public RevisedSimplexSolver(LPModel model)
            {
                this.model = model;
                this.isMax = model.Type.Trim().ToLower() == "max";
            }

            public LpResult Solve()
            {
                var result = new LpResult();
                result.IterationLog.Add("=== Revised Simplex with Dual Simplex Support ===");

                int m = model.ConstraintCoefficients.Count;
                int n = model.ObjectiveFunction.Count;

                // Objective vector
                double[] c = model.ObjectiveFunction.ToArray();
                if (!isMax)
                {
                    for (int j = 0; j < c.Length; j++) c[j] = -c[j];
                    result.IterationLog.Add("Converted minimization to maximization.");
                }

                // Build A and b from model
                double[,] A = new double[m, n];
                for (int i = 0; i < m; i++)
                    for (int j = 0; j < n; j++)
                        A[i, j] = model.ConstraintCoefficients[i][j];

                double[] b = new double[m];
                string[] senses = new string[m];
                for (int i = 0; i < m; i++)
                {
                    string s = model.ConstraintInequalities[i].Trim();
                    if (s.StartsWith("<="))
                    {
                        senses[i] = "<=";
                        b[i] = double.Parse(s.Substring(2), CultureInfo.InvariantCulture);
                    }
                    else if (s.StartsWith(">="))
                    {
                        senses[i] = ">=";
                        b[i] = double.Parse(s.Substring(2), CultureInfo.InvariantCulture);
                    }
                    else if (s.StartsWith("="))
                    {
                        senses[i] = "=";
                        b[i] = double.Parse(s.Substring(1), CultureInfo.InvariantCulture);
                    }
                    else throw new ArgumentException($"Constraint {i} must start with <=, >=, or =");
                }

                // ----- Inject Xi <= 0 for every "binary" sign on the corresponding objective variable -----
                // Note: per your requirement, when model.Signs[j] is "binary", we add the linear constraint x_j <= 0.
                // (This makes x_j forced to 0 in LP; if you intended {0,1}, you’d normally add 0 <= x_j <= 1 instead.)
                // ----- Inject Xi <= 1 for every "binary" sign on the corresponding objective variable -----
                if (model.Signs != null && model.Signs.Count >= n)
                {
                    var Arows = new List<List<double>>(A.GetLength(0));
                    for (int i = 0; i < A.GetLength(0); i++)
                    {
                        var row = new List<double>(n);
                        for (int j = 0; j < n; j++) row.Add(A[i, j]);
                        Arows.Add(row);
                    }
                    var bList = b.ToList();
                    var senseList = senses.ToList();

                    for (int j = 0; j < n; j++)
                    {
                        var tag = model.Signs[j]?.Trim().ToLowerInvariant();
                        if (tag == "binary")
                        {
                            var newRow = Enumerable.Repeat(0.0, n).ToArray();
                            newRow[j] = 1.0;               // Xi coefficient
                            Arows.Add(newRow.ToList());
                            bList.Add(1.0);                // RHS = 1
                            senseList.Add("<=");           // Xi <= 1

                            result.IterationLog.Add($"Injected constraint for binary sign: x{j + 1} <= 1");
                        }
                    }

                    // Repack A, b, senses
                    int newM = Arows.Count;
                    double[,] A2 = new double[newM, n];
                    for (int i = 0; i < newM; i++)
                        for (int j = 0; j < n; j++)
                            A2[i, j] = Arows[i][j];

                    A = A2;
                    b = bList.ToArray();
                    senses = senseList.ToArray();
                    m = newM; // update row count after injections
                }
                else
                {
                    result.IterationLog.Add("No binary sign constraints injected (model.Signs missing or shorter than number of variables).");
                }
                // ----- end injection -----

                // ----- end injection -----

                // Convert to standard form (slack/surplus/artificial)
                var std = BuildStandardForm(A, b, c, senses);
                double[,] Aext = std.Item1;
                double[] bext = std.Item2;
                double[] cext = std.Item3;
                List<int> basis = std.Item4;
                // Build canonical form for Iteration 0
                var initialTableau = BuildCanonicalTableau(Aext, bext, cext);
                result.IterationLog.Add("--- Iteration 0 (Canonical Form) ---");
                result.IterationLog.Add(GetCanonicalString(initialTableau));
                // Phase I: Dual Simplex if infeasible
                var phase1 = DualSimplex(Aext, bext, cext, basis, result);
                if (phase1.Status != "Feasible")
                    return phase1;

                // Phase II: Revised Simplex
                return RevisedSimplex(Aext, bext, cext, basis, result);
            }

            // ---------------- Build Standard Form ----------------
            private static Tuple<double[,], double[], double[], List<int>>
                BuildStandardForm(double[,] A, double[] b, double[] c, string[] senses)
            {
                int m = A.GetLength(0), n = A.GetLength(1);
                List<List<double>> Alist = new List<List<double>>();
                for (int i = 0; i < m; i++)
                    Alist.Add(new List<double>(Enumerable.Range(0, n).Select(j => A[i, j])));
                List<double> cList = new List<double>(c);
                List<int> basis = new List<int>();

                for (int i = 0; i < m; i++)
                {
                    if (senses[i] == "<=")
                    {
                        for (int k = 0; k < m; k++) Alist[k].Add(k == i ? 1.0 : 0.0);
                        cList.Add(0.0);
                        basis.Add(n + i);
                    }
                    else if (senses[i] == ">=")
                    {
                        // surplus
                        for (int k = 0; k < m; k++) Alist[k].Add(k == i ? -1.0 : 0.0);
                        cList.Add(0.0);
                        // artificial
                        for (int k = 0; k < m; k++) Alist[k].Add(k == i ? 1.0 : 0.0);
                        cList.Add(BIGM);
                        basis.Add(Alist[0].Count - 1);
                    }
                    else if (senses[i] == "=")
                    {
                        for (int k = 0; k < m; k++) Alist[k].Add(k == i ? 1.0 : 0.0);
                        cList.Add(BIGM);
                        basis.Add(Alist[0].Count - 1);
                    }
                }

                int newN = Alist[0].Count;
                double[,] newA = new double[m, newN];
                for (int i = 0; i < m; i++)
                    for (int j = 0; j < newN; j++)
                        newA[i, j] = Alist[i][j];

                return Tuple.Create(newA, b, cList.ToArray(), basis);
            }

            // ---------------- Dual Simplex ----------------
            private LpResult DualSimplex(double[,] A, double[] b, double[] c, List<int> basis, LpResult result)
            {
                int m = A.GetLength(0), n = A.GetLength(1);
                double[,] B = ExtractColumns(A, basis);
                double[,] Binv = Invert(B);
                double[] xB = Multiply(Binv, b);

                while (xB.Any(x => x < -TOL))
                {
                    // leaving variable
                    int leave = Array.FindIndex(xB, v => v < -TOL);

                    // row of Binv*A
                    double[] row = Multiply(Row(Binv, leave), A);

                    // reduced costs
                    double[] cb = basis.Select(j => c[j]).ToArray();
                    double[] y = Multiply(Transpose(Binv), cb);
                    double[] rc = new double[n];
                    for (int j = 0; j < n; j++)
                        rc[j] = c[j] - Dot(y, Column(A, j));

                    // entering
                    int enter = -1;
                    double ratio = double.PositiveInfinity;
                    for (int j = 0; j < n; j++)
                    {
                        if (basis.Contains(j)) continue;
                        if (row[j] < -TOL)
                        {
                            double val = rc[j] / row[j];
                            if (val < ratio) { ratio = val; enter = j; }
                        }
                    }
                    if (enter == -1)
                        return new LpResult { Status = "Infeasible", IterationLog = result.IterationLog };

                    basis[leave] = enter;
                    B = ExtractColumns(A, basis);
                    Binv = Invert(B);
                    xB = Multiply(Binv, b);
                }
                result.IterationLog.Add("Dual Simplex found a feasible BFS.");
                return new LpResult { Status = "Feasible", IterationLog = result.IterationLog };
            }

            // ---------------- Revised Simplex ----------------
            private LpResult RevisedSimplex(double[,] A, double[] b, double[] c, List<int> basis, LpResult result)
            {
                int m = A.GetLength(0), n = A.GetLength(1);
                double[,] B = ExtractColumns(A, basis);
                double[,] Binv = Invert(B);
                int iter = 0;

                while (true)
                {
                    iter++;
                    result.IterationLog.Add($"--- Iteration {iter} ---");

                    double[] xB = Multiply(Binv, b);
                    double[] x = new double[n];
                    for (int i = 0; i < m; i++) x[basis[i]] = xB[i];
                    result.IterationLog.Add("x = [" + string.Join(", ", x.Select(v => v.ToString("F2"))) + "]");

                    double[] cb = Subset(c, basis);
                    double[] y = Multiply(Transpose(Binv), cb);

                    double[] rc = new double[n];
                    for (int j = 0; j < n; j++) rc[j] = c[j] - Dot(y, Column(A, j));
                    result.IterationLog.Add("Reduced costs = [" + string.Join(", ", rc.Select(v => v.ToString("F2"))) + "]");

                    int enter = -1;
                    double best = isMax ? -1e9 : 1e9;
                    for (int j = 0; j < n; j++)
                    {
                        if (basis.Contains(j)) continue;
                        if (isMax && rc[j] > TOL && rc[j] > best) { best = rc[j]; enter = j; }
                        if (!isMax && rc[j] < -TOL && rc[j] < best) { best = rc[j]; enter = j; }
                    }
                    if (enter == -1)
                    {
                        double obj = Dot(cb, xB);
                        return new LpResult
                        {
                            Status = "Optimal",
                            ObjectiveValue = isMax ? obj : -obj,
                            PrimalSolution = x.Take(model.ObjectiveFunction.Count).ToArray(),
                            IterationLog = result.IterationLog,
                            Iterations = iter
                        };
                    }

                    double[] d = Multiply(Binv, Column(A, enter));
                    double ratio = double.PositiveInfinity;
                    int leave = -1;
                    for (int i = 0; i < m; i++)
                    {
                        if (d[i] > TOL)
                        {
                            double val = xB[i] / d[i];
                            if (val < ratio) { ratio = val; leave = i; }
                        }
                    }
                    if (leave == -1)
                        return new LpResult { Status = "Unbounded", IterationLog = result.IterationLog };

                    result.IterationLog.Add($"Pivot: Enter x{enter + 1}, Leave x{basis[leave] + 1}");
                    basis[leave] = enter;
                    B = ExtractColumns(A, basis);
                    Binv = Invert(B);
                }
            }

            // ---------------- linear algebra helpers ----------------
            private static double[] Multiply(double[,] A, double[] x)
            {
                int r = A.GetLength(0), c = A.GetLength(1);
                if (x.Length != c) throw new ArgumentException("Dimension mismatch in Multiply(A,x).");
                double[] y = new double[r];
                for (int i = 0; i < r; i++)
                {
                    double s = 0.0;
                    for (int j = 0; j < c; j++) s += A[i, j] * x[j];
                    y[i] = s;
                }
                return y;
            }

            private static double[] Multiply(double[] yT, double[,] A)
            {
                int r = A.GetLength(0), c = A.GetLength(1);
                if (yT.Length != r) throw new ArgumentException("Dimension mismatch in Multiply(yT,A).");
                double[] z = new double[c];
                for (int j = 0; j < c; j++)
                {
                    double s = 0.0;
                    for (int i = 0; i < r; i++) s += yT[i] * A[i, j];
                    z[j] = s;
                }
                return z;
            }

            private static double[,] Transpose(double[,] A)
            {
                int r = A.GetLength(0), c = A.GetLength(1);
                double[,] T = new double[c, r];
                for (int i = 0; i < r; i++)
                    for (int j = 0; j < c; j++)
                        T[j, i] = A[i, j];
                return T;
            }

            private static double[,] Invert(double[,] A)
            {
                int n = A.GetLength(0);
                if (n != A.GetLength(1)) throw new ArgumentException("Matrix must be square.");
                double[,] a = (double[,])A.Clone();
                double[,] inv = new double[n, n];
                for (int i = 0; i < n; i++) inv[i, i] = 1.0;

                for (int i = 0; i < n; i++)
                {
                    double diag = a[i, i];
                    if (Math.Abs(diag) < 1e-10) throw new InvalidOperationException("Singular matrix.");
                    for (int j = 0; j < n; j++) { a[i, j] /= diag; inv[i, j] /= diag; }
                    for (int k = 0; k < n; k++)
                    {
                        if (k == i) continue;
                        double factor = a[k, i];
                        for (int j = 0; j < n; j++)
                        {
                            a[k, j] -= factor * a[i, j];
                            inv[k, j] -= factor * inv[i, j];
                        }
                    }
                }
                return inv;
            }

            private static double[,] ExtractColumns(double[,] A, List<int> cols)
            {
                int r = A.GetLength(0), c = cols.Count;
                double[,] B = new double[r, c];
                for (int i = 0; i < r; i++)
                    for (int j = 0; j < c; j++)
                        B[i, j] = A[i, cols[j]];
                return B;
            }

            private static double[] Row(double[,] A, int i)
            {
                int c = A.GetLength(1);
                double[] row = new double[c];
                for (int j = 0; j < c; j++) row[j] = A[i, j];
                return row;
            }

            private static double[] Column(double[,] A, int j)
            {
                int r = A.GetLength(0);
                double[] col = new double[r];
                for (int i = 0; i < r; i++) col[i] = A[i, j];
                return col;
            }

            private static double[] Subset(double[] v, List<int> idxs)
            {
                double[] u = new double[idxs.Count];
                for (int i = 0; i < idxs.Count; i++) u[i] = v[idxs[i]];
                return u;
            }

            private static double Dot(double[] a, double[] b)
            {
                if (a.Length != b.Length) throw new ArgumentException("Dot dimension mismatch");
                double s = 0.0; for (int i = 0; i < a.Length; i++) s += a[i] * b[i];
                return s;
            }
            private static string GetCanonicalString(List<List<double>> tableau, string title = "Canonical Form")
            {
                if (tableau == null || tableau.Count == 0)
                    return $"{title}: no data.";

                int cols = tableau[0].Count;
                int n = cols - 1; // exclude RHS
                var headers = new List<string>();
                for (int j = 0; j < n; j++) headers.Add($"x{j + 1}");
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

                // Objective row = last
                var z = tableau.Last();
                for (int j = 0; j < z.Count; j++)
                    sb.Append(z[j].ToString("0.###").PadLeft(w[j]));
                sb.AppendLine();

                // Constraint rows
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
            private static List<List<double>> BuildCanonicalTableau(double[,] A, double[] b, double[] c)
            {
                int m = A.GetLength(0), n = A.GetLength(1);
                var tableau = new List<List<double>>();

                // Constraint rows
                for (int i = 0; i < m; i++)
                {
                    var row = new List<double>();
                    for (int j = 0; j < n; j++)
                        row.Add(A[i, j]);
                    row.Add(b[i]); // RHS
                    tableau.Add(row);
                }

                // Objective row (Z)
                var zRow = new List<double>();
                for (int j = 0; j < n; j++)
                    zRow.Add(c[j]);
                zRow.Add(0); // RHS for Z row
                tableau.Add(zRow);

                return tableau;
            }


        }
    }



}


