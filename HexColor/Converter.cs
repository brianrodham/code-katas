using System;
using System.Collections.Generic;
using System.Text;

namespace HexColor
{
    public class Converter
    {
        public string ColorToHex(int red, int green, int blue)
        {
            return "#" + ToHex(red) + ToHex(green) + ToHex(blue);
        }
        private string ToHex(int value)
        {
            return value.ToString("X2");
        }
    }
}
