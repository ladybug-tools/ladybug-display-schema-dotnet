extern alias LBTNewtonsoft; using System;


namespace LadybugDisplaySchema
{
    public partial class Point2D 
    {

        public Point2D (double x, double y, bool validate)
        {
            this.X = x;
            this.Y = y;
            this.Type = "Point2D";

            if (validate && this.GetType() == typeof(Point2D))
                this.IsValid(throwException: true);
        }

        public static Point2D FromXY(double x, double y)
        {
            return new Point2D(x, y, false);
        }


        /// <summary>
        /// Get a point that has been moved along a vector.
        /// </summary>
        /// <param name="movingVec">A Vector2D with the direction and
        /// distance to move the point.</param>
        /// <returns>Point2D.</returns>
        public Point2D Move(Vector2D movingVec)
        {
            return Point2D.FromXY(X + movingVec.X, Y + movingVec.Y);
        }

        /// <summary>
        /// Rotate a point counterclockwise by a certain angle around an origin.
        /// </summary>
        /// <param name="angle">An angle for rotation in radians.</param>
        /// <param name="origin">An angle for rotation in radians.</param>
        /// <returns>Point2D.</returns>
        public Point2D Rotate(double angle, Point2D origin)
        {
            var vec = (this - origin).ToVector2D().Rotate(angle);
            var sum = (vec + origin);

            return Point2D.FromXY(sum.X, sum.Y);
        }

        /// <summary>
        /// Get a point reflected across a plane with the input normal vector and origin.
        /// </summary>
        /// <param name="normal">A Vector2D representing the normal vector for the plane across
        /// which the point will be reflected. THIS VECTOR MUST BE NORMALIZED.</param>
        /// <param name="origin">A Point2D representing the origin from which to reflect.</param>
        /// <returns>Point2D.</returns>
        public Point2D Reflect(Vector2D normal, Point2D origin)
        {
            var vec = (this - origin).ToVector2D().Reflect(normal);
            var sum = (vec + origin);

            return Point2D.FromXY(sum.X, sum.Y);
        }

        /// <summary>
        /// Scale a point by a factor from an origin point.
        /// </summary>
        /// <param name="factor">Scale a point by a factor from an origin point.</param>
        /// <param name="origin">A Point2D representing the origin from which to scale.
        /// If null, it will be scaled from the World origin (0, 0).</param>
        /// <returns>Point2D.</returns>
        public Point2D Scale(double factor, Point2D origin = null)
        {
            if (origin is null)
            {
                return Point2D.FromXY(X * factor, Y * factor);
            }
            else
            {
                var res = ((this - origin) * factor) + origin;
                return Point2D.FromXY(Math.Round(res.X, APPROX),
                    Math.Round(res.Y, APPROX));
            }
        }

        /// <summary>
        /// Get the distance from this point to another Point2D.
        /// </summary>
        /// <param name="other">A Point2D representing the second point from which 
        /// to calculate the distance.</param>
        /// <returns>Value.</returns>
        public double DistanceToPoint(Point2D other)
        {
            var vec = Vector2D.FromXY(X - other.X, Y - other.Y);
            return Math.Sqrt(Math.Pow(vec.X, 2)
                + Math.Pow(vec.Y, 2));
        }
        public static bool operator >=(Point2D pt, Point2D other)
        {
            return (pt.X >= other.X);
        }

        public static bool operator <=(Point2D pt, Point2D other)
        {
            return (pt.X <= other.X);
        }

        public static Point2D operator +(Point2D pt, Point2D other)
        {
            return Point2D.FromXY(pt.X + other.X, pt.Y + other.Y);
        }

        public static Point2D operator -(Point2D pt)
        {
            return Point2D.FromXY(-pt.X, -pt.Y);
        }

        public static Point2D operator -(Point2D pt, Point2D other)
        {
            return Point2D.FromXY(pt.X - other.X, pt.Y - other.Y);
        }

        public static Point2D operator *(Point2D pt, double other)
        {
            return Point2D.FromXY(pt.X * other, pt.Y * other);
        }

        public static Point2D operator /(Point2D pt, double other)
        {
            return Point2D.FromXY(pt.X / other, pt.Y / other);
        }

   
        public int CompareTo(Object other)
        {
            var otherPt = other as Point2D;

            if (otherPt == null) return 1;

            if (X < otherPt.X) return 1;
            else if (X > otherPt.X) return -1;
            return 0;
        }

        public Vector2D ToVector2D()
        {
            return Vector2D.FromXY(this.X, this.Y);
        }
    }
}
