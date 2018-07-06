using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.Design;

namespace NET__Custom_Controls.Panel
{
    [ToolboxItem(true)]
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class Navigator : UserControl
    {
        public Navigator()
        {
            InitializeComponent();
        }

        public void DrawPage(Form page)
        {
            this.Controls.Clear();
            page.TopLevel = false;
            page.Dock = DockStyle.Fill;
            page.FormBorderStyle = FormBorderStyle.None;
            page.Parent = this;
            page.Visible = true;
            page.Show();
        }
    }

}
