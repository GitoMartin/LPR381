using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lpr381back
{
    public class LPModel
    {
        string type;
        List<double> objectiveFunction = new List<double>();
        List<List<double>> constraintCoefficients = new List<List<double>>();
        List<string> constraintInequalities = new List<string>();
        List<string> signs = new List<string>();
        public bool IsMaximize { get; set; } = true;
        public List<double> ObjectiveFunction { get => objectiveFunction; set => objectiveFunction = value; }
        
        public List<string> ConstraintInequalities { get => constraintInequalities; set => constraintInequalities = value; }
        public string Type { get => type; set => type = value; }
        public List<string> Signs { get => signs; set => signs = value; }
        public List<List<double>> ConstraintCoefficients { get => constraintCoefficients; set => constraintCoefficients = value; }
        public void showLP()
        {
            string line = " ";
            Console.WriteLine(Type);
            for (int i = 0; i < ObjectiveFunction.Count; i++)
            {
               line += " " + ObjectiveFunction[i].ToString();
            }
            Console.WriteLine(line);
            line = "";
            for (int i = 0; i < ConstraintCoefficients.Count; i++)
            {
                for (int j = 0; j < ConstraintCoefficients[i].Count; j++)
                {
                    line += " " + ConstraintCoefficients[i][j].ToString();
                }
                line += ConstraintInequalities[i];
                Console.WriteLine(line);
                line = "";
            }
            for (int i = 0; i < Signs.Count - 1; i++)
            {
                line += " " + Signs[i];
            }
            Console.WriteLine(line);
            line = "";
        }
        public LPModel Clone()
        {
            return new LPModel
            {
                Type = this.Type,
                ObjectiveFunction = new List<double>(this.ObjectiveFunction),
                ConstraintCoefficients = this.ConstraintCoefficients
                    .Select(row => new List<double>(row)).ToList(),
                ConstraintInequalities = new List<string>(this.ConstraintInequalities)
            };
        }
        public LPModel DeepClone()
        {
            return new LPModel
            {
                ObjectiveFunction = new List<double>(ObjectiveFunction),
                ConstraintCoefficients = ConstraintCoefficients
                    .Select(row => new List<double>(row)).ToList(),
                ConstraintInequalities = new List<string>(ConstraintInequalities),
                Signs = Signs != null ? new List<string>(Signs) : null,
                IsMaximize = IsMaximize
            };
        }

        // --- NEW: add a constraint x_varIndex (op) rhs, where op is "<=", ">=", or "=" ---
        // This is what Branch-and-Bound will call to create child subproblems.
        public LPModel CloneWithExtraConstraint(int varIndex, string op, double rhs)
        {
            if (op != "<=" && op != ">=" && op != "=")
                throw new ArgumentException("op must be \"<=\", \">=\", or \"=\"");

            var child = this.DeepClone();

            int n = ObjectiveFunction.Count;
            var newRow = Enumerable.Range(0, n).Select(j => j == varIndex ? 1.0 : 0.0).ToList();

            child.ConstraintCoefficients.Add(newRow);
            // Inequality strings in your pipeline are parsed like "<=12.5" etc.
            // Keep a compact, culture-invariant format:
            string rhsStr = rhs.ToString(System.Globalization.CultureInfo.InvariantCulture);
            child.ConstraintInequalities.Add(op + rhsStr);

            return child;
        }
    }
}
