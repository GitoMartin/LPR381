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
            this.tiRTB = new LPR381Project.RoundedRichTextBox();
            this.canonicalRTB = new LPR381Project.RoundedRichTextBox();
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
            this.contentHost3.Controls.Add(this.tiRTB);
            this.contentHost3.Controls.Add(this.canonicalRTB);
            this.contentHost3.Controls.Add(this.exportBtn);
            this.contentHost3.Controls.Add(this.btnSolve);
            this.contentHost3.Controls.Add(this.CuttingPlaneLbl);
            this.contentHost3.Controls.Add(this.CanonicalLbl);
            this.contentHost3.Controls.Add(this.ProdFormPOILbl);
            this.contentHost3.CornerRadius = 12;
            this.contentHost3.Location = new System.Drawing.Point(3, 15);
            this.contentHost3.Name = "contentHost3";
            this.contentHost3.Size = new System.Drawing.Size(842, 666);
            this.contentHost3.TabIndex = 1;
            this.contentHost3.Paint += new System.Windows.Forms.PaintEventHandler(this.contentHost3_Paint);
            // 
            // tiRTB
            // 
            this.tiRTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.tiRTB.BorderColor = System.Drawing.Color.LightGray;
            this.tiRTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tiRTB.BorderThickness = 1;
            this.tiRTB.CornerRadius = 12;
            this.tiRTB.Font = new System.Drawing.Font("Cambria Math", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiRTB.ForeColor = System.Drawing.Color.White;
            this.tiRTB.Location = new System.Drawing.Point(35, 406);
            this.tiRTB.Name = "tiRTB";
            this.tiRTB.Size = new System.Drawing.Size(804, 178);
            this.tiRTB.TabIndex = 15;
            this.tiRTB.Text = " Iterations including added cutting planes will be displayed here...";
            // 
            // canonicalRTB
            // 
            this.canonicalRTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.canonicalRTB.BorderColor = System.Drawing.Color.LightGray;
            this.canonicalRTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canonicalRTB.BorderThickness = 1;
            this.canonicalRTB.CornerRadius = 12;
            this.canonicalRTB.Font = new System.Drawing.Font("Cambria Math", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.canonicalRTB.ForeColor = System.Drawing.Color.White;
            this.canonicalRTB.Location = new System.Drawing.Point(35, 196);
            this.canonicalRTB.Name = "canonicalRTB";
            this.canonicalRTB.Size = new System.Drawing.Size(804, 142);
            this.canonicalRTB.TabIndex = 10;
            this.canonicalRTB.Text = "  Canonical Form will be displayed here... ";
            this.canonicalRTB.TextChanged += new System.EventHandler(this.canonicalRTB_TextChanged);
            // 
            // exportBtn
            // 
            this.exportBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.exportBtn.CornerRadius = 8;
            this.exportBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportBtn.ForeColor = System.Drawing.Color.White;
            this.exportBtn.Location = new System.Drawing.Point(76, 612);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(162, 51);
            this.exportBtn.TabIndex = 16;
            this.exportBtn.Text = "Export Results";
            this.exportBtn.UseVisualStyleBackColor = false;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // btnSolve
            // 
            this.btnSolve.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSolve.CornerRadius = 8;
            this.btnSolve.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSolve.ForeColor = System.Drawing.Color.White;
            this.btnSolve.Location = new System.Drawing.Point(35, 66);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(327, 47);
            this.btnSolve.TabIndex = 14;
            this.btnSolve.Text = "Solve With Cutting Plane Algorithm";
            this.btnSolve.UseVisualStyleBackColor = false;
            // 
            // CuttingPlaneLbl
            // 
            this.CuttingPlaneLbl.AutoSize = true;
            this.CuttingPlaneLbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CuttingPlaneLbl.Location = new System.Drawing.Point(29, 10);
            this.CuttingPlaneLbl.Name = "CuttingPlaneLbl";
            this.CuttingPlaneLbl.Size = new System.Drawing.Size(342, 32);
            this.CuttingPlaneLbl.TabIndex = 11;
            this.CuttingPlaneLbl.Text = "Cutting Plane Algorithm";
            // 
            // CanonicalLbl
            // 
            this.CanonicalLbl.AutoSize = true;
            this.CanonicalLbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CanonicalLbl.Location = new System.Drawing.Point(29, 136);
            this.CanonicalLbl.Name = "CanonicalLbl";
            this.CanonicalLbl.Size = new System.Drawing.Size(231, 32);
            this.CanonicalLbl.TabIndex = 12;
            this.CanonicalLbl.Text = "Canonical Form";
            // 
            // ProdFormPOILbl
            // 
            this.ProdFormPOILbl.AutoSize = true;
            this.ProdFormPOILbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProdFormPOILbl.Location = new System.Drawing.Point(29, 351);
            this.ProdFormPOILbl.Name = "ProdFormPOILbl";
            this.ProdFormPOILbl.Size = new System.Drawing.Size(691, 32);
            this.ProdFormPOILbl.TabIndex = 13;
            this.ProdFormPOILbl.Text = "Product Form and Price Out Iterations (with Cuts)";
            // 
            // CuttingPlanePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.contentHost3);
            this.Name = "CuttingPlanePage";
            this.Size = new System.Drawing.Size(848, 684);
            this.Load += new System.EventHandler(this.CuttingPlanePage_Load);
            this.contentHost3.ResumeLayout(false);
            this.contentHost3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RoundedPanel contentHost3;
        private RoundedRichTextBox tiRTB;
        private RoundedRichTextBox canonicalRTB;
        private RoundedButton exportBtn;
        private RoundedButton btnSolve;
        private System.Windows.Forms.Label CuttingPlaneLbl;
        private System.Windows.Forms.Label CanonicalLbl;
        private System.Windows.Forms.Label ProdFormPOILbl;
    }
}
