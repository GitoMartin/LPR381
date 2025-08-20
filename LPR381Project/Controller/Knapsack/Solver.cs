using LPR381Project.Model.Knapsack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPR381Project.Controller.Knapsack
{
    internal class Solver
    {

        private readonly int _capacity;
        private readonly List<Item> _itemsSorted; // sorted by ratio desc
        private readonly List<LogEntry> _log = new List<LogEntry>();
        private int _bestValue = 0;
        private bool[] _bestTaken = Array.Empty<bool>();
        private int _nodeCounter = 0;
        private int _iteration = 0;

        public Solver(IEnumerable<Item> items, int capacity)
        {
            _capacity = capacity;
            _itemsSorted = items
                .OrderByDescending(i => i.Ratio)
                .ThenBy(i => i.Weight)
                .ToList();
        }

        public List<Item> getItemsSorted() {             return _itemsSorted;
        }

        public KnapsackResult Solve()
        {
            _bestValue = 0;
            _bestTaken = new bool[_itemsSorted.Count];

            var root = new Node
            {
                Id = NextNodeId(),
                ParentId = null,
                Level = 0,
                Weight = 0,
                Value = 0,
                TakenPath = new bool[_itemsSorted.Count],
                Bound = UpperBound(0, 0, 0),
                LastDecision = "root",
                Status = "Branched",
            };

            Log(root, statusOverride: "Branched", reason: "Start at root");
            Explore(root);

            int bestWeight = 0;
            for (int i = 0; i < _itemsSorted.Count; i++)
                if (_bestTaken[i]) bestWeight += _itemsSorted[i].Weight;

            return new KnapsackResult
            {
                BestValue = _bestValue,
                BestWeight = bestWeight,
                BestTaken = _bestTaken.ToArray(),
                Log = _log
            };
        }

        private void Explore(Node node)
        {
            if (node.Weight > _capacity)
            {
                node.Status = "Fathomed";
                node.Reason = "Infeasible (over capacity)";
                Log(node);
                return;
            }

            if (node.Value > _bestValue)
            {
                _bestValue = node.Value;
                Array.Copy(node.TakenPath, _bestTaken, _bestTaken.Length);
            }

            if (node.Level == _itemsSorted.Count)
            {
                node.Status = "Candidate";
                node.Reason = "All variables decided";
                Log(node);
                return;
            }

            node.Bound = UpperBound(node.Level, node.Weight, node.Value);
            if (node.Bound <= _bestValue)
            {
                node.Status = "Fathomed";
                node.Reason = $"Bound {node.Bound:F2} ≤ best {_bestValue}";
                Log(node);
                return;
            }

            var item = _itemsSorted[node.Level];

            var left = new Node
            {
                Id = NextNodeId(),
                ParentId = node.Id,
                Level = node.Level + 1,
                Weight = node.Weight + item.Weight,
                Value = node.Value + item.Value,
                TakenPath = (bool[])node.TakenPath.Clone(),
                LastDecision = $"x{item.Id}=1"
            };
            left.TakenPath[node.Level] = true;
            left.Bound = UpperBound(left.Level, left.Weight, left.Value);
            Log(left, statusOverride: "Branched", reason: $"Decide take item #{item.Id}");
            Explore(left);

            var right = new Node
            {
                Id = NextNodeId(),
                ParentId = node.Id,
                Level = node.Level + 1,
                Weight = node.Weight,
                Value = node.Value,
                TakenPath = (bool[])node.TakenPath.Clone(),
                LastDecision = $"x{item.Id}=0"
            };
            right.TakenPath[node.Level] = false;
            right.Bound = UpperBound(right.Level, right.Weight, right.Value);
            Log(right, statusOverride: "Branched", reason: $"Decide skip item #{item.Id}");
            Explore(right);
        }

        private double UpperBound(int level, int currentWeight, int currentValue)
        {
            if (currentWeight > _capacity) return 0;

            double bound = currentValue;
            int totalWeight = currentWeight;

            for (int i = level; i < _itemsSorted.Count; i++)
            {
                var it = _itemsSorted[i];
                if (totalWeight + it.Weight <= _capacity)
                {
                    totalWeight += it.Weight;
                    bound += it.Value;
                }
                else
                {
                    int remaining = _capacity - totalWeight;
                    if (remaining > 0)
                        bound += it.Ratio * remaining;
                    break;
                }
            }
            return bound;
        }

        private int NextNodeId() => ++_nodeCounter;

        private void Log(Node node, string statusOverride = null, string reason = null)
        {
            _iteration++;
            string status = statusOverride ?? node.Status;
            string why = reason ?? node.Reason;

            var bits = new char[_itemsSorted.Count];
            for (int i = 0; i < _itemsSorted.Count; i++)
            {
                if (i < node.Level) bits[i] = node.TakenPath[i] ? '1' : '0';
                else bits[i] = 'x';
            }

            _log.Add(new LogEntry
            {
                Iteration = _iteration,
                NodeId = node.Id,
                ParentId = node.ParentId,
                Level = node.Level,
                Decision = node.LastDecision,
                Weight = node.Weight,
                Value = node.Value,
                Bound = node.Bound,
                Status = status,
                Reason = why,
                PathBinary = new string(bits)
            });
        }
    }


}
