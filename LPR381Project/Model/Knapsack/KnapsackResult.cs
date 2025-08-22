using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPR381Project.Model.Knapsack
{
    internal class KnapsackResult
    {
        public int BestValue { get; set; }
        public int BestWeight { get; set; }
        public bool[] BestTaken { get; set; } = Array.Empty<bool>();
        public List<LogEntry> Log { get; set; } = new List<LogEntry>();
    }
}
