using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transformaciones
{
    internal class Estrella : Figura, ICloneable
    {
        public Estrella(int size, Point location)
        {
            this.size = size * 100;
            int sides = 5;

            CalculatePoints(this.size, location);
        }

        public override void CalculatePoints(int size, Point location)
        {
            double angle = Math.PI / 5; // Ángulo para la estrella de cinco puntas
            double radius = size / (2 * Math.Sin(angle));

            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    // Puntos exteriores
                    this.AddPoint(new Point((int)(location.X + radius * Math.Cos(i * angle)),
                                             (int)(location.Y + radius * Math.Sin(i * angle))));
                }
                else
                {
                    // Puntos interiores
                    this.AddPoint(new Point((int)(location.X + (radius / 2) * Math.Cos(i * angle)),
                                             (int)(location.Y + (radius / 2) * Math.Sin(i * angle))));
                }
            }
        }

        public object Clone()
        {
            Estrella estrella = new Estrella(size, new Point(0, 0));

            estrella.currentRotation = this.currentRotation;
            estrella.currentX = this.currentX;
            estrella.currentY = this.currentY;
            estrella.currentScale = this.currentScale;

            for (int i = 0; i < 10; i++)
            {
                estrella.figurePoints[i] = this.figurePoints[i];
            }

            estrella.Transform();
            return estrella;
        }

        public override Point getCentroid()
        {
            return new Point((int)size * 100 / 2, (int)size * 100 / 2);
        }
    }
}

