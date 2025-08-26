using System;


namespace LadybugDisplaySchema
{
    public partial class Point3D
    {

        public Point3D
        (
           double x, double y, double z, bool validate
        )
        {
            this.X = x;
            this.Y = y;
            this.Z = z;

            this.Type = "Point3D";

            if (validate && this.GetType() == typeof(Point3D))
                this.IsValid(throwException: true);
        }

        public static Point3D FromXYZ(double x, double y, double z)
        {
            return new Point3D(x, y, z, false);
        }

        /// <summary>
        /// Get a point that has been moved along a vector.
        /// </summary>
        /// <param name="movingVec">A Vector2D with the direction and
        /// distance to move the point.</param>
        /// <returns>Point2D object.</returns>
        public Point3D Move(Vector3D movingVec)
        {
            return Point3D.FromXYZ(X + movingVec.X, Y + movingVec.Y,
                Z + movingVec.Z);
        }

        /// <summary>
        /// Rotate a point by a certain angle around an axis and origin.
        /// Right hand rule applies:
        /// If axis has a positive orientation, rotation will be clockwise.
        /// If axis has a negative orientation, rotation will be counterclockwise.
        /// </summary>
        /// <param name="axis">A Vector3D axis representing the axis of rotation.</param>
        /// <param name="angle">An angle for rotation in radians.</param>
        /// <param name="origin">A Point3D for the origin around which the point will be rotated.</param>
        /// <returns>Point3D object.</returns>
        public Point3D Rotate(Vector3D axis, 
            double angle, 
            Point3D origin)
        {
            var vec = (this - origin).Rotate(axis, angle);
            var sum = vec + origin;

            return Point3D.FromXYZ(sum.X, sum.Y, sum.Z);
        }

        /// <summary>
        /// Get a point rotated counterclockwise in the XY plane by a certain angle.
        /// </summary>
        /// <param name="angle">An angle in radians.</param>
        /// <param name="origin">A Point3D for the origin around which the point will be rotated.</param>
        /// <returns>Point3D object.</returns>
        public Point3D Rotate(
            double angle,
            Point3D origin)
        {
            var vec = (this - origin).Rotate(angle);
            var sum = vec + origin;

            return Point3D.FromXYZ(sum.X, sum.Y, sum.Z);
        }

        /// <summary>
        /// Get a point reflected across a plane with the input normal vector and origin.
        /// </summary>
        /// <param name="normal">A Vector3D representing the normal vector for the plane across
        /// which the point will be reflected. THIS VECTOR MUST BE NORMALIZED.</param>
        /// <param name="origin">A Point3D representing the origin from which to reflect.</param>
        /// <returns>Point3D object.</returns>
        public Point3D Reflect(Vector3D normal, Point3D origin)
        {
            var vec = (this - origin).Reflect(normal);
            var sum = (vec + origin);

            return Point3D.FromXYZ(sum.X, sum.Y, sum.Z);
        }

        /// <summary>
        /// Scale a point by a factor from an origin point.
        /// </summary>
        /// <param name="factor">A number representing how much the point should be scaled.</param>
        /// <param name="origin">A Point3D representing the origin from which to scale.
        /// If None, it will be scaled from the World origin (0, 0, 0).</param>
        /// <returns>Point3D object.</returns>
        public Point3D Scale(double factor, Point3D origin = null)
        {
            if (origin is null)
            {
                return Point3D.FromXYZ(X * factor, Y * factor, Z * factor);
            }
            else
            {
                var res = ((this - origin) * factor) + origin;
                return Point3D.FromXYZ(Math.Round(res.X, APPROX),
                    Math.Round(res.Y, APPROX),
                    Math.Round(res.Z, APPROX));
            }
        }

        /// <summary>
        /// Get the distance from this point to another Point3D.
        /// </summary>
        /// <param name="other">A Point2D representing the second point from which 
        /// to calculate the distance.</param>
        /// <returns>Value.</returns>
        public double DistanceTo(Point3D other)
        {
            return Math.Sqrt(DistanceToSquared(other));
        }

        public double DistanceToSquared(Point3D other)
        {
            var vec = Vector3D.FromXYZ(X - other.X, Y - other.Y, Z - other.Z);
            return Math.Pow(vec.X, 2)
                + Math.Pow(vec.Y, 2)
                + Math.Pow(vec.Z, 2);
        }

        /// <summary>
        /// Get a point projected a point3d into a plane with a given normal and origin
        /// </summary>
        /// <param name="normal">A Vector3D representing the normal vector of the plane into which
        /// the plane will be projected. THIS VECTOR MUST BE NORMALIZED.</param>
        /// <param name="origin">A Point3D representing the origin the plane into which the
        /// point will be projected.</param>
        /// <returns>Point3D object.</returns>
        public Point3D Project(Vector3D normal, Point3D origin)
        {
            var tranSelf = (this - origin);
            var point = this - normal * tranSelf.Dot(normal);
            return point;
        }

        public static Point3D operator +(Point3D pt, Point3D other)
        {
            return Point3D.FromXYZ(pt.X + other.X, 
                pt.Y + other.Y, 
                pt.Z + other.Z);
        }

        public static Point3D operator +(Point3D pt, Vector3D vector)
        {
            return Point3D.FromXYZ(pt.X + vector.X, pt.Y + vector.Y, pt.Z + vector.Z);
        }
        public static Point3D operator /(Point3D point, double t)
        {
            return Point3D.FromXYZ(point.X / t, point.Y / t, point.Z / t);
        }
        public static Point3D operator *(Point3D point, double t)
        {
            return Point3D.FromXYZ(point.X * t, point.Y * t, point.Z * t);
        }

        public static Point3D operator -(Point3D pt)
        {
            return Point3D.FromXYZ(-pt.X, -pt.Y, -pt.Z);
        }

        public static Vector3D operator -(Point3D pt, Point3D other)
        {
            return Vector3D.FromXYZ(pt.X - other.X, 
                pt.Y - other.Y, 
                pt.Z - other.Z);
        }

        public static Point3D operator -(Point3D pt, Vector3D vector)
        {
            return Point3D.FromXYZ(pt.X - vector.X, pt.Y - vector.Y, pt.Z - vector.Z);
        }


        public bool IsEquivalent(Point3D other, double tolerance = 0.001)
        {
            return ((Math.Abs(X - other.X) <= tolerance) &&
                (Math.Abs(Y - other.Y) <= tolerance) &&
                (Math.Abs(Z - other.Z) <= tolerance));
        }

        public int CompareTo(Object other)
        {
            var otherPt = other as Point2D;

            if (otherPt == null) return 1;

            if (X < otherPt.X) return 1;
            else if (X > otherPt.X) return -1;
            return 0;
        }


    }
}
