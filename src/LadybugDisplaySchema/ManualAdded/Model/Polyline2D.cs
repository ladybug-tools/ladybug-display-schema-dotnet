using System.Linq;


namespace LadybugDisplaySchema
{
    public partial class Polyline2D 
    {
     
        /// <summary>
        /// Create an instance of Polyline2D.
        /// </summary>
        /// <param name="vertices">Array of Point2D objects representing 
        /// the vertices of the polygon.</param>
        public Polyline2D(Point2D[] vertices)
            : this(vertices?.Select(x => x.ToDecimalList())?.ToList())
        { }

    

    }
}
