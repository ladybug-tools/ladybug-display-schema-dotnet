using System.Collections.Generic;
using System.Linq;

namespace LadybugDisplaySchema
{
    public struct Boundingbox
    {
        public Point3D Min { get; private set; }
        public Point3D Max { get; private set; }
        public Vector3D Diagonal => Max - Min;
        public Point3D Center => (Min + Max) / 2;
        public Boundingbox(IEnumerable<Point3D> pts)
        {
            var minX = pts.Min(_ => _.X);
            var minY = pts.Min(_ => _.Y);
            var minZ = pts.Min(_ => _.Z);

            var maxX = pts.Max(_ => _.X);
            var maxY = pts.Max(_ => _.Y);
            var maxZ = pts.Max(_ => _.Z);

            Min = Point3D.FromXYZ(minX, minY, minZ);
            Max = Point3D.FromXYZ(maxX, maxY, maxZ);
        }


        public void Inflate(double amount)
        {
            Min = Point3D.FromXYZ(Min.X - amount, Min.Y - amount, Min.Z - amount);
            Max = Point3D.FromXYZ(Max.X + amount, Max.Y + amount, Max.Z + amount);
        }

    }

}