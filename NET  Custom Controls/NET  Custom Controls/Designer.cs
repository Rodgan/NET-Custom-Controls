using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NET__Custom_Controls
{
    public enum ColorMode
    {
        Solid,
        Gradient
    }
    public enum Shape
    {
        Rectangle,
        Pie
    }

    public class Designer
    {
        private static bool FillGradient(PaintEventArgs e, GradientColor[] colors, LinearGradientMode direction, Shape shape, Rectangle? rectangle = null, float startAngle = 0, float sweepAngle = 0)
        {

            var rectangleToDraw = rectangle.HasValue ? rectangle.Value : e.ClipRectangle;

            if (colors == null || colors.Length < 2 || rectangleToDraw.Width == 0 || rectangleToDraw.Height == 0)
                return false;

            var brush = new LinearGradientBrush(rectangleToDraw,Color.Black,Color.Black, direction);
            var blend = new ColorBlend();

            blend.Colors = colors.Select(x => x.Color).ToArray();
            blend.Positions = colors.Select(x => x.Position).ToArray();

            if (blend.Positions.First() != 0 || blend.Positions.Last() != 1)
                return false;

            brush.InterpolationColors = blend;

            switch (shape)
            {
                case Shape.Rectangle:
                    e.Graphics.FillRectangle(brush, rectangleToDraw);
                    break;
                case Shape.Pie:
                    e.Graphics.FillPie(brush, rectangleToDraw, startAngle, sweepAngle);
                    break;
            }

            return true;
        }
        private static void FillSolid(PaintEventArgs e, Color color, Shape shape, Rectangle? rectangle = null, float startAngle = 0, float sweepAngle = 0)
        {
            var rectangleToDraw = rectangle.HasValue ? rectangle.Value : e.ClipRectangle;

            if (rectangleToDraw.Width == 0 || rectangleToDraw.Height == 0)
                return;

            var brush = new LinearGradientBrush(rectangleToDraw, color, color, LinearGradientMode.Horizontal);

            switch (shape)
            {
                case Shape.Rectangle:
                    e.Graphics.FillRectangle(brush, rectangleToDraw);
                    break;
                case Shape.Pie:
                    e.Graphics.FillPie(brush, rectangleToDraw, startAngle, sweepAngle);
                    break;
            }
        }

        public static bool FillRectangleGradient(PaintEventArgs e, GradientColor[] colors, LinearGradientMode direction, Rectangle? rectangle = null)
        {
            return FillGradient(e, colors, direction, Shape.Rectangle, rectangle);
        }

        public static bool FillPieGradient(PaintEventArgs e, GradientColor[] colors, LinearGradientMode direction, float startAngle, float sweepAngle, Rectangle? rectangle = null)
        {
            return FillGradient(e, colors, direction, Shape.Pie, rectangle, startAngle, sweepAngle);
        }
        
        public static void FillRectangleSolid(PaintEventArgs e, Color color, Rectangle? rectangle = null)
        {
            FillSolid(e, color, Shape.Rectangle, rectangle);
        }

        public static void FillPieSolid(PaintEventArgs e, Color color, float startAngle, float sweepAngle, Rectangle? rectangle = null)
        {
            FillSolid(e, color, Shape.Pie, rectangle, startAngle, sweepAngle);
        }
    }

    public class GradientColor
    {
        public Color Color { get; set; }

        public float Position
        {
            get { return _Position; }
            set
            {
                if (value < 0)
                    _Position = 0;
                else if (value > 1)
                    _Position = 1;
                else
                    _Position = value;
            }
        }
        private float _Position;
    }
}
