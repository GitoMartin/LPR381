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
using LPR381Project.Controller.Sensitivity_Analysis;
using LPR381Project.Controller.Knapsack;
using LPR381Project.Model.Sensitivity_analysis;


namespace LPR381Project
{
    public partial class SensitivityAnalysis : UserControl
    {
        SimplexTableau _tableau;
        private LPModel _model;
        private readonly SensitivityRanges _ranges;
        public SensitivityAnalysis(LPModel model)
        {
            InitializeComponent();
            _model = model;

            var simplexSolver = new SimplexSolver(_model);
            _tableau = simplexSolver.Solve();
            _ranges = new SensitivityRanges(_tableau);
            LoadComboboxes();
            AttachEventHandlers();


        }

        private void LoadComboboxes()
        {
            // Load Non-Basic Variables
            var nonBasics = new List<string>();
            for (int j = 0; j < _model.ObjectiveFunction.Count; j++)
            {
                if (Array.IndexOf(_tableau.BasicVariables, j) < 0)
                {
                    nonBasics.Add($"x{j + 1}");
                }
            }
            comboBoxNonBasicVar.DataSource = nonBasics;

            // Load Basic Variables
            var basics = new List<string>();
            for (int i = 0; i < _tableau.BasicVariables.Length; i++)
            {
                int varIdx = _tableau.BasicVariables[i];
                if (varIdx < _model.ObjectiveFunction.Count)
                {
                    basics.Add($"x{varIdx + 1}");
                }
                else
                {
                    basics.Add($"s{i + 1}");
                }
            }
            comboBoxBasicVar.DataSource = basics;

            // Load Constraint RHS
            var constraints = new List<string>();
            for (int i = 0; i < _model.Rhs.Count; i++)
            {
                constraints.Add($"Constraint {i + 1} (RHS: {_model.Rhs[i]})");
            }
            comboBoxConstraintRHS.DataSource = constraints;

            // Load Variables in NBV Column (same as non-basic for simplicity)
            comboBoxVarInNBV.DataSource = nonBasics;
        }

        private void AttachEventHandlers()
        {
            buttonShowRangeNonBasic.Click += (s, e) => ShowRangeNonBasic();
            buttonShowRangeBasic.Click += (s, e) => ShowRangeBasic();
            buttonShowRangeConstraint.Click += (s, e) => ShowRangeConstraint();
            buttonShowRangeNBV.Click += (s, e) => ShowRangeNBV();
        }

        private void ShowRangeNonBasic()
        {
            if (comboBoxNonBasicVar.SelectedIndex >= 0)
            {
                int j = comboBoxNonBasicVar.SelectedIndex;
                var (minDelta, maxDelta) = _ranges.GetObjectiveCoefRange(j);
                textBoxRangeResult.Text = _ranges.FormatRange(minDelta, maxDelta, _model.ObjectiveFunction[j]);
            }
        }

        private void ShowRangeBasic()
        {
            if (comboBoxBasicVar.SelectedIndex >= 0)
            {
                int j = _tableau.BasicVariables[comboBoxBasicVar.SelectedIndex];
                if (j < _model.ObjectiveFunction.Count)
                {
                    var (minDelta, maxDelta) = _ranges.GetObjectiveCoefRange(j);
                    textBoxRangeResult.Text = _ranges.FormatRange(minDelta, maxDelta, _model.ObjectiveFunction[j]);
                }
                else
                {
                    // Handle slack variable case if needed, or skip
                    textBoxRangeResult.Text = "Range not applicable for slack variables.";
                }
            }
        }

        private void ShowRangeConstraint()
        {
            if (comboBoxConstraintRHS.SelectedIndex >= 0)
            {
                int i = comboBoxConstraintRHS.SelectedIndex;
                var (minGamma, maxGamma) = _ranges.GetRHSRange(i);
                textBoxRangeResult.Text = _ranges.FormatRange(minGamma, maxGamma, _model.Rhs[i]);
            }
        }

        private void ShowRangeNBV()
        {
            if (comboBoxVarInNBV.SelectedIndex >= 0 && comboBoxConstraintRHS.SelectedIndex >= 0)
            {
                int j = comboBoxVarInNBV.SelectedIndex;
                int i = comboBoxConstraintRHS.SelectedIndex;
                var (minDelta, maxDelta) = _ranges.GetMatrixCoefRange(i, j);
                textBoxRangeResult.Text = _ranges.FormatRange(minDelta, maxDelta, _model.ConstraintCoefficients[i][j]);
            }
        }

        private void showRangeBtn1_Click(object sender, EventArgs e)
        {

        }

        private void buttonShowRangeBasic_Click(object sender, EventArgs e)
        {

        }
    }
}

