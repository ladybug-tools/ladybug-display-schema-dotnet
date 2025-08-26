using System;

namespace LadybugDisplaySchema
{
    public partial class Arc3D
    {
        private Arc2D _arc2D => new Arc2D(Point2D.FromXY(0, 0), this.Radius, this.A1, this.A2);

        public bool IsCircle
        {
            get
            {
                return A1 == 0 && 
                    A2 == (2 * Math.PI);
            }
        }

        /// <summary>
        /// Center point of the circle on which the arc lies.
        /// </summary>
        
        public Point3D C
        {
            get
            {
                return Plane.Origin;
            }
        }

        /// <summary>
        /// Start point.
        /// </summary>
        
        public Point3D P1
        {
            get
            {
                return Plane.XYtoXYZ(_arc2D.P1);
            }
        }

        /// <summary>
        /// End point.
        /// </summary>
        
        public Point3D P2
        {
            get
            {
                return Plane.XYtoXYZ(_arc2D.P2);
            }
        }

        /// <summary>
        /// The total angle over the domain of the arc in radians.
        /// </summary>
        
        public double Angle
        {
            get
            {
                var diff = A2 - A1;
                return (!IsInverted) ? diff : 2 * Math.PI + diff;
            }
        }

        /// <summary>
        /// Boolean noting whether the end angle a2 is
        /// smaller than the start angle a1.
        /// </summary>
        
        public bool IsInverted
        {
            get
            {
                return A2 < A1;
            }
        }

        /// <summary>
        /// Midpoint.
        /// </summary>
        
        public Point3D MidPoint
        {
            get
            {
                return PointAt(0.5);
            }
        }

       
        /// <summary>
        /// Get a point at a given fraction along the arc
        /// </summary>
        /// <param name="parameter">The fraction between the start and end point</param>
        /// <returns>Point2D object.</returns>
        public Point3D PointAt(double parameter)
        {
            return Plane.XYtoXYZ(_arc2D.PointAt(parameter));
        }

    
    }
}
