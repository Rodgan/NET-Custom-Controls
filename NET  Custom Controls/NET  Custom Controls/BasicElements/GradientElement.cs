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

        [Category("Theme")]
        [Description("Select Color Mode")]
        public ColorMode ColorMode
        {
            get { return _ColorMode; }
            set { _ColorMode = value; Invalidate(); }
        }
        protected ColorMode _ColorMode = ColorMode.Solid;

        [Category("Theme")]
        [Description("Select Color Direction for Gradient Color Mode")]
        public LinearGradientMode GradientColorDirection
        {
            get { return _GradientColorDirection; }
            set { _GradientColorDirection = value; Invalidate(); }
        }
        protected LinearGradientMode _GradientColorDirection = LinearGradientMode.Vertical;

        [Category("Theme")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected GradientTheme.Theme ThemeInUse
        {
            get { return _ThemeInUse ?? _Theme; }
            set { _ThemeInUse = value;}
        }
        protected GradientTheme.Theme? _ThemeInUse = null;

        [Category("Theme")]
        public GradientTheme.Theme Theme
        {
            get { return _Theme; }
            set { _Theme = value; _ColorMode = ColorMode.Gradient; Invalidate(); }
        }
        protected GradientTheme.Theme _Theme = GradientTheme.Theme.Custom;


        [Category("Theme")]
        public GradientTheme.Theme MouseUpTheme
        {
            get { return _MouseUpTheme ?? _Theme; }
            set { _MouseUpTheme = value; _ColorMode = ColorMode.Gradient; }
        }
        protected GradientTheme.Theme? _MouseUpTheme = null;

        [Category("Theme")]
        public GradientTheme.Theme MouseDownTheme
        {
            get { return _MouseDownTheme ?? _Theme; }
            set { _MouseDownTheme = value; _ColorMode = ColorMode.Gradient; }
        }
        protected GradientTheme.Theme? _MouseDownTheme = null;

        [Category("Theme")]
        public GradientTheme.Theme MouseEnterTheme
        {
            get { return _MouseEnterTheme ?? _Theme; }
            set { _MouseEnterTheme = value; _ColorMode = ColorMode.Gradient; }
        }
        protected GradientTheme.Theme? _MouseEnterTheme = null;

        [Category("Theme")]
        public GradientTheme.Theme MouseLeaveTheme
        {
            get { return _MouseLeaveTheme ?? _Theme; }
            set { _MouseLeaveTheme = value; _ColorMode = ColorMode.Gradient; }
        }
        protected GradientTheme.Theme? _MouseLeaveTheme = null;

        [Category("Theme")]
        [Browsable(true)]
        [Description("Colors used for Gradient Color Mode")]
        public GradientColor[] GradientColorList
        {
            get
            {
                if (ThemeInUse == GradientTheme.Theme.Custom)
                    return _GradientColorList;
                else
                    return (_GradientColorList = GradientTheme.GetTheme(ThemeInUse));
            }
            set { _GradientColorList = value; _ColorMode = ColorMode.Gradient; Invalidate(); }
        }
        protected GradientColor[] _GradientColorList;

        [Browsable(true)]
        [Category("Appearance")]
        public Image Image
        {
            get { return _Image; }
            set { _Image = value; Invalidate(); }
        }
        private Image _Image;

        [Category("Appearance")]
        public ImageAlignment ImageAlignment
        {
            get { return _ImageAlignment; }
            set { _ImageAlignment = value; Invalidate(); }
        }
        private ImageAlignment _ImageAlignment = ImageAlignment.MiddleCenter;

        [Category("Appearance")]
        public bool AdaptImage
        {
            get { return _AdaptImage; }
            set { _AdaptImage = value; Invalidate(); }
        }
        private bool _AdaptImage = true;

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

            if (Image != null)
                Designer.DrawImage(this, e, Image, ImageAlignment, AdaptImage);
        }

        protected void EnableThemeEffectsOnMouseEvents()
        {
            OnMouseEnter(GradientEvent_MouseEnter, this);
            OnMouseEnter(GradientEvent_MouseEnter, Controls);

            OnMouseDown(GradientEvent_MouseDown, this);
            OnMouseDown(GradientEvent_MouseDown, Controls);

            OnMouseUp(GradientEvent_MouseUp, this);
            OnMouseUp(GradientEvent_MouseUp, Controls);

            OnMouseLeave(GradientEvent_MouseLeave, this);
            OnMouseLeave(GradientEvent_MouseLeave, Controls);
        }
        protected void GradientEvent_MouseEnter(object sender, EventArgs e)
        {
            ThemeInUse = MouseEnterTheme;
            Invalidate();
        }
        protected void GradientEvent_MouseDown(object sender, MouseEventArgs e)
        {
            ThemeInUse = MouseDownTheme;
            Invalidate();
        }
        protected void GradientEvent_MouseUp(object sender, MouseEventArgs e)
        {
            ThemeInUse = MouseUpTheme;
            Invalidate();
        }
        protected void GradientEvent_MouseLeave(object sender, EventArgs e)
        {
            ThemeInUse = MouseLeaveTheme;
            Invalidate();
        }
    }
}
