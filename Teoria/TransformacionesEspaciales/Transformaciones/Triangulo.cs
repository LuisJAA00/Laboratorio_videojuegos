using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transformaciones
{
    internal class Triangulo : Figura, ICloneable
    {

        public Triangulo(int size, Point location) {
            this.size = size*100;
            int sides = 3;

            //for(int i = 0; i < sides; i++)
            //{
            //    this.AddPoint(new Point(0, 0));
            //}
            CalculatePoints(this.size,location);

           
        }

        public override void CalculatePoints(int size, Point location)
        {
            this.AddPoint(new Point((location.X - 1 * size / 3), (location.Y + size / 3 * 2)));
            this.AddPoint(new Point((location.X - 1 * size / 3), (location.Y - size / 3 * 1)));
            this.AddPoint(new Point((location.X + 2 * size / 3), (location.Y - size / 3 * 1)));
        }

        public object Clone()
        {
            Triangulo triangulo = new Triangulo(size,new Point(0,0));

            triangulo.currentRotation = this.currentRotation;
            triangulo.currentX = this.currentX;
            triangulo.currentY = this.currentY;
            triangulo.currentScale = this.currentScale;

            for (int i = 0; i < 3; i++)
            {
                triangulo.figurePoints[i] = this.figurePoints[i];
            }

            triangulo.Transform();
            return triangulo;

        }

        public override Point getCentroid()
        {
            return new Point((int)size * 100 / 3, (int)size * 100 / 3);
        }


    }
}
