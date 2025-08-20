using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPR381Project.Model.Knapsack
{
    internal class Item
    {
        public int Id { get; set; }            // Original ID (1-based for display)
        public int Weight { get; set; }
        public int Value { get; set; }
        public double Ratio => (double)Value / Weight;
    }
}
