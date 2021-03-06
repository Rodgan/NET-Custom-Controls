﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NET__Custom_Controls.Led
{
    [ToolboxItem(true)]
    [DefaultEvent("Click")]
    public partial class CircleLed : BasicElements.GradientElement
    {
        public CircleLed()
        {
            InitializeComponent();
            StopVisualStudioMakingRandomChanges();
            OldSize = Size;
            SetInitialTheme();
            SetDefaultEvents();
            EnableThemeEffectsOnMouseEvents();
        }

        private void SetInitialTheme()
        {
            Theme = GradientTheme.Theme.BlueSky;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            BackColor = Color.Transparent;

            switch (ColorMode)
            {
                case ColorMode.Solid:
                    Designer.FillPieSolid(e, BackColor, 0, 360);
                    break;
                case ColorMode.Gradient:
                    if (!Designer.FillPieGradient(e, GradientColorList, System.Drawing.Drawing2D.LinearGradientMode.Vertical, 0, 360))
                        ColorMode = ColorMode.Solid;
                    break;
            }

        }

        private Size OldSize;

        protected override void OnResize(EventArgs e)
        {
            var widthDifference = OldSize.Width - Size.Width;
            var heightDifference = OldSize.Height - Size.Height;

            if (widthDifference < 0)
                widthDifference *= -1;

            if (heightDifference < 0)
                heightDifference *= -1;

            if (widthDifference > heightDifference)
                Height = Width;
            else
                Width = Height;

        }
    }
}
