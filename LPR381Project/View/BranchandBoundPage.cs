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

namespace LPR381Project
{
    public partial class BranchandBoundPage : UserControl
    {
        public BranchandBoundPage()
        {
            InitializeComponent();
            this.AutoScroll = true;
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Text Files|*.txt|All Files|*.*";
                sfd.Title = "Save Results As";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllText(sfd.FileName, bestCandidTxtb.Text);
                    MessageBox.Show("Results exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void roundedRichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void connectHost2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            BranchAndBoundSolver BB = new BranchAndBoundSolver(Form1.model);
            tiRTB.Text = BB.ShowAllNodes();
            bestCandidTxtb.Text = BB.ShowBestSolution();
        }
    }
}
