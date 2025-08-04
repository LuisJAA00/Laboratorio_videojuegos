using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transformaciones
{
    internal class Canvas
    {
        public static Graphics graphics;
        public static Bitmap bitmap;
        public Canvas( PictureBox picture)
        {
            bitmap = new Bitmap(picture.Width, picture.Height);
            graphics =  Graphics.FromImage(bitmap);

        }

         public void Render(Figura figura)
        {
            figura.Rener(graphics);
        }
    }
}
