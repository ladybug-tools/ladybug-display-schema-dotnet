using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace LadybugDisplaySchema
{

    public partial class VisualizationData
    {
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
            this.LegendParameters = legend;
            if (HasMinMax(results, out var numBounds))
            {
                this.Max = numBounds.Value.max;
                this.Min = numBounds.Value.min;
            }
            UpdateLegendWithValues(numBounds);
        }


        public VisualizationData(List<string> results, LegendParameters legend = default) : this()
        {
            this.LegendParameters = legend;
            var isNumber = IsNumberList(results, out var nums, out var numBounds); // checks for None case
            var values = new List<double>(results.Count);

            if (numBounds.HasValue)
            {
                this.Max = numBounds.Value.max;
                this.Min = numBounds.Value.min;
            }
            
            if (isNumber)
            {
                this.Values = nums;
                UpdateLegendWithValues(numBounds);

            }
            else
            {

                values = Enumerable.Repeat(double.NaN, results.Count).ToList();
                var keyMapper = new Dictionary<double, string>();
                var gps = results.Select((_, i) => new { _, i }).GroupBy(_ => _._).ToList();

                // sort keys
                var comparer = new StringComparer();
                gps = gps.OrderBy(_ => _.Key, comparer).ToList();
                var steps = gps.Count;
                for (int i = 0; i < steps; i++)
                {
                    var gp = gps[i];
                    var key = gp.Key ?? "None";
                    keyMapper.Add(i, key);
                    
                    foreach (var item in gp)
                    {
                        values[item.i] = i;
                    }
                }
                this.Values = values;

                var min = keyMapper.First().Key;
                var max = keyMapper.Last().Key;
                //var count = keyMapper.Count;
                var legendPar = this.LegendParameters ?? new LegendParameters(min, max, steps);
                legendPar = legendPar.DuplicateLegendParameters();

                legendPar.Min = min;
                legendPar.Max = max;
                legendPar.SegmentCount = steps;
                legendPar.OrdinalDictionary = keyMapper;
                legendPar.ContinuousLegend = false;

                this.LegendParameters = legendPar;
            }

        }

        public LegendParameters ValidLegendParameters 
        { 
            get
            {
                UpdateLegendWithValues();
                return this.LegendParameters;
            } 
        }

        /// <summary>
        /// Checks all values 
        /// </summary>
        /// <param name="results"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool IsNumberList(List<string> results, out List<double> values, out (double min, double max)? numBounds)
        {
            var noneKeys = new string[] { "None", string.Empty, null };
            var gp = results.GroupBy(_ => noneKeys.Contains(_));
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

        public void UpdateLegendWithValues((double min, double max)? numBounds = default)
        {
            var legend = this.LegendParameters;
            var valueMin = this.Values.Min();
            var valueMax = this.Values.Max();
            var values = this.Values;

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

            //legend.Min = legend.Min == null || legend.Min.Obj is Default || legend.Min.Obj is double.NaN ? valueMin : legend.Min;
            //legend.Max = legend.Max == null || legend.Max.Obj is Default || legend.Max.Obj is double.NaN ? valueMax : legend.Max;

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

            if (string.IsNullOrEmpty(legend.Title))
                legend.Title = this.DataType?.Obj is DataType dd ? (dd.Name ?? dd._DataType.ToString()) : "Legend";

            if (!string.IsNullOrEmpty(this.Unit))
                legend = legend.AddUserData("_unit", this.Unit);


            if (hasNone && !allNones)
            {
                legend = legend.SetNoneColor(legend.GetNoneColorWithDefault());
            }
             
            this.LegendParameters = legend;

        }



    }
}
