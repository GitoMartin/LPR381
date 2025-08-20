using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPR381Project.Model.Knapsack
{
    internal class Node
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public int Level { get; set; }          // index of next item to decide on (0..n)
        public int Weight { get; set; }
        public int Value { get; set; }
        public bool[] TakenPath { get; set; }   // taken decisions aligned to sorted items
        public double Bound { get; set; }
        public string LastDecision { get; set; } = "root"; // e.g., x3=1 or x3=0
        public string Status { get; set; } = "";           // Branched / Fathomed / Leaf / Pruned
        public string Reason { get; set; } = "";           // why fathomed/pruned
    }
}
