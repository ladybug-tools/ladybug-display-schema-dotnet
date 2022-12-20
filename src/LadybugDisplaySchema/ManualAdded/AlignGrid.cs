using LadybugDisplaySchema;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LadybugDisplaySchema
{
    public struct Boundingbox
    {
        public Point3D Min { get; }
        public Point3D Max { get; }
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
            Min.X -= amount;
            Min.Y -= amount;
            Min.Z -= amount;
            Max.X += amount;
            Max.Y += amount;
            Max.Z += amount;
        }

    }


    public class AlignGrid
    {
        public Plane Plane { get; }
        public Plane WeightPlane { get; private set; }
        public LineSegment3D GridLine { get; }
        public LineSegment3D WeightedGridLine { get; }

        // all points close to plane within distance tolerance
        public List<Point3D> WeightPoints { get; private set; }


        public AlignGrid(Plane plane, IEnumerable<Point3D> weightPoints)
        {
            Plane = plane;
            WeightPlane = RefitPlane(ref weightPoints, plane);
            WeightPoints = weightPoints?.ToList();

            // create grid line
           
            GridLine = GenGridLine(plane);
            WeightedGridLine = GenGridLine(WeightPlane);

        }

        public AlignGrid Weight()
        {
            var newGrid = new AlignGrid(this.Plane, this.WeightPoints);
            return newGrid;
        }

        public static LineSegment3D GenGridLine(Plane plane)
        {
            var size = Math.Max(plane.Size, 1);
            var halfVec = plane.XAxis * size;
            // create grid line

            var from = plane.Origin;
            from.Z = 0;
            var line = new LineSegment3D(from - halfVec, halfVec * 2);
            return line;
        }

        private static Plane RefitPlane(ref IEnumerable<Point3D> weightPoints, Plane plane)
        {
            var weightPlane = plane;
            if (weightPoints != null && weightPoints.Any())
            {
                // remove duplicated
                weightPoints = weightPoints.Distinct();
                // move plane to center of weighted points
                var avgPt = weightPoints.Average();
                var projPt = plane.ClosestPoint(avgPt);
                var vec = avgPt - projPt;
                weightPlane.Translate(vec);
            }
            return weightPlane;
        }

        public override string ToString()
        {
            return $"Grid line ({this.WeightPoints?.Count} points)";
        }

        public static List<Plane> GenGlobalPlanes(List<LineSegment3D> geos, Vector3D vec, double gridSize)
        {
            var pts = geos.SelectMany(_ => new[] { _.Point1, _.Point2 });
            var bbox = new Boundingbox(pts);
            // generate guid planes
            var moveDir = vec.Rotate(Math.PI / 2);// rotate 90 degrees
            moveDir = moveDir.Normalize();
            var moveVec = moveDir * gridSize;


            var distance = bbox.Diagonal.Length;
            var halfDiagonal = distance / 2;
            var planeCounts = (int)(distance / gridSize);

            var baseOri = bbox.Center.Move(-halfDiagonal * moveDir);
            var basePlane = new Plane(moveDir, baseOri, vec);
         
            var gridPlanes = new List<Plane>();
            for (int i = 0; i < planeCounts; i++)
            {
                var gd = basePlane.DuplicatePlane();
                gd.Size = halfDiagonal;
                gd.Translate(i * moveVec);
                gridPlanes.Add(gd);
            }


            return gridPlanes;

        }

        public static List<AlignGrid> GenGrids(List<LineSegment3D> geos, List<Plane> globalGridPlanes, double gridSize, double angleRadTol, double distanceThreshold )
        {

            var gridPlanes = globalGridPlanes;
            var vec = gridPlanes.FirstOrDefault().XAxis;

            // get points from segments that are aligned with input vector
            var lines = geos
                .Where(_ =>
                {
                    var a = _.Direction.Angle(vec);
                    if (a <= angleRadTol)
                        return true;
                    return (Math.PI - a) <= angleRadTol;
                });

            var alignPts = lines.SelectMany(_ => new[] { _.Point1, _.Point2 }).ToList();


            // project pts to grids 
            var halfGridSize = gridSize / 2;
            var halfGridSizeSquared = halfGridSize * halfGridSize;
            //var projectedPlanes2 = gridPlanes.Select(_ => new AlignGrid(_, alignPts.Where(p => Math.Abs(_.DistanceTo(p)) < halfGridSize))).ToList();

            var projectedPlanes = new List<AlignGrid>();
            var restPts = alignPts;
            foreach (var plane in gridPlanes)
            {
                var pts = restPts.Where(p => plane.DistanceToSquared(p) < halfGridSizeSquared).ToList();
                if (pts.Any())
                {
                    var ag = new AlignGrid(plane, pts);
                    projectedPlanes.Add(ag);
                    restPts.RemoveAll(_ => pts.Contains(_));
                }
            }


            // average planes
            var ageragedPlanes = projectedPlanes.CullDuplicates(distanceThreshold);
            return ageragedPlanes ?? new List<AlignGrid>();
        }


    }

}