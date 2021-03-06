﻿#region Imports

using System.Windows.Forms;

#endregion

namespace ReaLTaiizor
{
    #region FormContextMenuStrip

    public class FormContextMenuStrip : ContextMenuStrip
    {

        public FormContextMenuStrip()
        {
            Renderer = new ControlRenderer();
        }

        public new ControlRenderer Renderer
        {
            get { return (ControlRenderer)base.Renderer; }
            set { base.Renderer = value; }
        }
    }

    #endregion
}