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
            EAN8,
            EAN13
        }

        protected enum PatternType
        {
            Start,
            Center,
            Stop,
            Normal
        }

        private int CurrentLinePositionX = 0;
        private int CurrentLinePositionY = 0;
        private int MaxBarcodeWidth = 0;
        private int MaxBarcodeHeight = 0;

        private int StartLeftControlBar = 0;
        private int EndLeftControlBar = 0;

        private int StartCenterControlBar = 0;
        private int EndCenterControlBar = 0;

        private int StartRightControlBar = 0;
        private int EndRightControlBar = 0;

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
            get { return _MarginTop * BarWidth; }
            set { _MarginTop = value; Invalidate(); }
        }
        private int _MarginTop = 1;

        [Category("Barcode Margin")]
        public int MarginLeft
        {
            get { return _MarginLeft * BarWidth; }
            set { _MarginLeft = value; Invalidate(); }
        }
        private int _MarginLeft = 1;

        [Category("Barcode Margin")]
        public int MarginRight
        {
            get { return _MarginRight * BarWidth; }
            set { _MarginRight = value; Invalidate(); }
        }
        private int _MarginRight = 1;

        [Category("Barcode Margin")]
        public int MarginBottom
        {
            get { return _MarginBottom * BarWidth; }
            set { _MarginBottom = value; Invalidate(); }
        }
        private int _MarginBottom = 1;

        [Category("Barcode")]
        public string Barcode
        {
            get { return _Barcode; }
            set { _Barcode = value; Invalidate(); }
        }
        private string _Barcode;

        [Category("Appearance")]
        [Browsable(true)]
        public override Font Font
        {
            get { return _Font; }
            set { _Font = value; Invalidate(); }
        }
        private Font _Font;

        protected void SetMargin(int left, int top, int right, int bottom)
        {
            MarginLeft = left;
            MarginTop = top;
            MarginRight = right;
            MarginBottom = bottom;
        }
        private bool ValidateBarcode(string barcode)
        {
            if (string.IsNullOrEmpty(barcode))
                return false;

            switch (CurrentBarcodeType)
            {
                case BarcodeType.EAN13:
                    if (!Regex.IsMatch(barcode, "^[0-9]{13}$"))
                        return false;
                    return IsCheckDigitValid(barcode, 1);

                case BarcodeType.EAN8:
                    if (!Regex.IsMatch(barcode, "^[0-9]{8}$"))
                        return false;
                    return IsCheckDigitValid(barcode, 3);
                default:
                    return false;
            }
        }
        protected bool IsCheckDigitValid(string barcode, int multiplier)
        {
            int sum = 0;
            int currentCheckDigit = int.Parse(barcode.Last().ToString());

            for (var i = 0; i < barcode.Length - 1; i++)
            {
                int digit = int.Parse(barcode[i].ToString());
                sum += (digit * multiplier);
                multiplier = multiplier == 1 ? 3 : 1;
            }

            int calculatedCheckDigit = 10 - (sum % 10);

            if (calculatedCheckDigit == 10)
                calculatedCheckDigit = 0;

            return calculatedCheckDigit == currentCheckDigit;
        }

        private void DrawEAN13(PaintEventArgs e)
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

            // Example 2 412345 678901
            // firstDigit = 2
            // firstSixDigits = 412345
            // lastSixDigits = 678901

            int firstDigit = int.Parse(Barcode.Substring(0,1));
            string firstSixDigits = Barcode.Substring(1,6);
            string lastSixDigits = Barcode.Substring(7,6);

            // Draw START
            DrawLeftControlBar(e);

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
            DrawCenterControlBar(e);

            // Draw Last Six Digits
            for (var i = 0; i < lastSixDigits.Length; i++)
            {
                int currentDigit = int.Parse(lastSixDigits[i].ToString());
                string barPattern = codeR[currentDigit];

                DrawBar(barPattern, PatternType.Normal, e);
            }
            // Draw Stop
            DrawRightControlBar(e);
        }
        private void DrawEAN8(PaintEventArgs e)
        {
            string[] codeR = new string[] {
                "1110010", "1100110", "1101100", "1000010", "1011100",
                "1001110", "1010000", "1000100", "1001000", "1110100"
            };

            string[] codeL = new string[]{
                "0001101", "0011001", "0010011", "0111101", "0100011",
                "0110001", "0101111", "0111011", "0110111", "0001011"
            };

            string firstFourDigits = Barcode.Substring(0,4);
            string lastFourDigits = Barcode.Substring(4,4);


            // Draw START
            DrawLeftControlBar(e);

            // Draw First Four Digits
            for (var i = 0; i < firstFourDigits.Length; i++)
            {
                int currentDigit = int.Parse(firstFourDigits[i].ToString());
                string barPattern = codeL[currentDigit];

                DrawBar(barPattern, PatternType.Normal, e);
            }
            // Draw Center
            DrawCenterControlBar(e);

            // Draw Last Four Digits
            for (var i = 0; i < lastFourDigits.Length; i++)
            {
                int currentDigit = int.Parse(lastFourDigits[i].ToString());
                string barPattern = codeR[currentDigit];

                DrawBar(barPattern, PatternType.Normal, e);
            }
            // Draw Stop
            DrawRightControlBar(e);
        }

        private void DrawLeftControlBar(PaintEventArgs e, string pattern = "101")
        {
            StartLeftControlBar = CurrentLinePositionX + BarWidth;
            DrawBar(pattern, PatternType.Start, e);
            EndLeftControlBar = CurrentLinePositionX - BarWidth;
        }
        private void DrawCenterControlBar(PaintEventArgs e , string pattern = "01010")
        {
            StartCenterControlBar = CurrentLinePositionX + BarWidth;
            DrawBar(pattern, PatternType.Center, e);
            EndCenterControlBar = CurrentLinePositionX - BarWidth;
        }
        private void DrawRightControlBar(PaintEventArgs e, string pattern = "101")
        {
            StartRightControlBar = CurrentLinePositionX + BarWidth;
            DrawBar(pattern, PatternType.Stop, e);
            EndRightControlBar = CurrentLinePositionX - BarWidth;
        }
        private void DrawBar(string pattern, PatternType patternType, PaintEventArgs e)
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
                        var textSize = MeasureText("0");
                        if (MaxBarcodeHeight < CurrentLinePositionY + height + textSize.Height)
                            MaxBarcodeHeight = CurrentLinePositionY + height + textSize.Height;

                        e.Graphics.DrawLine(Pens.Black, new Point(CurrentLinePositionX, CurrentLinePositionY), new Point(CurrentLinePositionX, CurrentLinePositionY + height));
                    }

                    CurrentLinePositionX++;
                    MaxBarcodeWidth++;
                }
            }

        }
        private void DrawCode(PaintEventArgs e)
        {
            switch (CurrentBarcodeType)
            {
                case BarcodeType.EAN13:
                    char firstDigit = Barcode[0];
                    string firstSixDigits = Barcode.Substring(1,6);
                    string lastSixDigits = Barcode.Substring(7,6);

                    e.Graphics.DrawString(firstDigit.ToString(), Font, Brushes.Black, FirstDigitBeforeLeftControlPoint(firstDigit));
                    e.Graphics.DrawString(firstSixDigits, Font, Brushes.Black, FirstGroupOfDigitsPoint(firstSixDigits));
                    e.Graphics.DrawString(lastSixDigits, Font, Brushes.Black, LastGroupOfDigitsPoint(lastSixDigits));
                    break;

                case BarcodeType.EAN8:
                    string firstFourDigits = Barcode.Substring(0,4);
                    string lastFourDigits = Barcode.Substring(4,4);

                    e.Graphics.DrawString(firstFourDigits, Font, Brushes.Black, FirstGroupOfDigitsPoint(firstFourDigits));
                    e.Graphics.DrawString(lastFourDigits, Font, Brushes.Black, LastGroupOfDigitsPoint(lastFourDigits));
                    break;

                default:
                    break;
            }
        }
        private void DrawError(PaintEventArgs e)
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
                    case BarcodeType.EAN8:
                        DrawEAN8(e);
                        break;
                    default:
                        break;
                }

                DrawCode(e);

                Width = MaxBarcodeWidth + MarginLeft + MarginRight;
                Height = MaxBarcodeHeight + MarginTop + MarginBottom;
            }
            else
            {
                DrawError(e);
            }

        }

        private Size MeasureText(string text)
        {
            return TextRenderer.MeasureText(text, Font);
        }
        private Point FirstDigitBeforeLeftControlPoint(char digit)
        {
            return new Point(StartLeftControlBar - MeasureText(digit.ToString()).Width, BarHeight + MarginTop);
        }
        private Point FirstGroupOfDigitsPoint(string digits)
        {
            var controlBarDistance = StartCenterControlBar - EndLeftControlBar;
            var textSize = MeasureText(digits);
            var margin = (controlBarDistance - textSize.Width) / 2;

            return new Point(EndLeftControlBar + margin, BarHeight + MarginTop);
        }
        private Point LastGroupOfDigitsPoint(string digits)
        {
            var controlBarDistance = StartRightControlBar - EndCenterControlBar;
            var textSize = MeasureText(digits);
            var margin = (controlBarDistance - textSize.Width) / 2;

            return new Point(EndCenterControlBar + margin, BarHeight + MarginTop);
        }
    }
}
