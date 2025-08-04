using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasBased.MeshTriangVert
{
    internal class Triangle
    {
        public List<Vertex> vertices;
        public Triangle(Vertex v1, Vertex v2, Vertex v3)
        {
            vertices = new List<Vertex>();
            vertices.Add(v1);
            vertices.Add(v2);
            vertices.Add(v3);
        }

        

    }

    

}

