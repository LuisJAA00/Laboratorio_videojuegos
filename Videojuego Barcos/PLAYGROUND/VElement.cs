using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PLAYGROUND
{
    public class VElement
    {
        public List<Vpoint> vpoints = new List<Vpoint>();
        public void Render(System.Drawing.Graphics g,Size size)
        {
            for (int i = 0; i < vpoints.Count; i++)
            {
                vpoints[i].Render(g,size.Width,size.Height);
            }
        }
    }
}
