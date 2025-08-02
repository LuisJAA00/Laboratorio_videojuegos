using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    internal class Pinky : Ghost
    {

        public Pinky(Collisions collisions_, int baseSpeed) {
            pictureBoxPosition = new Point(14 * 20, 15 * 20);
            MatrixPosition = new Point(14, 15);
            this.size = 20;
            collisions = collisions_;
            this.BASE_SPEED = baseSpeed;
        }
        public override char GoForPacman(Character pacman, char[,] level, bool getClose, Point redPos)
        {
          
            Point point = new Point();

            if (this.isDead)
            {
                this.CurrentObjectiveTile = IsDeadMode();
                getClose = true;
                return this.ChasePacman(IsDeadMode(), level, getClose);
            }
            else if (this.scaterMode)
            {
                this.CurrentObjectiveTile = ScatterMode();
                return this.ChasePacman(ScatterMode(), level, getClose);
            }
            else if (this.isScared)
            {
                this.CurrentObjectiveTile = ScatterMode();
                return this.ChasePacman(ScatterMode(), level, getClose);
            }
            else
            {
                switch (pacman.charCurrentDir)
                {
                    case 'u':
                        point = new Point(pacman.pictureBoxPosition.X + 20 * 4, pacman.pictureBoxPosition.Y);
                        break;
                    case 'd':
                        point = new Point(pacman.pictureBoxPosition.X - 20 * 4, pacman.pictureBoxPosition.Y);
                        break;
                    case 'l':
                        point = new Point(pacman.pictureBoxPosition.X, pacman.pictureBoxPosition.Y - 20 * 4);
                        break;
                    case 'r':
                        point = new Point(pacman.pictureBoxPosition.X, pacman.pictureBoxPosition.Y + 20 * 4);
                        break;
                }



                this.CurrentObjectiveTile = point;

                return this.ChasePacman(point, level, getClose);
            }
            
        }

        public override char MiedoMode()
        {
            throw new NotImplementedException();
        }

        public override void Render(Graphics graphics)
        {
            if(this.isDead)
            {
                switch (this.currentDir)
                {
                    case 'd':
                        graphics.DrawImage(Resource1.UpEyes, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                        break;
                    case 'u':
                        graphics.DrawImage(Resource1.DownEyes, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                        break;
                    case 'r':
                        graphics.DrawImage(Resource1.RightEyes, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                        break;
                    case 'l':
                        graphics.DrawImage(Resource1.LeftEyes, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                        break;
                    default: break;
                }

            }
            else if (this.isScared)
            {
                graphics.DrawImage(Resource1.KrustyScared, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
            }
            else
            {
                switch (this.currentDir)
                {
                    case 'd':
                        graphics.DrawImage(Resource1.KrustyUp, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                        break;
                    case 'u':
                        graphics.DrawImage(Resource1.KrustyDown, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                        break;
                    case 'r':
                        graphics.DrawImage(Resource1.KrustyRight, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                        break;
                    case 'l':
                        graphics.DrawImage(Resource1.KrustyLeft, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                        break;
                    default: break;
                }
            }
           
        }

        public override Point ScatterMode()
        {
            return new Point(500,500);
        }


    }
}
