namespace LPR381Project
{
    partial class SensitivityAnalysis
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SensAnaTbl = new System.Windows.Forms.TableLayoutPanel();
            this.ApplyChangesPanel = new LPR381Project.RoundedPanel();
            this.textBoxResult = new LPR381Project.RoundedRichTextBox();
            this.numericUpDownNonBasic = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownNBV = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownConstraint = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownBasic = new System.Windows.Forms.NumericUpDown();
            this.buttonApplyNBV = new LPR381Project.RoundedButton();
            this.buttonApplyConstraint = new LPR381Project.RoundedButton();
            this.buttonApplyBasic = new LPR381Project.RoundedButton();
            this.buttonApplyNonBasic = new LPR381Project.RoundedButton();
            this.comboBoxBasicVar2 = new System.Windows.Forms.ComboBox();
            this.comboBoxConstraintRHS2 = new System.Windows.Forms.ComboBox();
            this.comboBoxVarInNBV2 = new System.Windows.Forms.ComboBox();
            this.comboBoxNonBasicVar2 = new System.Windows.Forms.ComboBox();
            this.applychangesLbl = new System.Windows.Forms.Label();
            this.DualityPanel = new LPR381Project.RoundedPanel();
            this.roundedRichTextBox3 = new LPR381Project.RoundedRichTextBox();
            this.shadowPricetxtb = new LPR381Project.RoundedRichTextBox();
            this.solveDualBtn = new LPR381Project.RoundedButton();
            this.dispShadPricBtn = new LPR381Project.RoundedButton();
            this.dualityLbl = new System.Windows.Forms.Label();
            this.AddNewElementsPanel = new LPR381Project.RoundedPanel();
            this.roundedButton5 = new LPR381Project.RoundedButton();
            this.roundedButton4 = new LPR381Project.RoundedButton();
            this.roundedRichTextBox2 = new LPR381Project.RoundedRichTextBox();
            this.addnewActtxtb = new LPR381Project.RoundedRichTextBox();
            this.addnewelLbl = new System.Windows.Forms.Label();
            this.RangeAnalysisPanel = new LPR381Project.RoundedPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonShowRangeNBV = new LPR381Project.RoundedButton();
            this.buttonShowRangeConstraint = new LPR381Project.RoundedButton();
            this.buttonShowRangeBasic = new LPR381Project.RoundedButton();
            this.buttonShowRangeNonBasic = new LPR381Project.RoundedButton();
            this.textBoxRangeResult = new LPR381Project.RoundedRichTextBox();
            this.comboBoxBasicVar = new System.Windows.Forms.ComboBox();
            this.comboBoxConstraintRHS = new System.Windows.Forms.ComboBox();
            this.comboBoxVarInNBV = new System.Windows.Forms.ComboBox();
            this.comboBoxNonBasicVar = new System.Windows.Forms.ComboBox();
            this.RangeAnaLbl = new System.Windows.Forms.Label();
            this.sensAnalbl = new System.Windows.Forms.Label();
            this.SensAnaTbl.SuspendLayout();
            this.ApplyChangesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNonBasic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNBV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownConstraint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBasic)).BeginInit();
            this.DualityPanel.SuspendLayout();
            this.AddNewElementsPanel.SuspendLayout();
            this.RangeAnalysisPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SensAnaTbl
            // 
            this.SensAnaTbl.ColumnCount = 2;
            this.SensAnaTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SensAnaTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SensAnaTbl.Controls.Add(this.ApplyChangesPanel, 1, 0);
            this.SensAnaTbl.Controls.Add(this.DualityPanel, 1, 1);
            this.SensAnaTbl.Controls.Add(this.AddNewElementsPanel, 0, 1);
            this.SensAnaTbl.Controls.Add(this.RangeAnalysisPanel, 0, 0);
            this.SensAnaTbl.Location = new System.Drawing.Point(16, 55);
            this.SensAnaTbl.Name = "SensAnaTbl";
            this.SensAnaTbl.RowCount = 2;
            this.SensAnaTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SensAnaTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SensAnaTbl.Size = new System.Drawing.Size(1098, 945);
            this.SensAnaTbl.TabIndex = 0;
            // 
            // ApplyChangesPanel
            // 
            this.ApplyChangesPanel.BackColor = System.Drawing.Color.White;
            this.ApplyChangesPanel.Controls.Add(this.textBoxResult);
            this.ApplyChangesPanel.Controls.Add(this.numericUpDownNonBasic);
            this.ApplyChangesPanel.Controls.Add(this.numericUpDownNBV);
            this.ApplyChangesPanel.Controls.Add(this.numericUpDownConstraint);
            this.ApplyChangesPanel.Controls.Add(this.numericUpDownBasic);
            this.ApplyChangesPanel.Controls.Add(this.buttonApplyNBV);
            this.ApplyChangesPanel.Controls.Add(this.buttonApplyConstraint);
            this.ApplyChangesPanel.Controls.Add(this.buttonApplyBasic);
            this.ApplyChangesPanel.Controls.Add(this.buttonApplyNonBasic);
            this.ApplyChangesPanel.Controls.Add(this.comboBoxBasicVar2);
            this.ApplyChangesPanel.Controls.Add(this.comboBoxConstraintRHS2);
            this.ApplyChangesPanel.Controls.Add(this.comboBoxVarInNBV2);
            this.ApplyChangesPanel.Controls.Add(this.comboBoxNonBasicVar2);
            this.ApplyChangesPanel.Controls.Add(this.applychangesLbl);
            this.ApplyChangesPanel.CornerRadius = 12;
            this.ApplyChangesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ApplyChangesPanel.Location = new System.Drawing.Point(552, 3);
            this.ApplyChangesPanel.Name = "ApplyChangesPanel";
            this.ApplyChangesPanel.Size = new System.Drawing.Size(543, 466);
            this.ApplyChangesPanel.TabIndex = 0;
            this.ApplyChangesPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ApplyChangesPanel_Paint);
            // 
            // textBoxResult
            // 
            this.textBoxResult.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxResult.BorderColor = System.Drawing.Color.LightGray;
            this.textBoxResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxResult.BorderThickness = 1;
            this.textBoxResult.CornerRadius = 12;
            this.textBoxResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxResult.ForeColor = System.Drawing.Color.Black;
            this.textBoxResult.Location = new System.Drawing.Point(24, 342);
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(452, 106);
            this.textBoxResult.TabIndex = 31;
            this.textBoxResult.Text = "  Apply Result...";
            // 
            // numericUpDownNonBasic
            // 
            this.numericUpDownNonBasic.ForeColor = System.Drawing.Color.Silver;
            this.numericUpDownNonBasic.Location = new System.Drawing.Point(303, 103);
            this.numericUpDownNonBasic.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownNonBasic.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericUpDownNonBasic.Name = "numericUpDownNonBasic";
            this.numericUpDownNonBasic.Size = new System.Drawing.Size(120, 26);
            this.numericUpDownNonBasic.TabIndex = 38;
            this.numericUpDownNonBasic.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDownNBV
            // 
            this.numericUpDownNBV.ForeColor = System.Drawing.Color.Silver;
            this.numericUpDownNBV.Location = new System.Drawing.Point(303, 305);
            this.numericUpDownNBV.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownNBV.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericUpDownNBV.Name = "numericUpDownNBV";
            this.numericUpDownNBV.Size = new System.Drawing.Size(120, 26);
            this.numericUpDownNBV.TabIndex = 37;
            this.numericUpDownNBV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDownConstraint
            // 
            this.numericUpDownConstraint.ForeColor = System.Drawing.Color.Silver;
            this.numericUpDownConstraint.Location = new System.Drawing.Point(303, 237);
            this.numericUpDownConstraint.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownConstraint.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericUpDownConstraint.Name = "numericUpDownConstraint";
            this.numericUpDownConstraint.Size = new System.Drawing.Size(120, 26);
            this.numericUpDownConstraint.TabIndex = 36;
            this.numericUpDownConstraint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDownBasic
            // 
            this.numericUpDownBasic.ForeColor = System.Drawing.Color.Silver;
            this.numericUpDownBasic.Location = new System.Drawing.Point(303, 177);
            this.numericUpDownBasic.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownBasic.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericUpDownBasic.Name = "numericUpDownBasic";
            this.numericUpDownBasic.Size = new System.Drawing.Size(120, 26);
            this.numericUpDownBasic.TabIndex = 35;
            this.numericUpDownBasic.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonApplyNBV
            // 
            this.buttonApplyNBV.BackColor = System.Drawing.Color.Orange;
            this.buttonApplyNBV.CornerRadius = 8;
            this.buttonApplyNBV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonApplyNBV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonApplyNBV.ForeColor = System.Drawing.Color.White;
            this.buttonApplyNBV.Location = new System.Drawing.Point(432, 292);
            this.buttonApplyNBV.Name = "buttonApplyNBV";
            this.buttonApplyNBV.Size = new System.Drawing.Size(93, 38);
            this.buttonApplyNBV.TabIndex = 33;
            this.buttonApplyNBV.Text = "Apply";
            this.buttonApplyNBV.UseVisualStyleBackColor = false;
            // 
            // buttonApplyConstraint
            // 
            this.buttonApplyConstraint.BackColor = System.Drawing.Color.Orange;
            this.buttonApplyConstraint.CornerRadius = 8;
            this.buttonApplyConstraint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonApplyConstraint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonApplyConstraint.ForeColor = System.Drawing.Color.White;
            this.buttonApplyConstraint.Location = new System.Drawing.Point(432, 229);
            this.buttonApplyConstraint.Name = "buttonApplyConstraint";
            this.buttonApplyConstraint.Size = new System.Drawing.Size(93, 38);
            this.buttonApplyConstraint.TabIndex = 32;
            this.buttonApplyConstraint.Text = "Apply";
            this.buttonApplyConstraint.UseVisualStyleBackColor = false;
            // 
            // buttonApplyBasic
            // 
            this.buttonApplyBasic.BackColor = System.Drawing.Color.Orange;
            this.buttonApplyBasic.CornerRadius = 8;
            this.buttonApplyBasic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonApplyBasic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonApplyBasic.ForeColor = System.Drawing.Color.White;
            this.buttonApplyBasic.Location = new System.Drawing.Point(432, 171);
            this.buttonApplyBasic.Name = "buttonApplyBasic";
            this.buttonApplyBasic.Size = new System.Drawing.Size(93, 38);
            this.buttonApplyBasic.TabIndex = 31;
            this.buttonApplyBasic.Text = "Apply";
            this.buttonApplyBasic.UseVisualStyleBackColor = false;
            // 
            // buttonApplyNonBasic
            // 
            this.buttonApplyNonBasic.BackColor = System.Drawing.Color.Orange;
            this.buttonApplyNonBasic.CornerRadius = 8;
            this.buttonApplyNonBasic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonApplyNonBasic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonApplyNonBasic.ForeColor = System.Drawing.Color.White;
            this.buttonApplyNonBasic.Location = new System.Drawing.Point(432, 95);
            this.buttonApplyNonBasic.Name = "buttonApplyNonBasic";
            this.buttonApplyNonBasic.Size = new System.Drawing.Size(93, 38);
            this.buttonApplyNonBasic.TabIndex = 27;
            this.buttonApplyNonBasic.Text = "Apply";
            this.buttonApplyNonBasic.UseVisualStyleBackColor = false;
            // 
            // comboBoxBasicVar2
            // 
            this.comboBoxBasicVar2.FormattingEnabled = true;
            this.comboBoxBasicVar2.Location = new System.Drawing.Point(26, 171);
            this.comboBoxBasicVar2.Name = "comboBoxBasicVar2";
            this.comboBoxBasicVar2.Size = new System.Drawing.Size(258, 28);
            this.comboBoxBasicVar2.TabIndex = 30;
            this.comboBoxBasicVar2.Text = "Select Basic Var";
            // 
            // comboBoxConstraintRHS2
            // 
            this.comboBoxConstraintRHS2.FormattingEnabled = true;
            this.comboBoxConstraintRHS2.Location = new System.Drawing.Point(26, 235);
            this.comboBoxConstraintRHS2.Name = "comboBoxConstraintRHS2";
            this.comboBoxConstraintRHS2.Size = new System.Drawing.Size(258, 28);
            this.comboBoxConstraintRHS2.TabIndex = 29;
            this.comboBoxConstraintRHS2.Text = "Select Constraint RHS";
            // 
            // comboBoxVarInNBV2
            // 
            this.comboBoxVarInNBV2.FormattingEnabled = true;
            this.comboBoxVarInNBV2.Location = new System.Drawing.Point(26, 298);
            this.comboBoxVarInNBV2.Name = "comboBoxVarInNBV2";
            this.comboBoxVarInNBV2.Size = new System.Drawing.Size(258, 28);
            this.comboBoxVarInNBV2.TabIndex = 28;
            this.comboBoxVarInNBV2.Text = "Select Variable in NBV column";
            // 
            // comboBoxNonBasicVar2
            // 
            this.comboBoxNonBasicVar2.FormattingEnabled = true;
            this.comboBoxNonBasicVar2.Location = new System.Drawing.Point(26, 106);
            this.comboBoxNonBasicVar2.Name = "comboBoxNonBasicVar2";
            this.comboBoxNonBasicVar2.Size = new System.Drawing.Size(258, 28);
            this.comboBoxNonBasicVar2.TabIndex = 27;
            this.comboBoxNonBasicVar2.Text = "Select Non-Basic Var ";
            // 
            // applychangesLbl
            // 
            this.applychangesLbl.AutoSize = true;
            this.applychangesLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applychangesLbl.Location = new System.Drawing.Point(20, 15);
            this.applychangesLbl.Name = "applychangesLbl";
            this.applychangesLbl.Size = new System.Drawing.Size(160, 26);
            this.applychangesLbl.TabIndex = 0;
            this.applychangesLbl.Text = "Apply Changes";
            // 
            // DualityPanel
            // 
            this.DualityPanel.BackColor = System.Drawing.Color.White;
            this.DualityPanel.Controls.Add(this.roundedRichTextBox3);
            this.DualityPanel.Controls.Add(this.shadowPricetxtb);
            this.DualityPanel.Controls.Add(this.solveDualBtn);
            this.DualityPanel.Controls.Add(this.dispShadPricBtn);
            this.DualityPanel.Controls.Add(this.dualityLbl);
            this.DualityPanel.CornerRadius = 12;
            this.DualityPanel.Location = new System.Drawing.Point(552, 475);
            this.DualityPanel.Name = "DualityPanel";
            this.DualityPanel.Size = new System.Drawing.Size(543, 466);
            this.DualityPanel.TabIndex = 2;
            // 
            // roundedRichTextBox3
            // 
            this.roundedRichTextBox3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.roundedRichTextBox3.BorderColor = System.Drawing.Color.DarkGray;
            this.roundedRichTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.roundedRichTextBox3.BorderThickness = 1;
            this.roundedRichTextBox3.CornerRadius = 12;
            this.roundedRichTextBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundedRichTextBox3.ForeColor = System.Drawing.Color.Black;
            this.roundedRichTextBox3.Location = new System.Drawing.Point(38, 308);
            this.roundedRichTextBox3.Name = "roundedRichTextBox3";
            this.roundedRichTextBox3.Size = new System.Drawing.Size(474, 78);
            this.roundedRichTextBox3.TabIndex = 32;
            this.roundedRichTextBox3.Text = "  Duality Results";
            this.roundedRichTextBox3.TextChanged += new System.EventHandler(this.roundedRichTextBox3_TextChanged);
            // 
            // shadowPricetxtb
            // 
            this.shadowPricetxtb.BackColor = System.Drawing.Color.WhiteSmoke;
            this.shadowPricetxtb.BorderColor = System.Drawing.Color.DarkGray;
            this.shadowPricetxtb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.shadowPricetxtb.BorderThickness = 1;
            this.shadowPricetxtb.CornerRadius = 12;
            this.shadowPricetxtb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shadowPricetxtb.ForeColor = System.Drawing.Color.Black;
            this.shadowPricetxtb.Location = new System.Drawing.Point(38, 145);
            this.shadowPricetxtb.Name = "shadowPricetxtb";
            this.shadowPricetxtb.Size = new System.Drawing.Size(474, 78);
            this.shadowPricetxtb.TabIndex = 29;
            this.shadowPricetxtb.Text = "   Shadow Prices...";
            // 
            // solveDualBtn
            // 
            this.solveDualBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.solveDualBtn.CornerRadius = 8;
            this.solveDualBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solveDualBtn.ForeColor = System.Drawing.Color.White;
            this.solveDualBtn.Location = new System.Drawing.Point(38, 242);
            this.solveDualBtn.Name = "solveDualBtn";
            this.solveDualBtn.Size = new System.Drawing.Size(462, 51);
            this.solveDualBtn.TabIndex = 30;
            this.solveDualBtn.Text = "Solve Dual and Verify Duality";
            this.solveDualBtn.UseVisualStyleBackColor = false;
            this.solveDualBtn.Click += new System.EventHandler(this.solveDualBtn_Click);
            // 
            // dispShadPricBtn
            // 
            this.dispShadPricBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.dispShadPricBtn.CornerRadius = 8;
            this.dispShadPricBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dispShadPricBtn.ForeColor = System.Drawing.Color.White;
            this.dispShadPricBtn.Location = new System.Drawing.Point(38, 88);
            this.dispShadPricBtn.Name = "dispShadPricBtn";
            this.dispShadPricBtn.Size = new System.Drawing.Size(474, 51);
            this.dispShadPricBtn.TabIndex = 29;
            this.dispShadPricBtn.Text = "Display Shadow Prices";
            this.dispShadPricBtn.UseVisualStyleBackColor = false;
            this.dispShadPricBtn.Click += new System.EventHandler(this.dispShadPricBtn_Click);
            // 
            // dualityLbl
            // 
            this.dualityLbl.AutoSize = true;
            this.dualityLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dualityLbl.Location = new System.Drawing.Point(20, 18);
            this.dualityLbl.Name = "dualityLbl";
            this.dualityLbl.Size = new System.Drawing.Size(79, 26);
            this.dualityLbl.TabIndex = 2;
            this.dualityLbl.Text = "Duality";
            // 
            // AddNewElementsPanel
            // 
            this.AddNewElementsPanel.BackColor = System.Drawing.Color.White;
            this.AddNewElementsPanel.Controls.Add(this.roundedButton5);
            this.AddNewElementsPanel.Controls.Add(this.roundedButton4);
            this.AddNewElementsPanel.Controls.Add(this.roundedRichTextBox2);
            this.AddNewElementsPanel.Controls.Add(this.addnewActtxtb);
            this.AddNewElementsPanel.Controls.Add(this.addnewelLbl);
            this.AddNewElementsPanel.CornerRadius = 12;
            this.AddNewElementsPanel.Location = new System.Drawing.Point(3, 475);
            this.AddNewElementsPanel.Name = "AddNewElementsPanel";
            this.AddNewElementsPanel.Size = new System.Drawing.Size(543, 466);
            this.AddNewElementsPanel.TabIndex = 3;
            // 
            // roundedButton5
            // 
            this.roundedButton5.BackColor = System.Drawing.Color.DodgerBlue;
            this.roundedButton5.CornerRadius = 8;
            this.roundedButton5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundedButton5.ForeColor = System.Drawing.Color.White;
            this.roundedButton5.Location = new System.Drawing.Point(54, 349);
            this.roundedButton5.Name = "roundedButton5";
            this.roundedButton5.Size = new System.Drawing.Size(186, 52);
            this.roundedButton5.TabIndex = 28;
            this.roundedButton5.Text = "Add new Constraint";
            this.roundedButton5.UseVisualStyleBackColor = false;
            this.roundedButton5.Click += new System.EventHandler(this.roundedButton5_Click);
            // 
            // roundedButton4
            // 
            this.roundedButton4.BackColor = System.Drawing.Color.DodgerBlue;
            this.roundedButton4.CornerRadius = 8;
            this.roundedButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundedButton4.ForeColor = System.Drawing.Color.White;
            this.roundedButton4.Location = new System.Drawing.Point(54, 160);
            this.roundedButton4.Name = "roundedButton4";
            this.roundedButton4.Size = new System.Drawing.Size(158, 51);
            this.roundedButton4.TabIndex = 27;
            this.roundedButton4.Text = "Add new Activity";
            this.roundedButton4.UseVisualStyleBackColor = false;
            this.roundedButton4.Click += new System.EventHandler(this.roundedButton4_Click);
            // 
            // roundedRichTextBox2
            // 
            this.roundedRichTextBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.roundedRichTextBox2.BorderColor = System.Drawing.Color.DarkGray;
            this.roundedRichTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.roundedRichTextBox2.BorderThickness = 1;
            this.roundedRichTextBox2.CornerRadius = 12;
            this.roundedRichTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundedRichTextBox2.ForeColor = System.Drawing.Color.Black;
            this.roundedRichTextBox2.Location = new System.Drawing.Point(45, 217);
            this.roundedRichTextBox2.Name = "roundedRichTextBox2";
            this.roundedRichTextBox2.Size = new System.Drawing.Size(471, 105);
            this.roundedRichTextBox2.TabIndex = 10;
            this.roundedRichTextBox2.Text = "  New constraint coefficients, relation, RHS...";
            // 
            // addnewActtxtb
            // 
            this.addnewActtxtb.BackColor = System.Drawing.Color.WhiteSmoke;
            this.addnewActtxtb.BorderColor = System.Drawing.Color.DarkGray;
            this.addnewActtxtb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.addnewActtxtb.BorderThickness = 1;
            this.addnewActtxtb.CornerRadius = 12;
            this.addnewActtxtb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addnewActtxtb.ForeColor = System.Drawing.Color.Black;
            this.addnewActtxtb.Location = new System.Drawing.Point(45, 49);
            this.addnewActtxtb.Name = "addnewActtxtb";
            this.addnewActtxtb.Size = new System.Drawing.Size(471, 105);
            this.addnewActtxtb.TabIndex = 9;
            this.addnewActtxtb.Text = "  New actvity coefficients";
            // 
            // addnewelLbl
            // 
            this.addnewelLbl.AutoSize = true;
            this.addnewelLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addnewelLbl.Location = new System.Drawing.Point(14, 18);
            this.addnewelLbl.Name = "addnewelLbl";
            this.addnewelLbl.Size = new System.Drawing.Size(199, 26);
            this.addnewelLbl.TabIndex = 1;
            this.addnewelLbl.Text = "Add New Elements";
            // 
            // RangeAnalysisPanel
            // 
            this.RangeAnalysisPanel.BackColor = System.Drawing.Color.White;
            this.RangeAnalysisPanel.Controls.Add(this.label4);
            this.RangeAnalysisPanel.Controls.Add(this.label3);
            this.RangeAnalysisPanel.Controls.Add(this.label2);
            this.RangeAnalysisPanel.Controls.Add(this.label1);
            this.RangeAnalysisPanel.Controls.Add(this.buttonShowRangeNBV);
            this.RangeAnalysisPanel.Controls.Add(this.buttonShowRangeConstraint);
            this.RangeAnalysisPanel.Controls.Add(this.buttonShowRangeBasic);
            this.RangeAnalysisPanel.Controls.Add(this.buttonShowRangeNonBasic);
            this.RangeAnalysisPanel.Controls.Add(this.textBoxRangeResult);
            this.RangeAnalysisPanel.Controls.Add(this.comboBoxBasicVar);
            this.RangeAnalysisPanel.Controls.Add(this.comboBoxConstraintRHS);
            this.RangeAnalysisPanel.Controls.Add(this.comboBoxVarInNBV);
            this.RangeAnalysisPanel.Controls.Add(this.comboBoxNonBasicVar);
            this.RangeAnalysisPanel.Controls.Add(this.RangeAnaLbl);
            this.RangeAnalysisPanel.CornerRadius = 12;
            this.RangeAnalysisPanel.Location = new System.Drawing.Point(3, 3);
            this.RangeAnalysisPanel.Name = "RangeAnalysisPanel";
            this.RangeAnalysisPanel.Size = new System.Drawing.Size(543, 466);
            this.RangeAnalysisPanel.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 248);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(224, 20);
            this.label4.TabIndex = 30;
            this.label4.Text = "Select Variable in NBV column";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 183);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 20);
            this.label3.TabIndex = 29;
            this.label3.Text = "Select Constraint RHS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 114);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 20);
            this.label2.TabIndex = 28;
            this.label2.Text = "Select Basic Var ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 20);
            this.label1.TabIndex = 27;
            this.label1.Text = "Select Non-Basic Var ";
            // 
            // buttonShowRangeNBV
            // 
            this.buttonShowRangeNBV.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonShowRangeNBV.CornerRadius = 8;
            this.buttonShowRangeNBV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowRangeNBV.ForeColor = System.Drawing.Color.White;
            this.buttonShowRangeNBV.Location = new System.Drawing.Point(418, 265);
            this.buttonShowRangeNBV.Name = "buttonShowRangeNBV";
            this.buttonShowRangeNBV.Size = new System.Drawing.Size(124, 38);
            this.buttonShowRangeNBV.TabIndex = 26;
            this.buttonShowRangeNBV.Text = "Show Range";
            this.buttonShowRangeNBV.UseVisualStyleBackColor = false;
            // 
            // buttonShowRangeConstraint
            // 
            this.buttonShowRangeConstraint.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonShowRangeConstraint.CornerRadius = 8;
            this.buttonShowRangeConstraint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowRangeConstraint.ForeColor = System.Drawing.Color.White;
            this.buttonShowRangeConstraint.Location = new System.Drawing.Point(418, 206);
            this.buttonShowRangeConstraint.Name = "buttonShowRangeConstraint";
            this.buttonShowRangeConstraint.Size = new System.Drawing.Size(124, 38);
            this.buttonShowRangeConstraint.TabIndex = 25;
            this.buttonShowRangeConstraint.Text = "Show Range";
            this.buttonShowRangeConstraint.UseVisualStyleBackColor = false;
            // 
            // buttonShowRangeBasic
            // 
            this.buttonShowRangeBasic.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonShowRangeBasic.CornerRadius = 8;
            this.buttonShowRangeBasic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowRangeBasic.ForeColor = System.Drawing.Color.White;
            this.buttonShowRangeBasic.Location = new System.Drawing.Point(418, 135);
            this.buttonShowRangeBasic.Name = "buttonShowRangeBasic";
            this.buttonShowRangeBasic.Size = new System.Drawing.Size(124, 38);
            this.buttonShowRangeBasic.TabIndex = 24;
            this.buttonShowRangeBasic.Text = "Show Range";
            this.buttonShowRangeBasic.UseVisualStyleBackColor = false;
            // 
            // buttonShowRangeNonBasic
            // 
            this.buttonShowRangeNonBasic.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonShowRangeNonBasic.CornerRadius = 8;
            this.buttonShowRangeNonBasic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowRangeNonBasic.ForeColor = System.Drawing.Color.White;
            this.buttonShowRangeNonBasic.Location = new System.Drawing.Point(416, 77);
            this.buttonShowRangeNonBasic.Name = "buttonShowRangeNonBasic";
            this.buttonShowRangeNonBasic.Size = new System.Drawing.Size(124, 38);
            this.buttonShowRangeNonBasic.TabIndex = 23;
            this.buttonShowRangeNonBasic.Text = "Show Range";
            this.buttonShowRangeNonBasic.UseVisualStyleBackColor = false;
            // 
            // textBoxRangeResult
            // 
            this.textBoxRangeResult.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxRangeResult.BorderColor = System.Drawing.Color.LightGray;
            this.textBoxRangeResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxRangeResult.BorderThickness = 1;
            this.textBoxRangeResult.CornerRadius = 12;
            this.textBoxRangeResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRangeResult.ForeColor = System.Drawing.Color.Black;
            this.textBoxRangeResult.Location = new System.Drawing.Point(18, 323);
            this.textBoxRangeResult.Name = "textBoxRangeResult";
            this.textBoxRangeResult.Size = new System.Drawing.Size(498, 120);
            this.textBoxRangeResult.TabIndex = 0;
            this.textBoxRangeResult.Text = "  Range Result...";
            // 
            // comboBoxBasicVar
            // 
            this.comboBoxBasicVar.FormattingEnabled = true;
            this.comboBoxBasicVar.Location = new System.Drawing.Point(18, 142);
            this.comboBoxBasicVar.Name = "comboBoxBasicVar";
            this.comboBoxBasicVar.Size = new System.Drawing.Size(384, 28);
            this.comboBoxBasicVar.TabIndex = 4;
            this.comboBoxBasicVar.Text = "Select Basic Var";
            // 
            // comboBoxConstraintRHS
            // 
            this.comboBoxConstraintRHS.FormattingEnabled = true;
            this.comboBoxConstraintRHS.Location = new System.Drawing.Point(18, 206);
            this.comboBoxConstraintRHS.Name = "comboBoxConstraintRHS";
            this.comboBoxConstraintRHS.Size = new System.Drawing.Size(384, 28);
            this.comboBoxConstraintRHS.TabIndex = 3;
            this.comboBoxConstraintRHS.Text = "Select Constraint RHS";
            // 
            // comboBoxVarInNBV
            // 
            this.comboBoxVarInNBV.FormattingEnabled = true;
            this.comboBoxVarInNBV.Location = new System.Drawing.Point(18, 271);
            this.comboBoxVarInNBV.Name = "comboBoxVarInNBV";
            this.comboBoxVarInNBV.Size = new System.Drawing.Size(384, 28);
            this.comboBoxVarInNBV.TabIndex = 2;
            this.comboBoxVarInNBV.Text = "Select Variable in NBV column";
            // 
            // comboBoxNonBasicVar
            // 
            this.comboBoxNonBasicVar.FormattingEnabled = true;
            this.comboBoxNonBasicVar.Location = new System.Drawing.Point(18, 77);
            this.comboBoxNonBasicVar.Name = "comboBoxNonBasicVar";
            this.comboBoxNonBasicVar.Size = new System.Drawing.Size(384, 28);
            this.comboBoxNonBasicVar.TabIndex = 1;
            this.comboBoxNonBasicVar.Text = "Select Non-Basic Var ";
            // 
            // RangeAnaLbl
            // 
            this.RangeAnaLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RangeAnaLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RangeAnaLbl.Location = new System.Drawing.Point(14, 15);
            this.RangeAnaLbl.Name = "RangeAnaLbl";
            this.RangeAnaLbl.Size = new System.Drawing.Size(198, 34);
            this.RangeAnaLbl.TabIndex = 0;
            this.RangeAnaLbl.Text = "Range Analysis";
            // 
            // sensAnalbl
            // 
            this.sensAnalbl.AutoSize = true;
            this.sensAnalbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sensAnalbl.ForeColor = System.Drawing.Color.Black;
            this.sensAnalbl.Location = new System.Drawing.Point(12, 15);
            this.sensAnalbl.Name = "sensAnalbl";
            this.sensAnalbl.Size = new System.Drawing.Size(199, 26);
            this.sensAnalbl.TabIndex = 1;
            this.sensAnalbl.Text = "Sensitivity Analysis";
            // 
            // SensitivityAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.sensAnalbl);
            this.Controls.Add(this.SensAnaTbl);
            this.Name = "SensitivityAnalysis";
            this.Size = new System.Drawing.Size(1117, 1003);
            this.SensAnaTbl.ResumeLayout(false);
            this.ApplyChangesPanel.ResumeLayout(false);
            this.ApplyChangesPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNonBasic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNBV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownConstraint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBasic)).EndInit();
            this.DualityPanel.ResumeLayout(false);
            this.DualityPanel.PerformLayout();
            this.AddNewElementsPanel.ResumeLayout(false);
            this.AddNewElementsPanel.PerformLayout();
            this.RangeAnalysisPanel.ResumeLayout(false);
            this.RangeAnalysisPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel SensAnaTbl;
        private RoundedPanel ApplyChangesPanel;
        private RoundedPanel RangeAnalysisPanel;
        private RoundedPanel DualityPanel;
        private RoundedPanel AddNewElementsPanel;
        private System.Windows.Forms.Label sensAnalbl;
        private System.Windows.Forms.Label dualityLbl;
        private System.Windows.Forms.Label applychangesLbl;
        private System.Windows.Forms.Label addnewelLbl;
        private System.Windows.Forms.Label RangeAnaLbl;
        private System.Windows.Forms.ComboBox comboBoxBasicVar;
        private System.Windows.Forms.ComboBox comboBoxConstraintRHS;
        private System.Windows.Forms.ComboBox comboBoxVarInNBV;
        private System.Windows.Forms.ComboBox comboBoxNonBasicVar;
        private RoundedRichTextBox textBoxRangeResult;
        private RoundedRichTextBox roundedRichTextBox2;
        private RoundedRichTextBox addnewActtxtb;
        private RoundedButton buttonShowRangeNonBasic;
        private RoundedButton buttonApplyNonBasic;
        private System.Windows.Forms.ComboBox comboBoxBasicVar2;
        private System.Windows.Forms.ComboBox comboBoxConstraintRHS2;
        private System.Windows.Forms.ComboBox comboBoxVarInNBV2;
        private System.Windows.Forms.ComboBox comboBoxNonBasicVar2;
        private RoundedButton buttonShowRangeNBV;
        private RoundedButton buttonShowRangeConstraint;
        private RoundedButton buttonShowRangeBasic;
        private System.Windows.Forms.NumericUpDown numericUpDownNBV;
        private System.Windows.Forms.NumericUpDown numericUpDownConstraint;
        private System.Windows.Forms.NumericUpDown numericUpDownBasic;
        private RoundedButton buttonApplyNBV;
        private RoundedButton buttonApplyConstraint;
        private RoundedButton buttonApplyBasic;
        private System.Windows.Forms.NumericUpDown numericUpDownNonBasic;
        private RoundedButton roundedButton4;
        private RoundedRichTextBox roundedRichTextBox3;
        private RoundedRichTextBox shadowPricetxtb;
        private RoundedButton solveDualBtn;
        private RoundedButton dispShadPricBtn;
        private RoundedButton roundedButton5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private RoundedRichTextBox textBoxResult;
    }
}
