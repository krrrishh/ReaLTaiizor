﻿#region Imports

using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

#endregion

namespace ReaLTaiizor
{
    #region GroupBox

    public class GroupBox : ContainerControl
    {
        #region Variables

        private Color _HeaderColor = Color.CornflowerBlue;
        private Color _BorderColorH = Color.FromArgb(182, 180, 186);
        private Color _BorderColorG = Color.FromArgb(159, 159, 161);
        private Color _BackGColor = Color.DodgerBlue;

        #endregion

        #region Custom Properties

        public Color HeaderColor
        {
            get { return _HeaderColor; }
            set
            {
                _HeaderColor = value;
                Invalidate();
            }
        }

        public Color BorderColorH
        {
            get { return _BorderColorH; }
            set
            {
                _BorderColorH = value;
                Invalidate();
            }
        }

        public Color BorderColorG
        {
            get { return _BorderColorG; }
            set
            {
                _BorderColorG = value;
                Invalidate();
            }
        }

        public Color BackGColor
        {
            get { return _BackGColor; }
            set
            {
                _BackGColor = value;
                Invalidate();
            }
        }

        #endregion

        public GroupBox()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;
            Size = new Size(212, 104);
            MinimumSize = new Size(136, 50);
            Padding = new Padding(5, 28, 5, 5);
            ForeColor = Color.FromArgb(53, 53, 53);
            Font = new Font("Tahoma", 9, FontStyle.Regular);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            Rectangle TitleBox = new Rectangle(51, 3, Width - 103, 18);
            Rectangle box = new Rectangle(0, 0, Width - 1, Height - 10);

            G.Clear(Color.Transparent);
            G.SmoothingMode = SmoothingMode.HighQuality;

            // Draw the body of the GroupBox
            G.FillPath(new SolidBrush(_BackGColor), RoundRectangle.RoundRect(new Rectangle(1, 12, Width - 3, box.Height - 1), 8));
            // Draw the border of the GroupBox
            G.DrawPath(new Pen(_BorderColorG), RoundRectangle.RoundRect(new Rectangle(1, 12, Width - 3, Height - 13), 8));

            // Draw the background of the title box
            G.FillPath(new SolidBrush(_HeaderColor), RoundRectangle.RoundRect(TitleBox, 1));
            // Draw the border of the title box
            G.DrawPath(new Pen(_BorderColorH), RoundRectangle.RoundRect(TitleBox, 4));
            // Draw the specified string from 'Text' property inside the title box
            G.DrawString(Text, Font, new SolidBrush(ForeColor), TitleBox, new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            });

            e.Graphics.DrawImage((Image)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }

    #endregion
}