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
        private SensitivityRanges _ranges;
        SimplexSolver _solver;

        // Add these fields to store the actual variable indices
        private List<int> _nonBasicVarIndices;
        private List<int> _basicVarIndices;

        public SensitivityAnalysis(LPModel model)
        {
            InitializeComponent();
            _model = model;

            _solver = new SimplexSolver(_model);
            _tableau = _solver.Solve();
            _ranges = new SensitivityRanges(_tableau);

            // Initialize the index lists
            _nonBasicVarIndices = new List<int>();
            _basicVarIndices = new List<int>();

            LoadComboboxes();
            AttachEventHandlers();
        }

        /// <summary>
        /// Range Analysis
        /// </summary>
        private void LoadComboboxes()
        {
            // Load Non-Basic Variables
            var nonBasics = new List<string>();
            _nonBasicVarIndices.Clear(); // Clear previous indices

            for (int j = 0; j < _model.ObjectiveFunction.Count; j++)
            {
                if (Array.IndexOf(_tableau.BasicVariables, j) < 0)
                {
                    nonBasics.Add($"x{j + 1}");
                    _nonBasicVarIndices.Add(j); // Store the actual variable index
                }
            }
            comboBoxNonBasicVar.DataSource = nonBasics;
            comboBoxNonBasicVar2.DataSource = new List<string>(nonBasics); // Create copy for second combobox
            comboBoxVarInNBV.DataSource = new List<string>(nonBasics); // Create copy
            comboBoxVarInNBV2.DataSource = new List<string>(nonBasics); // Create copy

            // Load Basic Variables
            var basics = new List<string>();
            _basicVarIndices.Clear(); // Clear previous indices

            for (int i = 0; i < _tableau.BasicVariables.Length; i++)
            {
                int varIdx = _tableau.BasicVariables[i];
                if (varIdx < _model.ObjectiveFunction.Count)
                {
                    basics.Add($"x{varIdx + 1}");
                    _basicVarIndices.Add(varIdx); // Store the actual variable index
                }
                else
                {
                    basics.Add($"s{i + 1}");
                    _basicVarIndices.Add(varIdx); // Store the actual variable index (slack variable)
                }
            }
            comboBoxBasicVar.DataSource = basics;
            comboBoxBasicVar2.DataSource = new List<string>(basics); // Create copy

            // Load Constraint RHS
            var constraints = new List<string>();
            for (int i = 0; i < _model.Rhs.Count; i++)
            {
                constraints.Add($"Constraint {i + 1} (RHS: {_model.Rhs[i]})");
            }
            comboBoxConstraintRHS.DataSource = constraints;
            comboBoxConstraintRHS2.DataSource = new List<string>(constraints); // Create copy
        }

        private void AttachEventHandlers()
        {
            buttonShowRangeNonBasic.Click += (s, e) => ShowRangeNonBasic();
            buttonShowRangeBasic.Click += (s, e) => ShowRangeBasic();
            buttonShowRangeConstraint.Click += (s, e) => ShowRangeConstraint();
            buttonShowRangeNBV.Click += (s, e) => ShowRangeNBV();
            buttonApplyNonBasic.Click += (s, e) => ApplyChangeNonBasic();
            buttonApplyBasic.Click += (s, e) => ApplyChangeBasic();
            buttonApplyConstraint.Click += (s, e) => ApplyChangeConstraint();
            buttonApplyNBV.Click += (s, e) => ApplyChangeNBV();
        }

        private void ShowRangeNonBasic()
        {
            if (comboBoxNonBasicVar.SelectedIndex >= 0)
            {
                // Use the actual variable index instead of combobox index
                int j = _nonBasicVarIndices[comboBoxNonBasicVar.SelectedIndex];
                var (minDelta, maxDelta) = _ranges.GetObjectiveCoefRange(j);
                textBoxRangeResult.Text = _ranges.FormatRange(minDelta, maxDelta, _model.ObjectiveFunction[j]);
            }
        }

        private void ShowRangeBasic()
        {
            if (comboBoxBasicVar.SelectedIndex >= 0)
            {
                // Use the actual variable index instead of tableau basic variable index
                int j = _basicVarIndices[comboBoxBasicVar.SelectedIndex];
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
                // Use the actual variable index instead of combobox index
                int j = _nonBasicVarIndices[comboBoxVarInNBV.SelectedIndex];
                int i = comboBoxConstraintRHS.SelectedIndex;
                var (minDelta, maxDelta) = _ranges.GetMatrixCoefRange(i, j);
                textBoxRangeResult.Text = _ranges.FormatRange(minDelta, maxDelta, _model.ConstraintCoefficients[i][j]);
            }
        }

        /// <summary>
        /// Apply Changes
        /// </summary>  

        private void ApplyChangeNonBasic()
        {
            if (comboBoxNonBasicVar2.SelectedIndex >= 0)
            {
                // Use the actual variable index from the second combobox
                int j = _nonBasicVarIndices[comboBoxNonBasicVar2.SelectedIndex];
                double delta = (double)numericUpDownNonBasic.Value;
                var (minDelta, maxDelta) = _ranges.GetObjectiveCoefRange(j);
                if (delta >= minDelta && delta <= maxDelta)
                {
                    _model.ObjectiveFunction[j] += delta;

                    // Recalculate everything after the change
                    _tableau = _solver.Solve();
                    _ranges = new SensitivityRanges(_tableau);
                    LoadComboboxes(); // Reload comboboxes as basic/non-basic variables might change

                    textBoxResult.Text = $"Applied change to x{j + 1}\nNew Objective Value: {_tableau.ObjectiveValue}\nUpdated Coefficient: {_model.ObjectiveFunction[j]}";
                }
                else
                {
                    textBoxResult.Text = $"Change out of allowable range for x{j + 1}!\nAllowable range: [{minDelta:F2}, {maxDelta:F2}]";
                }
            }
            else
            {
                textBoxResult.Text = "Please select a non-basic variable to apply changes to.";
            }
        }

        private void ApplyChangeBasic()
        {
            if (comboBoxBasicVar2.SelectedIndex >= 0)
            {
                // Use the actual variable index from the second combobox
                int j = _basicVarIndices[comboBoxBasicVar2.SelectedIndex];
                if (j < _model.ObjectiveFunction.Count)
                {
                    double delta = (double)numericUpDownBasic.Value;
                    var (minDelta, maxDelta) = _ranges.GetObjectiveCoefRange(j);
                    if (delta >= minDelta && delta <= maxDelta)
                    {
                        _model.ObjectiveFunction[j] += delta;

                        // Recalculate everything after the change
                        _tableau = _solver.Solve();
                        _ranges = new SensitivityRanges(_tableau);
                        LoadComboboxes(); // Reload comboboxes as basic/non-basic variables might change

                        textBoxResult.Text = $"Applied change to x{j + 1}\nNew Objective Value: {_tableau.ObjectiveValue}\nUpdated Coefficient: {_model.ObjectiveFunction[j]}";
                    }
                    else
                    {
                        textBoxResult.Text = $"Change out of allowable range for x{j + 1}!\nAllowable range: [{minDelta:F2}, {maxDelta:F2}]";
                    }
                }
                else
                {
                    textBoxResult.Text = "Cannot apply changes to slack variables.";
                }
            }
            else
            {
                textBoxResult.Text = "Please select a basic variable to apply changes to.";
            }
        }

        private void ApplyChangeConstraint()
        {
            if (comboBoxConstraintRHS2.SelectedIndex >= 0)
            {
                int i = comboBoxConstraintRHS2.SelectedIndex;
                double gamma = (double)numericUpDownConstraint.Value;
                var (minGamma, maxGamma) = _ranges.GetRHSRange(i);
                if (gamma >= minGamma && gamma <= maxGamma)
                {
                    _model.Rhs[i] += gamma;

                    // Recalculate everything after the change
                    _tableau = _solver.Solve();
                    _ranges = new SensitivityRanges(_tableau);
                    LoadComboboxes(); // Reload comboboxes as basic/non-basic variables might change

                    textBoxResult.Text = $"Applied change to Constraint {i + 1}\nNew Objective Value: {_tableau.ObjectiveValue}\nUpdated RHS: {_model.Rhs[i]}";
                }
                else
                {
                    textBoxResult.Text = $"Change out of allowable range for Constraint {i + 1}!\nAllowable range: [{minGamma:F2}, {maxGamma:F2}]";
                }
            }
            else
            {
                textBoxResult.Text = "Please select a constraint to apply changes to.";
            }
        }

        private void ApplyChangeNBV()
        {
            if (comboBoxVarInNBV2.SelectedIndex >= 0 && comboBoxConstraintRHS2.SelectedIndex >= 0)
            {
                // Use the actual variable index from the second comboboxes
                int j = _nonBasicVarIndices[comboBoxVarInNBV2.SelectedIndex];
                int i = comboBoxConstraintRHS2.SelectedIndex;
                double delta = (double)numericUpDownNBV.Value;
                var (minDelta, maxDelta) = _ranges.GetMatrixCoefRange(i, j);
                if (delta >= minDelta && delta <= maxDelta)
                {
                    _model.ConstraintCoefficients[i][j] += delta;

                    // Recalculate everything after the change
                    _tableau = _solver.Solve();
                    _ranges = new SensitivityRanges(_tableau);
                    LoadComboboxes(); // Reload comboboxes as basic/non-basic variables might change

                    textBoxResult.Text = $"Applied change to x{j + 1} in Constraint {i + 1}\nNew Objective Value: {_tableau.ObjectiveValue}\nUpdated Coefficient: {_model.ConstraintCoefficients[i][j]}";
                }
                else
                {
                    textBoxResult.Text = $"Change out of allowable range for x{j + 1} in Constraint {i + 1}!\nAllowable range: [{minDelta:F2}, {maxDelta:F2}]";
                }
            }
            else
            {
                textBoxResult.Text = "Please select both a variable and constraint to apply changes to.";
            }
        }


    }
}

