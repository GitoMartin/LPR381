using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LPR381Project
{
    public class RoundedRichTextBox : RichTextBox
    {
        private int _cornerRadius = 12;
        private Color _borderColor = Color.LightGray;
        private int _borderThickness = 1;

        public int CornerRadius
        {
            get => _cornerRadius;
            set { _cornerRadius = value; Invalidate(); }
        }

        public Color BorderColor
        {
            get => _borderColor;
            set { _borderColor = value; Invalidate(); }
        }

        public int BorderThickness
        {
            get => _borderThickness;
            set { _borderThickness = value; Invalidate(); }
        }

        public RoundedRichTextBox()
        {
            BorderStyle = BorderStyle.None;  // remove default border
            Padding = new Padding(8);        // inner spacing
            BackColor = Color.White;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateRegion();
        }

        private void UpdateRegion()
        {
            using (GraphicsPath path = GetRoundedPath(ClientRectangle, _cornerRadius))
            {
                this.Region = new Region(path);
            }
        }

        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;

            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();

            return path;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (Graphics g = this.CreateGraphics())
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;

                using (Pen pen = new Pen(_borderColor, _borderThickness))
                {
                    using (GraphicsPath path = GetRoundedPath(ClientRectangle, _cornerRadius))
                    {
                        g.DrawPath(pen, path);
                    }
                }
            }
        }
    }
}
