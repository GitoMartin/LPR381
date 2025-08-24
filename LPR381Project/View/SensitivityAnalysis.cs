using LPR381Project.Controller;
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
    public partial class SensitivityAnalysis : UserControl
    {
        private SensitivityAnalysisController controller;

        public SensitivityAnalysis()
        {
            InitializeComponent();
            controller = new SensitivityAnalysisController(Form1.model);
        }


        private void SensAnaTbl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SensitivityAnalysis_Load(object sender, EventArgs e)
        {
            LPModel currentModel = controller.GetLPModel();
            List<List<double>> currentTableau = controller.GetFinalTableau();

            List<string> allVariables = new List<string>();
            for (int i = 0; i < currentModel.ObjectiveFunction.Count; i++)
            {
                allVariables.Add($"x{i + 1}");
            }

            List<string> basicVariables = new List<string>();
            List<string> nonBasicVariables = new List<string>();

            int numConstraints = currentModel.ConstraintCoefficients.Count;
            int numOriginalVariables = currentModel.ObjectiveFunction.Count;
            int numSlackSurplusVariables = currentTableau[0].Count - numOriginalVariables - 1; // -1 for RHS

            // Identify basic and non-basic variables
            for (int j = 0; j < numOriginalVariables + numSlackSurplusVariables; j++)
            {
                bool isBasic = false;
                int oneCount = 0;
                int oneRow = -1;

                for (int i = 0; i < numConstraints; i++)
                {
                    if (Math.Abs(currentTableau[i][j] - 1.0) < 1e-9)
                    {
                        oneCount++;
                        oneRow = i;
                    }
                    else if (Math.Abs(currentTableau[i][j]) > 1e-9)
                    {
                        // Not a unit vector column
                        isBasic = false;
                        break;
                    }
                }

                if (oneCount == 1)
                {
                    // Check if all other entries in the column are zero
                    bool allOthersZero = true;
                    for (int i = 0; i < numConstraints; i++)
                    {
                        if (i != oneRow && Math.Abs(currentTableau[i][j]) > 1e-9)
                        {
                            allOthersZero = false;
                            break;
                        }
                    }

                    if (allOthersZero)
                    {
                        isBasic = true;
                    }
                }

                if (isBasic)
                {
                    if (j < numOriginalVariables)
                    {
                        basicVariables.Add($"x{j + 1}");
                    }
                    else
                    {
                        // This is a slack/surplus variable that is basic
                        basicVariables.Add($"s{j - numOriginalVariables + 1}");
                    }
                }
                else
                {
                    if (j < numOriginalVariables)
                    {
                        nonBasicVariables.Add($"x{j + 1}");
                    }
                    else
                    {
                        // This is a slack/surplus variable that is non-basic
                        nonBasicVariables.Add($"s{j - numOriginalVariables + 1}");
                    }
                }
            }

            // Populate ComboBoxes
            selectNBV.Items.AddRange(nonBasicVariables.ToArray());
            comboBox4.Items.AddRange(nonBasicVariables.ToArray());

            selectBV.Items.AddRange(basicVariables.ToArray());
            comboBox1.Items.AddRange(basicVariables.ToArray());

            // Populate Constraint RHS ComboBoxes
            for (int i = 0; i < numConstraints; i++)
            {
                selectCRHS.Items.Add($"Constraint {i + 1}");
                comboBox2.Items.Add($"Constraint {i + 1}");
            }

            // Populate Variable in NBV column ComboBoxes (using all original variables for now)
            selectVarNBV.Items.AddRange(allVariables.ToArray());
            comboBox3.Items.AddRange(allVariables.ToArray());
        }

        private void selectNBV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void showRangeBtn1_Click(object sender, EventArgs e)
        {
            RangeResTxtb.Text = controller.GetNonBasicVariableRange(selectNBV.SelectedItem.ToString());
        }

        private void showRangeBtn2_Click(object sender, EventArgs e)
        {
            RangeResTxtb.Text = controller.GetBasicVariableRange(selectBV.SelectedItem.ToString());
        }

        private void showRangeBtn3_Click(object sender, EventArgs e)
        {
            RangeResTxtb.Text = controller.GetConstraintRhsRange(selectCRHS.SelectedIndex);
        }

        private void showRangeBtn4_Click(object sender, EventArgs e)
        {
            RangeResTxtb.Text = controller.GetVariableInNonBasicVariableColumnRange(selectVarNBV.SelectedItem.ToString(), selectVarNBV.SelectedIndex);
        }

        private void applybtn1_Click(object sender, EventArgs e)
        {
            controller.ApplyNonBasicVariableChange(comboBox4.SelectedItem.ToString(), (double)numericUpDown1.Value);
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            controller.ApplyBasicVariableChange(comboBox1.SelectedItem.ToString(), (double)numericUpDown2.Value);
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            controller.ApplyConstraintRhsChange(comboBox2.SelectedIndex, (double)numericUpDown3.Value);
        }

        private void roundedButton3_Click(object sender, EventArgs e)
        {
            controller.ApplyVariableInNonBasicVariableColumnChange(comboBox3.SelectedItem.ToString(), comboBox3.SelectedIndex, (double)numericUpDown4.Value);
        }

        private void roundedButton4_Click(object sender, EventArgs e)
        {
            // Expected format: "coeff1,coeff2,...,objective_coeff"
            // Example: "2,3,5" for a new activity with coefficients 2, 3 for constraints and 5 for objective
            List<double> newActivityCoefficients = addnewActtxtb.Text.Split(',').Select(double.Parse).ToList();
            controller.AddNewActivity(newActivityCoefficients);
        }

        private void roundedButton5_Click(object sender, EventArgs e)
        {
            // Expected format: "coeff1,coeff2,...,inequality_sign,rhs_value"
            // Example: "1,1,<=,10" for a new constraint x1 + x2 <= 10
            var parts = roundedRichTextBox2.Text.Split(',');
            var coefficients = parts.Take(parts.Length - 2).Select(double.Parse).ToList();
            var inequality = parts[parts.Length - 2];
            var rhs = double.Parse(parts[parts.Length - 1]);
            controller.AddNewConstraint(coefficients, inequality, rhs);
        }

        private void dispShadPricBtn_Click(object sender, EventArgs e)
        {
            shadowPricetxtb.Text = controller.GetShadowPrices();
        }

        private void solveDualBtn_Click(object sender, EventArgs e)
        {
            roundedRichTextBox3.Text = controller.SolveDualModel();
        }
    }
}
