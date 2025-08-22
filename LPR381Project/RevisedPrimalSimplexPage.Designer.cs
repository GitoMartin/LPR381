namespace LPR381Project
{
    partial class RevisedPrimalSimplexPage
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
            this.contentHost = new LPR381Project.RoundedPanel();
            this.tiRTB = new LPR381Project.RoundedRichTextBox();
            this.canonicalRTB = new LPR381Project.RoundedRichTextBox();
            this.exportBtn = new LPR381Project.RoundedButton();
            this.btnSolve = new LPR381Project.RoundedButton();
            this.RevisedPrimalSimpAlgoLbl = new System.Windows.Forms.Label();
            this.CanonicalLbl = new System.Windows.Forms.Label();
            this.TabIterLbl = new System.Windows.Forms.Label();
            this.contentHost.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentHost
            // 
            this.contentHost.BackColor = System.Drawing.Color.White;
            this.contentHost.Controls.Add(this.tiRTB);
            this.contentHost.Controls.Add(this.canonicalRTB);
            this.contentHost.Controls.Add(this.exportBtn);
            this.contentHost.Controls.Add(this.btnSolve);
            this.contentHost.Controls.Add(this.RevisedPrimalSimpAlgoLbl);
            this.contentHost.Controls.Add(this.CanonicalLbl);
            this.contentHost.Controls.Add(this.TabIterLbl);
            this.contentHost.CornerRadius = 12;
            this.contentHost.Location = new System.Drawing.Point(22, 17);
            this.contentHost.Name = "contentHost";
            this.contentHost.Size = new System.Drawing.Size(890, 673);
            this.contentHost.TabIndex = 0;
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
            this.tiRTB.Text = " All product form and price out iterations will be displayed";
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
            this.btnSolve.Text = "Solve With Revised Primal Simplex";
            this.btnSolve.UseVisualStyleBackColor = false;
            // 
            // RevisedPrimalSimpAlgoLbl
            // 
            this.RevisedPrimalSimpAlgoLbl.AutoSize = true;
            this.RevisedPrimalSimpAlgoLbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RevisedPrimalSimpAlgoLbl.Location = new System.Drawing.Point(29, 10);
            this.RevisedPrimalSimpAlgoLbl.Name = "RevisedPrimalSimpAlgoLbl";
            this.RevisedPrimalSimpAlgoLbl.Size = new System.Drawing.Size(479, 32);
            this.RevisedPrimalSimpAlgoLbl.TabIndex = 11;
            this.RevisedPrimalSimpAlgoLbl.Text = "Revised Primal Simplex Algorithm";
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
            // TabIterLbl
            // 
            this.TabIterLbl.AutoSize = true;
            this.TabIterLbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabIterLbl.Location = new System.Drawing.Point(29, 351);
            this.TabIterLbl.Name = "TabIterLbl";
            this.TabIterLbl.Size = new System.Drawing.Size(536, 32);
            this.TabIterLbl.TabIndex = 13;
            this.TabIterLbl.Text = "Product Form and Price Out Iterations";
            // 
            // RevisedPrimalSimplexPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.contentHost);
            this.Name = "RevisedPrimalSimplexPage";
            this.Size = new System.Drawing.Size(1200, 724);
            this.Load += new System.EventHandler(this.RevisedPrimalSimplexPage_Load);
            this.contentHost.ResumeLayout(false);
            this.contentHost.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private RoundedPanel contentHost;
        private RoundedRichTextBox tiRTB;
        private RoundedRichTextBox canonicalRTB;
        private RoundedButton exportBtn;
        private RoundedButton btnSolve;
        private System.Windows.Forms.Label RevisedPrimalSimpAlgoLbl;
        private System.Windows.Forms.Label CanonicalLbl;
        private System.Windows.Forms.Label TabIterLbl;
    }
}
