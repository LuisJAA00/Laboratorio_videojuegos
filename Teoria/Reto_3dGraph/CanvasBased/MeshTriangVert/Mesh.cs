
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CanvasBased.MeshTriangVert
{
    internal class Mesh
    {

        public List<Triangle> triangles = new List<Triangle>();

        public Mesh() { }
        public void AddQuad(Vertex v1,Vertex v2, Vertex v3, Vertex v4)
        {
            triangles.Add(new Triangle(v1,v2,v3));
            triangles.Add(new Triangle(v1,v3,v4));
        }

        public void AddTriangle(Vertex v1, Vertex v2, Vertex v3)
        {
            triangles.Add(new Triangle(v1,v2,v3));
        }


    }
}
