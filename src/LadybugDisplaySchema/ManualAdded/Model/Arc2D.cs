extern alias LBTNewtonsoft; using System;

namespace LadybugDisplaySchema
{
    public partial class Arc2D 
    {
       
        public Point2D Center => Point2D.FromXY(C[0], C[1]);

        /// <summary>
        /// Start point.
        /// </summary>
        
        public Point2D P1
        {
            get
            {
                return Point2D.FromXY(Center.X + Math.Cos(A1) * R, 
                    Center.Y + Math.Sin(A1) * R);
            }
        }

        /// <summary>
        /// End point.
        /// </summary>
        
        public Point2D P2
        {
            get
            {
                return Point2D.FromXY(Center.X + Math.Cos(A2) * R,
                    Center.Y + Math.Sin(A2) * R);
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
        /// Boolean noting whether the end angle a2 is smaller than the start angle a1.
        /// </summary>
        
        public bool IsInverted
        {
            get
            {
                return A2 < A1;
            }
        }
   
        public Arc2D(Point2D c, 
            double r, 
            double a1= 0, 
            double a2= 2 * Math.PI)
            : this(c.ToDecimalList(), r, a1, a2)
        {
        }

        /// <summary>
        /// Get a point at a given fraction along the arc.
        /// </summary>
        /// <param name="parameter">The fraction between the start and end point where the
        /// desired point lies.For example, 0.5 will yield the midpoint.</param>
        /// <returns>Point2D.</returns>
        public Point2D PointAt(double parameter)
        {
            var _ang = A1 + Angle * parameter;
            _ang = (_ang <= Math.PI) ? _ang : _ang - Math.PI * 2;
            return Point2D.FromXY(Center.X + Math.Cos(_ang) * R,
                Center.Y + Math.Sin(_ang) * R);
        }

    
    }
}
