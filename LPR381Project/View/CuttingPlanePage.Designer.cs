namespace LPR381Project
{
    partial class CuttingPlanePage
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
            this.contentHost3 = new LPR381Project.RoundedPanel();
            this.roundedRichTextBox1 = new LPR381Project.RoundedRichTextBox();
            this.BTFRTB = new LPR381Project.RoundedRichTextBox();
            this.exportBtn = new LPR381Project.RoundedButton();
            this.btnSolve = new LPR381Project.RoundedButton();
            this.CuttingPlaneLbl = new System.Windows.Forms.Label();
            this.CanonicalLbl = new System.Windows.Forms.Label();
            this.ProdFormPOILbl = new System.Windows.Forms.Label();
            this.contentHost3.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentHost3
            // 
            this.contentHost3.AutoScroll = true;
            this.contentHost3.AutoSize = true;
            this.contentHost3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.contentHost3.BackColor = System.Drawing.Color.White;
            this.contentHost3.Controls.Add(this.roundedRichTextBox1);
            this.contentHost3.Controls.Add(this.BTFRTB);
            this.contentHost3.Controls.Add(this.exportBtn);
            this.contentHost3.Controls.Add(this.btnSolve);
            this.contentHost3.Controls.Add(this.CuttingPlaneLbl);
            this.contentHost3.Controls.Add(this.CanonicalLbl);
            this.contentHost3.Controls.Add(this.ProdFormPOILbl);
            this.contentHost3.CornerRadius = 12;
            this.contentHost3.Location = new System.Drawing.Point(2, 10);
            this.contentHost3.Margin = new System.Windows.Forms.Padding(2);
            this.contentHost3.Name = "contentHost3";
            this.contentHost3.Size = new System.Drawing.Size(632, 433);
            this.contentHost3.TabIndex = 1;
            this.contentHost3.Paint += new System.Windows.Forms.PaintEventHandler(this.contentHost3_Paint);
            // 
            // roundedRichTextBox1
            // 
            this.roundedRichTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.roundedRichTextBox1.BorderColor = System.Drawing.Color.LightGray;
            this.roundedRichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.roundedRichTextBox1.BorderThickness = 1;
            this.roundedRichTextBox1.CornerRadius = 12;
            this.roundedRichTextBox1.Font = new System.Drawing.Font("Cambria Math", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundedRichTextBox1.ForeColor = System.Drawing.Color.White;
            this.roundedRichTextBox1.Location = new System.Drawing.Point(13, 254);
            this.roundedRichTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.roundedRichTextBox1.Name = "roundedRichTextBox1";
            this.roundedRichTextBox1.Size = new System.Drawing.Size(613, 140);
            this.roundedRichTextBox1.TabIndex = 20;
            this.roundedRichTextBox1.Text = "Iterations and final";
            // 
            // BTFRTB
            // 
            this.BTFRTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.BTFRTB.BorderColor = System.Drawing.Color.LightGray;
            this.BTFRTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BTFRTB.BorderThickness = 1;
            this.BTFRTB.CornerRadius = 12;
            this.BTFRTB.Font = new System.Drawing.Font("Cambria Math", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTFRTB.ForeColor = System.Drawing.Color.White;
            this.BTFRTB.Location = new System.Drawing.Point(9, 114);
            this.BTFRTB.Margin = new System.Windows.Forms.Padding(2);
            this.BTFRTB.Name = "BTFRTB";
            this.BTFRTB.Size = new System.Drawing.Size(621, 94);
            this.BTFRTB.TabIndex = 19;
            this.BTFRTB.Text = "Canonical Form";
            // 
            // exportBtn
            // 
            this.exportBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.exportBtn.CornerRadius = 8;
            this.exportBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportBtn.ForeColor = System.Drawing.Color.White;
            this.exportBtn.Location = new System.Drawing.Point(51, 398);
            this.exportBtn.Margin = new System.Windows.Forms.Padding(2);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(108, 33);
            this.exportBtn.TabIndex = 16;
            this.exportBtn.Text = "Export Results";
            this.exportBtn.UseVisualStyleBackColor = false;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // btnSolve
            // 
            this.btnSolve.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSolve.CornerRadius = 8;
            this.btnSolve.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSolve.ForeColor = System.Drawing.Color.White;
            this.btnSolve.Location = new System.Drawing.Point(23, 43);
            this.btnSolve.Margin = new System.Windows.Forms.Padding(2);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(218, 31);
            this.btnSolve.TabIndex = 14;
            this.btnSolve.Text = "Solve With Cutting Plane Algorithm";
            this.btnSolve.UseVisualStyleBackColor = false;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // CuttingPlaneLbl
            // 
            this.CuttingPlaneLbl.AutoSize = true;
            this.CuttingPlaneLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CuttingPlaneLbl.Location = new System.Drawing.Point(19, 6);
            this.CuttingPlaneLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CuttingPlaneLbl.Name = "CuttingPlaneLbl";
            this.CuttingPlaneLbl.Size = new System.Drawing.Size(206, 24);
            this.CuttingPlaneLbl.TabIndex = 11;
            this.CuttingPlaneLbl.Text = "Cutting Plane Algorithm";
            // 
            // CanonicalLbl
            // 
            this.CanonicalLbl.AutoSize = true;
            this.CanonicalLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CanonicalLbl.Location = new System.Drawing.Point(19, 88);
            this.CanonicalLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CanonicalLbl.Name = "CanonicalLbl";
            this.CanonicalLbl.Size = new System.Drawing.Size(144, 24);
            this.CanonicalLbl.TabIndex = 12;
            this.CanonicalLbl.Text = "Canonical Form";
            // 
            // ProdFormPOILbl
            // 
            this.ProdFormPOILbl.AutoSize = true;
            this.ProdFormPOILbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProdFormPOILbl.Location = new System.Drawing.Point(19, 228);
            this.ProdFormPOILbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ProdFormPOILbl.Name = "ProdFormPOILbl";
            this.ProdFormPOILbl.Size = new System.Drawing.Size(416, 24);
            this.ProdFormPOILbl.TabIndex = 13;
            this.ProdFormPOILbl.Text = "Product Form and Price Out Iterations (with Cuts)";
            // 
            // CuttingPlanePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.contentHost3);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CuttingPlanePage";
            this.Size = new System.Drawing.Size(636, 445);
            this.Load += new System.EventHandler(this.CuttingPlanePage_Load);
            this.contentHost3.ResumeLayout(false);
            this.contentHost3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RoundedPanel contentHost3;
        private RoundedButton exportBtn;
        private RoundedButton btnSolve;
        private System.Windows.Forms.Label CuttingPlaneLbl;
        private System.Windows.Forms.Label CanonicalLbl;
        private System.Windows.Forms.Label ProdFormPOILbl;
        private RoundedRichTextBox BTFRTB;
        private RoundedRichTextBox roundedRichTextBox1;
    }
}
