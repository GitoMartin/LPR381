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
    }
}
