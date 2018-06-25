using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace NET__Custom_Controls.BasicElements
{
    [ToolboxItem(false)]
    public partial class GradientElement : EventHandlerManager
    {
        public GradientElement()
        {
            InitializeComponent();
        }

        [Category("Appearance")]
        [Description("Select Color Mode")]
        public ColorMode ColorMode
        {
            get { return _ColorMode; }
            set { _ColorMode = value; Invalidate(); }
        }
        protected ColorMode _ColorMode = ColorMode.Solid;

        [Category("Appearance")]
        [Description("Select Color Direction for Gradient Color Mode")]
        public LinearGradientMode GradientColorDirection
        {
            get { return _GradientColorDirection; }
            set { _GradientColorDirection = value; Invalidate(); }
        }
        protected LinearGradientMode _GradientColorDirection = LinearGradientMode.Vertical;

        [Category("Appearance")]
        public GradientTheme.Theme Theme
        {
            get { return _Theme; }
            set { _Theme = value; GradientColorList = GradientTheme.GetTheme(value); }
        }
        protected GradientTheme.Theme _Theme = GradientTheme.Theme.Custom;

        [Category("Appearance")]
        [Browsable(true)]
        [Description("Colors used for Gradient Color Mode")]
        public GradientColor[] GradientColorList
        {
            get { return _BackColorList; }
            set { _BackColorList = value; _ColorMode = ColorMode.Gradient; Invalidate(); }
        }
        protected GradientColor[] _BackColorList;

        protected override void OnPaint(PaintEventArgs e)
        {
            switch (ColorMode)
            {
                case ColorMode.Solid:
                    Designer.FillRectangleSolid(e, BackColor, new Rectangle(0, 0, Width, Height));
                    break;
                case ColorMode.Gradient:
                    if (!Designer.FillRectangleGradient(e, GradientColorList, GradientColorDirection, new Rectangle(0, 0, Width, Height)))
                        ColorMode = ColorMode.Solid;
                    break;
            }
        }
    }
}
