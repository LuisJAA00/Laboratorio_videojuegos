using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLAYGROUND
{

    public class Canon
    {
        int width = 50;
        int height = 30;

        public void Render(Graphics g,float angle,Point currentLoc)
        {
            
            g.TranslateTransform(currentLoc.X, currentLoc.Y);

          
            g.RotateTransform(-angle);

            
            //g.DrawRectangle(Pens.Yellow, -width / 2, -height / 2, width, height);
            g.DrawImage(Resource1.CanonLeft, -width / 2, -height / 2, width, height);

         
            g.ResetTransform();

        }




    }
}
