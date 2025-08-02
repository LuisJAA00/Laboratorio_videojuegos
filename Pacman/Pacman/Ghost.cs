using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    internal abstract class Ghost: Character
    {

        protected static Collisions collisions;
        public bool currentlyMoving = false;
        public char currentDir;
        public char previousDir;
        public Boolean scaterMode = false;
      
        protected Point previousMatrixPoint;
        public Point CurrentObjectiveTile;

        public Point lastDesiciontakenAt;
        public Boolean leavingHouse = false;
        public Boolean isDead = false;
        public Boolean isScared = false;
        public abstract char GoForPacman(Character pacman, char[,] level, bool getClose,Point redPos);
        
        protected  char ChasePacman(Point pacmanPos, char[,] level, bool getClose)
        {
            char dir = this.currentDir;


            if (getClose == false)
            {
                for (int i = 0; i < 4; i++)
                {
                    switch (i)
                    {
                        case 0:
                            dir = 'u';
                            break;
                        case 1:
                            dir = 'r';
                            break;
                        case 2:
                            dir = 'd';
                            break;
                        case 3:
                            dir = 'l';
                            break;
                        default: break;
                    }


                    if (!collisions.DetectCollision(this.MatrixPosition, dir))
                    {
                        if (GetReverseDirection() != dir)
                        {

                            return dir;
                        }
                    }
                }



            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    switch (i)
                    {
                        case 0:
                            dir = 'u';
                            break;
                        case 1:
                            dir = 'r';
                            break;
                        case 2:
                            dir = 'd';
                            break;
                        case 3:
                            dir = 'l';
                            break;
                        default: break;
                    }


                    if (!collisions.DetectCollision(this.MatrixPosition, dir))
                    {
                        if (GetReverseDirection() != dir)
                        {
                            if (CloserToPacman(i, pacmanPos))
                            {

                                return dir;
                            }

                        }
                    }

                }
                for (int i = 0; i < 4; i++)
                {
                    switch (i)
                    {
                        case 0:
                            dir = 'u';
                            break;
                        case 1:
                            dir = 'r';
                            break;
                        case 2:
                            dir = 'd';
                            break;
                        case 3:
                            dir = 'l';
                            break;
                        default: break;
                    }


                    if (!collisions.DetectCollision(this.MatrixPosition, dir))
                    {
                        if (GetReverseDirection() != dir)
                        {

                            return dir;
                        }
                    }
                }
            }




            return 'e';
        }

        public abstract void Render(Graphics graphics);

        protected Boolean CloserToPacman(int i, Point p)
        {
            switch (i)
            {
                case 0:

                    if (Math.Abs(this.pictureBoxPosition.X - p.X) > Math.Abs(this.pictureBoxPosition.X + 20 - p.X))
                    {
                        return true;
                    }
                    return false;
                case 1:
                    if (Math.Abs(this.pictureBoxPosition.Y - p.Y) > Math.Abs(this.pictureBoxPosition.Y + 20 - p.Y))
                    {
                        return true;
                    }
                    return false;
                case 2:

                    if (Math.Abs(this.pictureBoxPosition.X - p.X) > Math.Abs(this.pictureBoxPosition.X - 20 - p.X))
                    {
                        return true;
                    }
                    return false;
                case 3:

                    if (Math.Abs(this.pictureBoxPosition.Y - p.Y) > Math.Abs(this.pictureBoxPosition.Y - 20 - p.Y))
                    {
                        return true;
                    }
                    return false;

                default:

                    break;
            }

            return false;
        }

        protected char GetReverseDirection()
        {

            switch (this.currentDir)
            {
                case 'u':
                    return 'd';
                case 'd':
                    return 'u';
                case 'l':
                    return 'r';
                case 'r':
                    return 'l';
                default:
                    return 'a';
            }
        }

        public abstract Point ScatterMode();
        public abstract char MiedoMode();
        public  Point IsDeadMode()
        {
            return new Point(11 * 20, 13 * 20);
        }

    }
}
