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
    public partial class PrimalSimplexControl : UserControl
    {
        private LPModel _model;
        private DualSimplex Ds;
        public PrimalSimplexControl(LPModel model)
        {
            InitializeComponent();
            SetPlaceholder(canonicalRTB, "  Canonical Form will be displayed here... ");
            SetPlaceholder(tiRTB, "  All Tableu Iterations will be displayed here...");
            this._model = model;
            Ds = new DualSimplex(_model);
        }
        private void SetPlaceholder(RichTextBox txt, string placeholder)
        {
            txt.ForeColor = Color.Gray;
            txt.Text = placeholder;
            txt.SelectAll();
            txt.SelectionAlignment = HorizontalAlignment.Center;
            txt.DeselectAll();

            txt.GotFocus += (s, e) =>
            {
                if (txt.Text == placeholder)
                {
                    txt.Clear();
                    txt.ForeColor = Color.Black;
                    txt.SelectionAlignment = HorizontalAlignment.Left; 
                }
            };

            txt.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Text = placeholder;
                    txt.ForeColor = Color.Gray;

                    txt.SelectAll();
                    txt.SelectionAlignment = HorizontalAlignment.Center;
                    txt.DeselectAll();
                }
            };
        }



        private void PrimalSimplexControl_Load(object sender, EventArgs e)
        {
            this.AutoScroll = true;
        }

        private void connectHost2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void canonicalRTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void roundedPanel1_Paint(object sender, PaintEventArgs e)
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

        private void tiRTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            Ds.Solve();
            canonicalRTB.Text = Ds.GetInitialCanonicalString();
            tiRTB.Text = Ds.GetIterationsString();
           
        }
    }
}
