using System.Linq;
using System.Collections.Generic;


namespace LadybugDisplaySchema
{
    public partial class LegendParameters 
    {
        public double X => (this.BasePlane?.O?.GetElementByIndex(0)).GetValueOrDefault();
        public double Y => (this.BasePlane?.O?.GetElementByIndex(1)).GetValueOrDefault();
        public double Z => (this.BasePlane?.O?.GetElementByIndex(2)).GetValueOrDefault();

        public double MinValue => this.Min != null && this.Min.Obj is double d ? d : 0;
        public double MaxValue => this.Max != null && this.Max.Obj is double d ? d : 100;
        public double TextHeightValue => this.TextHeight != null && this.TextHeight.Obj is double d ? d : 0;
        public int SegmentCountValue => this.SegmentCount != null && this.SegmentCount.Obj is int d ? d : 3;
        public double SegmentWidthValue => this.SegmentWidth != null && this.SegmentWidth.Obj is double d ? d : 25;
        public double SegmentHeightValue => this.SegmentHeight != null && this.SegmentHeight.Obj is double d ? d : 36;

        public double Width => this.Vertical ? this.SegmentWidthValue : this.SegmentWidthValue * this.SegmentCountValue;
        public double Height => this.Vertical ? this.SegmentHeightValue * this.SegmentCountValue : this.SegmentHeightValue;

        public bool HasOrdinalDictionary => this.OrdinalDictionary != null && this.GetOrdinalDictionary().Count > 0;

        public LegendParameters(int x = 50, int y = 100)
        {
            initDefault();
            this.BasePlane.O = new List<double>() { X, Y, 0 };
            Colors = LegendColorSet.Presets.First().Value.ToList();
        }

        public LegendParameters(double min, double max, int numSegs, List<Color> colors = default)
        {
            initDefault();
            Min = min;
            Max = max;
            SegmentCount = numSegs;

            var c = colors ?? _defaultColorSet.ToList();
            Colors = numSegs > 1 ? c : new List<Color>() { c[0], c[0] };
        }

        private void initDefault()
        {
            this.ResetBaseLocation();
            this.BasePlane.O = new List<double>() { 10, 100, 0 };
            this.SegmentWidth = 25;
            this.SegmentHeight = 36;

            TextHeight = 12;
            Min = 0;
            Max = 100;
            SegmentCount = 3;
            DecimalCount = 2;

            Colors = _defaultColorSet.ToList();
        }

        private List<Color> _defaultColorSet = LegendColorSet.Presets.First().Value.ToList();

        //public System.Drawing.Rectangle GetBoundary => new System.Drawing.Rectangle(this.X, this.Y, this.Width, this.Height);


        private List<double> _colorDomains;
        private List<double> ColorDomains()
        {
            if (_colorDomains != null && _colorDomains.Count == this.Colors.Count)
                return _colorDomains;

            if (this.Colors.Count < 2)
                throw new System.ArgumentException("Need at least 2 colors");

            var cs = this.Colors;
            double factor = 1.0 / (cs.Count - 1);
            var bounds = cs.Select((_, i) => i * factor).ToList();
            _colorDomains = bounds;
            return bounds;
        }
        /// <summary>
        /// Blend between two colors based on input value.
        /// </summary>
        /// <param name="value"></param>
        public Color CalColor(double value, ref Dictionary<double, Color> cache)
        {
            if (cache.TryGetValue(value, out var c))
                return c;
            var newColor = CalColor(value);
            cache.Add(value, newColor);
            return newColor;
        }

        public Color CalColor(double value)
        {

            var colors = this.Colors.ToList();

            var colorStart = colors.First();
            var colorEnd = colors.Last();
            if (value <= this.MinValue)
                return colorStart;
            if (value >= this.MaxValue)
                return colorEnd;

            var range_p = this.MaxValue - this.MinValue;
            var factor = range_p == 0 ? 0 : (value - this.MinValue) / range_p;

            var colorDomains = ColorDomains();
            var segFactor = colorDomains[1];
            var colorFactor = 0.0;
            for (int i = 1; i < colorDomains.Count; i++)
            {
                var cFactorBefore = colorDomains[i - 1];
                var cFactor = colorDomains[i];
                if (factor <= cFactor && factor >= cFactorBefore)
                {
                    colorStart = colors[i - 1];
                    colorEnd = colors[i];
                    colorFactor = (factor - cFactorBefore) / segFactor;
                }
                else
                    continue;
            }

            var newColor = BlendColors(colorFactor, colorStart, colorEnd);

            return newColor;
        }

        private Color BlendColors(double factor, Color c1, Color c2)
        {
            var red = (int)(factor * (c2.R - c1.R) + c1.R);
            var green = (int)(factor * (c2.G - c1.G) + c1.G);
            var blue = (int)(factor * (c2.B - c1.B) + c1.B);

            return new Color(red, green, blue);
        }

        public Dictionary<double, string> GetOrdinalDictionary()
        {
            var ud = ToDictionary(this.OrdinalDictionary);
            return ud;
        }


        private static Dictionary<double, string> ToDictionary(object userData)
        {
            if (userData is Dictionary<double, string> dd)
                return dd;

            var uds = new Dictionary<double, string>();
            Newtonsoft.Json.Linq.JObject jObj = null;
            if (userData is string)
                jObj = Newtonsoft.Json.Linq.JObject.Parse(userData?.ToString());
            else if (userData is Newtonsoft.Json.Linq.JObject j)
                jObj = j;

            if (jObj != null)
            {
                uds = jObj.Children()
                   .OfType<Newtonsoft.Json.Linq.JProperty>()
                   .ToDictionary(_ => double.Parse(_.Name), _ => _.Value.ToString());
            }
            return uds;

        }

        public void ResetBaseLocation(double X = default, double Y = default, double Z = default)
        {
            if (this.BasePlane == null)
                this.BasePlane = new Plane(new Vector3D(0,0,1), new Point3D(X,Y,Z));

            var basePt = new Point3D(X, Y, Z);
            this.BasePlane.O = basePt.ToDecimalList();
        }

    }
}
