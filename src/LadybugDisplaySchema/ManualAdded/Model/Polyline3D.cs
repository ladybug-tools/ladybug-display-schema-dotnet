using System.Collections.Generic;
using System.Linq;


namespace LadybugDisplaySchema
{
    public partial class Polyline3D
    {

        public Polyline3D(List<Point3D> vertices)
         : this(vertices?.Select(_=>_.ToDecimalList())?.ToList())
        { }

    }
}
