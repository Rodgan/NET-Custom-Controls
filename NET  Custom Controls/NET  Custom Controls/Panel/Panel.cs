﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.ComponentModel.Design;
using System.Drawing.Drawing2D;

namespace NET__Custom_Controls.Panel
{
    [ToolboxItem(true)]
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class Panel : BasicElements.GradientElement
    {
        public Panel()
        {
            InitializeComponent();
        }

        #region Drag Form
        [Category("Drag")]
        public bool EnableFormDragging { get; set; } = false;
        [Category("Drag")]
        public Form FormToDrag { get; set; }

        private bool Drag = false;

        private Point InitialFormPosition;
        private Point CurrentFormPosition
        {
            get { return FormToDrag.Location; }
        }
        private Point InitialMousePosition;
        private Point CurrentMousePosition
        {
            get { return Cursor.Position; }
        }
       
        private Point PositionDifference;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && EnableFormDragging && FormToDrag != null)
            {
                InitialMousePosition = CurrentMousePosition;
                InitialFormPosition = CurrentFormPosition;
                Drag = true;
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Drag = false;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (Drag && EnableFormDragging)
            {
                PositionDifference = new Point(CurrentMousePosition.X - InitialMousePosition.X, CurrentMousePosition.Y - InitialMousePosition.Y);
                FormToDrag.Location = new Point(
                    InitialFormPosition.X + PositionDifference.X,
                    InitialFormPosition.Y + PositionDifference.Y
                );
            }
        }
        #endregion

        [Category("Constraints")]
        public int MaxWidth
        {
            get { return _MaxWidth; }
            set { _MaxWidth = value; Invalidate(); }
        }
        private int _MaxWidth = 0;

        [Category("Constraints")]
        public int MaxHeight
        {
            get { return _MaxHeight; }
            set { _MaxHeight = value; Invalidate(); }
        }
        private int _MaxHeight = 0;

        [Category("Constraints")]
        public bool SetMaxHeight
        {
            get { return _SetMaxHeight; }
            set
            {
                _SetMaxHeight = value;

                if (value)
                {
                    if (_MaxHeight == 0)
                        _MaxHeight = Height;

                    Invalidate();
                }
            }
        }
        private bool _SetMaxHeight = false;

        [Category("Constraints")]
        public bool SetMaxWidth
        {
            get { return _SetMaxWidth; }
            set
            {
                _SetMaxWidth = value;
                if (value)
                {

                }
            }
        }
        private bool _SetMaxWidth = false;

        protected override void OnResize(EventArgs e)
        {
            if (SetMaxWidth)
            {
                if (Width > MaxWidth)
                    Width = MaxWidth;
            }

            if (SetMaxHeight)
            {
                if (Height > MaxHeight)
                    Height = MaxHeight;
            }
        }
        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    switch (ColorMode)
        //    {
        //        case ColorMode.Solid:
        //            Designer.FillRectangleSolid(e, BackColor, new Rectangle(0, 0, Width, Height));
        //            break;
        //        case ColorMode.Gradient:
        //            if (!Designer.FillRectangleGradient(e, GradientColorList, GradientColorDirection, new Rectangle(0, 0, Width, Height)))
        //                ColorMode = ColorMode.Solid;
        //            break;
        //    }
        //}


    }
}
