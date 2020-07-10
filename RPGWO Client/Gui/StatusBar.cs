using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace RPGWO_Client.Gui
{
    public class StatusBar : PictureBox
    {
        private int _Value = 0;
        private int _Maximum = 0;

        public StringFormat stringFormat { get; set; }
        public Brush Brush { get; set; }
        public Brush FontBrush { get; set; }

        public StatusBar()
        {
            stringFormat = new StringFormat();
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Alignment = StringAlignment.Center;

            Brush = Brushes.Green;
            FontBrush = new SolidBrush(System.Drawing.Color.FromArgb(200, 200, 200));

            this.Font = new Font(this.Font.FontFamily, 8, FontStyle.Bold, GraphicsUnit.Point);

            ResizeRedraw = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_Maximum <= 0)
                return;

            Rectangle rectangle = e.ClipRectangle;

            // Render a black background
            e.Graphics.FillRectangle(Brushes.Black, rectangle);

            rectangle.Width = (int)(rectangle.Width * ((double)Value / Maximum));
            rectangle.Height = rectangle.Height;
            e.Graphics.FillRectangle(Brush, 0, 0, rectangle.Width, rectangle.Height);

            // Render Text
            e.Graphics.DrawString(String.Format("{0}/{1}", _Value, _Maximum), Font, FontBrush, e.ClipRectangle, stringFormat);
        }

        public int Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = value;
                this.Invalidate();
            }
        }

        public int Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {
                _Maximum = value;
                this.Invalidate();
            }
        }
    }
}
