﻿#region Imports

using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

#endregion

namespace ReaLTaiizor
{
    #region HopeComboBox

    public class HopeComboBox : ComboBox
    {
        public HopeComboBox()
        {
            DrawItem += HopeComboBox_DrawItem;
            //SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            //DoubleBuffered = true;
            FlatStyle = FlatStyle.Flat;
            DrawMode = DrawMode.OwnerDrawFixed;

            Cursor = Cursors.Hand;

            Font = new Font("Segoe UI", 12F);
            ItemHeight = 30;
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern IntPtr GetWindowDC(IntPtr hWnd);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x000F || m.Msg == 0x133)
            {
                IntPtr hDC = GetWindowDC(m.HWnd);
                if (hDC.ToInt32() == 0)
                    return;

                Graphics graphics = Graphics.FromHdc(hDC);

                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.Clear(Parent.BackColor);

                var backPath = RoundRectangle.CreateRoundRect(1, 1, Width - 2, Height - 2, 2);
                graphics.FillPath(new SolidBrush(Color.White), backPath);
                graphics.DrawPath(new Pen(HopeColors.OneLevelBorder, 2), backPath);

                graphics.FillRectangle(new SolidBrush(Color.White), new RectangleF(1, 1, Width - 2, Height - 2));

                graphics.DrawString(Text, Font, new SolidBrush(HopeColors.PrimaryColor), new Point(6, 6));

                graphics.DrawString("6", new Font("Marlett", 12), new SolidBrush(SystemColors.ControlDark), new Rectangle(Width - 22, (Height - 18) / 2, 18, 18));

                ReleaseDC(m.HWnd, hDC);
            }
        }

        private void HopeComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            e.DrawBackground();
            e.DrawFocusRectangle();

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(HopeColors.ThreeLevelBorder), e.Bounds);

                e.Graphics.DrawString(base.GetItemText(base.Items[e.Index]), Font, new SolidBrush(HopeColors.PrimaryColor), e.Bounds, HopeStringAlign.BottomLeft);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.White), e.Bounds);
                var textColor = HopeColors.MainText;

                e.Graphics.DrawString(base.GetItemText(base.Items[e.Index]), Font, new SolidBrush(textColor), e.Bounds, HopeStringAlign.BottomLeft);
            }
            e.Graphics.Dispose();
        }
    }

    #endregion
}