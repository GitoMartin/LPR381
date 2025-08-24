using Lpr381back;
using Lpr381back.Lpr381back.LinearProgramming;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LPR381Project
{
    public partial class RevisedPrimalSimplexPage : UserControl
    {
        LPModel model;
        RevisedSimplexSolver solver;

        public RevisedPrimalSimplexPage(LPModel model)
        {
            this.model = model;
            
            InitializeComponent();
            
        }

        private void RevisedPrimalSimplexPage_Load(object sender, EventArgs e)
        {
            this.AutoScroll = true;
        }

        private void LoadRevisedSimplexPage()
        {
            RevisedPrimalSimplexPage revisedControl = new RevisedPrimalSimplexPage(model);
            revisedControl.Dock = DockStyle.Fill;
            contentHost.Controls.Clear();
            contentHost.Controls.Add(revisedControl);
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Text Files|*.txt|All Files|*.*";
                sfd.Title = "Save Results As";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllText(sfd.FileName, tiRTB.Text);
                    MessageBox.Show("Results exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            model = Form1.model;
            solver = new RevisedSimplexSolver(model);
            LpResult res = solver.Solve();

            var sb = new System.Text.StringBuilder();

            sb.AppendLine("Status: " + res.Status);
            sb.AppendLine("Objective value: " + res.ObjectiveValue);
            sb.AppendLine("Solution: [" + string.Join(", ", res.PrimalSolution) + "]");
            sb.AppendLine("Iterations: " + res.Iterations);
            sb.AppendLine("=== Iteration Log ===");

            foreach (var line in res.IterationLog)
                sb.AppendLine(line);

            // Display in textbox
            tiRTB.Text = sb.ToString();
            canonicalRTB.Text = string.Join(Environment.NewLine, res.IterationLog);


        }
        

    }
}
