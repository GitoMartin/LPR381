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
        public CuttingPlanePage()
        {
            InitializeComponent();
            this.AutoScroll = true;
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
                    System.IO.File.WriteAllText(sfd.FileName, tiRTB.Text);
                    MessageBox.Show("Results exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
