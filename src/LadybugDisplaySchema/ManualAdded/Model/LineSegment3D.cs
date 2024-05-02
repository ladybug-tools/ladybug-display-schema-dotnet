
extern alias LBTNewtonsoft; using System;
using System.Collections.Generic;

namespace LadybugDisplaySchema
{
    public partial class LineSegment3D
    {
        /// <summary>
        /// First point (same as p).
        /// </summary>
        public List<double> P1 => this.P;
        public Point3D Point1 => Point3D.FromXYZ(P1[0], P1[1], P1[2]);



        /// <summary>
        /// Second point.
        /// </summary>
        public List<double> P2 => new List<double> { V[0] + P[0], V[1] + P[1], V[2] + P[2] };
 
        public Point3D Point2 => Point3D.FromXYZ(P2[0], P2[1], P2[2]);

        public Vector3D Direction =>  Vector3D.FromXYZ(V[0], V[1], V[2]);


        public LineSegment3D (List<double> p, List<double> v, bool validate) 
        {
            this.P = p ?? throw new ArgumentNullException("p is a required property for LineSegment3D and cannot be null");
            this.V = v ?? throw new ArgumentNullException("v is a required property for LineSegment3D and cannot be null");

            this.Type = "LineSegment3D";


            if (validate && this.GetType() == typeof(LineSegment3D))
                this.IsValid(throwException: true);
        }


        public LineSegment3D(Point3D p1, Point3D p2)
          : this( p1.ToDecimalList(), (p2 - p1).ToDecimalList(), false)
        { }

        /// <summary>
        /// Create an instance of LineSegment3D.
        /// </summary>
        /// <param name="p">A Point3D representing the base.</param>
        /// <param name="v">A Vector3D representing the direction.</param>
        public LineSegment3D(Point3D p, Vector3D v)
            : this(p.ToDecimalList(), v.ToDecimalList(), false)
        {
        }

    }
}
