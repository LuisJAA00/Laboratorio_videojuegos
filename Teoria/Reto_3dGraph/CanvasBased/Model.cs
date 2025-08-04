using CanvasBased.MeshTriangVert;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasBased
{
    internal class Model
    {

        public Vertex centroid;
        public Mesh mesh = new Mesh();
        public Transform transform;

        private StreamReader reader;
        public String path;

        public Model(String path2File)
        {
            transform = new Transform(1,new Vertex(0,0,0), new Vertex (0,0,0));
            string line;
            reader = new StreamReader(path2File);
            this.path = path2File;

            List<Vertex> vertices = new List<Vertex>(); 


            while((line = reader.ReadLine()) != null)
            {
                if(line.StartsWith("v") && line[1] == ' ') // si tenemos un vertice...
                {
                    string[] parts = line.Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries);
                    
                    double x = double.Parse(parts[1]);
                    double y = double.Parse(parts[2]);
                    double z = double.Parse(parts[3]);

                    vertices.Add(new Vertex(x*100,y*100,z*100));
                }
                else if(line.StartsWith("f"))
                {
                    int v1, v2, v3;

                    string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string[] partsDivided;

                    partsDivided = parts[1].Split(new char[] {'/' }, StringSplitOptions.RemoveEmptyEntries);
                    v1 = int.Parse(partsDivided[0]);

                    partsDivided = parts[2].Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                    v2 = int.Parse(partsDivided[0]);

                    partsDivided = parts[3].Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                    v3 = int.Parse(partsDivided[0]);

                    mesh.AddTriangle(vertices[v1-1], vertices[v2-1], vertices[v3 - 1]);
                }
            }

            this.getCentroid(vertices);
        }

     

        private void getCentroid(List<Vertex> vertices)
        {
            double x = 0;
            double y = 0;
            double z = 0;

            for(int i = 0; i < vertices.Count; i++)
            {
                x += vertices[i][0];
                y += vertices[i][1];
                z += vertices[i][2];
            }

            x = x/vertices.Count;
            y = y/vertices.Count;
            z = z/vertices.Count;

            this.centroid = new Vertex(x, y, z);
        }

    }
}
