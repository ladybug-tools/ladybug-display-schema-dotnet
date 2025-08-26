using System.Collections.Generic;
using System.Linq;

namespace LadybugDisplaySchema
{
    public partial class Mesh2D
    {
        public bool IsColorByFace => Colors == null ? false : Colors.Count == this.Faces.Count;

        /// <summary>
        /// Create an instance of Mesh2D.
        /// </summary>
        /// <param name="vertices">Array of Point2D objects for vertices.</param>
        /// <param name="faces">Jagged array of int having either 3 or 4 integers.</param>
        /// <param name="colors">Array of Color objects.that correspond to either the faces
        /// of the mesh or the vertices of the mesh.</param>
        public Mesh2D(Point2D[] vertices,
            int[][] faces,
            Color[] colors = null)
            : this(
                 vertices.Select(_ => _.ToDecimalList()).ToList(),
                 faces.Select(_ => _.ToList()).ToList(),
                 colors?.ToList())
        { }
    }
    
}
