using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    internal class Pill
    {
        private static Random random = new Random();
        public Pill() { }

        public static void DrawPill(Graphics graphics, int x, int y, int size, int count)
        {
            if (random == null)
            {
                random = new Random();
            }

            if (((count + random.Next(1, 5)) % 5) == 0)
            {
               //graphics.FillEllipse(Brushes.Pink, (x * size) + 8, (y * size) + 8, size - 16, size - 16);
            }

            else
            {
                graphics.FillEllipse(Brushes.Pink, (x * size) + 8, (y * size) + 8, size - 4, size - 4);
                graphics.FillEllipse(Brushes.Black, (x * size) + 13, (y * size) + 13, size - 14, size - 14);
            }
        }

        public static void DrawPowerPill(Graphics graphics, int x, int y, int size, int count)
        {
            if (random == null)
            {
                random = new Random();
            }

            if (((count + random.Next(1, 5)) % 5) == 0)
            {
                graphics.FillEllipse(new SolidBrush(Color.FromArgb(35, 200, 200, 180)), (x * size), (y * size), size, size);
                graphics.FillEllipse(Brushes.Yellow, (x * size) + 3, (y * size) + 3, size - 6, size - 6);
                graphics.FillEllipse(Brushes.Linen, (x * size) + size, (y * size) + 5, size - 10, size - 10);
            }
            else
            {
                graphics.FillEllipse(new SolidBrush(Color.FromArgb(100, 200, 200, 180)), (x * size), (y * size), size, size);
                graphics.FillEllipse(Brushes.Orange, (x * size) + 2, (y * size) + 2, size - 4, size - 4);
                graphics.FillEllipse(new SolidBrush(Color.FromArgb(100, 100, 150, 180)), (x * size) + 5, (y * size) + 5, size - 10, size - 10);
            }
        }
    }
}
