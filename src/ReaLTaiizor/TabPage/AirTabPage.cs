﻿#region Imports

using System.Drawing;
using System.Windows.Forms;

#endregion

namespace ReaLTaiizor
{
    #region AirTabPage

    public class AirTabPage : TabControl
    {

        public AirTabPage()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            DoubleBuffered = true;
            SizeMode = TabSizeMode.Fixed;
            ItemSize = new Size(30, 115);
        }
        protected override void CreateHandle()
        {
            base.CreateHandle();
            Alignment = TabAlignment.Left;
        }

        Color C1 = Color.FromArgb(78, 87, 100);
        public Color SquareColor
        {
            get { return C1; }
            set
            {
                C1 = value;
                Invalidate();
            }
        }

        bool OB = false;
        public bool ShowOuterBorders
        {
            get { return OB; }
            set
            {
                OB = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);
            try
            {
                SelectedTab.BackColor = Color.White;
            }
            catch
            {
            }
            G.Clear(Color.White);
            for (int i = 0; i <= TabCount - 1; i++)
            {
                Rectangle x2 = new Rectangle(new Point(GetTabRect(i).Location.X - 2, GetTabRect(i).Location.Y - 2), new Size(GetTabRect(i).Width + 3, GetTabRect(i).Height - 1));
                Rectangle textrectangle = new Rectangle(x2.Location.X + 20, x2.Location.Y, x2.Width - 20, x2.Height);
                if (i == SelectedIndex)
                {
                    G.FillRectangle(new SolidBrush(C1), new Rectangle(x2.Location, new Size(9, x2.Height)));


                    if (ImageList != null)
                    {
                        try
                        {
                            if (ImageList.Images[TabPages[i].ImageIndex] != null)
                            {
                                G.DrawImage(ImageList.Images[TabPages[i].ImageIndex], new Point(textrectangle.Location.X + 8, textrectangle.Location.Y + 6));
                                G.DrawString("      " + TabPages[i].Text, Font, Brushes.Black, textrectangle, new StringFormat
                                {
                                    LineAlignment = StringAlignment.Center,
                                    Alignment = StringAlignment.Near
                                });
                            }
                            else
                            {
                                G.DrawString(TabPages[i].Text, Font, Brushes.Black, textrectangle, new StringFormat
                                {
                                    LineAlignment = StringAlignment.Center,
                                    Alignment = StringAlignment.Near
                                });
                            }
                        }
                        catch
                        {
                            G.DrawString(TabPages[i].Text, Font, Brushes.Black, textrectangle, new StringFormat
                            {
                                LineAlignment = StringAlignment.Center,
                                Alignment = StringAlignment.Near
                            });
                        }
                    }
                    else
                    {
                        G.DrawString(TabPages[i].Text, Font, Brushes.Black, textrectangle, new StringFormat
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Near
                        });
                    }

                }
                else
                {
                    if (ImageList != null)
                    {
                        try
                        {
                            if (ImageList.Images[TabPages[i].ImageIndex] != null)
                            {
                                G.DrawImage(ImageList.Images[TabPages[i].ImageIndex], new Point(textrectangle.Location.X + 8, textrectangle.Location.Y + 6));
                                G.DrawString("      " + TabPages[i].Text, Font, Brushes.DimGray, textrectangle, new StringFormat
                                {
                                    LineAlignment = StringAlignment.Center,
                                    Alignment = StringAlignment.Near
                                });
                            }
                            else
                            {
                                G.DrawString(TabPages[i].Text, Font, Brushes.DimGray, textrectangle, new StringFormat
                                {
                                    LineAlignment = StringAlignment.Center,
                                    Alignment = StringAlignment.Near
                                });
                            }
                        }
                        catch
                        {
                            G.DrawString(TabPages[i].Text, Font, Brushes.DimGray, textrectangle, new StringFormat
                            {
                                LineAlignment = StringAlignment.Center,
                                Alignment = StringAlignment.Near
                            });
                        }
                    }
                    else
                    {
                        G.DrawString(TabPages[i].Text, Font, Brushes.DimGray, textrectangle, new StringFormat
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Near
                        });
                    }
                }
            }

            e.Graphics.DrawImage((Image)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }

    #endregion
}