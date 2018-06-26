using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NET__Custom_Controls.BasicElements
{
    [ToolboxItem(false)]
    public partial class EventHandlerManager : UserControl
    {
        public EventHandlerManager()
        {
            InitializeComponent();
        }

        protected void SetDefaultEvents()
        {
            OnClick(Event_Click, Controls);
            OnMouseEnter(Event_MouseEnter, Controls);
            OnMouseHover(Event_MouseHover, Controls);
            OnMouseMove(Event_MouseMove, Controls);
            OnMouseLeave(Event_MouseLeave, Controls);
            OnMouseUp(Event_MouseUp, Controls);
            OnMouseDown(Event_MouseDown, Controls);

            OnClick(Event_Click, this);
            OnMouseEnter(Event_MouseEnter, this);
            OnMouseHover(Event_MouseHover, this);
            OnMouseMove(Event_MouseMove, this);
            OnMouseLeave(Event_MouseLeave, this);
            OnMouseUp(Event_MouseUp, this);
            OnMouseDown(Event_MouseDown, this);
        }

        public new event EventHandler Click;
        public new event EventHandler MouseHover;
        public new event MouseEventHandler MouseMove;
        public new event EventHandler MouseEnter;
        public new event EventHandler MouseLeave;
        public new event MouseEventHandler MouseUp;
        public new event MouseEventHandler MouseDown;
    
        protected void Event_Click(object sender, EventArgs e)
        {            
            if (Click != null)
                Click(this, e);
        }
        protected void Event_MouseEnter(object sender, EventArgs e)
        {
            if (MouseEnter != null)
                MouseEnter(this, e);
        }
        protected void Event_MouseHover(object sender, EventArgs e)
        {
            if (MouseHover != null)
                MouseHover(this, e);
        }
        protected void Event_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseMove != null)
                MouseMove(this, e);
        }
        protected void Event_MouseLeave(object sender, EventArgs e)
        {
            if (MouseLeave != null)
                MouseLeave(this, e);
        }
        protected void Event_MouseUp(object sender, MouseEventArgs e)
        {
            if (MouseUp != null)
                MouseUp(this, e);
        }
        protected void Event_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseDown != null)
                MouseDown(this, e);
        }

        protected void OnClick(EventHandler handler, ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                control.Click += handler;
            }
        }
        protected void OnClick(EventHandler handler, Control control)
        {
            control.Click += handler;
        }
        protected void OnMouseEnter(EventHandler handler, ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                control.MouseEnter += handler;
            }
        }
        protected void OnMouseEnter(EventHandler handler, Control control)
        {
            control.MouseEnter += handler;
        }
        protected void OnMouseHover(EventHandler handler, ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                control.MouseHover += handler;
            }
        }
        protected void OnMouseHover(EventHandler handler, Control control)
        {
            control.MouseHover += handler;
        }
        protected void OnMouseMove(MouseEventHandler handler, ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                control.MouseMove += handler;
            }
        }
        protected void OnMouseMove(MouseEventHandler handler, Control control)
        {
            control.MouseMove += handler;
        }
        protected void OnMouseLeave(EventHandler handler, ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                control.MouseLeave += handler;
            }
        }
        protected void OnMouseLeave(EventHandler handler, Control control)
        {
            control.MouseLeave += handler;
        }
        protected void OnMouseUp(MouseEventHandler handler, ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                control.MouseUp += handler;
            }
        }
        protected void OnMouseUp(MouseEventHandler handler, Control control)
        {
            control.MouseUp += handler;
        }
        protected void OnMouseDown(MouseEventHandler handler, ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                control.MouseDown += handler;
            }
        }
        protected void OnMouseDown(MouseEventHandler handler, Control control)
        {
            control.MouseDown += handler;
        }
    }
}
