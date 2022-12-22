

namespace LadybugDisplaySchema
{
    public partial class Plane 
    {

        //private Struct.Plane _plane= 
        public double NormalX => N[0];
        public double NormalY => N[1];
        public double NormalZ => N[2];
        public Vector3D Normal => new Vector3D(NormalX, NormalY, NormalZ);

        public double OriginX => O[0]; 
        public double OriginY => O[1];
        public double OriginZ => O[2];
        public Point3D Origin => new Point3D(OriginX, OriginY, OriginZ);

        public Vector3D XAxis 
        {
            get 
            {
                if (X == null) ValidateX();
                return new Vector3D(X[0], X[1], X[2]);
            }
        }

        /// <summary>
        /// Scalar constant relating origin point to normal vector.
        /// </summary>
        public double K => Normal.Dot(Origin);

        /// <summary>
        /// Plane Y-Axis. This vector will always be normalized (magnitude = 1).
        /// </summary>

        public Vector3D YAxis => Normal.Cross(XAxis);

        public Vector3D ZAxis => Normal;
        //public double Size { get; set; }

        public Plane(Vector3D n, Point3D o, Vector3D x = null): 
            this(
                n.Normalize().ToDecimalList(), 
                o.ToDecimalList(), 
                x?.Normalize()?.ToDecimalList())
        {
        }

        private void ValidateX()
        {
            //var n = this.Normal;
            if (NormalX == 0 && NormalY == 0)
                X = new System.Collections.Generic.List<double> { 1, 0, 0 };
            else
            {
                X = new System.Collections.Generic.List<double> { NormalY, -NormalX, 0 };
                X = XAxis.Normalize().ToDecimalList();
            }
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
            return new Point3D(
                O.X + u[0] + v[0], 
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

        public Point3D ClosestPoint(Point3D testPoint)
        {
            ClosestParameter(testPoint, out var s, out var t);
            return PointAt(s, t);
        }

        public bool ClosestParameter(Point3D testPoint, out double s, out double t)
        {
            var pt = testPoint;
            var vector3d = testPoint - Origin;
            s = vector3d * XAxis;
            t = vector3d * YAxis;

            return true;
        }

        public bool Translate(Vector3D delta)
        {
            if (delta == null || !delta.IsValid())
            {
                return false;
            }

            this.O = (Origin + delta).ToDecimalList();
            return true;
        }

        public Point3D PointAt(double u, double v)
        {
            return Origin + XAxis * u + YAxis * v;
        }

        public Point3D PointAt(double u, double v, double w)
        {
            return Origin + XAxis * u + YAxis * v + ZAxis * w;
        }

        public double DistanceTo(Point3D testPoint)
        {
            var cP = ClosestPoint(testPoint);
            return cP.DistanceTo(testPoint);
        }
        public double DistanceToSquared(Point3D testPoint)
        {
            var cP = ClosestPoint(testPoint);
            return cP.DistanceToSquared(testPoint);
        }

        public Runtime.Plane ToStruct()
        {
            var p = new Runtime.Plane();
            p.Normal = this.Normal.ToStruct();
            p.Origin= this.Origin.ToStruct();
            p.XAxis = this.XAxis.ToStruct();
            p.YAxis = this.YAxis.ToStruct();
            p.ZAxis = this.ZAxis.ToStruct();
            p.K= this.K;
            return p;
        }


    }
}
