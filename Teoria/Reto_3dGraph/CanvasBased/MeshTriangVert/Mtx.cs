using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasBased.MeshTriangVert
{
    internal class Mtx
    {
        const int x = 0;
        const int y = 1;
        const int z = 2;

        private double[,] Mat = new double[,]
        {
            { 1.0, 0.0, 0.0 },
            { 0.0, 1.0, 0.0 },
            { 0.0, 0.0, 1.0 }
        };
        private double[,] axis = new double[,]
        {
            { 1.0, 0.0, 0.0 },
            { 0.0, 1.0, 0.0 },
            { 0.0, 0.0, 1.0 }
        };

        public double this[int x, int y]
        {
            get { return Mat[x, y]; }
            set { Mat[x, y] = value; }
        }

        public Mtx(double[,] Math)
        {
            this.Mat = Math;
        }

        public Vertex Mul(Vertex vertex)
        {
            Vertex pts;

            pts = new Vertex(new double[3]);

            pts[x] = (this[x, x] * vertex[x]) + (this[y, x] * vertex[y]) + (this[z, x] * vertex[z]);
            pts[y] = (this[x, y] * vertex[x]) + (this[y, y] * vertex[y]) + (this[z, y] * vertex[z]);
            pts[z] = (this[x, z] * vertex[x]) + (this[y, z] * vertex[y]) + (this[z, z] * vertex[z]);

            return pts;
        }



    }
}
