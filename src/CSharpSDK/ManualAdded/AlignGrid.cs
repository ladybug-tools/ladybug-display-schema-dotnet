
using System;
using LadybugDisplaySchema;
using System.Collections.Generic;
using System.Linq;

namespace LadybugDisplaySchema
{


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
            var p1 = (from - halfVec);
            var v = (halfVec * 2);
            var line = new LineSegment3D(p1, v);
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

            var rVec = vec;
            // generate guid planes
            var moveDir = rVec.Rotate(Math.PI / 2);// rotate 90 degrees
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

            var alignPts = lines.SelectMany(_ => new[] { _.Point1, _.Point2 });


            // project pts to grids 
            var halfGridSize = gridSize / 2;
            var halfGridSizeSquared = halfGridSize * halfGridSize;
            //var projectedPlanes2 = gridPlanes.Select(_ => new AlignGrid(_, alignPts.Where(p => Math.Abs(_.DistanceTo(p)) < halfGridSize))).ToList();
            var projectedPlanes2 = gridPlanes.Select(_ => new AlignGrid(_, alignPts.Where(p => Math.Abs(_.DistanceToSquared(p)) < halfGridSizeSquared)));

            var projectedPlanes = new List<AlignGrid>();
            var restPts = alignPts;



            // average planes
            var ageragedPlanes = projectedPlanes2.CullDuplicates(distanceThreshold);
            return ageragedPlanes ?? new List<AlignGrid>();
        }


    }

}