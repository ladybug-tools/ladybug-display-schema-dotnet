extern alias LBTNewtonsoft; using System;
using System.Collections.Generic;
using System.Linq;


namespace LadybugDisplaySchema
{
    public partial class Face3D 
    {
        private double? _area = null;
        public IEnumerable<Point3D> BoundaryPoints => Boundary.Select(_ => Point3D.FromXYZ(_[0], _[1], _[2]));

        public IEnumerable<IEnumerable<Point3D>> HolePoints => Holes?.Select(b => b?.Select(_ => Point3D.FromXYZ(_[0], _[1], _[2])));

        public double Area
        {
            get
            {
                if (!_area.HasValue)
                    CalculateArea();
                return Math.Abs(_area.GetValueOrDefault());

            }
        }

        /// <summary>
        /// Normal vector for the plane in which the face exists.
        /// </summary>

        public Vector3D Normal
        {
            get
            {
                if (Plane != null)
                    return Plane.Normal;

                var pts = BoundaryPoints.ToList();
                return NormalFrom3Points(pts[0], pts[1], pts[2]);
            }
        }


        /// <summary>
        /// Boolean noting whether the face has holes within it.
        /// </summary>
        
        public bool HasHoles
        {
            get
            {
                return (Holes != null && Holes.Any());
            }
        }



        /// <summary>
        /// Create an instance of Cylinder.
        /// </summary>
        /// <param name="boundary">Array of Point3D objects representing the outer
        /// boundary vertices of the face.</param>
        /// <param name="plane">A Plane object indicating the plane in which the face exists.</param>
        /// <param name="holes">Optional collection of lists with one list for each hole in the face.</param>
        public Face3D(
            Point3D[] boundary,
            Plane plane = null,
            IEnumerable<Point3D[]> holes = null
            )
            : this( 
                  boundary.Select(_=> _.ToDecimalList())?.ToList(), 
                  holes?.Select(h=>h?.Select(_ => _.ToDecimalList())?.ToList())?.ToList(),
                  plane
                  )
        {

        }

        public Polygon2D ToPolygon2D()
        {
            this.Plane = this.Plane ?? PlaneFromVertices(this.BoundaryPoints.ToList());
           
            var boundaryPts = this.BoundaryPoints.Select(_ => Plane.XYZtoXY(_)).ToList();
            var holePts = this.HolePoints?.Select(hole => hole.Select(_ => Plane.XYZtoXY(_)).ToArray())?.ToList();
            holePts = holePts ?? new List<Point2D[]>();
            var polygon2D = Polygon2D.FromShapeWithHoles(boundaryPts, holePts);
            return polygon2D;
        }

        private void CalculateArea()
        {
            var polygon2D = this.ToPolygon2D();
            _area = polygon2D.Area;

        }


        /// <summary>
        /// Get a Vecto3D representing a normal vector from 3 vertices.
        /// </summary>
        /// <param name="pt1">Point 1.</param>
        /// <param name="pt2">Point 2.</param>
        /// <param name="pt3">Point 3.</param>
        /// <returns>Normal vector.</returns>
        public static Vector3D NormalFrom3Points(Point3D pt1,
            Point3D pt2,
            Point3D pt3)
        {
            var v1 = (pt2 - pt1);
            var v2 = (pt3 - pt1);
            return v1.Cross(v2).Normalize();
        }


        // https://github.com/ladybug-tools/ladybug-geometry/blob/c75aa30d8303fa644252e3801a1f18dee95dc76c/ladybug_geometry/geometry3d/face.py#L2084
        public static Plane PlaneFromVertices(List<Point3D> pts)
        {
            //    def _plane_from_vertices(verts):
            //"""Get a plane from a list of vertices.
            //Args:
            //verts: The vertices to be used to extract the normal.
            //"""
            //try:
            //    # walk around the shape and get cross products
            //    cprods, base_vert = [], verts[0]
            //    for i in range(len(verts) - 2):
            //        verts_3 = (base_vert, verts[i + 1], verts[i + 2])
            //        cprods.append(Face3D._normal_from_3pts(*verts_3))
            //    # sum together the cross products
            //    normal = [0, 0, 0]
            //    for cprodx in cprods:
            //        normal[0] += cprodx[0]
            //        normal[1] += cprodx[1]
            //        normal[2] += cprodx[2]
            //    # normalize the vector
            //    if normal != [0, 0, 0]:
            //        ds = math.sqrt(normal[0] ** 2 + normal[1] ** 2 + normal[2] ** 2)
            //        normal_vec = Vector3D(normal[0] / ds, normal[1] / ds, normal[2] / ds)
            //    else:  # zero area Face3D; default to positive Z axis
            //        normal_vec = Vector3D(0, 0, 1)
            //except Exception as e:
            //    raise ValueError('Incorrect vertices input for Face3D:\n\t{}'.format(e))
            //return Plane(normal_vec, verts[0])

            var cprods = new List<Vector3D>();
            var baseVert = pts.FirstOrDefault();
            for (int i = 0; i < pts.Count - 2; i++)
            {
                var n = NormalFrom3Points(baseVert, pts[i+1], pts[i+2]);
                cprods.Add(n);
            }

            var nX = cprods.Select(_ => _.X).Sum();
            var nY = cprods.Select(_ => _.Y).Sum();
            var nZ = cprods.Select(_ => _.Z).Sum();

            var normal = new[] { nX, nY, nZ };
            var normal_vec = Vector3D.FromXYZ(0, 0, 1);
            var isZero = normal.SequenceEqual(new[] { 0.0, 0.0, 0.0 });
            if (!isZero) //# zero area Face3D; default to positive Z axis
            {
                var ds = Math.Sqrt(nX * nX + nY * nY + nZ * nZ);
                normal_vec = Vector3D.FromXYZ(nX / ds, nY / ds, nZ / ds);
            }

            return new Plane(normal_vec, baseVert);


        }

    }
}
