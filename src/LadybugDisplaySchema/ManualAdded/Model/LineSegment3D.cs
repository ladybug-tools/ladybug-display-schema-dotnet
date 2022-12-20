
using System.Collections.Generic;

namespace LadybugDisplaySchema
{
    public partial class LineSegment3D
    {
        /// <summary>
        /// First point (same as p).
        /// </summary>
        public List<double> P1 => this.P;
        public Point3D Point1 => new Point3D(P1[0], P1[1], P1[2]);



        /// <summary>
        /// Second point.
        /// </summary>
        public List<double> P2 => new List<double> { V[0] + P[0], V[1] + P[1], V[2] + P[2] };
 
        public Point3D Point2 => new Point3D(P2[0], P2[1], P2[2]);

        public Vector3D Direction =>  new Vector3D(V[0], V[1], V[2]);


        public LineSegment3D(Point3D p1, Point3D p2)
          : this(
                p1.ToDecimalList(),
                (p2 - p1).ToDecimalList()
                )
        {
        }

        /// <summary>
        /// Create an instance of LineSegment3D.
        /// </summary>
        /// <param name="p">A Point3D representing the base.</param>
        /// <param name="v">A Vector3D representing the direction.</param>
        public LineSegment3D(Point3D p, Vector3D v)
            : this(
                  p.ToDecimalList(),
                  v.ToDecimalList()
                  )
        {
        }

        public static LineSegment2D FromEndPoints(Point2D p1, Point2D p2)
        {
            return new LineSegment2D(p1, new Vector2D(p2.X - p1.X, p2.Y - p1.Y));
        }
    }
}
