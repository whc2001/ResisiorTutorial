using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;

namespace ResisiorTutorial
{
    internal class ResistorHelper
    {
        private static readonly List<Color> avalibleColors = new List<Color>
        {
            Color.Black,
            Color.Brown,
            Color.Red,
            Color.Orange,
            Color.Yellow,
            Color.Green,
            Color.Blue,
            Color.Purple,
            Color.Gray,
            Color.White
        };

        public static long GetValueFromColor(Color[] colors)
        {
            if (colors.Length < 4 || colors.Length > 6)
                throw new ArgumentException("色环数不正确!");
            long value = 0;
            for (int i = 0; i < colors.Length - 2; i++)
            {
                if (avalibleColors.Contains(colors[i]))
                    value = value * 10 + avalibleColors.IndexOf(colors[i]);
            }
            value *= (long)Math.Pow(10, avalibleColors.IndexOf(colors[colors.Length - 1]));
            return value;
        }

        public static Color[] GetColorFromValue(long value, bool fiveBands)
        {
            List<Color> color = new List<Color>();
            string realVal = "000";
            int power = 0;
            while (value > (fiveBands ? 999 : 99))
            {
                value /= 10;
                power++;
            }
            if (power > 9)
                throw new ArgumentException("输入的值对于" + (fiveBands ? "五" : "四") + "色环电阻过大!");
            realVal = value.ToString().Replace(".", "").Substring(0, fiveBands ? 3 : 2);
            foreach (char c in realVal)
                color.Add(avalibleColors[int.Parse(c.ToString())]);
            color.Add(avalibleColors[power]);
            return color.ToArray();
        }

        //"4.7K" -> 4700
        public static long ExpressToValue(string express)
        {
            double value;
            Regex r = new Regex(@"^([\d.]+)((K|M)?)$", RegexOptions.Compiled);
            Match m = r.Match(express.Trim().ToUpper());
            if (m.Success)
            {
                value = double.Parse(m.Groups[1].Value);
                if (m.Groups[2].Value == "K")
                    value *= 1000;
                else if (m.Groups[2].Value == "M")
                    value *= 1000000;
                return (long)value;
            }
            else
                throw new ArgumentException("输入字符串格式不正确!");
        }

        //4700 -> "4.7K"
        public static string ValueToExpress(long value)
        {
            if (value >= 1000000)
                return (value / 1000000D).ToString() + "M";
            else if (value >= 1000)
                return (value / 1000D).ToString() + "K";
            else
                return value.ToString();
        }
    }
}
