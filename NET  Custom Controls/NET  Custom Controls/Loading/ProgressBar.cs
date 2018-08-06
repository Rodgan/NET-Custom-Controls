using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NET__Custom_Controls.Loading
{
    [ToolboxItem(true)]
    public partial class ProgressBar : BasicElements.GradientElement
    {
        public ProgressBar()
        {
            InitializeComponent();
            StopVisualStudioMakingRandomChanges();
            OldSize = Size;
        }

        public float Progress
        {
            get { return _Progress; }
            set { _Progress = value; Invalidate(); }
        }
        private float _Progress = 0f;

        public Color SolidColor
        {
            get { return _SolidColor; }
            set { _SolidColor = value; _ColorMode = ColorMode.Solid; Invalidate(); }
        }
        private Color _SolidColor = Color.White;

        protected override void OnPaint(PaintEventArgs e)
        {
            var widthToDraw = (int) ((Width / 100f) * Progress);

            if (widthToDraw > 0)
            {
                switch (ColorMode)
                {
                    case ColorMode.Solid:
                        Designer.FillRectangleSolid(e, SolidColor, new Rectangle(0, 0, widthToDraw, Height));
                        break;
                    case ColorMode.Gradient:
                        Designer.FillRectangleGradient(e, GradientColorList, GradientColorDirection, new Rectangle(0, 0, widthToDraw, Height));
                        break;
                }
            }

            Designer.DrawString(this, e, $"{Progress.ToString("0.00")} %", Font, ForeColor, ContentAlignment.MiddleCenter);

        }

        private Size OldSize;
        protected override void OnResize(EventArgs e)
        {
            if (OldSize.Width != Width)
                Height = Width / 10;
            else if (OldSize.Height != Height)
                Width = Height * 10;

        }
    }
}
