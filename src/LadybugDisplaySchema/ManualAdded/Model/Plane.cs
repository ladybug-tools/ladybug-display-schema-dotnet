

namespace LadybugDisplaySchema
{
    public partial class Plane 
    {
        public Vector3D Normal => new Vector3D(N[0], N[1], N[2]);

        public Point3D Origin => new Point3D(O[0], O[1], O[2]);

        public Vector3D XAxis => new Vector3D(X[0], X[1], X[2]);

        /// <summary>
        /// Scalar constant relating origin point to normal vector.
        /// </summary>
        
        public double K => Normal.Dot(Origin.ToVector3D());

        /// <summary>
        /// Plane Y-Axis. This vector will always be normalized (magnitude = 1).
        /// </summary>
        
        public Vector3D YAxis => Normal.Cross(XAxis);


        public Plane(Vector3D n, Point3D o, Vector3D x = null): 
            this(
                n.ToDecimalList(), 
                o.ToDecimalList(), 
                x?.ToDecimalList())
        {
        }

        /// <summary>
        /// Get a Point3D from a Point2D in the coordinate system of this plane
        /// </summary>
        /// <param name="point">Point2D</param>
        /// <returns>Point3D obejct.</returns>
        public Point3D XYtoXYZ(Point2D point)
        {
            var X = this.XAxis;
            var O = this.Origin;

            var u = new double[] { X.X * point.X, X.Y * point.X, X.Z * point.X };
            var v = new double[] { YAxis.X * point.Y, YAxis.Y * point.Y, YAxis.Z * point.Y };
            return new Point3D(O.X + u[0] + v[0], 
                O.Y + u[1] + v[1], 
                O.Z + u[2] + v[2]);
        }

        /// <summary>
        /// Get a Point2D in the coordinate system of this plane from a Point3D
        /// </summary>
        /// <param name="point">Point3D </param>
        /// <returns>Point2D object.</returns>
        public Point2D XYZtoXY(Point3D point)
        {
            var X = this.XAxis;
            var O = this.Origin;

            var diff = new Vector3D(point.X - O.X, point.Y - O.Y, point.Z - O.Z);
            return new Point2D(X.Dot(diff), YAxis.Dot(diff));
        }



        /// <summary>
        /// Get a flipped version of this plane (facing the opposite direction).
        /// </summary>
        /// <returns>Plane object.</returns>
        public Plane Flip()
        {
            return new Plane(Normal.Reverse(), Origin, XAxis);
        }

    }
}
