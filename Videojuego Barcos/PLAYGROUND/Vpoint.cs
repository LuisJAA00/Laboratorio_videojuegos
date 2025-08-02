using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYGROUND
{
    public class Vpoint
    {
        public Vec2 position = new Vec2(0, 0);
        public Vec2 oldPos = new Vec2(0, 0);
        public Vec2 vel = new Vec2(0, 0);   

        private float friction = 0.992f;
        private float groundFriction = 0.7f;
        private Vec2 gravity = new Vec2(0,0.02f);
        private int radius = 5;
        Color color = Color.Orange;
        private int mass = 1;
        private Brush brush = Brushes.AliceBlue;

        private Color c;

        public Vpoint(int x, int y, Vec2 initialSpeed) { 
            position = new Vec2(x, y);
            oldPos = new Vec2(x, y);
            vel = initialSpeed;
        }

        public Vpoint(int x, int y, Vec2 initialSpeed, Brush c)
        {
            position = new Vec2(x, y);
            oldPos = new Vec2(x, y);
            vel = initialSpeed;
            this.brush = c;
        }

        public void Update(Size size)
        {
            

            if(position.Y >= size.Height - radius && vel.MagSqr() > 0.0000001)
            {
                var m = vel.Lenght();
                vel.X /= m;
                vel.Y /= m;
                vel *= groundFriction * m;
                vel *= -1;
            }

            oldPos = new Vec2(position.X,position.Y);
            position += vel;
            position += this.gravity;

          
            vel = position - oldPos;
        
            vel *= this.friction;
        }

        public void Constrain2(Size size)
        {
            if(position.X > size.Width - radius)
            {
                position.X = size.Width - radius;
            }
            if(position.X < 0)
            {
                position.X = radius;
            }

            if(position.Y > size.Height - radius)
            {
                position.Y = size.Height - radius;
         
            }
            if(position.Y < 0)
            {
                
            }
        }

        public void Render(Graphics g, int width, int height)
        {
         
            Update(new Size(width,height));
      
            Constrain2(new Size(width, height));
        
            g.FillEllipse(brush, position.X - radius, position.Y - radius, radius*2,radius*2);
       
        }

    }
}
