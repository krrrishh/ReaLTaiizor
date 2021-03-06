﻿#region Imports

using System.Drawing;
using System.Windows.Forms;

#endregion

namespace ReaLTaiizor
{
    #region SpaceLabel

    public class SpaceLabel : SpaceControl // Create a Custom Label
    {
        public SpaceLabel()
        { // Create a Label
            SetColor("Text", 254, 254, 254); // Text Color for Label
            SetColor("Background", 42, 42, 42); // Background Color
            Size = new Size(75, 40);
        }

        private Color C1; // used for the Basic Background of the Label
        private SolidBrush B1; // The Main Color of the Text, Is painted on with a brush

        protected override void ColorHook()
        { // Assigning the colors to variables
            C1 = GetColor("Background"); // Get the Background Color
            B1 = new SolidBrush(GetColor("Text")); // Set up Color for the Text
        }

        protected override void PaintHook()
        {
            G.Clear(C1); // Clear the Color of Background
            DrawText(B1, HorizontalAlignment.Center, 0, 0); // Align Text In Center of Label
        }
    }

    #endregion
}