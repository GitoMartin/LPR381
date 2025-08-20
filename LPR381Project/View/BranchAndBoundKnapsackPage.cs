using Lpr381back;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LPR381Project.Controller.Knapsack;
using LPR381Project.Model.Knapsack;


namespace LPR381Project
{
    public partial class BranchAndBoundKnapsackPage : UserControl
    {
        private LPModel model;
        public BranchAndBoundKnapsackPage(LPModel importedModel)
        {
            InitializeComponent();
            model = importedModel;
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Text Files|*.txt|All Files|*.*";
                sfd.Title = "Save Results As";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllText(sfd.FileName, BCRTB.Text);
                    MessageBox.Show("Results exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            string capacityString = model.ConstraintInequalities[0];
            int capacity = int.Parse(capacityString.Substring(2));
            List<Item> items = new List<Item>();

            var values = model.ObjectiveFunction;
            var weights = model.ConstraintCoefficients[0]; // Assuming weights are in the first constraint

            for (int i = 0; i < values.Count; i++)
            {
                
                Item item = new Item
                {
                    Id = i + 1, // Create a 1-based ID for display
                    Value = (int)values[i],
                    Weight = (int)weights[i]
                };
                items.Add(item);
            }
            IEnumerable<Item> itemsEnumerable = items.AsEnumerable();

            Solver solver = new Solver(itemsEnumerable, capacity);

            KnapsackResult result = solver.Solve();

            var sb = new StringBuilder();

            sb.AppendLine("--- Best Candidate ---");
            sb.AppendLine($"Total Value: {result.BestValue}");
            sb.AppendLine($"Total Weight: {result.BestWeight}");
            sb.AppendLine();

            

            sb.Append("Items Taken (ID): ");
            
            sb.Append(string.Join(", ", result.BestTaken));
            BCRTB.Text = sb.ToString();

            var sbBranching = new StringBuilder();
            // 1. Define the format string for alignment. Negative numbers mean left-align, positive mean right-align.
            string headerFormat = "{0,-5} {1,-5} {2,-7} {3,-6} {4,-12} {5,7} {6,7} {7,10} {8,-12} {9,-20} {10,-15}";
            string rowFormat = "{0,-5} {1,-5} {2,-7} {3,-6} {4,-12} {5,7} {6,7} {7,10:F2} {8,-12} {9,-20} {10,-15}";

            // 2. Append the header
            sbBranching.AppendLine(string.Format(headerFormat,
                "Iter", "Node", "Parent", "Level", "Decision", "Weight", "Value", "Bound", "Status", "Reason", "Path"
            ));
            sbBranching.AppendLine(new string('-', 125));
            foreach (var entry in result.Log)
            {
                sbBranching.AppendLine(string.Format(rowFormat,
                entry.Iteration,
                entry.NodeId,
                entry.ParentId,
                entry.Level,
                entry.Decision,
                entry.Weight,
                entry.Value,
                entry.Bound,
                entry.Status,
                entry.Reason,
                entry.PathBinary
            ));
            }
            tiRTB.Text = sbBranching.ToString();
            
            


        }
    }
}
