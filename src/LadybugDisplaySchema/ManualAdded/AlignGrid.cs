using LadybugDisplaySchema;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LadybugDisplaySchema
{


    public class AlignGrid
    {
        public Runtime.Plane Plane { get; }
        public Runtime.Plane WeightPlane { get; private set; }
        public LineSegment3D GridLine { get; }
        public LineSegment3D WeightedGridLine { get; }

        // all points close to plane within distance tolerance
        public List<Runtime.Point3D> WeightPoints { get; private set; }


        public AlignGrid(Plane plane, IEnumerable<Point3D> weightPoints): this(plane.ToStruct(), weightPoints?.Select(_=>_.ToStruct()))
        {
        }

        public AlignGrid(Runtime.Plane plane, IEnumerable<Runtime.Point3D> weightPoints)
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

        public static LineSegment3D GenGridLine(Runtime.Plane plane)
        {
            var size = Math.Max(plane.Size, 1);
            var halfVec = plane.XAxis * size;
            // create grid line

            var from = plane.Origin;
            from.Z = 0;
            var p1 = (from - halfVec).ToLB();
            var v = (halfVec * 2).ToLB();
            var line = new LineSegment3D(p1, v);
            return line;
        }

        private static Runtime.Plane RefitPlane(ref IEnumerable<Runtime.Point3D> weightPoints, Runtime.Plane plane)
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

        public static List<Runtime.Plane> GenGlobalPlanes(List<LineSegment3D> geos, Vector3D vec, double gridSize)
        {
            var pts = geos.SelectMany(_ => new[] { _.Point1.ToStruct(), _.Point2.ToStruct() });
            var bbox = new Runtime.Boundingbox(pts);

            var rVec = vec.ToStruct();
            // generate guid planes
            var moveDir = rVec.Rotate(Math.PI / 2);// rotate 90 degrees
            moveDir = moveDir.Normalize();
            var moveVec = moveDir * gridSize;


            var distance = bbox.Diagonal.Length;
            var halfDiagonal = distance / 2;
            var planeCounts = (int)(distance / gridSize);

            var baseOri = bbox.Center.Move(-halfDiagonal * moveDir);
            var basePlane = new Plane(moveDir.ToLB(), baseOri.ToLB(), vec).ToStruct();
         
            var gridPlanes = new List<Runtime.Plane>();
            for (int i = 0; i < planeCounts; i++)
            {
                var gd = basePlane;
                gd.Size = halfDiagonal;
                gd.Translate(i * moveVec);
                gridPlanes.Add(gd);
            }


            return gridPlanes;

        }

        public static List<AlignGrid> GenGrids(List<LineSegment3D> geos, List<Runtime.Plane> globalGridPlanes, double gridSize, double angleRadTol, double distanceThreshold )
        {

            var gridPlanes = globalGridPlanes;
            var vec = gridPlanes.FirstOrDefault().XAxis.ToLB();

            // get points from segments that are aligned with input vector
            var lines = geos
                .Where(_ =>
                {
                    var a = _.Direction.Angle(vec);
                    if (a <= angleRadTol)
                        return true;
                    return (Math.PI - a) <= angleRadTol;
                });

            var alignPts = lines.SelectMany(_ => new[] { _.Point1.ToStruct(), _.Point2.ToStruct() }).ToList();


            // project pts to grids 
            var halfGridSize = gridSize / 2;
            var halfGridSizeSquared = halfGridSize * halfGridSize;
            //var projectedPlanes2 = gridPlanes.Select(_ => new AlignGrid(_, alignPts.Where(p => Math.Abs(_.DistanceTo(p)) < halfGridSize))).ToList();
            var projectedPlanes2 = gridPlanes.Select(_ => new AlignGrid(_, alignPts.Where(p => Math.Abs(_.DistanceToSquared(p)) < halfGridSizeSquared))).ToList();

            var projectedPlanes = new List<AlignGrid>();
            var restPts = alignPts;
            //foreach (var plane in gridPlanes)
            //{
            //    var pts = restPts.Where(p => plane.DistanceToSquared(p) < halfGridSizeSquared);
            //    if (pts.Any())
            //    {
            //        var ag = new AlignGrid(plane, pts);
            //        projectedPlanes.Add(ag);
            //        restPts.RemoveAll(_ => pts.Contains(_));
            //    }
            //}



            // average planes
            var ageragedPlanes = projectedPlanes2.CullDuplicates(distanceThreshold);
            return ageragedPlanes ?? new List<AlignGrid>();
        }


    }

}