using System.Collections.Generic;
using System.Linq;

namespace LadybugDisplaySchema.Runtime
{
    public struct Boundingbox
    {
        public Point3D Min { get; private set; }
        public Point3D Max { get; private set; }
        public Vector3D Diagonal => Max - Min;
        public Point3D Center => (Min + Max) /2;
        public Boundingbox(IEnumerable<Point3D> pts)
        {
            var minX = pts.Min(_ => _.X);
            var minY = pts.Min(_ => _.Y);
            var minZ = pts.Min(_ => _.Z);

            var maxX = pts.Max(_ => _.X);
            var maxY = pts.Max(_ => _.Y);
            var maxZ = pts.Max(_ => _.Z);

            this.Min = new Point3D(minX, minY, minZ);  
            this.Max = new Point3D(maxX, maxY, maxZ);
        }


        public void Inflate(double amount)
        {
            Min = new Point3D(Min.X - amount, Min.Y - amount, Min.Z - amount);
            Max = new Point3D(Max.X + amount, Max.Y + amount, Max.Z + amount);
        }

    }

}