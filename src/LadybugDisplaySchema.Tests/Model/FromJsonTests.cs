
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

            // check areas
            var face3Ds = contexts.SelectMany(_ => _.Geometry).OfType<DisplayFace3D>().Select(_ => _.Geometry).ToList();
            foreach (var f in face3Ds)
            {
                var p = f.Plane;
                var p2 = Face3D.PlaneFromVertices(f.BoundaryPoints.ToList());
                // test plane
                //Assert.AreEqual(p.Normal.ToString(true), p2.Normal.ToString(true));
                //Assert.AreEqual(p.Origin.ToString(true), p2.Origin.ToString(true));
                var pt = new Point3D(1, 10, 0);
                var pt2D = p.XYZtoXY(pt);
                var pt2D2 = p2.XYZtoXY(pt);
                Assert.AreEqual(Math.Abs(pt2D.X), Math.Abs(pt2D2.X));


                // test Polygon2D
                var polygon = f.ToPolygon2D();
                Assert.IsTrue(polygon.Vertices.Count == 4);

                var boundaryPts = f.BoundaryPoints.Select(_ => p2.XYZtoXY(_)).ToList();
                var polygon2 = Polygon2D.FromShapeWithHoles(boundaryPts, new List<Point2D[]>());
                Assert.AreEqual(polygon.ToString(true), polygon2.ToString(true));

                var area1 = Math.Round(polygon.Area, 2);
                var area2 = Math.Round(polygon2.Area, 2);

                Assert.IsTrue(area1 == area2);
                Assert.AreEqual(area1 , 15);
                Assert.IsTrue(f.Area > 14.9);
            }
          
        }

        [Test]
        public void Face3DAreaTest()
        {
            var boundary = new List<Point3D>() { 
                new Point3D(0,0,0 ),
                new Point3D(0,1.5,0 ),
                new Point3D(1,1.5,0 ),
                new Point3D(1,0,0 )
                };

            var face = new Face3D(boundary.ToArray());
            Assert.AreEqual(face.Area, 1.5);

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
            Assert.IsTrue(legend.OrdinalDictionary == null);
            Assert.IsTrue(legend.HasNone);

            data = new List<string>()
            {
                "Test",
                "1.2",
                "0.6",
                "None",
                "0.6",
                "2.6",
                "Test",
                "-4",
                "21"
            };
            vData = new VisualizationData(data, null);
            legend = vData.LegendParameters;
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
