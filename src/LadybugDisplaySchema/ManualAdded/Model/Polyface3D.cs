using System.Collections.Generic;
using System.Linq;


namespace LadybugDisplaySchema
{
    /// </summary>
    public partial class Polyface3D
    {
        public IEnumerable<Point3D> VerticePoints => Vertices.Select(_ => new Point3D(_[0], _[1], _[2]));


        private List<Face3D> _faces;
        ///// <summary>
        ///// Array of all Face3D objects making up this polyface.
        ///// </summary>
        public List<Face3D> Faces
        {
            get
            {
                if (_faces == null)
                    SetFacesIfNull();
                return _faces;
            }
        }

        /// <summary>
        /// Set Faces if array of faces is null
        /// </summary>
        private void SetFacesIfNull()
        {
            var faces = new List<Face3D>();
            var pp = Vertices.Select(_ => new Point3D(_[0], _[1], _[2]));
            var vPts = this.VerticePoints.ToList();
            foreach (var face in FaceIndices)
            {
                var pts = new List<Point3D>();
                foreach (var index in face[0])
                {
                    pts.Add(vPts[index]);
                }

                if (face.Count == 1)
                {
                    faces.Add(new Face3D(pts.ToArray()));
                }
                else
                {
                    var copyFaceIndex = face.
                        ToArray().Duplicate();

                    copyFaceIndex = copyFaceIndex.Skip(1)
                        .ToArray();

                    var holeGrps = new List<Point3D[]>();
                    foreach (var group in copyFaceIndex)
                    {
                        var holePts = new List<Point3D>();
                        foreach (var i in group)
                        {
                            holePts.Add(vPts[i]);
                        }
                        holeGrps.Add(holePts.ToArray());
                    }

                    faces.Add(new Face3D(pts.ToArray(),
                        holes: holeGrps));
                }
            }
            _faces = faces;

        }


        public Polyface3D(Polyface3D other)
            :this(other.Vertices, other.FaceIndices, other.EdgeInformation)
        {
        }

        /// <summary>
        /// Initialize Polyface3D from a list of Face3D objects.
        /// </summary>
        /// <param name="faces">A list of Face3D objects.</param>
        /// <param name="tolerance">The maximum difference between x, y, and z values.</param>
        /// <returns>Polyface3D object.</returns>
        public Polyface3D(List<Face3D> faces, double tolerance = 0.0001)
            :this(FromFace3Ds(faces, tolerance))
        {
        }

        private static Polyface3D FromFace3Ds(List<Face3D> faces, double tolerance = 0.0001)
        {
            var faceIndices = new List<List<List<int>>>();
            var vertices = new List<List<double>>();
            foreach (var f in faces)
            {
                var ind = new List<List<int>>();

                var loops = new List<List<List<double>>> { f.Boundary };
                if (f.HasHoles)
                    loops.Concat(f.Holes);


                for (int i = 0; i < loops.Count; i++)
                {
                    ind.Add(new List<int>());
                    foreach (var v in loops[i])
                    {
                        var found = false;
                        for (int j = 0; j < vertices.Count; j++)
                        {
                            if (Extension.AllEquals(v, vertices[j], tolerance))
                            {
                                found = true;
                                ind[i].Add(j);
                                break;
                            }
                        }
                        if (!found)
                        {
                            vertices.Add(v);
                            ind[i].Add(vertices.Count - 1);
                        }
                    }
                }
                faceIndices.Add(ind);
            }

            return new Polyface3D(vertices, faceIndices);

        }

      
    }
}
