
using System;
using System.Collections.Generic;
using System.Linq;

namespace LadybugDisplaySchema
{
    public partial class Polygon2D
    {
        private bool _isClockwise;
        private double _area;


        /// <summary>
        /// Array of all line segments in the polygon
        /// </summary>

        public LineSegment2D[] Segments => SegmentsFromVertices();

        /// <summary>
        /// The area of the polygon.
        /// </summary>

        public double Area => Math.Abs(_area);

        /// <summary>
        /// Calculate the area.
        /// </summary>
        private void CalculateArea()
        {
            double a = 0;
            for (int i = 1; i < Vertices.Count; i++)
            {
                a += Vertices.GetElementByIndex(i - 1)[0] * Vertices[i][1] -
                    Vertices.GetElementByIndex(i - 1)[1] * Vertices[i][0];
            }
            _area = a / 2;
        }

        /// <summary>
        /// Boolean for whether the polygon vertices are in clockwise order.
        /// </summary>

        public bool IsClockwise
        {
            get
            {
                return _area < 0;
            }
            private set
            {
                _isClockwise = value;
            }
        }

        public Polygon2D(Point2D[] vertices)
            : this(vertices?.Select(x => x.ToDecimalList())?.ToList())
        {
        }



        /// <summary>
        /// Get segments from vertices.
        /// </summary>
        /// <returns>Array of segments.</returns>
        private LineSegment2D[] SegmentsFromVertices()
        {
            var segs = new List<LineSegment2D>();
            for (int i = 0; i < Vertices.Count; i++)
            {
                var p1 = Vertices.GetElementByIndex(i - 1);
                var p2 = Vertices[i];
                var v = new List<double> { p2[0] - p1[0], p2[1] - p1[1] };
                var seg = new LineSegment2D(p1, v);
                segs.Add(seg);
            }
            var outSegments = segs.ToArray();
            outSegments.Rotate();

            return outSegments;
        }

        /// <summary>
        /// Initialize a Polygon2D from a boundary shape with a hole inside of it.
        /// This method will convert the shape into a single concave polygon by drawing
        /// a line from the hole to the outer boundary.
        /// </summary>
        /// <param name="boundary">A list of Point2D objects for the outer boundary of the polygon
        /// inside of which the hole is contained.</param>
        /// <param name="holes">A list of Point2D objects for the hole.</param>
        /// <returns>A new polygon.</returns>
        public static Polygon2D FromShapeWithHoles(List<Point2D> boundary,
            List<Point2D[]> holes)
        {
            foreach (var hole in holes)
            {
                if (hole.Length < 3)
                    throw new Exception("hole should have at least 3 vertices.");
            }

            var boundDirection = AreClockWise(boundary.ToArray());

            for (int i = 0; i < holes.Count; i++)
            {
                if (AreClockWise(holes[i].ToArray()) == boundDirection)
                {
                    var pts = new List<Point2D>();
                    foreach (var p in holes[i])
                    {
                        pts.Add(new Point2D(p.Y, p.X));
                    }
                    holes[i] = pts.ToArray();
                }
            }

            Polygon2D pol = null;
            while (holes.Count > 0)
            {
                var result = MergeBoundaryAndClosestHole(boundary.ToArray(),
                    holes.ToArray());
                holes = result.Item2;
                boundary = result.Item1;
                pol = new Polygon2D(boundary.ToArray());
            }
            pol.IsClockwise = boundDirection;
            return pol;
        }

        /// <summary>
        /// Return a list of points for a boundary merged with the closest hole.
        /// </summary>
        /// <param name="boundary">Array of Point2D objects for the outer boundary of the polygon
        /// inside of which the hole is contained.</param>
        /// <param name="holes">A list of Point2D objects for the hole.</param>
        /// <returns>Tuple of list of points.</returns>
        public static Tuple<List<Point2D>, List<Point2D[]>>
            MergeBoundaryAndClosestHole(Point2D[] boundary,
            Point2D[][] holes)
        {

            var holeDicts = new List<Dictionary<double, Tuple<int, int>>>();
            var minDists = new List<double>();
            foreach (var hole in holes)
            {
                var distDict = new Dictionary<double, Tuple<int, int>>();
                for (int i = 0; i < boundary.Length; i++)
                {
                    for (int j = 0; j < hole.Length; j++)
                    {
                        var dist = boundary[i].DistanceToPoint(hole[j]);
                        distDict[dist] = new Tuple<int, int>(i, j);
                    }
                }
                holeDicts.Add(distDict);
                minDists.Add(distDict.Keys.Min());
            }
            var holeIndex = minDists.IndexOf(minDists.Min());
            var newBoundary = MergeBoundaryAndHole(boundary,
                holes[holeIndex], holeDicts[holeIndex])
                .ToList();
            var outHoles = holes.ToList();
            outHoles.RemoveAt(holeIndex);

            return new Tuple<List<Point2D>, List<Point2D[]>>
                (newBoundary, outHoles);
        }

        /// <summary>
        /// Create a single list of points describing a boundary shape with a hole.
        /// </summary>
        /// <param name="boundary"> Array of Point2D objects for the outer boundary inside of
        /// which the hole is contained.</param>
        /// <param name="holes">A list of Point2D objects for the hole.</param>
        /// <param name="distDict">A dictionary with keys of distances between each of the points
        ///     in the boundary and hole lists and values as tuples with two values:
        ///     (the index of the boundary point, the index of the hole point)</param>
        /// <returns>Array of points.</returns>
        private static Point2D[] MergeBoundaryAndHole(Point2D[] boundary,
            Point2D[] hole,
            Dictionary<double, Tuple<int, int>> distDict)
        {
            var minDist = distDict.Keys.Min();
            var minIndexes = distDict[minDist];
            var holeDeque = hole.Duplicate();
            holeDeque.RotateByIndex(-minIndexes.Item2);

            var dup = holeDeque.Duplicate().ToList();
            var holeInsert = new List<Point2D>() { boundary[minIndexes.Item1] };
            holeInsert.AddRange(dup);
            var part2 = new List<Point2D>() { hole[minIndexes.Item2] };
            holeInsert.AddRange(part2);
            return boundary.InsertAt(holeInsert.ToArray(), minIndexes.Item1);
        }



        /// <summary>
        /// Check if a list of vertices are clockwise.
        /// </summary>
        /// <param name="vertices">Array of Point2D objects representing 
        /// the vertices of the polygon.</param>
        /// <returns>True if clockwise otherwise false.</returns>
        public static bool AreClockWise(Point2D[] vertices)
        {
            double a = 0;

            for (int i = 0; i < vertices.Length; i++)
            {
                a += vertices.GetElementByIndex(i - 1).X * vertices[i].Y -
                    vertices.GetElementByIndex(i - 1).Y * vertices[i].X;
            }
            return a < 0;
        }
    }
      
}
