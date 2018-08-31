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
    [ToolboxItem(true)]
    [DefaultEvent("Click")]
    public partial class Button : BasicElements.GradientElement
    {
        public Button()
        {
            InitializeComponent();
            SetDefaultEvents();
            EnableThemeEffectsOnMouseEvents();
        }

    }
}
