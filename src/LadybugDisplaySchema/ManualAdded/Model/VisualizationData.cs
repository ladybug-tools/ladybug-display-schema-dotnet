using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace LadybugDisplaySchema
{

    public partial class VisualizationData
    {
        public VisualizationData(List<double> results, LegendParameters legend = default)
        {
            this.Values = results;
            this.LegendParameters = legend;
            UpdateLegendWithValues();
        }


        public VisualizationData(List<string> results, LegendParameters legend = default)
        {
            this.LegendParameters = legend;
            var isNumber = results.All(_ => double.TryParse(_, out var n));
            var values = new List<double>(results.Count);
            if (isNumber)
            {
                values = results.Select(_ => double.Parse(_)).ToList();
                this.Values = values;
                UpdateLegendWithValues();

            }
            else
            {

                values = Enumerable.Repeat(-99.0, results.Count).ToList();
                var keyMapper = new Dictionary<double, string>();
                var gps = results.Select((_, i) => new { _, i }).GroupBy(_ => _._).ToList();

                // sort keys
                var comparer = new StringComparer();
                gps = gps.OrderByDescending(_ => _.Key, comparer).ToList();
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
                var count = keyMapper.Count;
                var legendPar = this.LegendParameters ?? new LegendParameters(min, max, steps);
                legendPar = legendPar.DuplicateLegendParameters();

                legendPar.Min = legendPar.Min == null || legendPar.Min.Obj is Default ? min : legendPar.Min;
                legendPar.Max = legendPar.Max == null || legendPar.Max.Obj is Default ? max : legendPar.Max;
                legendPar.SegmentCount = legendPar.SegmentCount == null || legendPar.SegmentCount.Obj is Default ? steps : legendPar.SegmentCount;
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
        public void UpdateLegendWithValues()
        {
            var legend = this.LegendParameters;
            if (legend == null)
            {
                var values = this.Values;
                var min = values.Min();
                var max = values.Max();
                legend = new LegendParameters(min, max, 10) { ContinuousLegend = true};
            }
            //legend = legend.DuplicateLegendParameters();

            var isNumber = !legend.HasOrdinalDictionary;
            if (isNumber)
            {
                var values = this.Values;

                legend.Min = legend.Min == null || legend.Min.Obj is Default ? values.Min() : legend.Min;
                legend.Max = legend.Max == null || legend.Max.Obj is Default ? values.Max() : legend.Max;

                if (legend.SegmentCount == null || legend.SegmentCount.Obj is Default)
                {
                    var distinctCounts = values.Distinct().Count();
                    var steps = distinctCounts > 10 ? 10 : distinctCounts;
                    legend.SegmentCount = steps;
                }

                legend.OrdinalDictionary = null;
            }
            else
            {

                legend.Min = legend.Min == null || legend.Min.Obj is Default ? this.Values.Min() : legend.Min;
                legend.Max = legend.Max == null || legend.Max.Obj is Default ? this.Values.Max() : legend.Max;
                // it has ordinal dictionary
                if (legend.SegmentCount == null || legend.SegmentCount.Obj is Default)
                {
                    legend.SegmentCount = legend.GetOrdinalDictionary().Count;
                }
            
                legend.ContinuousLegend = false;
            }

            this.LegendParameters = legend;

        }



    }
}
