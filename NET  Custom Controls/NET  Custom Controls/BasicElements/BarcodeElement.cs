using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace NET__Custom_Controls.BasicElements
{
    [ToolboxItem(false)]
    public partial class BarcodeElement : UserControl
    {
        protected enum BarcodeType
        {
            None,
            EAN13
        }

        protected enum PatternType
        {
            Start,
            Center,
            Stop,
            Normal
        }

        public BarcodeElement()
        {
            InitializeComponent();
        }

        protected BarcodeType CurrentBarcodeType = BarcodeType.None;

        [Category("Barcode Size")]
        public int StartBarHeight
        {
            get { return _StartBarHeight; }
            set { _StartBarHeight = value; Invalidate(); }
        }
        private int _StartBarHeight = 70;

        [Category("Barcode Size")]
        public int CenterBarHeight
        {
            get { return _CenterBarHeight; }
            set { _CenterBarHeight = value; Invalidate(); }
        }
        private int _CenterBarHeight = 70;

        [Category("Barcode Size")]
        public int StopBarHeight
        {
            get { return _StopBarHeight; }
            set { _StopBarHeight = value; Invalidate(); }
        }
        private int _StopBarHeight = 70;

        [Category("Barcode Size")]
        public int BarHeight
        {
            get { return _BarHeight; }
            set { _BarHeight = value; Invalidate(); }
        }
        private int _BarHeight = 50;

        [Category("Barcode Size")]
        public int BarWidth
        {
            get { return _BarWidth; }
            set { _BarWidth = value; Invalidate(); }
        }
        private int _BarWidth = 2;

        [Category("Barcode Margin")]
        public int MarginTop
        {
            get { return _MarginTop; }
            set { _MarginTop = value; Invalidate(); }
        }
        private int _MarginTop = 5;

        [Category("Barcode Margin")]
        public int MarginLeft
        {
            get { return _MarginLeft; }
            set { _MarginLeft = value; Invalidate(); }
        }
        private int _MarginLeft = 5;

        [Category("Barcode Margin")]
        public int MarginRight
        {
            get { return _MarginRight; }
            set { _MarginRight = value; Invalidate(); }
        }
        private int _MarginRight = 5;

        [Category("Barcode Margin")]
        public int MarginBottom
        {
            get { return _MarginBottom; }
            set { _MarginBottom = value; Invalidate(); }
        }
        private int _MarginBottom = 5;

        [Category("Barcode")]
        public string Barcode
        {
            get { return _Barcode; }
            set { _Barcode = value; Invalidate(); }
        }
        private string _Barcode;

        protected bool ValidateBarcode(string barcode)
        {
            if (string.IsNullOrEmpty(barcode))
                return false;

            switch (CurrentBarcodeType)
            {
                case BarcodeType.EAN13:
                    if (!Regex.IsMatch(barcode, "^[0-9]{13}$"))
                        return false;

                    int multiplier = 1;
                    int sum = 0;
                    int currentCheckDigit = int.Parse(barcode[12].ToString());

                    for (var i = 0; i < 12; i++)
                    {
                        int digit = int.Parse(barcode[i].ToString());
                        sum += (digit * multiplier);
                        multiplier = multiplier == 1 ? 3 : 1;
                    }

                    int calculatedCheckDigit = 10 - (sum % 10);

                    if (calculatedCheckDigit == 10)
                        calculatedCheckDigit = 0;

                    return calculatedCheckDigit == currentCheckDigit;
                default:
                    return false;
            }
        }

        protected void DrawEAN13(PaintEventArgs e)
        {
            string[] codeR = new string[] {
                "1110010", "1100110", "1101100", "1000010", "1011100",
                "1001110", "1010000", "1000100", "1001000", "1110100"
            };

            string[] codeG = new string[]{
                "0100111", "0110011", "0011011", "0100001", "0011101",
                "0111001", "0000101", "0010001", "0001001", "0010111"
            };

            string[] codeL = new string[]{
                "0001101", "0011001", "0010011", "0111101", "0100011",
                "0110001", "0101111", "0111011", "0110111", "0001011"
            };

            string[] patternForEachBar = new string[] {
                "LLLLLL", "LLGLGG", "LLGGLG", "LLGGGL", "LGLLGG",
                "LGGLLG", "LGGGLL", "LGLGLG", "LGLGGL", "LGGLGL"
            };

            string start = "101";
            string center = "01010";
            string stop = "101";

            // Example 2 412345 678901
            // firstDigit = 2
            // firstSixDigits = 412345
            // lastSixDigits = 678901

            int firstDigit = int.Parse(Barcode.Substring(0,1));
            string firstSixDigits = Barcode.Substring(1,6);
            string lastSixDigits = Barcode.Substring(7,6);

            // Draw START
            DrawBar(start, PatternType.Start, e);

            // Draw First Six Digits
            for (var i = 0; i < firstSixDigits.Length; i++)
            {
                string barPattern = "";
                string barsPattern = patternForEachBar[firstDigit];
                char patternGroup = barsPattern[i];

                int currentDigit = int.Parse(firstSixDigits[i].ToString());

                if (patternGroup == 'L')
                    barPattern = codeL[currentDigit];
                else if (patternGroup == 'G')
                    barPattern = codeG[currentDigit];

                DrawBar(barPattern, PatternType.Normal, e);
            }
            // Draw Center
            DrawBar(center, PatternType.Center, e);

            // Draw Last Six Digits
            for (var i = 0; i < lastSixDigits.Length; i++)
            {
                int currentDigit = int.Parse(lastSixDigits[i].ToString());
                string barPattern = codeR[currentDigit];

                DrawBar(barPattern, PatternType.Normal, e);
            }
            // Draw Stop
            DrawBar(stop, PatternType.Stop, e);
        }

        private int CurrentLinePositionX = 0;
        private int CurrentLinePositionY = 0;
        private int MaxBarcodeWidth = 0;
        private int MaxBarcodeHeight = 0;

        protected void DrawBar(string pattern, PatternType patternType, PaintEventArgs e)
        {

            for (var i = 0; i < pattern.Length; i++)
            {
                char currentDigit = pattern[i];

                for (var j = 0; j < BarWidth; j++)
                {
                    int height = 0;

                    switch (patternType)
                    {
                        case PatternType.Start:
                            height = StartBarHeight;
                            break;
                        case PatternType.Center:
                            height = CenterBarHeight;
                            break;
                        case PatternType.Stop:
                            height = StopBarHeight;
                            break;
                        case PatternType.Normal:
                        default:
                            height = BarHeight;
                            break;
                    }

                    if (currentDigit == '1')
                    {
                        if (MaxBarcodeHeight < CurrentLinePositionY + height)
                            MaxBarcodeHeight = CurrentLinePositionY + height;

                        e.Graphics.DrawLine(Pens.Black, new Point(CurrentLinePositionX, CurrentLinePositionY), new Point(CurrentLinePositionX, CurrentLinePositionY + height));
                    }

                    CurrentLinePositionX++;
                    MaxBarcodeWidth++;
                }
            }

        }

        protected void DrawError(PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.Red,2), new Point(0, 0), new Point(Width, Height));
            e.Graphics.DrawLine(new Pen(Color.Red,2), new Point(Width, 0), new Point(0, Height));
            e.Graphics.DrawRectangle(new Pen(Color.Black, 2), e.ClipRectangle);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);

            if (ValidateBarcode(Barcode))
            {
                CurrentLinePositionX = MarginLeft;
                CurrentLinePositionY = MarginTop;

                MaxBarcodeHeight = 0;
                MaxBarcodeWidth = 0;

                switch (CurrentBarcodeType)
                {
                    case BarcodeType.EAN13:
                        DrawEAN13(e);
                        break;
                    default:
                        break;
                }

                Width = MaxBarcodeWidth + MarginLeft + MarginRight;
                Height = MaxBarcodeHeight + MarginTop + MarginBottom;
            }
            else
            {
                DrawError(e);
            }

        }
    }
}
