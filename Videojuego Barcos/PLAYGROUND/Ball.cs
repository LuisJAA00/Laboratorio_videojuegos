using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYGROUND
{
    internal class Ball:VElement
    {
        
        public Ball() {
            vpoints.Add(new Vpoint(250,250,new Vec2 (0,-9)));
        }

    }
}
