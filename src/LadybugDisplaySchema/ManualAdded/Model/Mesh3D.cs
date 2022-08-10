using System.Linq;


namespace LadybugDisplaySchema
{
    /// <summary>
    /// Mesh 3D object.
    /// </summary>
    public partial class Mesh3D
    {

        /// <summary>
        /// Create an instance of Mesh3D.
        /// </summary>
        /// <param name="vertices">Array of Point3D objects for vertices.</param>
        /// <param name="faces">Jagged array of int having either 3 or 4 integers.</param>
        /// <param name="colors">Array of Color objects.that correspond to either the faces
        /// of the mesh or the vertices of the mesh.</param>
        public Mesh3D(
            Point3D[] vertices,
            int[][] faces,
            Color[] colors = null)
            : this(
                  vertices?.Select(_=>_.ToDecimalList())?.ToList(), 
                  faces?.Select(_=>_.ToList())?.ToList(), 
                  colors?.ToList())
        { }



    }
}
