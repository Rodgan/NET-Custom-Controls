using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NET__Custom_Controls
{
    public partial class ActivableButton: UserControl
    {
        public ActivableButton()
        {
            InitializeComponent();
            InitialSettings();
        }

        private void InitialSettings()
        {
            OnMouseClick(Event_MouseClick);
            OnMouseDown(Event_MouseDown);
            OnMouseUp(Event_MouseUp);
            OnMouseMove(Event_MouseMove);
            OnMouseEnter(Event_MouseEnter);
            OnMouseLeave(Event_MouseLeave);
        }

        public enum ButtonStatus
        {
            Active,
            Inactive,
            Disabled
        }
        public enum BarPosition
        {
            Left,
            Right
        }

        #region Properties

        public Color StatusBarHoverColor
        {
            get { return _StatusBarHoverColor; }
            set { _StatusBarHoverColor = value; }
        }
        private Color _StatusBarHoverColor = Color.LightSlateGray;

        /// <summary>
        /// Get or Set the color for Active Status
        /// </summary>
        public Color StatusBarActiveColor
        {
            get { return _StatusBarActiveColor; }
            set { _StatusBarActiveColor = value; }
        }
        private Color _StatusBarActiveColor = Color.ForestGreen;

        /// <summary>
        /// Get or Set the color for Inactive Status
        /// </summary>
        public Color StatusBarInactiveColor
        {
            get { return _StatusBarInactiveColor; }
            set { _StatusBarInactiveColor = value; UpdateStatus(); }
        }
        private Color _StatusBarInactiveColor = Color.OrangeRed;

        /// <summary>
        /// Get or Set the color for Disabled Status
        /// </summary>
        public Color StatusBarDisabledColor
        {
            get { return _StatusBarDisabledColor; }
            set { _StatusBarDisabledColor = value; UpdateStatus(); }
        }
        private Color _StatusBarDisabledColor = Color.LightGray;

        /// <summary>
        /// Get or Set the Status
        /// </summary>
        public ButtonStatus Status
        {
            get { return _Status; }
            set { _Status = value; UpdateStatus(); }
        }
        private ButtonStatus _Status =  ButtonStatus.Active;

        /// <summary>
        /// Get or Set the Status Bar Position
        /// </summary>
        public BarPosition StatusBarPosition
        {
            get { return _StatusBarPosition; }
            set { _StatusBarPosition = value; UpdateBarPosition(); }
        }
        private BarPosition _StatusBarPosition = BarPosition.Left;

        /// <summary>
        /// Get or Set the Status Bar Width
        /// </summary>
        public int StatusBarWidth
        {
            get { return StatusBar.Width; }
            set { StatusBar.Width = value; }
        }

        /// <summary>
        /// Get or Set the Button Text
        /// </summary>
        public string ButtonText
        {
            get { return LabelText.Text; }
            set { LabelText.Text = value; }
        }

        /// <summary>
        /// Get or Set if button has 3D effect on click
        /// </summary>
        public bool Use3DEffectOnClick
        {
            get { return _Use3DEffectOnClick; }
            set { _Use3DEffectOnClick = value; }
        }
        private bool _Use3DEffectOnClick = true;
        #endregion

        #region Update Graphic
        private void UpdateStatus()
        {
            switch (Status)
            {
                case ButtonStatus.Active:
                    StatusBar.BackColor = StatusBarActiveColor;
                    break;
                case ButtonStatus.Inactive:
                    StatusBar.BackColor = StatusBarInactiveColor;
                    break;
                case ButtonStatus.Disabled:
                    StatusBar.BackColor = StatusBarDisabledColor;
                    break;
            }
        }
        private void UpdateBarPosition()
        {
            switch (StatusBarPosition)
            {
                case BarPosition.Left:
                default:
                    StatusBar.Dock = DockStyle.Left;
                    break;
                case BarPosition.Right:
                    StatusBar.Dock = DockStyle.Right;
                    break;
            }
        }
        #endregion

        #region Event Handler Manager
        public void OnMouseClick(MouseEventHandler handler)
        {
            this.LabelText.MouseClick += handler;
            this.StatusBar.MouseClick += handler;
        }
        public void OnMouseDown(MouseEventHandler handler)
        {
            LabelText.MouseDown += handler;
            StatusBar.MouseDown += handler;
        }
        public void OnMouseUp(MouseEventHandler handler)
        {
            LabelText.MouseUp += handler;
            StatusBar.MouseUp += handler;
        }
        public void OnMouseEnter(EventHandler handler)
        {
            LabelText.MouseEnter += handler;
            StatusBar.MouseEnter += handler;
        }
        public void OnMouseLeave(EventHandler handler)
        {
            LabelText.MouseLeave += handler;
            StatusBar.MouseLeave += handler;
        }
        public void OnMouseMove(MouseEventHandler handler)
        {
            LabelText.MouseMove += handler;
            StatusBar.MouseMove += handler;   
        }
        #endregion

        #region Basic Events
        private void Event_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Status == ButtonStatus.Active)
                    Status = ButtonStatus.Inactive;
                else if (Status == ButtonStatus.Inactive)
                    Status = ButtonStatus.Active;
            }
        }
        private void Event_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && Use3DEffectOnClick)
                BorderStyle = BorderStyle.Fixed3D;
        }
        private void Event_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button ==  MouseButtons.Left && Use3DEffectOnClick)
                BorderStyle = BorderStyle.FixedSingle;
        }
        private void Event_MouseMove(object sender, MouseEventArgs e)
        {
            StatusBar.BackColor = StatusBarHoverColor;
        }
        private void Event_MouseEnter(object sender, EventArgs e)
        {
            StatusBar.BackColor = StatusBarHoverColor;
        }
        private void Event_MouseLeave(object sender, EventArgs e)
        {
            UpdateStatus();
        }
        #endregion
    }
}
