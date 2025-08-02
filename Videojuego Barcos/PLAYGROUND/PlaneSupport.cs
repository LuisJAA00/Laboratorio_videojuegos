using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYGROUND
{
    public class PlaneSupport
    {
        public Vec2 position = new Vec2(0,0);
        public List<Projectile> projectiles = new List<Projectile>();
        private int size;

        public Boolean isOnScreen = false;

        private Boolean startsOnLeft = false;
        private int counterSeconds =  0;
        private Image image;
        private Brush brush;

        public PlaneSupport(int size, Brush brush, Image image) { 
            this.size = size;
            this.brush = brush;
            this.image = image;
        }

        public Boolean secondsCounter()
        {
            counterSeconds++;

            if(counterSeconds > 60)
            {
                counterSeconds = 0;
                Drop();
                return true;
            }
            return false;
           
        }

        public void Drop()
        {
            if (this.projectiles.Count > 10)
            {
                if (this.AllProjectilesStoped())
                {
                    this.projectiles = new List<Projectile>();
                }

                return;
            }
            int speed;

            if(startsOnLeft)
            {
                speed = 1;
            }
            else
            {
                speed = -1;
            }

            if(startsOnLeft)
            {
                projectiles.Add(new Projectile(new Vec2(speed, 0), position, Brushes.Red));
            }
            else
            {
                projectiles.Add(new Projectile(new Vec2(speed, 0), position, Brushes.Purple));
            }

            
        }

        public void Attack(Boolean left)
        {
            isOnScreen = true;
            this.startsOnLeft = left;

            if(left)
            {
                position.X = 0;
                position.Y = 100;
            }
            else
            {
                position.X = 958;
                position.Y = 100;
            }

            

        }
        public void Render(Graphics g, Size size)
        {
            if(!isOnScreen)
            {
                for (int i = 0; i < projectiles.Count; i++)
                {
                    projectiles[i].Render(g, size);
                }
                if(AllProjectilesStoped() )
                {
                    projectiles = new List<Projectile>();
                }
                
            }
            else
            {
                Move();
                secondsCounter();
                for (int i = 0; i < projectiles.Count; i++)
                {
                    projectiles[i].Render(g, size);
                }
                //g.FillRectangle(this.brush, position.X, position.Y, this.size, this.size);
                g.DrawImage(this.image, position.X, position.Y, this.size, this.size);
            }  

        }

        public void Move()
        {
            if(isOnScreen)
            {
                if(startsOnLeft)
                {
                    position.X += 2;
                }
                else
                {
                    position.X += -2;
                }

                if (position.X > 958 || position.X < 0)
                {
                    isOnScreen = false;
                }
            }
        }

   

        private Boolean AllProjectilesStoped()
        {
            for (int i = 0; i < projectiles.Count; i++)
            {
                if (projectiles[i].vpoints[0].vel.MagSqr() > 0.5)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
