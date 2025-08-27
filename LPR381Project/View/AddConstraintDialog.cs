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
    public partial class AddConstraintDialog : Form
    {
        public List<double> VariableCoefficients { get; private set; }
        public double Rhs { get; private set; }

        private readonly int _numVariables;

        public AddConstraintDialog(int numVariables)
        {
            _numVariables = numVariables;
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            this.Text = "Add New Constraint";
            this.Size = new Size(400, 300);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            FlowLayoutPanel panel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                AutoScroll = true
            };

            // Add labels and textboxes for each variable coefficient
            for (int i = 0; i < _numVariables; i++)
            {
                Label label = new Label { Text = $"Coefficient for x{i + 1}:" };
                TextBox textBox = new TextBox { Tag = i, Width = 100 };
                panel.Controls.Add(label);
                panel.Controls.Add(textBox);
            }

            // Add label and textbox for RHS
            Label rhsLabel = new Label { Text = "RHS (<=):" };
            TextBox rhsTextBox = new TextBox { Tag = "rhs", Width = 100 };
            panel.Controls.Add(rhsLabel);
            panel.Controls.Add(rhsTextBox);

            // Add OK and Cancel buttons
            Button okButton = new Button { Text = "OK", DialogResult = DialogResult.OK };
            Button cancelButton = new Button { Text = "Cancel", DialogResult = DialogResult.Cancel };
            FlowLayoutPanel buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                FlowDirection = FlowDirection.RightToLeft,
                Height = 40
            };
            buttonPanel.Controls.Add(cancelButton);
            buttonPanel.Controls.Add(okButton);

            this.Controls.Add(panel);
            this.Controls.Add(buttonPanel);

            this.AcceptButton = okButton;
            this.CancelButton = cancelButton;

            okButton.Click += OkButton_Click;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            try
            {
                VariableCoefficients = new List<double>();
                foreach (Control control in this.Controls[0].Controls)
                {
                    if (control is TextBox textBox)
                    {
                        if (textBox.Tag is int index)
                        {
                            // Variable coefficients
                            while (VariableCoefficients.Count <= index)
                            {
                                VariableCoefficients.Add(0);
                            }
                            VariableCoefficients[index] = double.Parse(textBox.Text);
                        }
                        else if (textBox.Tag.ToString() == "rhs")
                        {
                            Rhs = double.Parse(textBox.Text);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error parsing inputs: {ex.Message}", "Input Error");
                this.DialogResult = DialogResult.None;
            }
        }
    }
}
