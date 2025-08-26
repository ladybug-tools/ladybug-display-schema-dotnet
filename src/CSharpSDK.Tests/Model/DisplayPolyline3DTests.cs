
using NUnit.Framework;

using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using LadybugDisplaySchema;

using System.Reflection;
using Newtonsoft.Json;

namespace LadybugDisplaySchema.Test
{
    public class DisplayPolyline3DTests
    {
      
        [Test]
        public void FromJsonTest()
        {
            var json = @"
{'type': 'DisplayPolyline3D', 'geometry': {'type': 'Polyline3D', 'vertices': [[98.51014371559587, 14.2522628435291, 0.0], [97.82999633098406, 20.677544453188457, 1.3156645720173707], [93.8113045550201, 34.571532867053484, 2.061129037082051], [91.75058879477656, 39.77151197665916, 0.2372570384150121], [91.9356682425542, 39.305471895943526, 0.0]], 'interpolated': true}, 'color': {'r': 0, 'g': 0, 'b': 0, 'a': 255, 'type': 'Color'}, 'line_width': {'type': 'Default'}, 'line_type': 'Continuous'}
";

            var obj = DisplayPolyline3D.FromJson(json);
            Assert.AreEqual(obj.Type, "DisplayPolyline3D");
            Assert.IsTrue(obj.LineWidth.Obj is Default);


        }


   
    }

}
