using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    internal class Clayde:Ghost
    {

        public Clayde(Collisions collisions_, int baseSpeed) {
            pictureBoxPosition = new Point(14 * 20, 15 * 20);
            MatrixPosition = new Point(14, 15);
            this.size = 20;
            collisions = collisions_;
            this.BASE_SPEED = baseSpeed;
        }

        public override char GoForPacman(Character pacman, char[,] level, bool getClose, Point redPos)
        {
            if (this.isDead)
            {
                this.CurrentObjectiveTile = IsDeadMode();
                getClose = true;
                return this.ChasePacman(IsDeadMode(), level, getClose);
            }
            else if( 80 <= Math.Sqrt( (this.pictureBoxPosition.X - pacman.pictureBoxPosition.X)*(this.pictureBoxPosition.X - pacman.pictureBoxPosition.X) + (this.pictureBoxPosition.Y - pacman.pictureBoxPosition.Y) *(this.pictureBoxPosition.Y - pacman.pictureBoxPosition.Y) ) && !this.scaterMode )
            {
                this.CurrentObjectiveTile = pacman.pictureBoxPosition;
                return this.ChasePacman(pacman.pictureBoxPosition, level, getClose);
            }
            else if (this.isScared)
            {
                this.CurrentObjectiveTile = ScatterMode();
                return this.ChasePacman(ScatterMode(), level, getClose);
            }
            else 
            {
                this.CurrentObjectiveTile = ScatterMode();
                return this.ChasePacman(ScatterMode(), level, getClose);
            }
            
        }

        public override char MiedoMode()
        {
            throw new NotImplementedException();
        }

        public override void Render(Graphics graphics)
        {
            if (this.isDead)
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
                graphics.DrawImage(Resource1.FlandersScared, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
            }
            else
            {
                switch (this.currentDir)
                {
                    case 'd':
                        graphics.DrawImage(Resource1.FlandersUp, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                        break;
                    case 'u':
                        graphics.DrawImage(Resource1.FlandersDown, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                        break;
                    case 'r':
                        graphics.DrawImage(Resource1.FlandersRight, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                        break;
                    case 'l':
                        graphics.DrawImage(Resource1.FlandersLeft, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                        break;
                    default: break;
                }
            }

        }

        public override Point ScatterMode()
        {
            return new Point(0, 500);
        }
    }
}
