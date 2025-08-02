using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLAYGROUND
{
    public class Plataforma
    {
        //La plataforma deberia de permitir mover al barco, ajustar y disparar
        public int hp = 10;
        public Boolean isDead = false;
        public float angle = 45;
        public Vec2 position, positionLeft, positionRight;

        public int anchoBarco;

        public Boolean isMovingRight = false;
        public Boolean isMovingLeft = false;

        private int constraintLimitX = 0;

        private bool clockWise = false;

        private Canon cañon;

        public List<Projectile> projectiles = new List<Projectile>();

        private static CustomRandom random = new CustomRandom();

        private Boolean startPosIsLeft = false;

        private int inmunityCounter = 0;
        private bool isInmune = false;

        private bool isMareaUp = false;

        public PlaneSupport plane;

        private Boolean parpadea = false; //parpadea cuando es inmune
        private Brush brush;
        private Image image;

        public Plataforma(int ancho, int constraintLimitX, bool left, Vec2 initPos) 
        {
            anchoBarco = ancho;
            this.constraintLimitX = constraintLimitX;
            cañon = new Canon();
            this.position = initPos;

            startPosIsLeft = left;

            // if left = true  then barco is on the left

            if (!left)
            {
                this.angle = 135;
            }
            
            if(left)
            {
                plane = new PlaneSupport(50,Brushes.Red,Resource1.PlaneLeft);
            }
            else
            {
                plane = new PlaneSupport(50,Brushes.Violet,Resource1.PlaneRight);
            }
        }
        public void MoveLeft()
        {
            if (isMovingLeft)
            {
                position.X -= 2;
            }




        }

        public void MoveRight() {

            if (isMovingRight)
            {
                position.X += 2;
            }
        }

        public void Move()
        {
            MoveLeft();
            MoveRight();
        }

        private void Constraints(Size size)
        {


            if (!startPosIsLeft)
            {
                if (position.X <= this.constraintLimitX + anchoBarco)
                {

                    position.X = this.constraintLimitX + anchoBarco;
                }
            }
            else
            {
                if (position.X >= this.constraintLimitX - anchoBarco)
                {

                    position.X = this.constraintLimitX - anchoBarco;
                }
            }

            if (position.X > size.Width - anchoBarco)
            {

                position.X = size.Width - anchoBarco;
            }

            if (position.X < 0)
            {
                position.X = 0;
            }

            if (position.Y > size.Height - anchoBarco)
            {
                position.Y = size.Height - anchoBarco;

            }
            if (position.Y < 0)
            {
                position.Y = anchoBarco;
            }
        }
        public void Hitted()
        {
            if (isInmune)
            {
                return;
            }
            hp--;
            if (hp <= 0)
            {
                isDead = true;
            }
            isInmune = true;
        }

        public void Shoot()
        {
            if (this.projectiles.Count > 20)
            {
                if (this.AllProjectilesStoped())
                {
                    this.projectiles = new List<Projectile>();
                }

                return;
            }

            int initialSpeed = 7;

            float speedY = -(float)(initialSpeed * Math.Sin(angle * (Math.PI / 180)));
            float speedX = (float)(initialSpeed * Math.Cos(angle * (Math.PI / 180)));
            
            if(startPosIsLeft)
            {
                projectiles.Add(new Projectile(new Vec2(speedX, speedY), position,Brushes.Red));
            }
            else
            {
                projectiles.Add(new Projectile(new Vec2(speedX, speedY), position, Brushes.Purple));
            }
            
            
        }

        public void AdjustUp()
        {
            if (!startPosIsLeft)
            {
                angle += 0.2f;

                if (angle > 160)
                {
                    angle = 160;
                    clockWise = false;
                }
            }
            else
            {
                angle += 0.2f;

                if (angle > 90)
                {
                    angle = 90;
                    clockWise = false;
                }
            }
        }

        public void AdjustDown()
        {
            
            if (!startPosIsLeft)
            {
                angle -= 0.2f;

                if (angle < 90)
                {
                    angle = 90;
                    clockWise = true;
                }
            }
            else
            {
                angle -= 0.2f;

                if (angle < 25)
                {
                    angle = 25;
                    clockWise = true;
                }
            }

        }

        public void ChangeCanonDir()
        {
            //each this is called it increments or reduces the current angle of the canon

            if(clockWise)
            {
                AdjustUp();
            }
            else
            {
                AdjustDown();
            }
        }

        public void Render(Graphics g,Size size )
        {
            if (startPosIsLeft)
            {
                brush = Brushes.Red;
                image = Resource1.ShipLeft;
            }
            else
            {
                brush = Brushes.Violet;
                image = Resource1.ShipRight;
            }

            Move();
            ChangeCanonDir();
            
            
            Constraints(size);

            inmunityCounter++;
            if (inmunityCounter > 60)
            {
                isInmune = false;
                inmunityCounter = 0;
            }

            for(int i = 0; i < projectiles.Count; i++)
            {

                projectiles[i].Render(g,size);
            }

            if (isInmune) { InmuneRender(g,brush); }
            else { g.DrawImage(image, position.X-20, position.Y-20, anchoBarco+20, anchoBarco + 20); }

            this.cañon.Render(g,angle,new Point((int)position.X,(int)position.Y-10));

            g.FillRectangle(Brushes.DarkBlue, 0, position.Y+anchoBarco, size.Width, size.Height);

            Marea();
        }

        private Boolean AllProjectilesStoped()
        {
            for(int i = 0; i < projectiles.Count; i++)
            {
                if (projectiles[i].vpoints[0].vel.MagSqr() > 0.5)
                {
                    return false;
                }
            }
            return true;
        }

        public Boolean ProjectileCollision(List<Projectile> projectiles)
        {

            for(int i = 0; i < projectiles.Count; i++)
            {
                if (projectiles[i].vpoints[0].position.X > this.position.X +10- this.anchoBarco/2 && projectiles[i].vpoints[0].position.X < this.position.X +10+ this.anchoBarco/2)
                {
                    if(projectiles[i].vpoints[0].position.Y > this.position.Y - this.anchoBarco/5 && projectiles[i].vpoints[0].position.Y < this.position.Y + this.anchoBarco / 5)
                    {
                        Hitted();
                    }
                }
            }


            return false;
        }

        public void CallAirSupport()
        {
            plane.Attack(this.startPosIsLeft);
        }
        private void MareaUp()
        {
            position.Y += 0.2f;

            if (position.Y > 270)
            {
                position.Y = 270;
                isMareaUp = false;
            }
        }

        private void MareaDown()
        {
            position.Y -= 0.2f;

            if (position.Y < 230)
            {
                position.Y = 230;
                isMareaUp = true;
            }
        }

        public void Marea()
        {
            if(isMareaUp)
            {
                MareaUp();
            }
            else
            {
                MareaDown();
            }
        }

        private void InmuneRender(Graphics g, Brush brush)
        {
            if(parpadea)
            {
                parpadea = false;
                if (startPosIsLeft) 
                {
                    g.DrawImage(Resource1.ShipLeftHit, position.X-20, position.Y - 20, anchoBarco+20, anchoBarco+20);
                }
                else
                {
                    g.DrawImage(Resource1.ShipRightHit, position.X-20, position.Y-20, anchoBarco+20, anchoBarco+20);
                }
                //g.FillRectangle(brush, position.X+10, position.Y, this.anchoBarco / 2, this.anchoBarco / 2);
            }
            else
            {
                parpadea = true;
                if (startPosIsLeft)
                {
                    g.DrawImage(Resource1.ShipLeft, position.X - 20, position.Y - 20, anchoBarco + 20, anchoBarco + 20);
                }
                else 
                {
                    g.DrawImage(Resource1.ShipRight, position.X - 20, position.Y - 20, anchoBarco+20, anchoBarco+20);
                }
               //g.FillRectangle(Brushes.MistyRose, position.X+10, position.Y, this.anchoBarco / 2, this.anchoBarco / 2);
            }
        }

    }
}
