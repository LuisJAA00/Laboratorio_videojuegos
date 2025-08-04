using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CanvasBased.MeshTriangVert
{
    internal class Vertex
    {




        const int X1 = 0;
        const int Y1 = 1;
        const int Z1 = 2;
        public int transX = 0;
        public int transY = 0;
        public int transZ = 0;
        public double currentRotationZ = 0;
        public double currentRotationY = 0;
        public double currentRotationX = 0;

        public double[] values = new double[3];

        public double this[int i]
        {
            get { return values[i]; }
            set { values[i] = value; }
        }
        public Vertex(double[] values)
        {
            this.values = values;
        }
        public Vertex(double x, double y, double z)
        {
            this[X1] = x;
            this[Y1] = y;
            this[Z1] = z;
        }
        public static Vertex operator *(Vertex a, Vertex b)
        {
            return new Vertex(new double[] { a[X1] * b[X1], a[Y1] * b[Y1], a[Z1] * b[Z1] });
        }
        public static Vertex operator +(Vertex a, Vertex b)
        {
            return new Vertex(new double[] { a[X1] + b[X1], a[Y1] + b[Y1], a[Z1] + b[Z1] });
        }
        public override string ToString()
        {
            return this[X1] + " , " + this[Y1] + " , " + this[Z1] + "  ";
        }
        //public Vertex(double x, double y, double z)
        //{
        //    this.x = x;
        //    this.y = y;
        //    this.z = z;
        //}

        public void Render(Graphics graphics)
        {

            Vertex vertex = new Vertex(this[X1], this[Y1], this[Z1]);


            vertex = Scale(1, vertex);

            if (currentRotationZ > 0)
            {
                vertex = RotZ(currentRotationZ, vertex);
            }
            if (currentRotationY > 0)
            {
                vertex = RotY(currentRotationY, vertex);
            }
            if (currentRotationX > 0)
            {
                vertex = RotX(currentRotationX, vertex);
            }
            vertex = PerspectiveMatrix(3, vertex);

            vertex[X1] = vertex[X1] + this.transX;
            vertex[Y1] = vertex[Y1] + this.transY;
            vertex[Z1] = vertex[Z1] + this.transZ;

            graphics.DrawEllipse(Pens.Yellow, new Rectangle((int)vertex[X1], (int)vertex[Y1], 10, 10));

        }

        public Point Transform() // apply transformations and return vertex in 2d cords
        {
            Vertex vertex = new Vertex(this[X1], this[Y1], this[Z1]);


            vertex = Scale(1, vertex);

            if (currentRotationZ > 0)
            {
                vertex = RotZ(currentRotationZ, vertex);
            }
            if (currentRotationY > 0)
            {
                vertex = RotY(currentRotationY, vertex);
            }
            if (currentRotationX > 0)
            {
                vertex = RotX(currentRotationX, vertex);
            }
            vertex = PerspectiveMatrix(3, vertex);

            vertex[X1] = vertex[X1] + this.transX;
            vertex[Y1] = vertex[Y1] + this.transY;
            vertex[Z1] = vertex[Z1] + this.transZ;

            return new Point((int)vertex[X1], (int)vertex[Y1]);
        }

        public static Vertex TransformationMatrix(Vertex vertex) // proyeccion
        {
            Double[] res = new Double[2];

            res[0] = vertex[X1] * 1;
            res[1] = vertex[Y1] * 1;

            return new Vertex(res[0], res[1], 0);
        }

        public Vertex TranslateThisVertex(int x, int y, int z)
        {
            Vertex resVer = new Vertex(this[X1] + x, this[Y1] + y, this[Z1] + z);

            return resVer;
        }
        public void Translacion(int x, int y, int z)
        {

            this.transX += x;
            this.transY += y;
            this.transZ += z;
        }
        public Vertex Scale(int factor, Vertex vertex)
        {
            vertex[X1] = vertex[X1] * factor;
            vertex[Y1] = vertex[Y1] * factor;
            vertex[Z1] = vertex[Z1] * factor;

            return vertex;
        }

        public Vertex RotZ(Double angle, Vertex p)
        {

            Debug.Write($"Points before this shit {p} xd");
            Mtx Mat;

            double cos = (double)Math.Cos(angle);
            double sin = (double)Math.Sin(angle);
            Debug.WriteLine($"the cos is {cos} and the sin is {sin}");

            double[,] axis = new Double[,]
                       {
                { cos, -sin, 0},
                { sin, cos, 0},
                { 0  ,   0, 1 }

                       };
            Mat = new Mtx(axis);

            Vertex vertex = Mat.Mul(p);
            Debug.Write($"Printing points {vertex} xd");
            return vertex;
        }

        public Vertex RotZ(Double angle)
        {

            Vertex p = this;
            Mtx Mat;

            double cos = (double)Math.Cos(angle);
            double sin = (double)Math.Sin(angle);
            Debug.WriteLine($"the cos is {cos} and the sin is {sin}");

            double[,] axis = new Double[,]
                       {
                { cos, -sin, 0},
                { sin, cos, 0},
                { 0  ,   0, 1 }

                       };
            Mat = new Mtx(axis);

            Vertex vertex = Mat.Mul(p);
            Debug.Write($"Printing points {vertex} xd");
            return vertex;
        }

        public Vertex RotY(Double angle, Vertex p)
        {

            Mtx Mat;

            double cos = (double)Math.Cos(angle);
            double sin = (double)Math.Sin(angle);


            double[,] axis = new Double[,]
                       {
                { cos, 0, sin},
                { 0, 1, 0},
                { -sin,0, cos }

                       };
            Mat = new Mtx(axis);

            Vertex vertex = Mat.Mul(p);
            Debug.Write($"Printing points {vertex} xd");
            return vertex;
        }
        public Vertex RotY(Double angle)
        {

            Mtx Mat;
            Vertex p = this;

            double cos = (double)Math.Cos(angle);
            double sin = (double)Math.Sin(angle);


            double[,] axis = new Double[,]
                       {
                { cos, 0, sin},
                { 0, 1, 0},
                { -sin,0, cos }

                       };
            Mat = new Mtx(axis);

            Vertex vertex = Mat.Mul(p);
            Debug.Write($"Printing points {vertex} xd");
            return vertex;
        }

        public Vertex RotX(Double angle, Vertex p)
        {

            Mtx Mat;

            double cos = (double)Math.Cos(angle);
            double sin = (double)Math.Sin(angle);


            double[,] axis = new Double[,]
                       {
                { 1, 0, 0},
                { 0, cos, -sin},
                { 0,sin, cos }

                       };
            Mat = new Mtx(axis);

            Vertex vertex = Mat.Mul(p);
            Debug.Write($"Printing points {vertex} xd");
            return vertex;
        }
        public Vertex RotX(Double angle)
        {
            Vertex p = this;
            Mtx Mat;

            double cos = (double)Math.Cos(angle);
            double sin = (double)Math.Sin(angle);


            double[,] axis = new Double[,]
                       {
                { 1, 0, 0},
                { 0, cos, -sin},
                { 0,sin, cos }

                       };
            Mat = new Mtx(axis);

            Vertex vertex = Mat.Mul(p);
            Debug.Write($"Printing points {vertex} xd");
            return vertex;
        }
        public void IncreaseRotation(double angle, char axis)
        {
            switch (axis)
            {
                case 'x':
                    this.currentRotationX += angle;
                    break;
                case 'y':
                    this.currentRotationY += angle;
                    break;
                case 'z':
                    this.currentRotationZ += angle;
                    break;
            }
            Debug.WriteLine($"current y angle {currentRotationY * (180 / 3.1416)}");
        }

        public static Vertex PerspectiveMatrix(double dist, Vertex p)
        {

            Mtx Mat;

            double z = (double)(-1 / (dist - p[Z1] / 100));


            double[,] axis = new Double[,]
                       {
                { z, 0, 0},
                { 0, z, 0},
                { 0,0, 1 }

                       };
            Mat = new Mtx(axis);

            Vertex vertex = Mat.Mul(p);

            return vertex;
        }
        public  Vertex PerspectiveMatrix(double dist)
        {
            Vertex p = this;
            Mtx Mat;

            double z = (double)(-1 / (dist - p[Z1] / 100));


            double[,] axis = new Double[,]
                       {
                { z, 0, 0},
                { 0, z, 0},
                { 0,0, 1 }

                       };
            Mat = new Mtx(axis);

            Vertex vertex = Mat.Mul(p);

            return vertex;
        }

    }
}
