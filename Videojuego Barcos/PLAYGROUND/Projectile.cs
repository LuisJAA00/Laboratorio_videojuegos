using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYGROUND
{
    public class Projectile:VElement
    {

        public Projectile(Vec2 initialSpeed,Vec2 initialCords, Brush c) {
            vpoints.Add(new Vpoint((int)initialCords.X,(int)initialCords.Y,initialSpeed,c));
        }


    }
}
