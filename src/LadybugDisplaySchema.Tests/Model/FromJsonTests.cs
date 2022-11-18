
using NUnit.Framework;

using System;
using System.Linq;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace LadybugDisplaySchema.Test
{


    public class FromJsonTests
    {
        [Test]
        public void LegendParamTest()
        {
            var obj = new LegendParameters(10, 100);
            var dup = obj.DuplicateLegendParameters();
            Assert.AreEqual(obj.ToString(), dup.ToString());
            Assert.IsTrue(obj.Equals( dup));
            Assert.AreEqual(obj, dup);
            Assert.IsTrue(obj == dup);  
        }

        //D:\Dev\ladybug_tools\ladybug-display-schema-dotnet\src\LadybugDisplaySchema.Tests\bin\Debug\net5
        string _projDir = new System.IO.DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;

        [Test]
        public void AnalysisGeometryTest()
        {
            var file = Path.Combine(_projDir, "Samples", "AnalysisGeometry.json");
            var json = File.ReadAllText(file);

            var obj = AnalysisGeometry.FromJson(json);
            Assert.AreEqual(obj.Type, "AnalysisGeometry");
            var geos = obj.Geometry.Where(_ => _ != null).ToList();
            Assert.AreEqual(geos.Count, 1);
            var cGeo = geos[0].Obj as Mesh2D;
            Assert.AreEqual(cGeo.Colors, null);
            Assert.AreEqual(cGeo.Faces.Count, 100);

        }


        [Test]
        public void VisualizationSetTest()
        {
            var file = Path.Combine(_projDir, "Samples", "visualization.json");
            var json = File.ReadAllText(file);

            var obj = VisualizationSet.FromJson(json);
            Assert.AreEqual(obj.Type, "VisualizationSet");
            var contexts = obj.Geometry.OfType<ContextGeometry>().Where(_ => _ != null).ToList();
            Assert.AreEqual(contexts.Count, 1);
            var cGeo = contexts.First().Geometry.FirstOrDefault().Obj as DisplayFace3D;
            Assert.IsTrue(cGeo.DisplayMode == DisplayModes.Wireframe);

        }

        [Test]
        public void VisualizationDataWithStringValuesTest()
        {
            var data = new List<string>()
            {
                "0.6",
                "1.2",
                "0.6",
                "None",
                "13",
                "2.6",
                "0.6",
                "-4",
                "21"
            };

            var vData = new VisualizationData(data, null);
            var legend = vData.LegendParameters;
            Assert.IsTrue(legend.OrdinalDictionary != null);
            Assert.AreEqual(legend.GetOrdinalDictionary().Count, 7);
        }

        [Test]
        public void DisplayArc2DTest()
        {
            var file = Path.Combine(_projDir, "Samples", "DisplayArc2D.json");

            var json = File.ReadAllText(file);
            var obj = DisplayArc2D.FromJson(json);

            if (obj.LineWidth.Obj is double d)
            {
                Assert.AreEqual(d, 1);
            }
            else
            {
                Assert.IsTrue(obj.LineWidth.Obj is Default);
            }
            

        }

    }

}
