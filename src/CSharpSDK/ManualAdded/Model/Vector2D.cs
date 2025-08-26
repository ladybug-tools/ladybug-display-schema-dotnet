using System;


namespace LadybugDisplaySchema
{
    public partial class Vector2D 
    {
 
        
        public double Magnitude
        {
            get
            {
                return (Math.Sqrt(MagnitudeSquared));
            }
        }

        /// <summary>
        /// Get the magnitude squared of the vector.
        /// </summary>
        
        public double MagnitudeSquared
        {
            get
            {
                return (Math.Pow(X, 2) + Math.Pow(Y, 2));
            }
        }

        /// <summary>
        /// Boolean to note whether the vector is zero.
        /// </summary>
        
        public bool IsNotZero
        {
            get
            {
                return X != 0 || Y != 0;
            }
        }

        public Vector2D (double x, double y, bool validate)
        {
            this.X = x;
            this.Y = y;

            this.Type = "Vector2D";

            if (validate && this.GetType() == typeof(Vector2D))
                this.IsValid(throwException: true);
        }


        public static Vector2D FromXY(double x, double y)
        {
            return new Vector2D(x, y, false);
        }


        /// <summary>
        /// Boolean to note whether the vector is within a given zero tolerance.
        /// </summary>
        /// <param name="tolerance">The tolerance below which the vector is considered to
        /// be a zero vector.</param>
        /// <returns>True o false.</returns>
        public bool IsZero(double tolerance)
        {
            return ((Math.Abs(X) <= tolerance) &&
                (Math.Abs(Y) <= tolerance));
        }

        /// <summary>
        /// Test whether this object is equivalent to another within a certain tolerance.
        /// </summary>
        /// <param name="other">Another Vector2D for which geometric equivalency will be tested.</param>
        /// <param name="tolerance">The minimum difference between the coordinate values of two
        /// objects at which they can be considered geometrically equivalent.</param>
        /// <returns>True o false.</returns>
        public bool IsEquivalent(Vector2D other, double tolerance = TOL)
        {
            return ((Math.Abs(X - other.X) <= tolerance) &&
                (Math.Abs(Y - other.Y) <= tolerance));
        }

        /// <summary>
        /// Get a copy of the vector that is a unit vector (magnitude=1).
        /// </summary>
        /// <returns>Vector2D object.</returns>
        public Vector2D Normalize()
        {
            var d = Magnitude;
            if (d != 0)
            {
                return Vector2D.FromXY(X / d, Y / d);
            }
            else
            {
                return DuplicateVector2D();
            }
        }

        /// <summary>
        /// Get a copy of this vector that is reversed.
        /// </summary>
        /// <returns>Reversed Vector2D.</returns>
        public Vector2D Reverse()
        {
            return Vector2D.FromXY(-X, -Y);
        }

        /// <summary>
        /// Get the dot product of this vector with another.
        /// </summary>
        /// <param name="other">Vector2D to use with the dot product.</param>
        /// <returns>Value.</returns>
        public double Dot(Vector2D other)
        {
            return (X * other.X + Y * other.Y);
        }

        /// <summary>
        /// Get the determinant between this vector and another 2D vector.
        /// </summary>
        /// <param name="other">Vector2D to use to calculate the determinant.</param>
        /// <returns>Value object.</returns>
        public double Determinant(Vector2D other)
        {
            return (X * other.Y - Y * other.X);
        }

        /// <summary>
        /// et the cross product of this vector.
        /// </summary>
        /// <returns>Vector2D object.</returns>
        public Vector2D Cross()
        {
            return Vector2D.FromXY(Y, -X);
        }

        /// <summary>
        /// Get the smallest angle between this vector and another.
        /// </summary>
        /// <param name="other">Vector2D to use to calculate the angle.</param>
        /// <returns>Value in radians.</returns>
        public double Angle(Vector2D other)
        {
            try
            {
                return (Math.Acos(Dot(other) /
                    (Magnitude * other.Magnitude)));
            }
            catch (Exception)
            {
                if (Dot(other) < 0)
                    return Math.Acos(-1);
                return Math.Acos(1);
            }
        }

        /// <summary>
        /// Get the counterclockwise angle between this vector and another.
        /// </summary>
        /// <param name="other">Vector2D to use to calculate the angle.</param>
        /// <returns>Value in radians.</returns>
        public double AngleCounterclockwise(Vector2D other)
        {
            var inner = Angle(other);
            var det = Determinant(other);
            if (det >= 0)
                return inner;
            else
                return (2 * Math.PI - inner);
        }

        /// <summary>
        /// Get the clockwise angle between this vector and another.
        /// </summary>
        /// <param name="other">Vector2D to use to calculate the angle.</param>
        /// <returns>Value in radians.</returns>
        public double AngleClockwise(Vector2D other)
        {
            var inner = Angle(other);
            var det = Determinant(other);
            if (det <= 0)
                return inner;
            else
                return (2 * Math.PI - inner);
        }

        /// <summary>
        /// Get a vector that is rotated counterclockwise by a certain angle.
        /// </summary>
        /// <param name="angle">Angle to use.</param>
        /// <returns>Vecto2D object.</returns>
        public Vector2D Rotate(double angle)
        {
            return Rotate(this, angle);
        }

        /// <summary>
        /// Get a vector that is reflected across a plane with the input normal vector.
        /// </summary>
        /// <param name="normal">Normal vector to use.</param>
        /// <returns>Vector2D object.</returns>
        public Vector2D Reflect(Vector2D normal)
        {
            return Reflect(this, normal);
        }

        /// <summary>
        /// Compute the circular mean across a list of angles in radians.
        /// If no circular mean exists, the normal mean will be returned.
        /// </summary>
        /// <param name="angles">An array of angles in radians.</param>
        /// <param name="tolerance"></param>
        /// <returns>Value.</returns>
        public static double CircularMean(double[] angles,
           double tolerance = TOL)
        {
            double angleSum = 0;
            double sum = 0;
            foreach (var ang in angles)
            {
                angleSum += Math.Cos(ang);
                sum += ang;
            }
            var avgX = angleSum / angles.Length;

            angleSum = 0;
            foreach (var ang in angles)
            {
                angleSum += Math.Sin(ang);
            }
            var avgY = angleSum / angles.Length;

            if (avgX == 0 && avgY == 0)
                return (sum / angles.Length);
            var res = Math.Atan2(avgY, avgX);
            if (Math.Abs(res) < tolerance)
                return 0;
            return res;
        }

        public static Vector2D operator +(Vector2D vec, Vector2D other)
        {
            return Vector2D.FromXY(vec.X + other.X, vec.Y + other.Y);
        }

        public static Vector2D operator +(Vector2D vec, Point2D other)
        {
            return Vector2D.FromXY(vec.X + other.X, vec.Y + other.Y);
        }

        public static Vector2D operator -(Vector2D vec)
        {
            return vec.Reverse();
        }

        public static Vector2D operator -(Vector2D vec, Vector2D other)
        {
            return Vector2D.FromXY(vec.X - other.X, vec.Y - other.Y);
        }

        public static Vector2D operator *(Vector2D vec, double other)
        {
            return Vector2D.FromXY(vec.X * other, vec.Y * other);
        }

        public static Vector2D operator /(Vector2D vec, double other)
        {
            return Vector2D.FromXY(vec.X / other, vec.Y / other);
        }

        /// <summary>
        /// Floor division operation used by Vector2D.
        /// </summary>
        /// <param name="other">A vector to use for calculation.</param>
        /// <returns>Vecto2D object.</returns>
        public Vector2D Floor(double other)
        {
            return Vector2D.FromXY(Math.Floor(X / other),
                        Math.Floor(Y / other));
        }

        /// <summary>
        /// Rotation method used by Vector2D.
        /// </summary>
        /// <param name="vec">Vector2D to use for the rotation.</param>
        /// <param name="angle">Value to use in radians.</param>
        /// <returns>Vector2D.</returns>
        protected static Vector2D Rotate(Vector2D vec, double angle)
        {
            var cosA = Math.Cos(angle);
            var sinA = Math.Sin(angle);
            var qx = (cosA * vec.X - sinA * vec.Y);
            var qy = (sinA * vec.X + cosA * vec.Y);

            return Vector2D.FromXY(Math.Round(qx, APPROX),
                Math.Round(qy, APPROX));
        }

        /// <summary>
        /// Hidden reflection method used by Vector2D.
        /// </summary>
        /// <param name="vec">Vector2D to use for the reflection.</param>
        /// <param name="normal">Normal vector to use for the reflection.</param>
        /// <returns>Vector2D.</returns>
        protected static Vector2D Reflect(Vector2D vec, Vector2D normal)
        {
            var d = 2 * (vec.X * normal.X + vec.Y * normal.Y);
            var qx = vec.X - d * normal.X;
            var qy = vec.Y - d * normal.Y;

            return Vector2D.FromXY(Math.Round(qx, APPROX),
                Math.Round(qy, APPROX));
        }

        public Point2D ToPoint2D()
        {
            return Point2D.FromXY(X, Y);
        }
    }
}
