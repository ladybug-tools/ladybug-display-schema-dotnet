using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LadybugDisplaySchema
{

    public partial class VisualizationData
    {
        public VisualizationData(List<double> results, LegendParameters legend)
        {
            this.Values = results;
            this.LegendParameters = legend;
            UpdateLegendWithValues();
        }

        public VisualizationData(List<string> results, LegendParameters legend)
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
                var keyMapper = new Dictionary<double, string>();
                var gps = results.Select((_, i) => new { _, i }).GroupBy(_ => _._).ToList();
                for (int i = 0; i < gps.Count; i++)
                {
                    var gp = gps[i];
                    var key = gp.Key ?? "None";
                    keyMapper.Add(i, key);

                    foreach (var item in gp)
                    {
                        values.Insert(item.i, i);
                        //values[item.i] = i;
                    }
                }
                this.Values = values;

                var min = keyMapper.First().Key;
                var max = keyMapper.Last().Key;
                var count = keyMapper.Count;
                var legendPar = this.LegendParameters ??
                    new LegendParameters(min, max, 10)
                    {
                        ContinuousLegend = false
                    };
                legendPar = legendPar.DuplicateLegendParameters();

                legendPar.Min = legendPar.Min == null || legendPar.Min.Obj is Default ? min : legendPar.Min;
                legendPar.Max = legendPar.Max == null || legendPar.Max.Obj is Default ? max : legendPar.Max;
                legendPar.SegmentCount = legendPar.SegmentCount == null || legendPar.SegmentCount.Obj is Default ? 10 : legendPar.SegmentCount;
                legendPar.OrdinalDictionary = keyMapper;
                legendPar.ContinuousLegend = false;

                this.LegendParameters = legendPar;
            }

        }

        public void UpdateLegendWithValues()
        {
            var isNumber = !LegendParameters.HasOrdinalDictionary;
            if (isNumber)
            {
                var values = this.Values;
                var min = values.Min();
                var max = values.Max();
                var legendPar = this.LegendParameters ?? new LegendParameters(min, max, 10) { ContinuousLegend = true };
                legendPar = legendPar.DuplicateLegendParameters();

                legendPar.Min = legendPar.Min == null || legendPar.Min.Obj is Default ? min : legendPar.Min;
                legendPar.Max = legendPar.Max == null || legendPar.Max.Obj is Default ? max : legendPar.Max;
                legendPar.SegmentCount = legendPar.SegmentCount == null || legendPar.SegmentCount.Obj is Default ? 10 : legendPar.SegmentCount;

                legendPar.OrdinalDictionary = null;
                this.LegendParameters = legendPar;
            }
            else
            {
                // do nothing if it has ordinal dictionary
            }

        }



    }
}
