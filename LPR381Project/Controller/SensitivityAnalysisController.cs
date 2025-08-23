using Lpr381back;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPR381Project.Controller
{
    public class SensitivityAnalysisController
    {
        private readonly LPModel lpModel;
        private List<List<double>> finalTableau;
        public List<List<double>> GetFinalTableau() { return finalTableau; }
        public LPModel GetLPModel() { return lpModel; }

        public SensitivityAnalysisController(LPModel lpModel)
        {
            this.lpModel = lpModel;
            DualSimplex dualSimplex = new DualSimplex(lpModel);
            this.finalTableau = dualSimplex.Solve().Last();
        }

        public string GetNonBasicVariableRange(string variableName)
        {
            int varIndex = lpModel.ObjectiveFunction.FindIndex(v => v.ToString() == variableName);
            double currentCoeff = lpModel.ObjectiveFunction[varIndex];
            double reducedCost = finalTableau.Last()[varIndex];

            double allowableIncrease = reducedCost;
            double allowableDecrease = double.PositiveInfinity;

            return $"Allowable range for {variableName}: [{currentCoeff - allowableDecrease}, {currentCoeff + allowableIncrease}]";
        }

        public string GetBasicVariableRange(string variableName)
        {
            int varIndex = lpModel.ObjectiveFunction.FindIndex(v => v.ToString() == variableName);
            double currentCoeff = lpModel.ObjectiveFunction[varIndex];

            double allowableIncrease = double.PositiveInfinity;
            double allowableDecrease = double.PositiveInfinity;

            for (int j = 0; j < finalTableau.Last().Count - 1; j++)
            {
                if (j != varIndex)
                {
                    double val = finalTableau[varIndex][j];
                    double cj_zj = finalTableau.Last()[j];

                    if (val > 0)
                    {
                        allowableIncrease = Math.Min(allowableIncrease, cj_zj / val);
                    }
                    else if (val < 0)
                    {
                        allowableDecrease = Math.Min(allowableDecrease, -cj_zj / val);
                    }
                }
            }

            return $"Allowable range for {variableName}: [{currentCoeff - allowableDecrease}, {currentCoeff + allowableIncrease}]";
        }

        public string GetConstraintRhsRange(int constraintIndex)
        {
            double currentRhs = double.Parse(lpModel.ConstraintInequalities[constraintIndex].Trim().Split(' ')[1]);
            double allowableIncrease = double.PositiveInfinity;
            double allowableDecrease = double.PositiveInfinity;

            for (int i = 0; i < finalTableau.Count - 1; i++)
            {
                int columnIndexToAccess = lpModel.ObjectiveFunction.Count + constraintIndex;
                if (columnIndexToAccess >= finalTableau[i].Count)
                {
                    // This indicates an issue with tableau structure or indexing
                    throw new IndexOutOfRangeException($"Column index {columnIndexToAccess} is out of bounds for tableau row {i}. Tableau row has {finalTableau[i].Count} columns. Final Tableau dimensions: {finalTableau.Count} rows x {(finalTableau.Count > 0 ? finalTableau[0].Count : 0)} columns.");
                }
                double val = finalTableau[i][columnIndexToAccess];
                double rhs = finalTableau[i].Last();

                if (val > 0)
                {
                    allowableDecrease = Math.Min(allowableDecrease, rhs / val);
                }
                else if (val < 0)
                {
                    allowableIncrease = Math.Min(allowableIncrease, -rhs / val);
                }
            }

            return $"Allowable range for constraint {constraintIndex + 1} RHS: [{currentRhs - allowableDecrease}, {currentRhs + allowableIncrease}]";
        }

        public string GetVariableInNonBasicVariableColumnRange(string variableName, int columnIndex)
        {
            // This is a complex operation and requires detailed knowledge of the tableau structure
            // and how changes in non-basic columns affect optimality. This is a placeholder.
            return "Range for variable " + variableName + " in column " + columnIndex + " is [complex and not yet implemented]";
        }

        public void ApplyNonBasicVariableChange(string variableName, double newValue)
        {
            int varIndex = lpModel.ObjectiveFunction.FindIndex(v => v.ToString() == variableName);
            lpModel.ObjectiveFunction[varIndex] = newValue;

            // Re-solve the model with the updated objective function
            PrimalSimplex primalSimplex = new PrimalSimplex(lpModel);
            this.finalTableau = primalSimplex.Solve().Last();
        }

        public void ApplyBasicVariableChange(string variableName, double newValue)
        {
            int varIndex = lpModel.ObjectiveFunction.FindIndex(v => v.ToString() == variableName);
            lpModel.ObjectiveFunction[varIndex] = newValue;

            // Re-solve the model with the updated objective function
            PrimalSimplex primalSimplex = new PrimalSimplex(lpModel);
            this.finalTableau = primalSimplex.Solve().Last();
        }

        public void ApplyConstraintRhsChange(int constraintIndex, double newValue)
        {
            string[] parts = lpModel.ConstraintInequalities[constraintIndex].Trim().Split(' ');
            lpModel.ConstraintInequalities[constraintIndex] = parts[0] + " " + newValue.ToString();

            // Re-solve the model with the updated RHS
            PrimalSimplex primalSimplex = new PrimalSimplex(lpModel);
            this.finalTableau = primalSimplex.Solve().Last();
        }

        public void ApplyVariableInNonBasicVariableColumnChange(string variableName, int columnIndex, double newValue)
        {
            // This is a complex operation and requires detailed knowledge of the tableau structure
            // and how changes in non-basic columns affect optimality. This is a placeholder.
            // For now, we'll just re-solve the model as if the change was made directly to the LPModel.
            // A proper implementation would involve updating the tableau directly and checking for optimality.

            // Assuming variableName refers to an original variable (x1, x2, etc.)
            int varIndex = lpModel.ObjectiveFunction.FindIndex(v => v.ToString() == variableName);

            // This part is highly dependent on how 'columnIndex' maps to the actual coefficient in the A matrix.
            // For simplicity, let's assume columnIndex refers to the constraint index.
            if (varIndex != -1 && columnIndex >= 0 && columnIndex < lpModel.ConstraintCoefficients.Count)
            {
                List<double> targetList = lpModel.ConstraintCoefficients[columnIndex];
                targetList[varIndex] = newValue;
            }

            // Re-solve the model with the updated coefficient
            PrimalSimplex primalSimplex = new PrimalSimplex(lpModel);
            this.finalTableau = primalSimplex.Solve().Last();
        }

        public void AddNewActivity(List<double> newActivityCoefficients)
        {
            // Add new coefficient to objective function
            lpModel.ObjectiveFunction.Add(newActivityCoefficients.Last());

            // Add new coefficients to constraints
            for (int i = 0; i < lpModel.ConstraintCoefficients.Count; i++)
            {
                lpModel.ConstraintCoefficients[i].Add(newActivityCoefficients[i]);
            }

            // Re-solve the model with the new activity
            PrimalSimplex primalSimplex = new PrimalSimplex(lpModel);
            this.finalTableau = primalSimplex.Solve().Last();
        }

        public void AddNewConstraint(List<double> newConstraintCoefficients, string inequality, double rhs)
        {
            lpModel.ConstraintCoefficients.Add(newConstraintCoefficients);
            lpModel.ConstraintInequalities.Add($"{inequality} {rhs}");

            // Re-solve the model with the new constraint
            PrimalSimplex primalSimplex = new PrimalSimplex(lpModel);
            this.finalTableau = primalSimplex.Solve().Last();
        }

        public string GetShadowPrices()
        {
            StringBuilder sb = new StringBuilder("Shadow Prices:" + Environment.NewLine);
            int numConstraints = lpModel.ConstraintCoefficients.Count;
            int numVars = lpModel.ObjectiveFunction.Count;

            for (int i = 0; i < numConstraints; i++)
            {
                sb.AppendLine($"Constraint {i + 1}: {finalTableau.Last()[numVars + i]}");
            }

            return sb.ToString();
        }

        public LPModel GetDualModel()
        {
            int m = lpModel.ConstraintCoefficients.Count; // Number of constraints in primal = number of variables in dual
            int n = lpModel.ObjectiveFunction.Count; // Number of variables in primal = number of constraints in dual

            // Dual objective function coefficients (from primal RHS)
            List<double> dualObjectiveFunction = new List<double>();
            foreach (string inequality in lpModel.ConstraintInequalities)
            {
                dualObjectiveFunction.Add(double.Parse(inequality.Trim().Split(' ')[1]));
            }

            // Dual constraint coefficients (transpose of primal constraint coefficients)
            List<List<double>> dualConstraintCoefficients = new List<List<double>>();
            for (int j = 0; j < n; j++)
            {
                List<double> row = new List<double>();
                for (int i = 0; i < m; i++)
                {
                    row.Add(lpModel.ConstraintCoefficients[i][j]);
                }
                dualConstraintCoefficients.Add(row);
            }

            // Dual constraint inequalities (from primal objective function coefficients and type)
            List<string> dualConstraintInequalities = new List<string>();
            string dualType = (lpModel.Type.ToLower() == "max") ? "min" : "max";

            for (int j = 0; j < n; j++)
            {
                string inequalitySign = "";
                if (lpModel.Type.ToLower() == "max")
                {
                    inequalitySign = ">=";
                }
                else
                {
                    inequalitySign = "<=";
                }
                dualConstraintInequalities.Add($"{inequalitySign} {lpModel.ObjectiveFunction[j]}");
            }

            // Dual signs (from primal constraint inequalities)
            List<string> dualSigns = new List<string>();
            for (int i = 0; i < m; i++)
            {
                string primalIneq = lpModel.ConstraintInequalities[i].Trim();
                if (primalIneq.StartsWith("<="))
                {
                    dualSigns.Add("Non-negative");
                }
                else if (primalIneq.StartsWith(">="))
                {
                    dualSigns.Add("Non-positive");
                }
                else if (primalIneq.StartsWith("="))
                {
                    dualSigns.Add("Unrestricted");
                }
            }

            return new LPModel
            {
                Type = dualType,
                ObjectiveFunction = dualObjectiveFunction,
                ConstraintCoefficients = dualConstraintCoefficients,
                ConstraintInequalities = dualConstraintInequalities,
                Signs = dualSigns
            };
        }

        public string SolveDualModel()
        {
            LPModel dualModel = GetDualModel();
            PrimalSimplex dualSolver = new PrimalSimplex(dualModel);
            List<List<List<double>>> dualIterations = dualSolver.Solve();

            // You can format the output of the dual solution as needed
            StringBuilder sb = new StringBuilder("Dual Model Solution:\n");
            // For simplicity, just showing the final tableau of the dual
            sb.AppendLine("Final Dual Tableau:");
            foreach (var row in dualIterations.Last())
            {
                sb.AppendLine(string.Join("\t", row.Select(x => x.ToString("F2"))));
            }

            return sb.ToString();
        }

        public string VerifyDuality()
        {
            // Get primal objective value
            double primalObjectiveValue = finalTableau.Last().Last();

            // Get dual objective value
            LPModel dualModel = GetDualModel();
            PrimalSimplex dualSolver = new PrimalSimplex(dualModel);
            List<List<List<double>>> dualIterations = dualSolver.Solve();
            double dualObjectiveValue = dualIterations.Last().Last().Last();


            // Compare and verify duality
            if (Math.Abs(primalObjectiveValue - dualObjectiveValue) < 1e-6)
            {
                return $"Strong Duality holds: Primal Objective = {primalObjectiveValue:F2}, Dual Objective = {dualObjectiveValue:F2}";
            }
            else if (primalObjectiveValue <= dualObjectiveValue) // For maximization primal and minimization dual
            {
                return $"Weak Duality holds: Primal Objective = {primalObjectiveValue:F2}, Dual Objective = {dualObjectiveValue:F2}";
            }
            else
            {
                return "Duality does not hold as expected.";
            }
        }
    }
}

