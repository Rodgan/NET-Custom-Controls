using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NET__Custom_Controls.Buttons
{
    public partial class OnOffButton : UserControl
    {
        public OnOffButton()
        {
            InitializeComponent();
            SetInitialTheme();
            OnClick(Event_OnClick);
            RefreshGraphic();
        }

        private void SetInitialTheme()
        {
            _OnColorList = GradientTheme.BlueWater;
            _OffColorList = GradientTheme.RedFire;
            _InactivePartColorList = GradientTheme.WhiteApple;
        }
        public enum ButtonStatus
        {
            On,
            Off
        }

        public ButtonStatus Status
        {
            get { return _Status; }
            set { _Status = value; RefreshGraphic(); }
        }
        private ButtonStatus _Status = ButtonStatus.On;

        public ColorMode ColorMode
        {
            get { return _ColorMode; }
            set { _ColorMode = value; RefreshGraphic(); }
        }
        private ColorMode _ColorMode = ColorMode.Gradient;

        public bool IsOn
        {
            get { return Status == ButtonStatus.On; }
        }
        public bool IsOff
        {
            get { return Status == ButtonStatus.Off; }
        }

        public Color OnColor
        {
            get { return _OnColor; }
            set { _OnColor = value; RefreshGraphic(); }
        }
        private Color _OnColor = Color.Blue;

        public Color OffColor
        {
            get { return _OffColor; }
            set { _OffColor = value; RefreshGraphic(); }
        }
        private Color _OffColor  = Color.Red;

        public Color InactivePartColor
        {
            get { return _InactivePartColor; }
            set { _InactivePartColor = value; RefreshGraphic(); }
        }
        private Color _InactivePartColor = Color.Gray;

        public GradientColor[] OnColorList
        {
            get { return _OnColorList; }
            set { _OnColorList = value; RefreshGraphic(); }
        }
        private GradientColor[] _OnColorList;

        public GradientColor[] OffColorList
        {
            get { return _OffColorList; }
            set { _OffColorList = value; RefreshGraphic(); }
        }
        private GradientColor[] _OffColorList;

        public GradientColor[] InactivePartColorList
        {
            get { return _InactivePartColorList; }
            set { _InactivePartColorList = value; RefreshGraphic(); }
        }
        private GradientColor[] _InactivePartColorList;

        public string OnText
        {
            get { return _OnText; }
            set { _OnText = value; RefreshGraphic(); }
        }
        private string _OnText = "ON";

        public string OffText
        {
            get { return _OffText; }
            set { _OffText = value; RefreshGraphic(); }
        }
        private string _OffText = "OFF";

        public void OnClick(EventHandler handler)
        {
            lblON.Click += handler;
            lblOFF.Click += handler;
        }


        private void Event_OnClick(object sender, EventArgs e)
        {
            Status = IsOn ? ButtonStatus.Off : ButtonStatus.On;
        }
        protected override void OnResize(EventArgs e)
        {
            panelON.Width = Width / 2;
            panelOFF.Width = Width / 2;

            panelON.Height = Height;
            panelOFF.Height = Height;
        }
        protected override void OnFontChanged(EventArgs e)
        {
            RefreshFont = true;
            RefreshGraphic();
        }

        private bool RefreshFont = true;
        private void RefreshGraphic()
        {
            panelON.ColorMode = ColorMode;
            panelOFF.ColorMode = ColorMode;

            if (ColorMode == ColorMode.Solid)
            {
                panelON.BackColor = IsOn ? OnColor : InactivePartColor;
                panelOFF.BackColor = IsOff ? OffColor : InactivePartColor;
            }
            else if (ColorMode == ColorMode.Gradient)
            {
                panelON.GradientColorList = IsOn ? OnColorList : InactivePartColorList;
                panelOFF.GradientColorList = IsOff ? OffColorList : InactivePartColorList;
            }

            if (RefreshFont)
            {
                lblON.Font = Font;
                lblOFF.Font = Font;

                lblON.Dock = DockStyle.None;
                lblOFF.Dock = DockStyle.None;

                lblON.Dock = DockStyle.Fill;
                lblOFF.Dock = DockStyle.Fill;

                RefreshFont = false;
            }

            lblON.Text = IsOn ? OnText : "";
            lblOFF.Text = IsOff ? OffText : "";
        }
    }
}
