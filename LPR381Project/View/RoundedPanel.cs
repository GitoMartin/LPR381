using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LPR381Project
{
    public class RoundedPanel : Panel
    {
        public int CornerRadius { get; set; } = 12;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Rectangle rect = this.ClientRectangle;
            rect.Width--; rect.Height--;

            using (GraphicsPath path = GetRoundPath(rect, CornerRadius))
            using (Pen pen = new Pen(Color.LightGray, 1))
            {
                this.Region = new Region(path);
                e.Graphics.DrawPath(pen, path);
            }
        }

        private GraphicsPath GetRoundPath(Rectangle rect, int radius)
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
    }
}
