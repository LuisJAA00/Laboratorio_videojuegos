using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transformaciones
{
    internal class Frame
    {
        List<Figura> figuras;

       
        public Frame(List<Figura> frame)
        {
            figuras = new List<Figura>();

            for(int i = 0; i < frame.Count; i++)
            {
                if (frame[i] is Cuadrado cuadrado)
                {
                    figuras.Add((Figura)cuadrado.Clone());
                }
                else if(frame[i] is Triangulo triangulo)
                {
                    figuras.Add((Figura)triangulo.Clone());
                }
                else if (frame[i] is Estrella estrella)
                {
                    figuras.Add((Figura)estrella.Clone());
                }
            }
        }

        public Figura getFigure(int i)
        {
            return figuras[i];
        }
    }
}
