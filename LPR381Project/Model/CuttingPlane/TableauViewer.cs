using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPR381Project.Model.CuttingPlane
{
    internal class TableauViewer
    {
        public static string DisplayString(double[,] tableau, int numVariables, int[] basis)
        {
            int rows = tableau.GetLength(0);
            int cols = tableau.GetLength(1);

            var sb = new System.Text.StringBuilder();

            // --- Header ---
            sb.AppendFormat("{0, -7}", "Basis");
            sb.AppendFormat("{0, 8}", "Z");
            for (int j = 1; j <= numVariables; j++)
            {
                sb.AppendFormat("x{0, -7}", j);
            }
            for (int j = numVariables + 1; j < cols - 1; j++)
            {
                sb.AppendFormat("s{0, -7}", j - numVariables);
            }
            sb.AppendFormat("{0, 8}", "RHS");
            sb.AppendLine();
            sb.AppendLine(new string('-', cols * 8 + 5));

            // --- Rows ---
            for (int i = 0; i < rows; i++)
            {
                // Basis variable name
                if (i == 0) sb.AppendFormat("{0, -7}", "Z");
                else if (basis[i] <= numVariables) sb.AppendFormat("x{0, -7}", basis[i]);
                else sb.AppendFormat("s{0, -7}", basis[i] - numVariables);

                // Row values
                for (int j = 0; j < cols; j++)
                {
                    sb.AppendFormat("{0, 8:F2}", tableau[i, j]);
                }
                sb.AppendLine();
            }
            sb.AppendLine();
            return sb.ToString();
        }
    }
}
