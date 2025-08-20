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
    public partial class BranchAndBoundKnapsackPage : UserControl
    {
        public BranchAndBoundKnapsackPage()
        {
            InitializeComponent();
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
    }
}
