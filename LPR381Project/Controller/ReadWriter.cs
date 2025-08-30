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
        public void ReadFromFile(LPModel model, string path)
        {
            var lines = File.ReadAllLines(path);

            if (lines.Length < 2)
                throw new Exception("File must have at least an objective and one line of signs.");

            // ===== FIRST LINE: objective function =====
            var firstParts = lines[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            model.Type = firstParts[0];

            for (int j = 1; j < firstParts.Length; j++)
            {
                if (!double.TryParse(firstParts[j], System.Globalization.NumberStyles.Float,
                                     System.Globalization.CultureInfo.InvariantCulture, out double coef))
                    throw new Exception($"Invalid objective coefficient: '{firstParts[j]}'");
                model.ObjectiveFunction.Add(coef);
            }

            // ===== MIDDLE LINES: constraints =====
            for (int i = 1; i < lines.Length - 1; i++)
            {
                var parts = lines[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length < 3)
                    throw new Exception($"Constraint line {i + 1} is invalid: {lines[i]}");

                // operator and RHS
                string ineqSign = parts[parts.Length - 2].Trim(); // <=, >=, =
                string rhsStr = parts[parts.Length - 1].Trim();

                if (ineqSign != "<=" && ineqSign != ">=" && ineqSign != "=")
                    throw new Exception($"Invalid inequality token: '{ineqSign}' on line {i + 1}");

                if (!double.TryParse(rhsStr, System.Globalization.NumberStyles.Float,
                                     System.Globalization.CultureInfo.InvariantCulture, out double rhs))
                    throw new Exception($"Invalid RHS value '{rhsStr}' on line {i + 1}");

                model.ConstraintInequalities.Add($"{ineqSign} {rhs}");
                model.Rhs.Add(rhs);

                // coefficients
                var rowCoefficients = new List<double>();
                for (int k = 0; k < parts.Length - 2; k++)
                {
                    if (!double.TryParse(parts[k], System.Globalization.NumberStyles.Float,
                                         System.Globalization.CultureInfo.InvariantCulture, out double num))
                        throw new Exception($"Invalid number '{parts[k]}' in constraint row {i + 1}");
                    rowCoefficients.Add(num);
                }

                // sanity check: coefficient count matches objective length
                if (rowCoefficients.Count != model.ObjectiveFunction.Count)
                    throw new Exception($"Constraint row {i + 1} has {rowCoefficients.Count} coefficients, expected {model.ObjectiveFunction.Count}");

                model.ConstraintCoefficients.Add(rowCoefficients);
            }

            // ===== LAST LINE: sign/type restrictions =====
            var lastParts = lines[lines.Length - 1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (lastParts.Length != model.ObjectiveFunction.Count)
                throw new Exception($"Sign restriction count ({lastParts.Length}) does not match number of variables ({model.ObjectiveFunction.Count})");

            model.Signs.Clear();
            foreach (var sign in lastParts)
                model.Signs.Add(sign.Trim());
        }
    }
}
