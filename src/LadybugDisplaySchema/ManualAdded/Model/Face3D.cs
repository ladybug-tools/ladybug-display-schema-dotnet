using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;


namespace LadybugDisplaySchema
{
    public partial class Face3D 
    {
        public IEnumerable<Point3D> BoundaryPoints => Boundary.Select(_ => new Point3D(_[0], _[1], _[2]));

        public IEnumerable<IEnumerable<Point3D>> HolePoints => Holes?.Select(b => b?.Select(_ => new Point3D(_[0], _[1], _[2])));


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
        /// <param name="enforceRightHand">Boolean to note whether a check should be run to
        /// ensure that input vertices are counterclockwise within the input plane,
        /// thereby enforcing the right-hand rule.</param>
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
            var v1 = (pt2 - pt1).ToVector3D();
            var v2 = (pt3 - pt1).ToVector3D();
            return v1.Cross(v2).Normalize();
        }


    }
}
