namespace LPR381Project
{
    partial class BranchandBoundPage
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
            this.connectHost2 = new LPR381Project.RoundedPanel();
            this.BestCanLbl = new System.Windows.Forms.Label();
            this.bestCandidTxtb = new LPR381Project.RoundedRichTextBox();
            this.exportBtn = new LPR381Project.RoundedButton();
            this.tiRTB = new LPR381Project.RoundedRichTextBox();
            this.BTFRTB = new LPR381Project.RoundedRichTextBox();
            this.btnSolve = new LPR381Project.RoundedButton();
            this.BTaFLbl = new System.Windows.Forms.Label();
            this.SpTIlbl = new System.Windows.Forms.Label();
            this.BranchAndBoundLbl = new System.Windows.Forms.Label();
            this.connectHost2.SuspendLayout();
            this.SuspendLayout();
            // 
            // connectHost2
            // 
            this.connectHost2.AutoScroll = true;
            this.connectHost2.AutoSize = true;
            this.connectHost2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.connectHost2.BackColor = System.Drawing.Color.White;
            this.connectHost2.Controls.Add(this.BestCanLbl);
            this.connectHost2.Controls.Add(this.bestCandidTxtb);
            this.connectHost2.Controls.Add(this.exportBtn);
            this.connectHost2.Controls.Add(this.tiRTB);
            this.connectHost2.Controls.Add(this.BTFRTB);
            this.connectHost2.Controls.Add(this.btnSolve);
            this.connectHost2.Controls.Add(this.BTaFLbl);
            this.connectHost2.Controls.Add(this.SpTIlbl);
            this.connectHost2.Controls.Add(this.BranchAndBoundLbl);
            this.connectHost2.CornerRadius = 12;
            this.connectHost2.Location = new System.Drawing.Point(3, 29);
            this.connectHost2.Name = "connectHost2";
            this.connectHost2.Size = new System.Drawing.Size(882, 910);
            this.connectHost2.TabIndex = 0;
            this.connectHost2.Paint += new System.Windows.Forms.PaintEventHandler(this.connectHost2_Paint);
            // 
            // BestCanLbl
            // 
            this.BestCanLbl.AutoSize = true;
            this.BestCanLbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BestCanLbl.Location = new System.Drawing.Point(24, 603);
            this.BestCanLbl.Name = "BestCanLbl";
            this.BestCanLbl.Size = new System.Drawing.Size(226, 32);
            this.BestCanLbl.TabIndex = 24;
            this.BestCanLbl.Text = "Best Candidate";
            // 
            // bestCandidTxtb
            // 
            this.bestCandidTxtb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.bestCandidTxtb.BorderColor = System.Drawing.Color.LightGray;
            this.bestCandidTxtb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bestCandidTxtb.BorderThickness = 1;
            this.bestCandidTxtb.CornerRadius = 12;
            this.bestCandidTxtb.Font = new System.Drawing.Font("Cambria Math", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bestCandidTxtb.ForeColor = System.Drawing.Color.White;
            this.bestCandidTxtb.Location = new System.Drawing.Point(30, 653);
            this.bestCandidTxtb.Name = "bestCandidTxtb";
            this.bestCandidTxtb.Size = new System.Drawing.Size(849, 178);
            this.bestCandidTxtb.TabIndex = 23;
            this.bestCandidTxtb.Text = "  The best integer solution found will be displayed here...";
            this.bestCandidTxtb.TextChanged += new System.EventHandler(this.roundedRichTextBox1_TextChanged);
            // 
            // exportBtn
            // 
            this.exportBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.exportBtn.CornerRadius = 8;
            this.exportBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportBtn.ForeColor = System.Drawing.Color.White;
            this.exportBtn.Location = new System.Drawing.Point(88, 856);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(162, 51);
            this.exportBtn.TabIndex = 22;
            this.exportBtn.Text = "Export Results";
            this.exportBtn.UseVisualStyleBackColor = false;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
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
            this.tiRTB.Location = new System.Drawing.Point(30, 399);
            this.tiRTB.Name = "tiRTB";
            this.tiRTB.Size = new System.Drawing.Size(849, 161);
            this.tiRTB.TabIndex = 21;
            this.tiRTB.Text = "  Table iterations for sub-problems will be displayed here...\n";
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
            this.BTFRTB.Location = new System.Drawing.Point(30, 194);
            this.BTFRTB.Name = "BTFRTB";
            this.BTFRTB.Size = new System.Drawing.Size(849, 142);
            this.BTFRTB.TabIndex = 17;
            this.BTFRTB.Text = "Backtracking, sub-problems, and fathomed nodes will be displayed here...\n\n";
            // 
            // btnSolve
            // 
            this.btnSolve.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSolve.CornerRadius = 8;
            this.btnSolve.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSolve.ForeColor = System.Drawing.Color.White;
            this.btnSolve.Location = new System.Drawing.Point(30, 68);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(365, 47);
            this.btnSolve.TabIndex = 20;
            this.btnSolve.Text = "Solve With Branch And Bound Simplex";
            this.btnSolve.UseVisualStyleBackColor = false;
            // 
            // BTaFLbl
            // 
            this.BTaFLbl.AutoSize = true;
            this.BTaFLbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTaFLbl.Location = new System.Drawing.Point(24, 140);
            this.BTaFLbl.Name = "BTaFLbl";
            this.BTaFLbl.Size = new System.Drawing.Size(440, 32);
            this.BTaFLbl.TabIndex = 18;
            this.BTaFLbl.Text = "Branching Tree and Fathoming";
            // 
            // SpTIlbl
            // 
            this.SpTIlbl.AutoSize = true;
            this.SpTIlbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpTIlbl.Location = new System.Drawing.Point(24, 350);
            this.SpTIlbl.Name = "SpTIlbl";
            this.SpTIlbl.Size = new System.Drawing.Size(416, 32);
            this.SpTIlbl.TabIndex = 19;
            this.SpTIlbl.Text = "Sub-problem Table Iterations";
            // 
            // BranchAndBoundLbl
            // 
            this.BranchAndBoundLbl.AutoSize = true;
            this.BranchAndBoundLbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BranchAndBoundLbl.Location = new System.Drawing.Point(24, 11);
            this.BranchAndBoundLbl.Name = "BranchAndBoundLbl";
            this.BranchAndBoundLbl.Size = new System.Drawing.Size(531, 32);
            this.BranchAndBoundLbl.TabIndex = 12;
            this.BranchAndBoundLbl.Text = "Branch And Bound Simplex Algorithm";
            // 
            // BranchandBoundPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.connectHost2);
            this.Name = "BranchandBoundPage";
            this.Size = new System.Drawing.Size(888, 942);
            this.connectHost2.ResumeLayout(false);
            this.connectHost2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RoundedPanel connectHost2;
        private System.Windows.Forms.Label BranchAndBoundLbl;
        private RoundedRichTextBox bestCandidTxtb;
        private RoundedRichTextBox tiRTB;
        private RoundedRichTextBox BTFRTB;
        private RoundedButton exportBtn;
        private RoundedButton btnSolve;
        private System.Windows.Forms.Label BTaFLbl;
        private System.Windows.Forms.Label SpTIlbl;
        private System.Windows.Forms.Label BestCanLbl;
    }
}
