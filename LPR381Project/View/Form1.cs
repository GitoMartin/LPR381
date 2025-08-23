using Lpr381back;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;


namespace LPR381Project
{
    public partial class Form1 : Form
    {
        private Button activeButton = null;
        private Label _inputPlaceholderLabel;
        public static LPModel model;
        public Form1()
        {
            InitializeComponent();
            contentHost.AutoScroll = true;
            var primalControl = new PrimalSimplexControl(model);
            primalControl.Dock = DockStyle.Fill;
            contentHost.Controls.Clear();
            contentHost.Controls.Add(primalControl);

        }

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;


        private void Form1_Load(object sender, EventArgs e)
        {
            RoundButton(PrimalSimplex, 8);
            RoundButton(RevisedPrimalSimplex, 8);
            RoundButton(BranchAndBound, 8);
            RoundButton(CuttingPlane, 8);
            RoundButton(BranchBoundKnap, 8);
            RoundButton(SensitivityAnalysis, 8);
            RoundButton(LoadModel, 8);
            AddHoverEffect(PrimalSimplex);
            AddHoverEffect(RevisedPrimalSimplex);
            AddHoverEffect(BranchAndBound);
            AddHoverEffect(CuttingPlane);
            AddHoverEffect(BranchBoundKnap);
            AddHoverEffect(SensitivityAnalysis);

            SetActiveButton(PrimalSimplex);
            StyleLoadModelButton(LoadModel);

            StyleTitleBarButton(btn_Min, Color.LightGray);
            StyleTitleBarButton(btn_Max, Color.LightGray);
            StyleTitleBarButton(btn_Close, Color.Red);
            SetupCenteredPlaceholder();
        }

        private void RoundButton(Button btn, int radius = 10)
        {
            if (btn == null || btn.Width == 0 || btn.Height == 0) return;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(btn.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(btn.Width - radius, btn.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, btn.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            btn.Region = new Region(path);
        }

        private void SetActiveButton(Button btn)
        {
            // reset previous
            if (activeButton != null)
            {
                activeButton.BackColor = Color.FromArgb(31, 41, 55); // dark sidebar
                activeButton.ForeColor = Color.White;
                activeButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            }

            // set new active
            activeButton = btn;
            activeButton.BackColor = Color.FromArgb(99, 102, 241); // purple
            activeButton.ForeColor = Color.White;
            activeButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        }

        private void AddHoverEffect(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;

            btn.MouseEnter += (s, e) =>
            {
                if (btn != activeButton)
                    btn.BackColor = Color.FromArgb(79, 70, 229); // hover purple
            };

            btn.MouseLeave += (s, e) =>
            {
                if (btn != activeButton)
                    btn.BackColor = Color.FromArgb(31, 41, 55); // reset
            };

            btn.Click += (s, e) => SetActiveButton(btn);
        }

        private void StyleLoadModelButton(Button btn)
        {
            btn.BackColor = Color.FromArgb(99, 102, 241); // purple
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;

            btn.MouseEnter += (s, e) =>
            {
                btn.BackColor = Color.FromArgb(67, 56, 202); // darker purple
            };

            btn.MouseLeave += (s, e) =>
            {
                btn.BackColor = Color.FromArgb(99, 102, 241); // reset purple
            };
        }

        private void btn_Min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_Max_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }


        private void btn_Close_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void StyleTitleBarButton(Button btn, Color hoverColor)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.FromArgb(255, 255,255);

            btn.MouseEnter += (s, e) => btn.BackColor = hoverColor;
            btn.MouseLeave += (s, e) => btn.BackColor = Color.FromArgb(255, 255, 255);
        }

        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int radius = 20;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            this.Region = new Region(path);
        }

        private void SetPlaceholder(RichTextBox txt, string placeholder)
        {
            txt.ForeColor = Color.Gray;
            txt.Text = placeholder;
            txt.SelectAll();
            txt.SelectionAlignment = HorizontalAlignment.Center;
            txt.DeselectAll();

            txt.GotFocus += (s, e) =>
            {
                if (txt.Text == placeholder)
                {
                    txt.Clear();
                    txt.ForeColor = Color.Black;
                    txt.SelectionAlignment = HorizontalAlignment.Left;
                }
            };

            txt.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Text = placeholder;
                    txt.ForeColor = Color.Gray;
                    txt.SelectAll();
                    txt.SelectionAlignment = HorizontalAlignment.Center;
                    txt.DeselectAll();
                }
            };
        }

        private void SetupCenteredPlaceholder()
        {
            _inputPlaceholderLabel = new Label
            {
                Text = "   Load a Model File or Paste its content here...",
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = false,
                BackColor = InputModelTxt1.BackColor,
                Visible = string.IsNullOrEmpty(InputModelTxt1.Text)
            };

            _inputPlaceholderLabel.Bounds = InputModelTxt1.Bounds;
            _inputPlaceholderLabel.Cursor = Cursors.IBeam;

            // put it on the same parent as the RTB, above it
            roundedPanel1.Controls.Add(_inputPlaceholderLabel);
            _inputPlaceholderLabel.BringToFront();

            // click on placeholder moves focus to RTB
            _inputPlaceholderLabel.Click += (s, e) => InputModelTxt1.Focus();

            // show/hide rules
            void sync()
            {
                _inputPlaceholderLabel.Visible = string.IsNullOrEmpty(InputModelTxt1.Text) && !InputModelTxt1.Focused;
                _inputPlaceholderLabel.Bounds = InputModelTxt1.Bounds; // keep in sync if resized
            }

            InputModelTxt1.TextChanged += (s, e) => sync();
            InputModelTxt1.GotFocus += (s, e) => sync();
            InputModelTxt1.LostFocus += (s, e) => sync();
            InputModelTxt1.Resize += (s, e) => sync();
        }


        private void rootLayout_Paint(object sender, PaintEventArgs e)
        {

        }

        private void contentHost_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sideBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void InputModelTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void titleBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void contentHost_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void RevisedPrimalSimplex_Click(object sender, EventArgs e)
        {
            contentHost.Controls.Clear();
            RevisedPrimalSimplexPage revisedPage = new RevisedPrimalSimplexPage(model);
            revisedPage.Dock = DockStyle.Fill;
            contentHost.Controls.Add(revisedPage);
        }

        private void PrimalSimplex_Click(object sender, EventArgs e)
        {
            contentHost.Controls.Clear();
            PrimalSimplexControl revisedPage = new PrimalSimplexControl(model);
            revisedPage.Dock = DockStyle.Fill;
            contentHost.Controls.Add(revisedPage);
        }

        private void BranchAndBound_Click(object sender, EventArgs e)
        {
            contentHost.Controls.Clear();
            BranchandBoundPage revisedPage = new BranchandBoundPage();
            revisedPage.Dock = DockStyle.Fill;
            contentHost.Controls.Add(revisedPage);
        }

        private void CuttingPlane_Click(object sender, EventArgs e)
        {
            contentHost.Controls.Clear();
            CuttingPlanePage revisedPage = new CuttingPlanePage();
            revisedPage.Dock = DockStyle.Fill;
            contentHost.Controls.Add(revisedPage);
        }

        private void BranchBoundKnap_Click(object sender, EventArgs e)
        {
            contentHost.Controls.Clear();
            BranchAndBoundKnapsackPage revisedPage = new BranchAndBoundKnapsackPage(model);
            revisedPage.Dock = DockStyle.Fill;
            contentHost.Controls.Add(revisedPage);
        }

        private void roundedPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void roundedRichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void SensitivityAnalysis_Click(object sender, EventArgs e)
        {
            contentHost.Controls.Clear();
            SensitivityAnalysis saPage = new SensitivityAnalysis();
            saPage.Dock = DockStyle.Fill;
            contentHost.Controls.Add(saPage);
        }

        private void CuttingPlane_Click_1(object sender, EventArgs e)
        {
            contentHost.Controls.Clear();
            CuttingPlanePage revisedPage = new CuttingPlanePage();
            revisedPage.Dock = DockStyle.Fill;
            contentHost.Controls.Add(revisedPage);
        }

        private void BranchBoundKnap_Click_1(object sender, EventArgs e)
        {
            contentHost.Controls.Clear();
            BranchAndBoundKnapsackPage revisedPage = new BranchAndBoundKnapsackPage(model);
            revisedPage.Dock = DockStyle.Fill;
            contentHost.Controls.Add(revisedPage);
        }

        private void LoadModel_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Text Files|*.txt|All Files|*.*";
                ofd.Title = "Select Model File";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string content = System.IO.File.ReadAllText(ofd.FileName);
                    InputModelTxt.Text = content;
                    // Create model and reader
                    model = new LPModel();
                    ReadWriter reader = new ReadWriter();

                    // Parse file into LPModel
                    reader.ReadFromFile(model, ofd.FileName);

                    StringBuilder sb = new StringBuilder();

                    // Objective
                    sb.AppendLine($"Type: {model.Type}");
                    sb.AppendLine($"Objective: {string.Join(", ", model.ObjectiveFunction)}");

                    // Constraints
                    sb.AppendLine("Constraints:");
                    for (int i = 0; i < model.ConstraintCoefficients.Count; i++)
                    {
                        string coeffs = string.Join(", ", model.ConstraintCoefficients[i]);
                        string rhs = model.ConstraintInequalities[i]; // stored last token
                        sb.AppendLine($"[{coeffs}] = {rhs}");
                    }

                    // Signs
                    sb.AppendLine($"Signs: {string.Join(", ", model.Signs)}");

                    // Show in inputbox
                    InputModelTxt1.Text = sb.ToString();
                }
            }
        }

        private void btn_Close_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Max_Click_1(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void btn_Min_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
