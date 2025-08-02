using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    internal class Pacman : Character
    {

        public Boolean isBuffed = false;
        public Pacman(int baseSpeed)
        {
            pictureBoxPosition = new Point(17 * 20, 14 * 20);
            MatrixPosition = new Point(17, 14);
            this.size = 20;
            this.BASE_SPEED = baseSpeed;
        }

        public  void DrawPacman(Graphics graphics, int x, int y)
        {            
            graphics.FillRectangle(Brushes.Yellow,  this.pictureBoxPosition.X, this.pictureBoxPosition.Y, size, size);
        }
        public void DrawPacman(Graphics graphics, int counter)
        {
            if(this.pacmanIsDead)
            {
                graphics.DrawImage(Resource1.HomeroDead, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
            }
            else
            {
                switch (this.charCurrentDir)
                { 
                    case 'u':
                        PacmanDown(graphics, counter);
                        break;
                    case 'd':
                        PacmanUp(graphics, counter);
                        break;
                    case 'r':
                        PacmanRight(graphics, counter);
                        break;
                    case 'l':
                        PacmanLeft(graphics, counter);
                        break;
                    default:
                        graphics.DrawImage(Resource1.HomerRight3, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                        break;
                }
            }
        }


        public void PacmanUp(Graphics graphics, int counter)
        {
            switch (counter)
            {
                case 0:
                    graphics.DrawImage(Resource1.HomerUp1, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                case 1:
                    graphics.DrawImage(Resource1.HomerUp1, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                case 2:
                    graphics.DrawImage(Resource1.HomerUp2, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                case 3:
                    graphics.DrawImage(Resource1.HomerUp2, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                case 4:
                    graphics.DrawImage(Resource1.HomerUp3, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                case 5:
                    graphics.DrawImage(Resource1.HomerUp3, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                case 6:
                    graphics.DrawImage(Resource1.HomerUp2, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                case 7:
                    graphics.DrawImage(Resource1.HomerUp2, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                case 8:
                    graphics.DrawImage(Resource1.HomerUp1, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                case 9:
                    graphics.DrawImage(Resource1.HomerUp1, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                case 10:
                    graphics.DrawImage(Resource1.HomerUp2, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                default:
                    break;
            }
        }

        public void PacmanDown(Graphics graphics, int counter)
        {
            switch (counter)
            {
                case 0:
                    graphics.DrawImage(Resource1.HomerDown1, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                case 1:
                    graphics.DrawImage(Resource1.HomerDown1, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                case 2:
                    graphics.DrawImage(Resource1.HomerDown2, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                case 3:
                    graphics.DrawImage(Resource1.HomerDown2, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                case 4:
                    graphics.DrawImage(Resource1.HomerDown3, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                case 5:
                    graphics.DrawImage(Resource1.HomerDown3, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                case 6:
                    graphics.DrawImage(Resource1.HomerDown2, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                case 7:
                    graphics.DrawImage(Resource1.HomerDown2, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                case 8:
                    graphics.DrawImage(Resource1.HomerDown1, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                case 9:
                    graphics.DrawImage(Resource1.HomerDown1, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                case 10:
                    graphics.DrawImage(Resource1.HomerDown2, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                default:
                    break;
            }
        }
        public void PacmanLeft(Graphics graphics, int counter)
        {
            switch (counter)
            {
                case 0:
                    graphics.DrawImage(Resource1.HomerLeft1, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                case 1:
                    graphics.DrawImage(Resource1.HomerLeft1, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                case 2:
                    graphics.DrawImage(Resource1.HomerLeft2, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                case 3:
                    graphics.DrawImage(Resource1.HomerLeft2, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                case 4:
                    graphics.DrawImage(Resource1.HomerLeft3, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                case 5:
                    graphics.DrawImage(Resource1.HomerLeft3, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                case 6:
                    graphics.DrawImage(Resource1.HomerLeft2, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                case 7:
                    graphics.DrawImage(Resource1.HomerLeft2, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                case 8:
                    graphics.DrawImage(Resource1.HomerLeft1, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                case 9:
                    graphics.DrawImage(Resource1.HomerLeft1, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                case 10:
                    graphics.DrawImage(Resource1.HomerLeft2, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                default:
                    break;
            }
        }

        public void PacmanRight(Graphics graphics, int counter)
        {
            switch (counter)
            {
                case 0:
                    graphics.DrawImage(Resource1.HomerRight1, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                case 1:
                    graphics.DrawImage(Resource1.HomerRight1, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                case 2:
                    graphics.DrawImage(Resource1.HomerRight2, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                case 3:
                    graphics.DrawImage(Resource1.HomerRight2, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                case 4:
                    graphics.DrawImage(Resource1.HomerRight3, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                case 5:
                    graphics.DrawImage(Resource1.HomerRight3, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                case 6:
                    graphics.DrawImage(Resource1.HomerRight2, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                case 7:
                    graphics.DrawImage(Resource1.HomerRight2, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                case 8:
                    graphics.DrawImage(Resource1.HomerRight1, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                case 9:
                    graphics.DrawImage(Resource1.HomerRight1, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                case 10:
                    graphics.DrawImage(Resource1.HomerRight2, new PointF(this.pictureBoxPosition.Y, this.pictureBoxPosition.X));
                    break;
                default:
                    break;
            }
        }
    }
}
