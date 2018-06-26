using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NET__Custom_Controls.Buttons
{
    [DefaultEvent("Click")]
    public partial class Button : BasicElements.GradientElement
    {
        public Button()
        {
            InitializeComponent();
            SetDefaultEvents();
            EnableThemeEffectsOnMouseEvents();
        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Browsable(true)]
        [Category("Appearance")]
        public override string Text
        {
            get { return lblText.Text; }
            set { lblText.Text = value; }
        }

        [Category("Appearance")]
        public ContentAlignment TextAlign
        {
            get { return lblText.TextAlign; }
            set { lblText.TextAlign = value; }
        }

    }
}
