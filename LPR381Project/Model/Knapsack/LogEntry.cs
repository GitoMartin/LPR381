using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPR381Project.Model.Knapsack
{
    internal class LogEntry
    {
        public int Iteration { get; set; }
        public int NodeId { get; set; }
        public int? ParentId { get; set; }
        public int Level { get; set; }
        public string Decision { get; set; } = "";
        public int Weight { get; set; }
        public int Value { get; set; }
        public double Bound { get; set; }
        public string Status { get; set; } = "";
        public string Reason { get; set; } = "";
        public string PathBinary { get; set; } = ""; // e.g., 101x (x = undecided)
    }
}
