using LPR381Project.Controller;
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
            Pass null for the final tableau for now
            controller = new SensitivityAnalysisController(Form1.model, null);
        }


        private void SensAnaTbl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SensitivityAnalysis_Load(object sender, EventArgs e)
        {

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
            // Assuming the user enters the new activity coefficients in the format "c1,c2,c3,..."
            List<double> newActivityCoefficients = addnewActtxtb.Text.Split(',').Select(double.Parse).ToList();
            controller.AddNewActivity(newActivityCoefficients);
        }

        private void roundedButton5_Click(object sender, EventArgs e)
        {
            // Assuming the user enters the new constraint in the format "c1,c2,c3,...,<=,rhs"
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
