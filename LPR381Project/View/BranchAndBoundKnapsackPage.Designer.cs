namespace LPR381Project
{
    partial class BranchAndBoundKnapsackPage
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
            this.tiListView = new System.Windows.Forms.ListView();
            this.BestCanLbl = new System.Windows.Forms.Label();
            this.BCRTB = new LPR381Project.RoundedRichTextBox();
            this.exportBtn = new LPR381Project.RoundedButton();
            this.btnSolve = new LPR381Project.RoundedButton();
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
            this.connectHost2.Controls.Add(this.tiListView);
            this.connectHost2.Controls.Add(this.BestCanLbl);
            this.connectHost2.Controls.Add(this.BCRTB);
            this.connectHost2.Controls.Add(this.exportBtn);
            this.connectHost2.Controls.Add(this.btnSolve);
            this.connectHost2.Controls.Add(this.SpTIlbl);
            this.connectHost2.Controls.Add(this.BranchAndBoundLbl);
            this.connectHost2.CornerRadius = 12;
            this.connectHost2.Location = new System.Drawing.Point(35, 22);
            this.connectHost2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.connectHost2.Name = "connectHost2";
            this.connectHost2.Size = new System.Drawing.Size(785, 728);
            this.connectHost2.TabIndex = 1;
            // 
            // tiListView
            // 
            this.tiListView.FullRowSelect = true;
            this.tiListView.GridLines = true;
            this.tiListView.HideSelection = false;
            this.tiListView.Location = new System.Drawing.Point(26, 157);
            this.tiListView.Name = "tiListView";
            this.tiListView.Size = new System.Drawing.Size(755, 322);
            this.tiListView.TabIndex = 25;
            this.tiListView.UseCompatibleStateImageBehavior = false;
            this.tiListView.View = System.Windows.Forms.View.Details;
            // 
            // BestCanLbl
            // 
            this.BestCanLbl.AutoSize = true;
            this.BestCanLbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BestCanLbl.Location = new System.Drawing.Point(21, 482);
            this.BestCanLbl.Name = "BestCanLbl";
            this.BestCanLbl.Size = new System.Drawing.Size(189, 28);
            this.BestCanLbl.TabIndex = 24;
            this.BestCanLbl.Text = "Best Candidate";
            // 
            // BCRTB
            // 
            this.BCRTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.BCRTB.BorderColor = System.Drawing.Color.LightGray;
            this.BCRTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BCRTB.BorderThickness = 1;
            this.BCRTB.CornerRadius = 12;
            this.BCRTB.Font = new System.Drawing.Font("Cambria Math", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCRTB.ForeColor = System.Drawing.Color.White;
            this.BCRTB.Location = new System.Drawing.Point(27, 522);
            this.BCRTB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BCRTB.Name = "BCRTB";
            this.BCRTB.Size = new System.Drawing.Size(755, 142);
            this.BCRTB.TabIndex = 23;
            this.BCRTB.Text = "  The best integer solution found will be displayed here...";
            // 
            // exportBtn
            // 
            this.exportBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.exportBtn.CornerRadius = 8;
            this.exportBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportBtn.ForeColor = System.Drawing.Color.White;
            this.exportBtn.Location = new System.Drawing.Point(78, 685);
            this.exportBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(144, 41);
            this.exportBtn.TabIndex = 22;
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
            this.btnSolve.Location = new System.Drawing.Point(27, 54);
            this.btnSolve.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(446, 38);
            this.btnSolve.TabIndex = 20;
            this.btnSolve.Text = "Solve With Branch And Bound Knapsack Algorithm";
            this.btnSolve.UseVisualStyleBackColor = false;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // SpTIlbl
            // 
            this.SpTIlbl.AutoSize = true;
            this.SpTIlbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpTIlbl.Location = new System.Drawing.Point(21, 116);
            this.SpTIlbl.Name = "SpTIlbl";
            this.SpTIlbl.Size = new System.Drawing.Size(412, 28);
            this.SpTIlbl.TabIndex = 19;
            this.SpTIlbl.Text = "Sub-problems and Table Iterations";
            // 
            // BranchAndBoundLbl
            // 
            this.BranchAndBoundLbl.AutoSize = true;
            this.BranchAndBoundLbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BranchAndBoundLbl.Location = new System.Drawing.Point(21, 9);
            this.BranchAndBoundLbl.Name = "BranchAndBoundLbl";
            this.BranchAndBoundLbl.Size = new System.Drawing.Size(470, 28);
            this.BranchAndBoundLbl.TabIndex = 12;
            this.BranchAndBoundLbl.Text = "Branch And Bound Knapsack Algorithm";
            // 
            // BranchAndBoundKnapsackPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.connectHost2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "BranchAndBoundKnapsackPage";
            this.Size = new System.Drawing.Size(823, 752);
            this.connectHost2.ResumeLayout(false);
            this.connectHost2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RoundedPanel connectHost2;
        private System.Windows.Forms.Label BestCanLbl;
        private RoundedRichTextBox BCRTB;
        private RoundedButton exportBtn;
        private RoundedButton btnSolve;
        private System.Windows.Forms.Label SpTIlbl;
        private System.Windows.Forms.Label BranchAndBoundLbl;
        private System.Windows.Forms.ListView tiListView;
    }
}
