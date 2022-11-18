using System;
using System.Text.RegularExpressions;

namespace LadybugDisplaySchema
{
    public class StringComparer : System.Collections.Generic.IComparer<string>
    {
        public StringComparer()
        {
        }
        public int Compare(string x, string y)
        {
            x = x ?? string.Empty;
            y = y ?? string.Empty;

            var rexS = @"^(\D*)"; // non-digis from beginning
            var xS = Regex.Match(x, rexS).Value;
            var yS = Regex.Match(y, rexS).Value;
            var c1 = string.Compare(xS, yS, StringComparison.OrdinalIgnoreCase);

            //starts with the same letters
            if (c1 == 0)
            {
                var rexNo = @"\d+(\.\d)*(\D)*";
                var xIsNo = double.TryParse(Regex.Match(x, rexNo).Value, out var xNo);
                var yIsNo = double.TryParse(Regex.Match(y, rexNo).Value, out var yNo);
                c1 = xIsNo && yIsNo ? xNo.CompareTo(yNo) : c1;
                // if NumX and NumY are the same, then compare the string
                c1 = c1 != 0 ? c1 : string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
            }

            return c1;
        }

    }
}
