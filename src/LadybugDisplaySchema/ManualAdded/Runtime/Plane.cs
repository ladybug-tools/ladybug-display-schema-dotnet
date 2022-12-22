namespace LadybugDisplaySchema.Runtime
{
    public struct Plane
    {
        public Vector3D Normal { get; set; }

        public Point3D Origin { get; set; }

        public Vector3D XAxis { get; set; }
        public double K { get; set; }

        public Vector3D YAxis { get; set; }

        public Vector3D ZAxis { get; set; }
        public double Size { get; set; }

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
            if (delta == null)
            {
                return false;
            }

            this.Origin = Origin + delta;
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

    }
}
