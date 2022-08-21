
using System.Collections.Generic;
using System.Linq;

namespace LadybugDisplaySchema
{
    public partial class AnalysisGeometry
    {
        public AnalysisGeometry(Mesh3D geometry, VisualizationData dataSets)
            : this( new List<IGeometry>() { geometry }, new List<VisualizationData> { dataSets })
        {
        }

        public AnalysisGeometry(List<Mesh3D> geometry, List<VisualizationData> dataSets)
            :this(geometry.OfType<IGeometry>(), dataSets)
        {
        }
        public AnalysisGeometry(Polyface3D geometry, VisualizationData dataSets)
           : this(new List<IGeometry>() { geometry }, new List<VisualizationData> { dataSets })
        {
        }

        public AnalysisGeometry(List<Polyface3D> geometry, List<VisualizationData> dataSets)
            : this(geometry.OfType<IGeometry>(), dataSets)
        {
        }

        public AnalysisGeometry(Mesh2D geometry, VisualizationData dataSets)
           : this(new List<IGeometry>() { geometry }, new List<VisualizationData> { dataSets })
        {
        }

        public AnalysisGeometry(List<Mesh2D> geometry, List<VisualizationData> dataSets)
          : this(geometry.OfType<IGeometry>(), dataSets)
        {
        }

        public AnalysisGeometry(IEnumerable<IGeometry> geometry, List<VisualizationData> dataSets)
          : this(geometry.Select(_ => new AnyOf<IGeometry>(_)).ToList(), dataSets)
        {
        }

        public VisualizationData GetActiveData()
        {
            if (this.DataSets == null || this.DataSets.Count == 0)
                return null;

            if (this.DataSets.Count - 1 < this.ActiveData)
            {
                return this.DataSets[0];
            }
            else
            {
                return this.DataSets[this.ActiveData];
            }
        }
    }
}
