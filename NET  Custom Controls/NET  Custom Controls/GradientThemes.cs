using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace NET__Custom_Controls
{
    public class GradientTheme
    {
        public enum Theme
        {
            Custom,
            BlueWater,
            WhiteApple,
            RedFire,
            Lime
        }

        public static GradientColor[] GetTheme(Theme theme)
        {
            switch (theme)
            {
                case Theme.BlueWater:
                    return BlueWater;
                case Theme.WhiteApple:
                    return WhiteApple;
                case Theme.RedFire:
                    return RedFire;
                case Theme.Lime:
                    return Lime;

                case Theme.Custom:
                default:
                    return null;
            }
        }

        public static GradientColor[] BlueWater
        {
            get
            {
                return new GradientColor[] {
                    new GradientColor() { Color = Color.FromArgb(94,170,251), Position = 0 },
                    new GradientColor() { Color = Color.FromArgb(25, 119, 220), Position = 1}
                };
            }
        }

        public static GradientColor[] WhiteApple
        {
            get
            {
                return new GradientColor[] {
                    new GradientColor() { Color = Color.FromArgb(226, 225, 223), Position = 0 },
                    new GradientColor() { Color = Color.FromArgb(136, 136, 136), Position = 1},
                };
            }
        }

        public static GradientColor[] RedFire
        {
            get
            {
                return new GradientColor[] {
                    new GradientColor() { Color = Color.FromArgb(215,15,15), Position = 0 },
                    new GradientColor() { Color = Color.FromArgb(242,100,52), Position = 1}
                };
            }
        }

        public static GradientColor[] Lime
        {
            get
            {
                return new GradientColor[] {
                    new GradientColor() { Color = Color.FromArgb(255, 255, 255), Position = 0 },
                    new GradientColor() { Color = Color.FromArgb(173, 255, 47), Position = 1}
                };
            }
        }
    }    

}
