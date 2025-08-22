namespace LPR381Project
{
    partial class PrimalSimplexControl
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
            this.roundedPanel1 = new LPR381Project.RoundedPanel();
            this.tiRTB = new LPR381Project.RoundedRichTextBox();
            this.canonicalRTB = new LPR381Project.RoundedRichTextBox();
            this.exportBtn = new LPR381Project.RoundedButton();
            this.btnSolve = new LPR381Project.RoundedButton();
            this.PrimalSimpAlgoLbl = new System.Windows.Forms.Label();
            this.CanonicalLbl = new System.Windows.Forms.Label();
            this.TabIterLbl = new System.Windows.Forms.Label();
            this.roundedPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // roundedPanel1
            // 
            this.roundedPanel1.BackColor = System.Drawing.Color.White;
            this.roundedPanel1.Controls.Add(this.tiRTB);
            this.roundedPanel1.Controls.Add(this.canonicalRTB);
            this.roundedPanel1.Controls.Add(this.exportBtn);
            this.roundedPanel1.Controls.Add(this.btnSolve);
            this.roundedPanel1.Controls.Add(this.PrimalSimpAlgoLbl);
            this.roundedPanel1.Controls.Add(this.CanonicalLbl);
            this.roundedPanel1.Controls.Add(this.TabIterLbl);
            this.roundedPanel1.CornerRadius = 12;
            this.roundedPanel1.Location = new System.Drawing.Point(20, 15);
            this.roundedPanel1.Name = "roundedPanel1";
            this.roundedPanel1.Size = new System.Drawing.Size(869, 673);
            this.roundedPanel1.TabIndex = 8;
            this.roundedPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.roundedPanel1_Paint);
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
            this.tiRTB.Location = new System.Drawing.Point(37, 413);
            this.tiRTB.Name = "tiRTB";
            this.tiRTB.Size = new System.Drawing.Size(804, 178);
            this.tiRTB.TabIndex = 9;
            this.tiRTB.Text = "  All Tableu Iterations will be displayed here...";
            this.tiRTB.TextChanged += new System.EventHandler(this.tiRTB_TextChanged);
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
            this.canonicalRTB.Location = new System.Drawing.Point(37, 203);
            this.canonicalRTB.Name = "canonicalRTB";
            this.canonicalRTB.Size = new System.Drawing.Size(804, 142);
            this.canonicalRTB.TabIndex = 0;
            this.canonicalRTB.Text = "  Canonical Form will be displayed here... ";
            this.canonicalRTB.TextChanged += new System.EventHandler(this.canonicalRTB_TextChanged);
            // 
            // exportBtn
            // 
            this.exportBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.exportBtn.CornerRadius = 8;
            this.exportBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportBtn.ForeColor = System.Drawing.Color.White;
            this.exportBtn.Location = new System.Drawing.Point(78, 619);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(162, 51);
            this.exportBtn.TabIndex = 9;
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
            this.btnSolve.Location = new System.Drawing.Point(37, 73);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(247, 47);
            this.btnSolve.TabIndex = 8;
            this.btnSolve.Text = "Solve With Primal Simplex";
            this.btnSolve.UseVisualStyleBackColor = false;
            // 
            // PrimalSimpAlgoLbl
            // 
            this.PrimalSimpAlgoLbl.AutoSize = true;
            this.PrimalSimpAlgoLbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrimalSimpAlgoLbl.Location = new System.Drawing.Point(31, 17);
            this.PrimalSimpAlgoLbl.Name = "PrimalSimpAlgoLbl";
            this.PrimalSimpAlgoLbl.Size = new System.Drawing.Size(362, 32);
            this.PrimalSimpAlgoLbl.TabIndex = 1;
            this.PrimalSimpAlgoLbl.Text = "Primal Simplex Algorithm";
            // 
            // CanonicalLbl
            // 
            this.CanonicalLbl.AutoSize = true;
            this.CanonicalLbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CanonicalLbl.Location = new System.Drawing.Point(31, 143);
            this.CanonicalLbl.Name = "CanonicalLbl";
            this.CanonicalLbl.Size = new System.Drawing.Size(231, 32);
            this.CanonicalLbl.TabIndex = 3;
            this.CanonicalLbl.Text = "Canonical Form";
            // 
            // TabIterLbl
            // 
            this.TabIterLbl.AutoSize = true;
            this.TabIterLbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabIterLbl.Location = new System.Drawing.Point(31, 358);
            this.TabIterLbl.Name = "TabIterLbl";
            this.TabIterLbl.Size = new System.Drawing.Size(248, 32);
            this.TabIterLbl.TabIndex = 5;
            this.TabIterLbl.Text = "Tableu Iterations";
            // 
            // PrimalSimplexControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.roundedPanel1);
            this.Name = "PrimalSimplexControl";
            this.Size = new System.Drawing.Size(1197, 691);
            this.Load += new System.EventHandler(this.PrimalSimplexControl_Load);
            this.roundedPanel1.ResumeLayout(false);
            this.roundedPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private RoundedPanel roundedPanel1;
        private System.Windows.Forms.Label PrimalSimpAlgoLbl;
        private System.Windows.Forms.Label CanonicalLbl;
        private System.Windows.Forms.Label TabIterLbl;
        private RoundedButton exportBtn;
        private RoundedButton btnSolve;
        private RoundedRichTextBox canonicalRTB;
        private RoundedRichTextBox tiRTB;
    }
}
