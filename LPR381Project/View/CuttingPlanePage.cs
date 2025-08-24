using Lpr381back;
using LPR381Project.Controller.CuttingPlane;
using LPR381Project.Controller.Knapsack;
using LPR381Project.Model.CuttingPlane;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LPR381Project
{
    public partial class CuttingPlanePage : UserControl
    {
        private LPModel model;
        public CuttingPlanePage(LPModel _model)
        {
            InitializeComponent();
            this.AutoScroll = true;
            model = _model;
        }

        private void contentHost3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CuttingPlanePage_Load(object sender, EventArgs e)
        {

        }

        private void canonicalRTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Text Files|*.txt|All Files|*.*";
                sfd.Title = "Save Results As";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllText(sfd.FileName, BTFRTB.Text);
                    MessageBox.Show("Results exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        
        private void btnSolve_Click(object sender, EventArgs e)
        {
            BTFRTB.Clear();
            roundedRichTextBox1.Clear();
            model = Form1.model;
            var solver = new CuttingPlaneSolver(model);
            string output = solver.Solve();
            
            StringBuilder canonicalLog = solver.canonical;
            // To get the string content:
            string canonicalText = canonicalLog.ToString();

            BTFRTB.Text = canonicalText;
            roundedRichTextBox1.Text = output;

        }

        
    }
}
