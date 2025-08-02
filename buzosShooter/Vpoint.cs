using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scroll
{
    public class Vpoint
    {
        public Vec2 position = new Vec2(0, 0);
        public Vec2 tileMapCords = new Vec2(0,0);
        public Vec2 oldPos = new Vec2(0, 0);
        public Vec2 vel = new Vec2(0, 0);
        public Vec2 initialCameraPos;

        private float friction = 0.992f;
        private float groundFriction = 0.7f;
        private Vec2 gravity = new Vec2(0, 0.02f);
        private int radius = 15;
        Color color = Color.Orange;
        private int mass = 1;
        private Brush brush = Brushes.AliceBlue;

        private Color c;
        public char dir = 'p'; // p -> projectile va a derecha, b -> va a la izquierda
        public Vpoint(int x, int y, Vec2 initialSpeed)
        {
            position = new Vec2(x, y);
            oldPos = new Vec2(x, y);
            vel = initialSpeed;
        }

        public Vpoint(int x, int y, Vec2 initialSpeed, Brush c,Vec2 initialPos,Vec2 tileMapCords)
        {
            position = new Vec2(x, y);
            oldPos = new Vec2(x, y);
            vel = initialSpeed;
            this.brush = c;
            this.initialCameraPos = initialPos;
            this.tileMapCords = tileMapCords;
            if(initialSpeed.X > 0)
            {
                dir = 'p';
            }
            else
            {
                dir = 'b';
            }
        }

        public void Update(Size size,Map map,float elapsedTime)
        {


            if (position.Y >= size.Height - radius && vel.MagSqr() > 0.0000001)
            {
                var m = vel.Lenght();
                vel.X /= m;
                vel.Y /= m;
                vel *= groundFriction * m;
                vel *= -1;
            }

            oldPos = new Vec2(position.X, position.Y);
            position += vel;

            float fNewPlayerPosX = tileMapCords.X + vel.X * elapsedTime;
            
            tileMapCords = new Vec2(fNewPlayerPosX, tileMapCords.Y);

            CheckPicks(map,tileMapCords.X,tileMapCords.Y,'.',dir);
            if (
                map.GetTile(tileMapCords.X + 1, tileMapCords.Y) != '#'
                
                )
            { 
                if(
                    map.GetTile(tileMapCords.X + 1, tileMapCords.Y) == 'f' ||
                    map.GetTile(tileMapCords.X + 1, tileMapCords.Y) == 'g' ||
                    map.GetTile(tileMapCords.X + 1, tileMapCords.Y) == 'k'
                    )
                {

                }
                else
                {
                    map.SetTile(tileMapCords.X + 1, tileMapCords.Y, '.');
                }
                
            }
            
            if (
                map.GetTile(tileMapCords.X - 1, tileMapCords.Y) != '#'
                )
            {
                if(
                    map.GetTile(tileMapCords.X - 1, tileMapCords.Y) == 'f' ||
                    map.GetTile(tileMapCords.X - 1, tileMapCords.Y) == 'g' ||
                    map.GetTile(tileMapCords.X - 1, tileMapCords.Y) == 'k'
                    )
                {

                }
                else
                {
                    map.SetTile(tileMapCords.X - 1, tileMapCords.Y, '.');
                }
                
            }
            vel = position - oldPos;

            

        }

        public void Constrain2(Size size)
        {
            if (position.X > size.Width - radius)
            {
                position.X = size.Width - radius;
            }
            if (position.X < 0)
            {
                position.X = radius;
            }

            if (position.Y > size.Height - radius)
            {
                position.Y = size.Height - radius;

            }
            if (position.Y < 0)
            {

            }
        }

        public void Render(Graphics g, int width, int height,Map map,float elapsedTime)
        {
         
            Update(new Size(width, height),map,elapsedTime);

            Constrain2(new Size(width, height));

            //g.FillEllipse(brush, (int)position.X - radius, (int)position.Y - radius, radius * 2, radius * 2);

        }

        public void UpdatePosMapPlayer(Vec2 positionChage)
        {
           
            this.position.X += positionChage.X; 
            this.position.Y += positionChage.Y;
        
        }

        public void CheckPicks(Map map, float fNewPlayerPosX, float fNewPlayerPosY, char c, char c2)
        {
            // Check for pickups!
            if (map.GetTile(fNewPlayerPosX + 0.0f, fNewPlayerPosY + 0.0f) == c)
                map.SetTile(fNewPlayerPosX + 0.0f, fNewPlayerPosY + 0.0f, c2);

            if (map.GetTile(fNewPlayerPosX + 0.0f, fNewPlayerPosY + 0.0f) == c)
                map.SetTile(fNewPlayerPosX + 0.0f, fNewPlayerPosY + 0.0f, c2);

            if (map.GetTile(fNewPlayerPosX + 1.0f, fNewPlayerPosY + 0.0f) == c)
                map.SetTile(fNewPlayerPosX + 1.0f, fNewPlayerPosY + 0.0f, c2);

            if (map.GetTile(fNewPlayerPosX + 1.0f, fNewPlayerPosY + 0.0f) == c)
                map.SetTile(fNewPlayerPosX + 1.0f, fNewPlayerPosY + 0.0f, c2);
        }
    }
}
