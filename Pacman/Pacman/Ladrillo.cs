using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    internal class Ladrillo
    {

        public Ladrillo()
        {

        }
        public static void DrawLadrillo(Graphics graphics, int x, int y, int size)
        {
            graphics.FillRectangle(Brushes.DarkBlue, x * size, y * size, size, size);
            graphics.FillRectangle(Brushes.DarkCyan, (x * size) + 4, (y * size) + 4, size - 8, size - 8);

            graphics.DrawLine(Pens.Black, (x * size), (y * size), (x * size) + size, (y * size) + size - 1);

            graphics.DrawLine(Pens.DimGray, (x * size), (y * size), (x * size) + size / 2, (y * size) + size / 2);
            graphics.DrawLine(Pens.Black, (x * size), (y * size) + size, (x * size) + size, (y * size));
        }

    }
}
