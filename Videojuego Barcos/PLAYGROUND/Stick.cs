using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYGROUND
{
    internal class Stick
    {
        public Vec2 startPoint = new Vec2 (0, 0);
        public Vec2 endPoint = new Vec2 (0, 0);

        public int stiffnes = 2;
        public Color color = Color.Red;
        public float lenght;
        
        public Stick(Vec2 start, Vec2 end, float lenght)
        {
            startPoint = start;
            endPoint = end;

            if (!(lenght >= 0))
            {
                this.lenght = startPoint.Distance(end);
            }
            else
            {
                this.lenght = lenght;
            }
        }

        public void Update()
        {
            float dx = endPoint.X - startPoint.X;
            float dy = endPoint.Y - startPoint.Y;

            float dist = (float)Math.Sqrt((float)(dx * dx + dy * dy));

            float diff = (lenght - dist)/dist;


        }


    }
}
