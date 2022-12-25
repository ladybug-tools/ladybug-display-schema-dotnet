
using System.Collections.Generic;

namespace LadybugDisplaySchema
{
    public partial class LineSegment2D
    {
        /// <summary>
        /// First point (same as p).
        /// </summary>
        public List<double> P1 => this.P;
        public Point2D Point1 => Point2D.FromXY(P1[0], P1[1]);

        /// <summary>
        /// Second point.
        /// </summary>
        public List<double> P2 => new List<double> { V[0] + P[0], V[1] + P[1] };
        public Point2D Point2 => Point2D.FromXY(P2[0], P2[1]);



        /// <summary>
        /// Create an instance of LineSegment2D.
        /// </summary>
        /// <param name="p">A Point2D representing the base.</param>
        /// <param name="v">A Vector2D representing the direction.</param>
        public LineSegment2D(Point2D p, Vector2D v)
            : this(p.ToDecimalList(), v.ToDecimalList())
        {
        }
        public static LineSegment2D FromEndPoints(Point2D p1, Point2D p2)
        {
            return new LineSegment2D(p1, Vector2D.FromXY(p2.X - p1.X, p2.Y - p1.Y));
        }
    }
}
