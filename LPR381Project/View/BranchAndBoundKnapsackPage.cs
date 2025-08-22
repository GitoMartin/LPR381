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
            try
            {
                model = Form1.model;
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
                List<Item> itemSorted = solver.getItemsSorted();


                var sb = new StringBuilder();

                sb.AppendLine("--- Best Candidate ---");
                sb.AppendLine($"Total Value: {result.BestValue}");
                sb.AppendLine($"Total Weight: {result.BestWeight}");
                sb.AppendLine();
                sb.Append("Items Taken (ID): ");
                //sb.Append(string.Join(", ", result.BestTaken));
                for (int i = 0; i < result.BestTaken.Length; i++)
                {
                    if (result.BestTaken[i])
                    {
                        sb.Append("x" + itemSorted[i].Id + ", ");
                    }
                }


                BCRTB.Text = sb.ToString();



                // Clear previous data
                tiListView.Clear();

                // 1. Add columns (headers)
                tiListView.Columns.Add("Iter", 50);
                tiListView.Columns.Add("Node", 50);
                tiListView.Columns.Add("Parent", 60);
                tiListView.Columns.Add("Level", 60);
                tiListView.Columns.Add("Decision", 80);
                tiListView.Columns.Add("Weight", 70);
                tiListView.Columns.Add("Value", 70);
                tiListView.Columns.Add("Z Value", 80);
                tiListView.Columns.Add("Status", 100);
                tiListView.Columns.Add("Reason", 150);
                tiListView.Columns.Add("Path", 120);

                // 2. Add rows from log
                foreach (var entry in result.Log)
                {
                    var row = new ListViewItem(entry.Iteration.ToString());
                    row.SubItems.Add(entry.NodeId.ToString());
                    row.SubItems.Add(entry.ParentId.ToString());
                    row.SubItems.Add(entry.Level.ToString());
                    row.SubItems.Add(entry.Decision.ToString());
                    row.SubItems.Add(entry.Weight.ToString());
                    row.SubItems.Add(entry.Value.ToString());
                    row.SubItems.Add(entry.Bound.ToString("F2")); // formatted like before
                    row.SubItems.Add(entry.Status.ToString());
                    row.SubItems.Add(entry.Reason.ToString());
                    row.SubItems.Add(entry.PathBinary.ToString());

                    tiListView.Items.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }
    }
}
