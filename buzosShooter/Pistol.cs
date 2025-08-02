using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scroll
{
    public class Pistol : Weapon
    {
        public Pistol()
        {
           
        }

        

        public override void Shoot(char d, Vec2 position,Vec2 cameraPos,Vec2 tileMapPos)
        {
            int a = 0;
            if(d == 'l')
            {
                a = -1;
                position.X -= 40;
                tileMapPos.X -= 2;
            }
            else
            {
                a = 1;
                position.X += 40;
                tileMapPos.X += 2;
            }
            
            projectiles.Add(new Projectile(new Vec2(this.Speed*a, 0), position, Brushes.Red,cameraPos, tileMapPos));

          
        }

        public override void ShowProjectiles(Graphics g, Size s,Vec2 currentCameraPos,Map map,float elapsedTime)
        {
            for(int i = 0; i < projectiles.Count; i++)
            {
                this.projectiles[i].Render(g,s,currentCameraPos, map, elapsedTime);
            }
        }
        


    }
}
