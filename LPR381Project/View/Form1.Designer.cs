using System.Drawing;
using System.Windows.Forms;

namespace LPR381Project
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.permanentContent = new System.Windows.Forms.Panel();
            this.titleBar = new System.Windows.Forms.Panel();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Max = new System.Windows.Forms.Button();
            this.btn_Min = new System.Windows.Forms.Button();
            this.sideBar = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.line3 = new System.Windows.Forms.Label();
            this.line2 = new System.Windows.Forms.Label();
            this.line1 = new System.Windows.Forms.Label();
            this.LoadModel = new System.Windows.Forms.Button();
            this.PrimalSimplex = new System.Windows.Forms.Button();
            this.SensitivityAnalysis = new System.Windows.Forms.Button();
            this.RevisedPrimalSimplex = new System.Windows.Forms.Button();
            this.BranchBoundKnap = new System.Windows.Forms.Button();
            this.BranchAndBound = new System.Windows.Forms.Button();
            this.CuttingPlane = new System.Windows.Forms.Button();
            this.rootLayout = new System.Windows.Forms.TableLayoutPanel();
            this.InputModelLbl = new System.Windows.Forms.Label();
            this.contentHost = new LPR381Project.RoundedPanel();
            this.roundedPanel1 = new LPR381Project.RoundedPanel();
            this.InputModelTxt1 = new LPR381Project.RoundedRichTextBox();
            this.InputLbl = new System.Windows.Forms.Label();
            this.InputModelTxt = new LPR381Project.RoundedRichTextBox();
            this.permanentContent.SuspendLayout();
            this.titleBar.SuspendLayout();
            this.sideBar.SuspendLayout();
            this.rootLayout.SuspendLayout();
            this.roundedPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // permanentContent
            // 
            this.permanentContent.Controls.Add(this.contentHost);
            this.permanentContent.Controls.Add(this.titleBar);
            this.permanentContent.Controls.Add(this.roundedPanel1);
            this.permanentContent.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.permanentContent.Location = new System.Drawing.Point(271, 3);
            this.permanentContent.Name = "permanentContent";
            this.permanentContent.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.permanentContent.Size = new System.Drawing.Size(926, 791);
            this.permanentContent.TabIndex = 1;
            this.permanentContent.Paint += new System.Windows.Forms.PaintEventHandler(this.contentHost_Paint);
            // 
            // titleBar
            // 
            this.titleBar.Controls.Add(this.btn_Close);
            this.titleBar.Controls.Add(this.btn_Max);
            this.titleBar.Controls.Add(this.btn_Min);
            this.titleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBar.Location = new System.Drawing.Point(2, 2);
            this.titleBar.Name = "titleBar";
            this.titleBar.Size = new System.Drawing.Size(922, 48);
            this.titleBar.TabIndex = 0;
            this.titleBar.Paint += new System.Windows.Forms.PaintEventHandler(this.titleBar_Paint);
            this.titleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseDown);
            // 
            // btn_Close
            // 
            this.btn_Close.Font = new System.Drawing.Font("Showcard Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.ForeColor = System.Drawing.Color.Black;
            this.btn_Close.Location = new System.Drawing.Point(873, 2);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(45, 45);
            this.btn_Close.TabIndex = 12;
            this.btn_Close.Text = "✕";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click_1);
            // 
            // btn_Max
            // 
            this.btn_Max.Font = new System.Drawing.Font("Showcard Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Max.ForeColor = System.Drawing.Color.Black;
            this.btn_Max.Location = new System.Drawing.Point(822, 2);
            this.btn_Max.Name = "btn_Max";
            this.btn_Max.Size = new System.Drawing.Size(45, 45);
            this.btn_Max.TabIndex = 11;
            this.btn_Max.Text = "▢";
            this.btn_Max.UseVisualStyleBackColor = true;
            this.btn_Max.Click += new System.EventHandler(this.btn_Max_Click_1);
            // 
            // btn_Min
            // 
            this.btn_Min.Font = new System.Drawing.Font("Showcard Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Min.ForeColor = System.Drawing.Color.Black;
            this.btn_Min.Location = new System.Drawing.Point(770, 2);
            this.btn_Min.Name = "btn_Min";
            this.btn_Min.Size = new System.Drawing.Size(45, 45);
            this.btn_Min.TabIndex = 10;
            this.btn_Min.Text = "—";
            this.btn_Min.UseVisualStyleBackColor = true;
            this.btn_Min.Click += new System.EventHandler(this.btn_Min_Click_1);
            // 
            // sideBar
            // 
            this.sideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.sideBar.Controls.Add(this.label1);
            this.sideBar.Controls.Add(this.line3);
            this.sideBar.Controls.Add(this.line2);
            this.sideBar.Controls.Add(this.line1);
            this.sideBar.Controls.Add(this.LoadModel);
            this.sideBar.Controls.Add(this.PrimalSimplex);
            this.sideBar.Controls.Add(this.SensitivityAnalysis);
            this.sideBar.Controls.Add(this.RevisedPrimalSimplex);
            this.sideBar.Controls.Add(this.BranchBoundKnap);
            this.sideBar.Controls.Add(this.BranchAndBound);
            this.sideBar.Controls.Add(this.CuttingPlane);
            this.sideBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sideBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.sideBar.Location = new System.Drawing.Point(3, 3);
            this.sideBar.Name = "sideBar";
            this.sideBar.Size = new System.Drawing.Size(262, 791);
            this.sideBar.TabIndex = 0;
            this.sideBar.Paint += new System.Windows.Forms.PaintEventHandler(this.sideBar_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(24, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 45);
            this.label1.TabIndex = 7;
            this.label1.Text = "LP/IP Solver";
            // 
            // line3
            // 
            this.line3.BackColor = System.Drawing.Color.Gray;
            this.line3.Location = new System.Drawing.Point(10, 80);
            this.line3.Name = "line3";
            this.line3.Size = new System.Drawing.Size(220, 2);
            this.line3.TabIndex = 13;
            // 
            // line2
            // 
            this.line2.BackColor = System.Drawing.Color.Gray;
            this.line2.Location = new System.Drawing.Point(9, 692);
            this.line2.Name = "line2";
            this.line2.Size = new System.Drawing.Size(220, 2);
            this.line2.TabIndex = 12;
            // 
            // line1
            // 
            this.line1.BackColor = System.Drawing.Color.Gray;
            this.line1.Location = new System.Drawing.Point(10, 568);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(220, 2);
            this.line1.TabIndex = 11;
            // 
            // LoadModel
            // 
            this.LoadModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.LoadModel.FlatAppearance.BorderSize = 0;
            this.LoadModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadModel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadModel.ForeColor = System.Drawing.Color.White;
            this.LoadModel.Location = new System.Drawing.Point(9, 715);
            this.LoadModel.Name = "LoadModel";
            this.LoadModel.Size = new System.Drawing.Size(240, 45);
            this.LoadModel.TabIndex = 6;
            this.LoadModel.Text = "Load Model File";
            this.LoadModel.UseVisualStyleBackColor = false;
            this.LoadModel.Click += new System.EventHandler(this.LoadModel_Click);
            // 
            // PrimalSimplex
            // 
            this.PrimalSimplex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.PrimalSimplex.FlatAppearance.BorderSize = 0;
            this.PrimalSimplex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PrimalSimplex.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrimalSimplex.ForeColor = System.Drawing.Color.White;
            this.PrimalSimplex.Location = new System.Drawing.Point(9, 129);
            this.PrimalSimplex.Name = "PrimalSimplex";
            this.PrimalSimplex.Size = new System.Drawing.Size(240, 45);
            this.PrimalSimplex.TabIndex = 0;
            this.PrimalSimplex.Text = "Primal Simplex";
            this.PrimalSimplex.UseVisualStyleBackColor = false;
            this.PrimalSimplex.Click += new System.EventHandler(this.PrimalSimplex_Click);
            // 
            // SensitivityAnalysis
            // 
            this.SensitivityAnalysis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.SensitivityAnalysis.FlatAppearance.BorderSize = 0;
            this.SensitivityAnalysis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SensitivityAnalysis.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SensitivityAnalysis.ForeColor = System.Drawing.Color.White;
            this.SensitivityAnalysis.Location = new System.Drawing.Point(9, 586);
            this.SensitivityAnalysis.Name = "SensitivityAnalysis";
            this.SensitivityAnalysis.Size = new System.Drawing.Size(240, 45);
            this.SensitivityAnalysis.TabIndex = 5;
            this.SensitivityAnalysis.Text = "Sensitivity Analysis";
            this.SensitivityAnalysis.UseVisualStyleBackColor = false;
            this.SensitivityAnalysis.Click += new System.EventHandler(this.SensitivityAnalysis_Click);
            // 
            // RevisedPrimalSimplex
            // 
            this.RevisedPrimalSimplex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.RevisedPrimalSimplex.FlatAppearance.BorderSize = 0;
            this.RevisedPrimalSimplex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RevisedPrimalSimplex.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RevisedPrimalSimplex.ForeColor = System.Drawing.Color.White;
            this.RevisedPrimalSimplex.Location = new System.Drawing.Point(9, 205);
            this.RevisedPrimalSimplex.Name = "RevisedPrimalSimplex";
            this.RevisedPrimalSimplex.Size = new System.Drawing.Size(240, 97);
            this.RevisedPrimalSimplex.TabIndex = 1;
            this.RevisedPrimalSimplex.Text = "Revised Primal Simplex";
            this.RevisedPrimalSimplex.UseVisualStyleBackColor = false;
            this.RevisedPrimalSimplex.Click += new System.EventHandler(this.RevisedPrimalSimplex_Click);
            // 
            // BranchBoundKnap
            // 
            this.BranchBoundKnap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.BranchBoundKnap.FlatAppearance.BorderSize = 0;
            this.BranchBoundKnap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BranchBoundKnap.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BranchBoundKnap.ForeColor = System.Drawing.Color.White;
            this.BranchBoundKnap.Location = new System.Drawing.Point(9, 458);
            this.BranchBoundKnap.Name = "BranchBoundKnap";
            this.BranchBoundKnap.Size = new System.Drawing.Size(240, 75);
            this.BranchBoundKnap.TabIndex = 4;
            this.BranchBoundKnap.Text = "Branch and Bound Knapsack";
            this.BranchBoundKnap.UseVisualStyleBackColor = false;
            this.BranchBoundKnap.Click += new System.EventHandler(this.BranchBoundKnap_Click_1);
            // 
            // BranchAndBound
            // 
            this.BranchAndBound.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.BranchAndBound.FlatAppearance.BorderSize = 0;
            this.BranchAndBound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BranchAndBound.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BranchAndBound.ForeColor = System.Drawing.Color.White;
            this.BranchAndBound.Location = new System.Drawing.Point(9, 308);
            this.BranchAndBound.Name = "BranchAndBound";
            this.BranchAndBound.Size = new System.Drawing.Size(240, 45);
            this.BranchAndBound.TabIndex = 2;
            this.BranchAndBound.Text = "Branch and Bound";
            this.BranchAndBound.UseVisualStyleBackColor = false;
            this.BranchAndBound.Click += new System.EventHandler(this.BranchAndBound_Click);
            // 
            // CuttingPlane
            // 
            this.CuttingPlane.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.CuttingPlane.FlatAppearance.BorderSize = 0;
            this.CuttingPlane.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CuttingPlane.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CuttingPlane.ForeColor = System.Drawing.Color.White;
            this.CuttingPlane.Location = new System.Drawing.Point(9, 372);
            this.CuttingPlane.Name = "CuttingPlane";
            this.CuttingPlane.Size = new System.Drawing.Size(240, 45);
            this.CuttingPlane.TabIndex = 3;
            this.CuttingPlane.Text = "Cutting Plane";
            this.CuttingPlane.UseVisualStyleBackColor = false;
            this.CuttingPlane.Click += new System.EventHandler(this.CuttingPlane_Click_1);
            // 
            // rootLayout
            // 
            this.rootLayout.ColumnCount = 2;
            this.rootLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 268F));
            this.rootLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rootLayout.Controls.Add(this.sideBar, 0, 0);
            this.rootLayout.Controls.Add(this.permanentContent, 1, 0);
            this.rootLayout.Location = new System.Drawing.Point(-2, 2);
            this.rootLayout.Name = "rootLayout";
            this.rootLayout.RowCount = 1;
            this.rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 797F));
            this.rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 797F));
            this.rootLayout.Size = new System.Drawing.Size(1200, 797);
            this.rootLayout.TabIndex = 0;
            this.rootLayout.Paint += new System.Windows.Forms.PaintEventHandler(this.rootLayout_Paint);
            // 
            // InputModelLbl
            // 
            this.InputModelLbl.AutoSize = true;
            this.InputModelLbl.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputModelLbl.Location = new System.Drawing.Point(19, 11);
            this.InputModelLbl.Name = "InputModelLbl";
            this.InputModelLbl.Size = new System.Drawing.Size(180, 38);
            this.InputModelLbl.TabIndex = 1;
            this.InputModelLbl.Text = "Input Model";
            // 
            // contentHost
            // 
            this.contentHost.CornerRadius = 12;
            this.contentHost.Location = new System.Drawing.Point(0, 258);
            this.contentHost.Name = "contentHost";
            this.contentHost.Size = new System.Drawing.Size(920, 525);
            this.contentHost.TabIndex = 4;
            this.contentHost.Paint += new System.Windows.Forms.PaintEventHandler(this.contentHost_Paint_1);
            // 
            // roundedPanel1
            // 
            this.roundedPanel1.BackColor = System.Drawing.Color.White;
            this.roundedPanel1.Controls.Add(this.InputModelTxt1);
            this.roundedPanel1.Controls.Add(this.InputLbl);
            this.roundedPanel1.CornerRadius = 12;
            this.roundedPanel1.Location = new System.Drawing.Point(4, 55);
            this.roundedPanel1.Name = "roundedPanel1";
            this.roundedPanel1.Size = new System.Drawing.Size(903, 198);
            this.roundedPanel1.TabIndex = 3;
            this.roundedPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.roundedPanel1_Paint);
            // 
            // InputModelTxt1
            // 
            this.InputModelTxt1.BackColor = System.Drawing.SystemColors.Control;
            this.InputModelTxt1.BorderColor = System.Drawing.Color.LightGray;
            this.InputModelTxt1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InputModelTxt1.BorderThickness = 1;
            this.InputModelTxt1.CornerRadius = 12;
            this.InputModelTxt1.Location = new System.Drawing.Point(32, 52);
            this.InputModelTxt1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.InputModelTxt1.Name = "InputModelTxt1";
            this.InputModelTxt1.Size = new System.Drawing.Size(832, 118);
            this.InputModelTxt1.TabIndex = 1;
            this.InputModelTxt1.Text = "";
            this.InputModelTxt1.TextChanged += new System.EventHandler(this.roundedRichTextBox1_TextChanged);
            // 
            // InputLbl
            // 
            this.InputLbl.AutoSize = true;
            this.InputLbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputLbl.Location = new System.Drawing.Point(27, 23);
            this.InputLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.InputLbl.Name = "InputLbl";
            this.InputLbl.Size = new System.Drawing.Size(124, 23);
            this.InputLbl.TabIndex = 0;
            this.InputLbl.Text = "Input Model";
            // 
            // InputModelTxt
            // 
            this.InputModelTxt.BackColor = System.Drawing.SystemColors.Control;
            this.InputModelTxt.BorderColor = System.Drawing.Color.LightGray;
            this.InputModelTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InputModelTxt.BorderThickness = 1;
            this.InputModelTxt.CornerRadius = 12;
            this.InputModelTxt.Location = new System.Drawing.Point(26, 64);
            this.InputModelTxt.Name = "InputModelTxt";
            this.InputModelTxt.Size = new System.Drawing.Size(849, 96);
            this.InputModelTxt.TabIndex = 3;
            this.InputModelTxt.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1208, 805);
            this.Controls.Add(this.rootLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1200, 669);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.permanentContent.ResumeLayout(false);
            this.titleBar.ResumeLayout(false);
            this.sideBar.ResumeLayout(false);
            this.sideBar.PerformLayout();
            this.rootLayout.ResumeLayout(false);
            this.roundedPanel1.ResumeLayout(false);
            this.roundedPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel permanentContent;
        private Label InputModelLbl;
        private Panel titleBar;
        private Panel sideBar;
        private Label label1;
        private Label line3;
        private Label line2;
        private Label line1;
        private Button LoadModel;
        private Button PrimalSimplex;
        private Button SensitivityAnalysis;
        private Button RevisedPrimalSimplex;
        private Button BranchBoundKnap;
        private Button BranchAndBound;
        private Button CuttingPlane;
        private TableLayoutPanel rootLayout;
        private RoundedPanel roundedPanel1;
        private RoundedPanel contentHost;
        private RoundedRichTextBox InputModelTxt;
        private Button btn_Close;
        private Button btn_Max;
        private Button btn_Min;
        private RoundedRichTextBox InputModelTxt1;
        private Label InputLbl;
    }
}

