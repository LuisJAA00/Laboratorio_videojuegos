using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scroll
{
    public class VElement
    {
        public List<Vpoint> vpoints = new List<Vpoint>();
        public void Render(System.Drawing.Graphics g, Size size,Vec2 currentCameraPos,Map map,float elapsedTime)
        {
            Vec2 adjustedPos;
            for (int i = 0; i < vpoints.Count; i++)
            {
                //adjustedPos = vpoints[i].initialCameraPos - currentCameraPos;
                //vpoints[i].initialCameraPos = currentCameraPos;
                //vpoints[i].UpdatePosMapPlayer(adjustedPos);
                if (vpoints[i].position.X < 10 )
                {
                    
                    
                    if (map.GetTile(vpoints[i].tileMapCords.X, vpoints[i].tileMapCords.Y) != '#')
                    {
                        map.SetTile(vpoints[i].tileMapCords.X, vpoints[i].tileMapCords.Y, '.');
                    }
                    vpoints.Remove(vpoints[i]);
                    return;
                }
                if (vpoints[i].position.X > 1150)
                {
                    if (map.GetTile(vpoints[i].tileMapCords.X, vpoints[i].tileMapCords.Y) != '#')
                    {
                        map.SetTile(vpoints[i].tileMapCords.X, vpoints[i].tileMapCords.Y, '.');
                    }
                    vpoints.Remove(vpoints[i]);
                    return;
                }
                vpoints[i].Render(g, size.Width, size.Height,map,elapsedTime);
            }
        }

        
    }
}
