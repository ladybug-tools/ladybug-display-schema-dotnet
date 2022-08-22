
using NUnit.Framework;

using System;
using System.Linq;
using System.IO;
using System.Collections;

namespace LadybugDisplaySchema.Test
{


    public class FromJsonTests
    {
        [Test]
        public void LegendParamTest()
        {
            var obj = new LegendParameters(10, 100);
            Assert.IsTrue(obj != null);

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
            var cGeo = geos[0].Obj as Arc2D;
            Assert.AreEqual(cGeo.R, 3);

        }


        [Test]
        public void VisualizationSetTest()
        {
            var file = Path.Combine(_projDir, "Samples", "visualization.json");
            var json = File.ReadAllText(file);

            var obj = VisualizationSet.FromJson(json);
            Assert.AreEqual(obj.Type, "VisualizationSet");
            var contexts = obj.ContextGeometry.Where(_ => _ != null).ToList();
            Assert.AreEqual(contexts.Count, 2);
            var cGeo = contexts[0].Obj as DisplayArc2D;
            Assert.IsTrue(cGeo.LineWidth.Obj is Default);

        }

        [Test]
        public void DisplayArc2DTest()
        {
            var file = Path.Combine(_projDir, "Samples", "DisplayArc2D.json");

            var json = File.ReadAllText(file);
            var obj = DisplayArc2D.FromJson(json);

            Assert.IsTrue(obj.LineWidth.Obj is Default);

        }

    }

}
