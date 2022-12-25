using System.Linq;
using System.Collections.Generic;


namespace LadybugDisplaySchema
{
    public partial class LegendParameters
    {

        protected LegendParameters()
        {
            this.Type = "LegendParameters";
        }

        public double MinValue => GetValue(this.Min, 0);
        public double MaxValue => GetValue(this.Max, 100);

        public int SegmentCountValue => this.SegmentCount != null && this.SegmentCount.Obj is int d ? d : 11;


        #region 2D Helpers
        public double X2D
        {
            get
            {
                Check2DLegend();
                return GetPxValue(this.Properties2d.OriginX);
            }
        }
        public double Y2D
        {
            get
            {
                Check2DLegend();
                return GetPxValue(this.Properties2d.OriginY);
            }
        }

        public double SegmentWidth2D {
            get {
                Check2DLegend();
                return GetPxValue(this.Properties2d.SegmentWidth);
            }
        }
        public double SegmentHeight2D
        {
            get
            {
                Check2DLegend();
                return GetPxValue(this.Properties2d.SegmentHeight);
            }
        }

        public double Width2D => this.Vertical ? this.SegmentWidth2D : this.SegmentWidth2D * this.SegmentCountValue;
        public double Height2D => this.Vertical ? this.SegmentHeight2D * this.SegmentCountValue : this.SegmentHeight2D;
        public double TextHeight2D
        {
            get
            {
                Check2DLegend();
                return GetPxValue(this.Properties2d.TextHeight);
            }
        }

        #endregion

        #region 3D helpers
        public double SegmentHeight3D
        {
            get
            {
                Check3DLegend();
                return GetValue(this.Properties3d.SegmentHeight);
            }
        }
        public double SegmentWidth3D
        {
            get
            {
                Check3DLegend();
                return GetValue(this.Properties3d.SegmentWidth);
            }
        }
        public double TextHeight3D
        {
            get
            {
                Check3DLegend();
                return GetValue(this.Properties3d.TextHeight);
            }
        }
        public double X3D
        {
            get
            {
                Check3DLegend();
                return GetValue(this.Properties3d.BasePlane?.O[0]);
            }
        }
        public double Y3D
        {
            get
            {
                Check3DLegend();
                return GetValue(this.Properties3d.BasePlane?.O[1]);
            }
        }
        public double Z3D
        {
            get
            {
                Check3DLegend();
                return GetValue(this.Properties3d.BasePlane?.O[2]);
            }
        }
        #endregion

        public bool HasOrdinalDictionary => this.OrdinalDictionary != null && this.GetOrdinalDictionary().Count > 0;

        public List<Color> ColorsWithDefault => this.Colors ?? _defaultColorSet.ToList();

        public LegendParameters(int x = 50, int y = 100): this()
        {
            init2DDefault();
            Min = 0;
            Max = 100;
            SegmentCount = 11;
            DecimalCount = 2;

            Reset2DBaseLocation(x, y);
            Colors = _defaultColorSet.ToList();
        }

        public LegendParameters(double min, double max, int numSegs, List<Color> colors = default) : this()
        {
            init2DDefault();
            DecimalCount = 2;

            Min = min;
            Max = max;
            SegmentCount = numSegs;

            var c = colors ?? _defaultColorSet.ToList();
            Colors = numSegs > 1 ? c : new List<Color>() { c[0], c[0] };
        }

        private Legend2DParameters init2DDefault()
        {
            this.Reset2DBaseLocation(10,100);
            this.Map2DLegendTo1080p();
            return this.Properties2d;
        }

        private Legend3DParameters init3DDefault()
        {
            this.Reset3DBaseLocation(0, 0);
            return this.Properties3d;
        }

        private List<Color> _defaultColorSet = LegendColorSet.Presets.First().Value.ToList();

        //public System.Drawing.Rectangle GetBoundary => new System.Drawing.Rectangle(this.X, this.Y, this.Width, this.Height);


        private List<double> _colorDomains;
        private List<double> ColorDomains()
        {
            var cs = this.ColorsWithDefault;
            if (_colorDomains != null && _colorDomains.Count == cs.Count)
                return _colorDomains;

            if (cs.Count < 2)
                throw new System.ArgumentException("Need at least 2 colors");

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
            var colors = this.ColorsWithDefault.ToList();
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

        public void Reset2DBaseLocation(double X = default, double Y = default)
        {
            if (this.Properties2d == null) 
                this.Properties2d = new Legend2DParameters(originX: $"{X}{_pxUnit}", originY: $"{Y}{_pxUnit}");

            this.Properties2d.OriginX = $"{X}{_pxUnit}";
            this.Properties2d.OriginY = $"{Y}{_pxUnit}";
            
        }

        public void Reset3DBaseLocation(double X = default, double Y = default, double Z = default)
        {
            if (this.Properties3d == null)
                this.Properties3d = new Legend3DParameters(new Plane(Vector3D.FromXYZ(0, 0, 1), Point3D.FromXYZ(X, Y, Z)));

            if (this.Properties3d.BasePlane == null)
                this.Properties3d.BasePlane = new Plane(Vector3D.FromXYZ(0, 0, 1), Point3D.FromXYZ(X, Y, Z));

            var basePt = Point3D.FromXYZ(X, Y, Z);
            this.Properties3d.BasePlane.O = basePt.ToDecimalList();
        }

        private void Check2DLegend()
        {
            if (this.Properties2d == null)
                this.init2DDefault();
            else
                this.Map2DLegendTo1080p(); // get or assign default values
        }


        public Legend2DParameters Map2DLegendTo1080p() => Map2DLegendToPixel();
        public Legend2DParameters Map2DLegendTo2160p() => Map2DLegendToPixel(2160, 3840);
        public Legend2DParameters Map2DLegendToPixel(int viewWidth = 1080, int viewHeight = 1920)
        {
            var l = this.Properties2d ?? new Legend2DParameters();
            l.TextHeight = ToPxValue(l.TextHeight, 12, viewHeight);
            l.SegmentWidth = ToPxValue(l.SegmentWidth, 25, viewWidth);
            l.SegmentHeight = ToPxValue(l.SegmentHeight, 36, viewHeight);
            l.OriginX = ToPxValue(l.OriginX, 10, viewWidth);
            l.OriginY = ToPxValue(l.OriginY, 100, viewHeight);
            this.Properties2d = l;
            return this.Properties2d;
        }

        private void Check3DLegend()
        {
            if (this.Properties3d == null)
                this.init3DDefault();
            else
            {
                // get or assign default values
                var l = this.Properties3d;
                l.BasePlane = l.BasePlane ?? new Plane(Vector3D.FromXYZ(0, 0, 1), Point3D.FromXYZ(0, 0, 0));
                l.TextHeight = GetValue(l.TextHeight, 12);
                l.SegmentWidth = GetValue(l.SegmentWidth, 25);
                l.SegmentHeight = GetValue(l.SegmentHeight, 36);
                this.Properties3d = l;
            }
        }

        private const string _pxUnit = "px";
        private const string _percentUnit = "%";
        private static string ToPxValue(AnyOf<Default, string> input, double defaultPxValue, int viewSize)
        {
            var value = defaultPxValue;
            if (input == null || input.Obj is Default)
                value = defaultPxValue;
            else if (input.Obj is string ss)
            {
                ss = ss.ToLower().Trim();
                if (ss.Contains(_pxUnit))
                {
                    ss = ss.Replace(_pxUnit, "");
                    double.TryParse(ss, out value);
                }
                else if (ss.Contains(_percentUnit))
                {
                    ss = ss.Replace(_percentUnit, "");
                    var done = double.TryParse(ss, out var percentValue);
                    value = done? percentValue / 100 * viewSize : defaultPxValue;

                }
                else value = defaultPxValue;
            }
            else
                value = defaultPxValue;

            return $"{value}{_pxUnit}";
        }
        private static double GetPxValue(AnyOf<Default, string> input)
        {
            var value = 0.0;
            if (input.Obj is string ss)
            {
                ss = ss.ToLower().Trim();
                if (ss.Contains(_pxUnit))
                {
                    ss = ss.Replace(_pxUnit, "");
                    double.TryParse(ss, out value);
                }
            }
            else
                value = 0.0;

            return value;
        }
        private static double GetValue(AnyOf<Default, double> input, double defaultValue = default)
        {
            return input != null && input.Obj is double d ? d : defaultValue;
        }
        //private double GetValue(AnyOf<Default, string> input, double defaultValue, out Unit unit)
        //{

        //    if (input.Obj is Default)
        //        return defaultValue;
        //    else if (input.Obj is string ss)
        //    {

        //    }


        //}

        //enum Unit
        //{
        //    px,
        //    percent
        //}
    }
}
