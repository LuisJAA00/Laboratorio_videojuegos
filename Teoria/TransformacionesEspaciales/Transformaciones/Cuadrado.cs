using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transformaciones
{
    internal class Cuadrado: Figura, ICloneable
    {
        Attribute attribute;
        Point location;
        
        public Cuadrado(int size, Point location) {
            size = size * 100;
            this.location = location;
            //for(int i = 0; i < sides; i++)
            //{
               
            //    this.AddPoint(new Point(0, 0));
            //}
            CalculatePoints(size,location);
        }

       

        public override void CalculatePoints(int size, Point location)
        {
            this.AddPoint(new Point(location.X - (int)size / 2, location.Y - (int)size / 2));
            this.AddPoint(new Point(location.X + (int)size / 2, location.Y - (int)size / 2));
            this.AddPoint(new Point(location.X + (int)size / 2, location.Y + (int)size / 2));
            this.AddPoint(new Point(location.X - (int)size / 2, location.Y + (int)size / 2));

        }

        public object Clone()
        {
            Cuadrado cuadrado = new Cuadrado(this.size, new Point(0,0));

            cuadrado.currentRotation = this.currentRotation;
            cuadrado.currentX = this.currentX;
            cuadrado.currentY = this.currentY;
            cuadrado.currentScale = this.currentScale;

            for(int i = 0; i < 4; i++)
            {
                cuadrado.figurePoints[i] = this.figurePoints[i];
            }

            cuadrado.Transform();
            return cuadrado;

        }

        public override Point getCentroid() //esto esta mañ!!
        {
            return new Point(size * 100 / 2, size * 100 / 2);
        }
    }
}
