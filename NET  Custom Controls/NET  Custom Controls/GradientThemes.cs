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
            BlueSky,
            BlueWater,
            Clouds,
            DarkSky,
            DeepSpace,
            Grass,
            JuicyOrange,
            Lime,
            Mango,
            MidnightCity,
            OliveGreen,
            Rastafari,
            RedFire,
            RelaxingRed,
            RoyalBlue,
            Sky,
            Titanium,
            WhiteApple,
            YouTube
        }
        
        public static GradientColor[] GetTheme(Theme theme)
        {
            switch (theme)
            {
                case Theme.BlueWater:
                    return BlueWater;
                case Theme.BlueSky:
                    return BlueSky;
                case Theme.WhiteApple:
                    return WhiteApple;
                case Theme.RedFire:
                    return RedFire;
                case Theme.Lime:
                    return Lime;
                case Theme.Grass:
                    return Grass;
                case Theme.RelaxingRed:
                    return RelaxingRed;
                case Theme.Titanium:
                    return Titanium;
                case Theme.MidnightCity:
                    return MidnightCity;
                case Theme.DeepSpace:
                    return DeepSpace;
                case Theme.Rastafari:
                    return Rastafari;
                case Theme.DarkSky:
                    return DarkSky;
                case Theme.Mango:
                    return Mango;
                case Theme.RoyalBlue:
                    return RoyalBlue;
                case Theme.Sky:
                    return Sky;
                case Theme.Clouds:
                    return Clouds;
                case Theme.JuicyOrange:
                    return JuicyOrange;
                case Theme.YouTube:
                    return YouTube;
                case Theme.OliveGreen:
                    return OliveGreen;
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

        public static GradientColor[] BlueSky
        {
            get
            {
                return new GradientColor[] {
                    new GradientColor() { Color = Color.FromArgb(86, 204, 242), Position = 0 },
                    new GradientColor() { Color = Color.FromArgb(47, 128, 237), Position = 1}
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

        public static GradientColor[] Grass
        {
            get
            {
                return new GradientColor[] {
                    new GradientColor() { Color = Color.FromArgb(0, 192, 0), Position = 0 },
                    new GradientColor() { Color = Color.FromArgb(128, 255, 128), Position = 0.5f},
                    new GradientColor() { Color = Color.FromArgb(0, 192, 0), Position = 1 }
                };
            }
        }

        public static GradientColor[] RelaxingRed
        {
            get
            {
                return new GradientColor[] {
                    new GradientColor() { Color = Color.FromArgb(255, 251, 213), Position = 0 },
                    new GradientColor() { Color = Color.FromArgb(178, 10, 44), Position = 1}
                };
            }
        }

        public static GradientColor[] Titanium
        {
            get
            {
                return new GradientColor[] {
                    new GradientColor() { Color = Color.FromArgb(40, 48, 72), Position = 0 },
                    new GradientColor() { Color = Color.FromArgb(133, 147, 152), Position = 1}
                };
            }
        }

        public static GradientColor[] MidnightCity
        {
            get
            {
                return new GradientColor[] {
                    new GradientColor() { Color = Color.FromArgb(35, 37, 38), Position = 0 },
                    new GradientColor() { Color = Color.FromArgb(65, 67, 69), Position = 1}
                };
            }
        }

        public static GradientColor[] DeepSpace
        {
            get
            {
                return new GradientColor[] {
                    new GradientColor() { Color = Color.FromArgb(0, 0, 0), Position = 0 },
                    new GradientColor() { Color = Color.FromArgb(67, 67, 67), Position = 1}
                };
            }
        }

        public static GradientColor[] Rastafari
        {
            get
            {
                return new GradientColor[] {
                    new GradientColor() { Color = Color.FromArgb(30, 150, 0), Position = 0 },
                    new GradientColor() { Color = Color.FromArgb(255, 242, 0), Position = 0.5f},
                    new GradientColor() { Color = Color.Red, Position = 1}
                };
            }
        }

        public static GradientColor[] DarkSky
        {
            get
            {
                return new GradientColor[] {
                    new GradientColor() { Color = Color.FromArgb(75, 121, 161), Position = 0 },
                    new GradientColor() { Color = Color.FromArgb(40, 62, 81), Position = 1}
                };
            }
        }

        public static GradientColor[] Mango
        {
            get
            {
                return new GradientColor[] {
                    new GradientColor() { Color = Color.FromArgb(255, 226, 89), Position = 0 },
                    new GradientColor() { Color = Color.FromArgb(255, 167, 81), Position = 1}
                };
            }
        }

        public static GradientColor[] RoyalBlue
        {
            get
            {
                return new GradientColor[] {
                    new GradientColor() { Color = Color.FromArgb(83, 105, 118), Position = 0 },
                    new GradientColor() { Color = Color.FromArgb(41, 46, 73), Position = 1}
                };
            }
        }

        public static GradientColor[] Sky
        {
            get
            {
                return new GradientColor[] {
                    new GradientColor() { Color = Color.FromArgb(7, 101, 133), Position = 0 },
                    new GradientColor() { Color = Color.FromArgb(255, 255, 255), Position = 1}
                };
            }
        }

        public static GradientColor[] Clouds
        {
            get
            {
                return new GradientColor[] {
                    new GradientColor() { Color = Color.FromArgb(236, 233, 230), Position = 0 },
                    new GradientColor() { Color = Color.FromArgb(255, 255, 255), Position = 1}
                };
            }
        }

        public static GradientColor[] JuicyOrange
        {
            get
            {
                return new GradientColor[] {
                    new GradientColor() { Color = Color.FromArgb(255, 128, 8), Position = 0 },
                    new GradientColor() { Color = Color.FromArgb(255, 200, 55), Position = 1}
                };
            }
        }

        public static GradientColor[] YouTube
        {
            get
            {
                return new GradientColor[] {
                    new GradientColor() { Color = Color.FromArgb(229, 45, 39), Position = 0 },
                    new GradientColor() { Color = Color.FromArgb(179, 18, 23), Position = 1}
                };
            }
        }

        public static GradientColor[] OliveGreen
        {
            get
            {
                return new GradientColor[] {
                    new GradientColor() { Color = Color.FromArgb(121, 159, 12), Position = 0 },
                    new GradientColor() { Color = Color.FromArgb(172, 187, 120), Position = 1}
                };
            }
        }
    }    

}
