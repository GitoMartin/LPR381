using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPR381Project.Model.Sensitivity_analysis
{
    public class SimplexTableau
    {
        public double[,] Tableau { get; set; }
        public int NumVariables { get; set; }
        public int NumSlackSurplus { get; set; }
        // Stores the index of the variable in each basic row (e.g., 0 for x1, 1 for x2, etc.)
        public int[] BasicVariables { get; set; }
        public double ObjectiveValue { get; set; }
    }
}
