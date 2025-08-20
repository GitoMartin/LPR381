using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lpr381back
{
    internal class ReadWriter
    {
        public  void ReadFromFile(LPModel model, string path)
        {

            var lines = File.ReadAllLines(path);

            if (lines.Length == 0)
                return;

            // ===== FIRST LINE =====
            var firstParts = lines[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            model.Type = firstParts[0];
            double num;
            for (int j = 1; j < firstParts.Length; j++)
            {
                if (firstParts[j][0]=='+')
                {
                    model.ObjectiveFunction.Add(double.Parse(firstParts[j]));
                }
                else
                {
                    num = double.Parse(firstParts[j]);
                    num = num * -1;
                    model.ObjectiveFunction.Add(num);
                }
                    
            }

            // ===== MIDDLE LINES =====
            // Loop through lines except first and last
            for (int i = 1; i < lines.Length - 1; i++)
            {
                var parts = lines[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 0)
                    continue;

                // Last token = inequality
                model.ConstraintInequalities.Add(parts[parts.Length - 1]);

                // Rest = coefficients
                var rowCoefficients = new List<double>();
                for (int k = 0; k < parts.Length - 1; k++)
                {
                    if (parts[k][0]=='+')
                    {
                        rowCoefficients.Add(double.Parse(parts[k]));
                    }
                    else
                    {
                        num = double.Parse(parts[k]);
                        num = num * -1;
                        rowCoefficients.Add(num);
                    }
                        
                }
                model.ConstraintCoefficients.Add(rowCoefficients);
            }

            // ===== LAST LINE =====
            var lastParts = lines[lines.Length - 1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < lastParts.Length; j++)
            {
                model.Signs.Add(lastParts[j]);
            }
        }
    }
}
