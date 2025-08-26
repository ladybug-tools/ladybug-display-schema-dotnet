using System;
using System.Collections.Generic;
using System.Linq;


namespace LadybugDisplaySchema
{
    public partial class Polyline3D
    {

        public Polyline3D ( List<List<double>> vertices, bool validate, bool interpolated = false) 
        {
            // to ensure "vertices" is required (not null)
            this.Vertices = vertices ?? throw new ArgumentNullException("vertices is a required property for Polyline3D and cannot be null");
            this.Interpolated = interpolated;

            // Set non-required readonly properties with defaultValue
            this.Type = "Polyline3D";

            // check if object is valid, only check for inherited class
            if (validate && this.GetType() == typeof(Polyline3D))
                this.IsValid(throwException: true);
        }

        public Polyline3D(List<Point3D> vertices)
         : this(vertices?.Select(_=>_.ToDecimalList())?.ToList(), false)
        { }

    }
}
