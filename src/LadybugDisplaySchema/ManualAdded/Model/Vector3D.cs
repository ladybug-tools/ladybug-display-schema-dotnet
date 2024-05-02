extern alias LBTNewtonsoft; using System;


namespace LadybugDisplaySchema
{
    public partial class Vector3D 
    {
        public static Vector3D XAxis = Vector3D.FromXYZ(1, 0, 0);
        public static Vector3D YAxis = Vector3D.FromXYZ(0, 1, 0);
        public static Vector3D ZAxis = Vector3D.FromXYZ(0, 0, 1);
        public double Length => Magnitude;

        public double SquareLength => MagnitudeSquared;

        /// <summary>
        /// Get the magnitude of the vector.
        /// </summary>

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
                return X * X + Y * Y + Z * Z;
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


        public Vector3D
        (
          double x, double y, double z, bool validate
        ) 
        {
            this.X = x;
            this.Y = y;
            this.Z = z;

            this.Type = "Vector3D";

            if (validate && this.GetType() == typeof(Vector3D))
                this.IsValid(throwException: true);
        }


        public static Vector3D FromXYZ(double x, double y, double z)
        {
            return new Vector3D(x, y, z, false);
        }

        /// <summary>
        /// Initialize a Vector3D from an array.
        /// </summary>
        /// <param name="array">An array with three numbers
        /// representing the x, y and z values of the point.</param>
        /// <returns>Vector3D object.</returns>
        public static Vector3D FromArray(double[] array)
        {
            return Vector3D.FromXYZ(array[0], array[1], array[2]);
        }

        /// <summary>
        /// Get Vector3D as an array of two numbers
        /// </summary>
        /// <returns>Array</returns>
        public double[] ToArray()
        {
            return new[] { X, Y, Z };
        }

        /// <summary>
        /// Boolean to note whether the vector is within a given zero tolerance.
        /// </summary>
        /// <param name="tolerance">The tolerance below which the vector is considered to
        /// be a zero vector.</param>
        /// <returns>True o false.</returns>
        public bool IsZero(double tolerance = TOL)
        {
            return (Math.Abs(X) <= tolerance) &&
                (Math.Abs(Y) <= tolerance) && 
                (Math.Abs(Z) <= tolerance);
        }

        /// <summary>
        /// Test whether this object is equivalent to another within a certain tolerance.
        /// </summary>
        /// <param name="other">Another Vector3D for which geometric equivalency will be tested.</param>
        /// <param name="tolerance">The minimum difference between the coordinate values of two
        /// objects at which they can be considered geometrically equivalent.</param>
        /// <returns>True o false.</returns>
        public bool IsEquivalent(Vector3D other, double tolerance = TOL)
        {
            return (Math.Abs(X - other.X) <= tolerance) &&
                (Math.Abs(Y - other.Y) <= tolerance) &&
                (Math.Abs(Z - other.Z) <= tolerance);
        }

        /// <summary>
        /// Get a copy of this vector that is reversed.
        /// </summary>
        /// <returns>Reversed Vector3D.</returns>
        public Vector3D Reverse()
        {
            return Vector3D.FromXYZ(-X, -Y, -Z);
        }

        /// <summary>
        /// Get the cross product of this vector and another vector
        /// </summary>
        /// <param name="other">Vector3D</param>
        /// <returns></returns>
        public Vector3D Cross(Vector3D other)
        {
            return Vector3D.FromXYZ(Y * other.Z - Z * other.Y,
                        -X * other.Z + Z * other.X,
                        X * other.Y - Y * other.X);
        }

        /// <summary>
        /// Get a copy of the vector that is a unit vector (magnitude=1)
        /// </summary>
        /// <returns>Vector3D object.</returns>
        public Vector3D Normalize()
        {
            var d = Magnitude;
            if (d != 0 && d != 1)
            {
                return Vector3D.FromXYZ(X / d, Y / d, Z / d);
            }
            else
            {
                return Vector3D.FromXYZ(X, Y, Z);
            }
        }


        /// <summary>
        /// Get the dot product of this vector with another.
        /// </summary>
        /// <param name="other">Vector3D to use with the dot product.</param>
        /// <returns>Value.</returns>
        public double Dot(Vector3D other)
        {
            return (X * other.X + Y * other.Y + Z * other.Z);
        }
        public double Dot(Point3D other)
        {
            return (X * other.X + Y * other.Y + Z * other.Z);
        }

        /// <summary>
        /// Get the smallest angle between this vector and another.
        /// </summary>
        /// <param name="other">Vector3D to use to calculate the angle.</param>
        /// <returns>Value in radians.</returns>
        public double Angle(Vector3D other)
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
        /// Get a vector rotated around an axis through an angle
        /// Right hand rule applies:
        /// If axis has a positive orientation, rotation will be clockwise.
        /// If axis has a negative orientation, rotation will be counterclockwise.
        /// </summary>
        /// <param name="axis">A Vector3D axis representing the axis of rotation.</param>
        /// <param name="angle">An angle in radians.</param>
        /// <returns>Vector3D object.</returns>
        public Vector3D Rotate(Vector3D axis, double angle)
        {
            return Rotate(this, axis, angle);
        }

        /// <summary>
        /// Get a vector that is reflected across a plane with the input normal vector
        /// </summary>
        /// <param name="normal">A Vector3D representing the normal vector 
        /// for the plane across which the vector will be reflected.
        /// THIS VECTOR MUST BE NORMALIZED</param>
        /// <returns>Vector3D object.</returns>
        public Vector3D Reflect(Vector3D normal)
        {
            return Reflect(this, normal);
        }

        /// <summary>
        /// Get a vector rotated counterclockwise in the XY plane by a certain angle
        /// </summary>
        /// <param name="angle">An angle in radians</param>
        /// <returns>Vecto3D object.</returns>
        public Vector3D Rotate(double angle)
        {
            var vec = (Vector2D.FromXY(X, Y)).Rotate(angle);
            return Vector3D.FromXYZ(vec.X, vec.Y, Z);
        }

        /// <summary>
        /// Rotation method used by both Point3D and Vector3D.
        /// </summary>
        /// <returns>Vector3D object.</returns>
        protected static Vector3D Rotate(Vector3D vec, 
            Vector3D axis,
            double angle)
        {
            var x = vec.X;
            var y = vec.Y;
            var z = vec.Z;
            var u = axis.X;
            var v = axis.Y;
            var w = axis.Z;

            var r2 = Math.Pow(u, 2) + Math.Pow(v, 2) + Math.Pow(w, 2);
            var r = Math.Sqrt(r2);
            var ct = Math.Cos(angle);
            var st = Math.Sin(angle) / r;
            var dt = (u * x + v * y + w * z) * (1 - ct) / r2;

            var xC = (u * dt + x * ct + (-w * y + v * z) * st);
            var yC = (v * dt + y * ct + (w * x - u * z) * st);
            var zC = (w * dt + z * ct + (-v * x + u * y) * st);

            return Vector3D.FromXYZ(Math.Round(xC, APPROX),
                Math.Round(yC, APPROX), 
                Math.Round(zC, APPROX));
        }

        /// <summary>
        /// Reflection method used by both Point3D and Vector3D
        /// </summary>
        protected static Vector3D Reflect(Vector3D vec,
           Vector3D normal)
        {
            var d = 2 * (vec.X * normal.X + vec.Y * normal.Y + vec.Z * normal.Z);
            return Vector3D.FromXYZ(Math.Round(vec.X - d * normal.X, APPROX),
                        Math.Round(vec.Y - d * normal.Y, APPROX),
                        Math.Round(vec.Z - d * normal.Z, APPROX));
        }

        public static Vector3D operator +(Vector3D vec, Vector3D other)
        {
            return Vector3D.FromXYZ(vec.X + other.X, vec.Y + 
                other.Y, vec.Z + other.Z);
        }

        public static Vector3D operator + (Vector3D vec, Point3D other)
        {
            return Vector3D.FromXYZ(vec.X + other.X, vec.Y +
                other.Y, vec.Z + other.Z);
        }

        public static Vector3D operator -(Vector3D vec)
        {
            return vec.Reverse();
        }

        public static Vector3D operator -(Vector3D vec, Vector3D other)
        {
            return Vector3D.FromXYZ(vec.X - other.X, vec.Y -
                other.Y, vec.Z - other.Z);
        }

        public static Vector3D operator -(Vector3D vec, Point3D other)
        {
            return Vector3D.FromXYZ(vec.X - other.X, vec.Y -
                other.Y, vec.Z - other.Z);
        }

        public static Vector3D operator *(Vector3D vec, double other)
        {
            return Vector3D.FromXYZ(vec.X * other, vec.Y * other,
                vec.Z * other);
        }

        public static Vector3D operator *( double other, Vector3D vec)
        {
            return vec * other;
        }

        public static double operator *(Vector3D vector1, Vector3D vector2)
        {
            return vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z;
        }

        public static Vector3D operator /(Vector3D vec, double other)
        {
            return Vector3D.FromXYZ(vec.X / other, vec.Y / other,
                vec.Z / other);
        }

        public Vector3D Floor(double other)
        {
            return Vector3D.FromXYZ(Math.Floor(X / other),
                        Math.Floor(Y / other),
                        Math.Floor(Z / other));
        }



    }
}
