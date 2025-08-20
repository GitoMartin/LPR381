using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LPR381Project
{
    public class PlaceholderRichTextBox : RichTextBox
    {
        public string Placeholder { get; set; } = "Enter text...";
        public Color PlaceholderColor { get; set; } = Color.Gray;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (string.IsNullOrEmpty(this.Text) && !this.Focused)
            {
                using (SolidBrush brush = new SolidBrush(PlaceholderColor))
                {
                    StringFormat format = new StringFormat
                    {
                        Alignment = StringAlignment.Center,   // horizontal center
                        LineAlignment = StringAlignment.Center // vertical center
                    };

                    e.Graphics.DrawString(
                        Placeholder,
                        this.Font,
                        brush,
                        this.ClientRectangle,
                        format
                    );
                }
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.Invalidate(); // repaint when text changes
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            this.Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            this.Invalidate();
        }
    }

}
