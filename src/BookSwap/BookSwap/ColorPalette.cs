using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BookSwap
{
    public static class ColorPalette
    {
        private static int nextColor = 0;
        public static ColorValues[] ColorValues;
        //public static ColorValues SwapBookColorValues = new ColorValues
        //{
        //    Accent = Color.FromHex("#FFF571"),
        //    DarkAccent = Color.FromHex("#F1EE55"),
        //    ExtraDarkAccent = Color.FromHex("#F3DD3F"),
        //    TitleColor = Color.FromHex("#F00D39"),
        //    AccentTextColor = Color.FromHex("#B7A701"),
        //};

        static ColorPalette()
        {
            ColorValues = new ColorValues[]
            {
                new ColorValues
                {
                    Accent = Color.FromHex("#0FF4C3"),
                    DarkAccent = Color.FromHex("#18E6AE"),
                    ExtraDarkAccent = Color.FromHex("#1BDCA3"),
                    TitleColor = Color.FromHex("#052436"),
                    AccentTextColor = Color.FromHex("#07B399"),
                },
                new ColorValues
                {
                    Accent = Color.FromHex("#B76EFE"), 
                    DarkAccent = Color.FromHex("#A962FD"),
                    ExtraDarkAccent = Color.FromHex("#954AF7"),
                    TitleColor = Color.FromHex("#FFEE78"),
                    AccentTextColor = Color.FromHex("#843CC4")
                },
                new ColorValues
                {
                    Accent = Color.FromHex("#FF848B"), 
                    DarkAccent = Color.FromHex("#F58078"),
                    ExtraDarkAccent = Color.FromHex("#F4625F"),
                    TitleColor = Color.FromHex("#FFFFFF"),
                    AccentTextColor = Color.FromHex("#F9584E")
                },
                new ColorValues
                {
                    Accent = Color.FromHex("#B8E384"), 
                    DarkAccent = Color.FromHex("#A0CF5D"),
                    ExtraDarkAccent = Color.FromHex("#85BE41"),
                    TitleColor = Color.FromHex("#1B3604"),
                    AccentTextColor = Color.FromHex("#628D2E")
                },
                new ColorValues
                {
                    Accent = Color.FromHex("#536CCF"), 
                    DarkAccent = Color.FromHex("#4168CA"),
                    ExtraDarkAccent = Color.FromHex("#3956BC"),
                    TitleColor = Color.FromHex("#FFFFFF"),
                    AccentTextColor = Color.FromHex("#203C9E")
                },
                new ColorValues
                {
                    Accent = Color.FromHex("#FF8CCF"),
                    DarkAccent = Color.FromHex("#FF7BCE"),
                    ExtraDarkAccent = Color.FromHex("#FF6DB9"),
                    TitleColor = Color.FromHex("#FFFFFF"),
                    AccentTextColor = Color.FromHex("#C55190")
                },
            };
        }

        public static ColorValues GetNextColorValues(int colorIndex)
        {
            return ColorValues[colorIndex];
        }

        public static ColorValues GetNextColorValues()
        {
            var colorValues = GetNextColorValues(nextColor);
            nextColor++;
            if (nextColor >= ColorValues.Length)
                nextColor = 0;
            return colorValues;
        }

    }

    public class ColorValues
    {
        public Color Accent { get; set; }
        public Color DarkAccent { get; set; }
        public Color ExtraDarkAccent { get; set; }
        public Color TitleColor { get; set; }
        public Color AccentTextColor { get; set; } 
    }
}
