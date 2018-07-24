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
    public enum ImageAlignment
    {
        BottomLeft,
        BottomCenter,
        BottomRight,
        MiddleLeft,
        MiddleCenter,
        MiddleRight,
        TopLeft,
        TopCenter,
        TopRight,
        Fill
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

        public static void DrawImage(object sender, PaintEventArgs e, Image image, ImageAlignment alignment, bool adaptImage)
        {
            UserControl control = (UserControl)sender;
            int
                x = 0,
                y = 0,
                controlHeight = control.Height,
                controlWidth = control.Width,
                imageHeight = image.Height,
                imageWidth = image.Width;

            float aspectRatio = (float) image.Width / image.Height;

            Size adaptedSize = new Size(imageWidth, imageHeight);

            if (adaptImage)
            {
                adaptedSize = AdaptImage(image, new Size(controlWidth, controlHeight));
                imageWidth = adaptedSize.Width;
                imageHeight = adaptedSize.Height;
            }

            switch (alignment)
            {
                case ImageAlignment.BottomLeft:
                    x = 0;
                    y = controlHeight - imageHeight;
                    break;
                case ImageAlignment.BottomCenter:
                    x = (controlWidth / 2) - (imageWidth / 2);
                    y = controlHeight - imageHeight;
                    break;
                case ImageAlignment.BottomRight:
                    x = controlWidth - imageWidth;
                    y = controlHeight - imageHeight;
                    break;

                case ImageAlignment.MiddleLeft:
                    x = 0;
                    y = (controlHeight / 2) - (imageHeight /2);
                    break;
                case ImageAlignment.MiddleCenter:
                    x = (controlWidth / 2) - (imageWidth / 2);
                    y = (controlHeight / 2) - (imageHeight / 2);
                    break;
                case ImageAlignment.MiddleRight:
                    x = controlWidth - imageWidth;
                    y = (controlHeight / 2) - (imageHeight / 2);
                    break;

                case ImageAlignment.TopLeft:
                    x = 0;
                    y = 0;
                    break;
                case ImageAlignment.TopCenter:
                    x = (controlWidth / 2) - (imageWidth / 2);
                    y = 0;
                    break;
                case ImageAlignment.TopRight:
                    x = controlWidth - imageWidth;
                    y = 0;
                    break;

                case ImageAlignment.Fill:
                    x = 0;
                    y = 0;
                    
                    if (!adaptImage)
                    {
                        adaptedSize.Width = controlWidth;
                        adaptedSize.Height = controlHeight;
                    }
                    break;
            }
            
            e.Graphics.DrawImage(image, new Rectangle(x,y, adaptedSize.Width, adaptedSize.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);
        }

        private static Size AdaptImage(Image originalImage, Size maxSize)
        {
            Size newSize = new Size(Min(originalImage.Width, maxSize.Width), Min(originalImage.Height, maxSize.Height));
            float originalAspectRatio = AspectRatio(originalImage.Size);
            float adaptedAspectRatio = AspectRatio(newSize);

            if (originalAspectRatio != adaptedAspectRatio)
            {
                while (true)
                {
                    newSize.Height--;
                    newSize.Width = (int) (newSize.Height * originalAspectRatio);

                    if (newSize.Height <= maxSize.Height && newSize.Width <= maxSize.Width)
                        return newSize;
                }
                
            }

            return newSize;
    
        }
        private static int Max(params int[] nums)
        {
            return nums.Max();
        }
        private static int Min(params int[] nums)
        {
            return nums.Min();
        }
        private static float AspectRatio(Size size)
        {
            return (float)size.Width / size.Height;
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
