using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scroll
{
    abstract public class Weapon
    {
        public List<Projectile> projectiles = new List<Projectile>();
        public static Vec2 CameraPos;
        public void AdjustPosition(float adjX, float adjY)
        {
            for (int i = 0; i < this.projectiles.Count; i++)
            {
                for(int j = 0; j < this.projectiles[i].vpoints.Count; j++)
                {
                    this.projectiles[i].vpoints[j].UpdatePosMapPlayer(new Vec2(adjX,adjY));
                
                }
                

            }
        }

        public int Speed { get; set; } = 14;

        abstract public void Shoot(char dir, Vec2 position,Vec2 initialCameraPos,Vec2 tileMapPos);

        abstract public void ShowProjectiles(Graphics g, Size s, Vec2 changeVal, Map map, float elapsedTime);

        
        
    }
}
