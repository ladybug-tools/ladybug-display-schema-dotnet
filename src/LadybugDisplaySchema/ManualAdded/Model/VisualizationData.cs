
using System.Collections.Generic;
using System.Linq;

namespace LadybugDisplaySchema
{

    public partial class VisualizationData
    {
        private static readonly string[] _noneKeys = new string[] { "None", "N/A", "NaN", string.Empty, null };
        public static readonly string NoneKey = "N/A";

        /// <summary>
        /// Possible max value while removing nones values. Max will be double.NaN if no numerical value found.
        /// </summary>
        public double Max { get; set; } = double.NaN;

        /// <summary>
        /// Possible min value while removing nones values. Min will be double.NaN if no numerical value found.
        /// </summary>
        public double Min { get; set; } = double.NaN;

    

        public VisualizationData(List<double> results, LegendParameters legend = default) : this()
        {
            this.Values = results;
            if (HasMinMax(results, out var numBounds))
            {
                this.Max = numBounds.Value.max;
                this.Min = numBounds.Value.min;
            }
            var newLegend = UpdateLegendWithValues(this.Values, legend, numBounds);
            this.LegendParameters = newLegend;
        }


        /// <summary>
        /// This is currently only used in the GlobalRenderer for ColorByProperties
        /// </summary>
        /// <param name="results"></param>
        /// <param name="legend"></param>
        /// <param name="categorizedLegend">This is currently only used in the GlobalRenderer for ColorByProperties</param>
        public VisualizationData(List<string> results, LegendParameters legend, bool categorizedLegend = false) : this()
        {
            this.LegendParameters = legend;
            var isNumber = IsNumberList(results, out var nums, out var numBounds); // checks for None case

            var hasNone = false;
            var allNones = false;


            LegendParameters newLegend;
            if (isNumber && !categorizedLegend)
            {
                // check the raw numbers with double.NaN
                var valueMin = nums.Min();
                var valueMax = nums.Max();

                // check None case which is set to double.NaN
                hasNone = double.IsNaN(valueMin);
                allNones = double.IsNaN(valueMax);

                // only true numbers can have max and min
                if (numBounds.HasValue)
                {
                    this.Max = numBounds.Value.max;
                    this.Min = numBounds.Value.min;
                }

                // update the legend
                this.Values = nums;
                newLegend = UpdateLegendWithValues(this.Values, legend, numBounds);
          
            }
            else
            {
                // this is all categorized
                this.Values = CategorizeValues(results, out var keyMapper);

                // check nones
                var mappers = keyMapper.Values.ToList();
                hasNone = mappers.Any(_ => _ == NoneKey);
                allNones = mappers.All(_ => _ == NoneKey);

                // update the legend
                newLegend = UpdateLegendWithTextValues(legend, keyMapper);
            }

            // check legend title
            if (string.IsNullOrEmpty(newLegend.Title))
                newLegend.Title = this.DataType?.Obj is DataType dd ? (dd.Name ?? dd._DataType.ToString()) : "Legend";

            // check legend unit
            if (!string.IsNullOrEmpty(this.Unit))
                newLegend = newLegend.AddUserData("_unit", this.Unit);

            // set none color to legend
            if (hasNone && !allNones)
            {
                newLegend = newLegend.SetNoneColor(newLegend.GetNoneColorWithDefault());
            }

            this.LegendParameters = newLegend;
        }

        public LegendParameters ValidLegendParameters 
        { 
            get
            {
                this.LegendParameters = UpdateLegendWithValues(this.Values, this.LegendParameters);
                return this.LegendParameters;
            } 
        }

        /// <summary>
        /// Checks all values, and replace Nones ("None", string.Empty, null) with double.NaN
        /// </summary>
        /// <param name="results"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool IsNumberList(List<string> results, out List<double> values, out (double min, double max)? numBounds)
        {
            var gp = results.GroupBy(_ => _noneKeys.Contains(_));
            var hasNone = (gp.FirstOrDefault(_ => _.Key)?.Any()).GetValueOrDefault();
            // check if all the rest values are numbers. If an empty list found, consider it as true to the rest value is number.
            var allRestNums = (gp.FirstOrDefault(_ => !_.Key)?.All(r => double.TryParse(r, out _))).GetValueOrDefault(true);
            values = null;
            numBounds = null;

            if (allRestNums) // all non-None values are numbers
            {
                var noneReplacement = double.NaN;

                // replace all none values with noneReplacement
                values = results.Select(r => double.TryParse(r, out var v) ? v : noneReplacement).ToList();

                // get bounds
                // values.Min() will be NaN if there is any NaN found, Max() will return the max value and ignore the NaN
                HasMinMax(values, out numBounds);
                return true;
            }
            else
            {
                return false;
            }

        }

        private static bool HasMinMax(IEnumerable<double> values, out (double min, double max)? numBounds)
        {
            var nonNaNs = values.Where(_ => !double.IsNaN(_));
            if (nonNaNs.Any())
            {
                numBounds = (nonNaNs.Min(), nonNaNs.Max());
                return true;
            }
            else
            {
                numBounds = (double.NaN, double.NaN);
                return false;
            }
        }

        public static LegendParameters UpdateLegendWithValues(List<double> values, LegendParameters legend, (double min, double max)? numBounds = default)
        {
            var valueMin = values.Min();
            var valueMax = values.Max();

            // check None case which is set to double.NaN
            var hasNone = double.IsNaN(valueMin);
            var allNones = double.IsNaN(valueMax);
            if (numBounds.HasValue && !allNones)
            {
                valueMin = numBounds.Value.min;
                valueMax = numBounds.Value.max;
            }

            // update the legend with the real number values except NaNs
            if (hasNone && !allNones)
                values = values.Where(_ => !double.IsNaN(_)).ToList();

            var distinctCounts = values.Distinct().Count();
            var steps = distinctCounts > 11 ? 11 : distinctCounts;

            if (legend == null)
            {
                legend = new LegendParameters(valueMin, valueMax, steps) { ContinuousLegend = distinctCounts >1};
            }

            var lMin = legend.Min?.Obj;
            var lMax = legend.Max?.Obj;
            if (lMin == null || lMin is Default || lMin is double.NaN)
                legend.Min = valueMin;
            if (lMax == null || lMax is Default || lMax is double.NaN)
                legend.Max = valueMax;

            // reset colors, min, max when previous saved legend is only for one value/color
            if (legend.MinMaxRange == 0 && valueMax>valueMin)
            {
                legend.Min = valueMin;
                legend.Max = valueMax;
                legend.SegmentCount = steps;
                legend.Colors = null;
                legend.ContinuousLegend = distinctCounts > 1;
            }

            var isNumber = !legend.HasOrdinalDictionary;
            if (isNumber)
            {
                if (legend.SegmentCount == null || legend.SegmentCount.Obj is Default)
                    legend.SegmentCount = steps;

                legend.OrdinalDictionary = null;
            }
            else
            {
                // it has ordinal dictionary
                if (legend.SegmentCount == null || legend.SegmentCount.Obj is Default)
                {
                    legend.SegmentCount = legend.GetOrdinalDictionary().Count;
                }
            
                legend.ContinuousLegend = false;
            }

          
             
           return legend;

        }


        public static LegendParameters UpdateLegendWithTextValues(LegendParameters legend, Dictionary<double, string> keyMapper)
        {
            var min = keyMapper.First().Key;
            var max = keyMapper.Last().Key;
            var steps = keyMapper.Count;
            var legendPar = legend ?? new LegendParameters(min, max, steps);
            legendPar = legendPar.DuplicateLegendParameters();


            legendPar.Min = min;
            legendPar.Max = max;
            legendPar.SegmentCount = steps;
            legendPar.OrdinalDictionary = keyMapper;
            legendPar.ContinuousLegend = false;

            return legendPar;
        }

        public static List<double> CategorizeValues(List<string> results, out Dictionary<double, string> mapper)
        {
            var values = Enumerable.Repeat(double.NaN, results.Count).ToList();
            var keyMapper = new Dictionary<double, string>();
            var gps = results.Select((_, i) => new { _, i }).GroupBy(_ => _._).ToList();

            // sort keys
            var comparer = new StringComparer();
            gps = gps.OrderBy(_ => _.Key, comparer).ToList();
            var steps = gps.Count;
            for (int i = 0; i < steps; i++)
            {
                var gp = gps[i];
                var key = _noneKeys.Contains(gp.Key) ? NoneKey : gp.Key;
                keyMapper.Add(i, key);

                foreach (var item in gp)
                {
                    values[item.i] = i;
                }
            }
            mapper = keyMapper;
            return values;


        }

    }
}
