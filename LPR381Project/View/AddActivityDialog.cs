using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LPR381Project.View
{
    public partial class AddActivityDialog : Form
    {
        public double ObjectiveCoefficient { get; private set; }
        public List<double> ConstraintCoefficients { get; private set; }
        private NumericUpDown nudObjective;
        private List<TextBox> txtCoefficients;

        public AddActivityDialog(int numConstraints)
        {
            this.Text = "Add New Activity";
            this.Size = new Size(300, 150 + numConstraints * 40);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;

            Label lblObjective = new Label { Text = "Objective Coefficient (Cj):", Location = new Point(15, 20) };
            nudObjective = new NumericUpDown { Location = new Point(180, 20), Width = 80, DecimalPlaces = 2 };

            txtCoefficients = new List<TextBox>();
            for (int i = 0; i < numConstraints; i++)
            {
                Label lblConstraint = new Label { Text = $"Constraint {i + 1} Coeff:", Location = new Point(15, 60 + i * 30), Width = 150 };
                TextBox txt = new TextBox { Location = new Point(180, 60 + i * 30), Width = 80 };
                this.Controls.Add(lblConstraint);
                this.Controls.Add(txt);
                txtCoefficients.Add(txt);
            }

            Button btnOk = new Button { Text = "OK", Location = new Point(60, this.Height - 80), DialogResult = DialogResult.OK };
            Button btnCancel = new Button { Text = "Cancel", Location = new Point(150, this.Height - 80), DialogResult = DialogResult.Cancel };
            btnOk.Click += (s, e) => { if (!ValidateInput()) this.DialogResult = DialogResult.None; };

            this.Controls.AddRange(new Control[] { lblObjective, nudObjective, btnOk, btnCancel });
            this.AcceptButton = btnOk;
            this.CancelButton = btnCancel;
        }

        private bool ValidateInput()
        {
            ObjectiveCoefficient = (double)nudObjective.Value;
            ConstraintCoefficients = new List<double>();
            foreach (var txt in txtCoefficients)
            {
                if (double.TryParse(txt.Text, out double coeff))
                {
                    ConstraintCoefficients.Add(coeff);
                }
                else
                {
                    MessageBox.Show($"Invalid number entered for a constraint coefficient: '{txt.Text}'", "Input Error");
                    return false;
                }
            }
            return true;
        }
    }
}
