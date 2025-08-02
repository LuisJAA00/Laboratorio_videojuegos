using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scroll
{
    public class Projectile : VElement
    {
        public Projectile(Vec2 initialSpeed, Vec2 initialCords, Brush c,Vec2 initialPosCamera,Vec2 tileMapCords)
        {
            vpoints.Add(new Vpoint((int)initialCords.X, (int)initialCords.Y, initialSpeed, c,initialPosCamera, tileMapCords));
        }
    }
}
