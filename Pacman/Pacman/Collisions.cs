using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    internal class Collisions
    {
       

        private const int SIZE = 20;
        private char[,] level;

        public Collisions(char[,] level)
        {
            this.level = level;

        }

     

        public Boolean DetectCollision(Point matrixPos, char dir)
        {
            Point nextPoint;
           
            switch (dir)
            {
                case 'u':
                    nextPoint = new Point(matrixPos.X+1, matrixPos.Y);
                    break;
                case 'd':
                    nextPoint = new Point(matrixPos.X-1, matrixPos.Y);
                    break;
                case 'l':
                    nextPoint = new Point(matrixPos.X,matrixPos.Y-1);
                    break;
                case 'r':
                    nextPoint = new Point(matrixPos.X, matrixPos.Y + 1);
                    break;
                default:
                    nextPoint = new Point(matrixPos.X, matrixPos.Y);
                    break;
            }

            if (Overlaping(nextPoint))     
            {
               //Debug.WriteLine($"Overlaping!");
               return true;
            }
          

            return false;
        }
        private Boolean Overlaping(Point point)
        {
            //Debug.WriteLine($"next point val is {this.level[18, 18]} at ");
            //g.FillRectangle(Brushes.Red, point.Y * 20, point.X * 20, 20, 20);
            //Debug.WriteLine($"cords {point}");
            if (this.level[point.Y, point.X] == '2'  )
            {
                return true;
            }
            return false;
        }


        public Boolean DetectCollision(Point matrixPos, char dir, Character character)
        {
            Point nextPoint;

            switch (dir)
            {
                case 'u':
                    nextPoint = new Point(matrixPos.X + 1, matrixPos.Y);
                    break;
                case 'd':
                    nextPoint = new Point(matrixPos.X - 1, matrixPos.Y);
                    break;
                case 'l':
                    nextPoint = new Point(matrixPos.X, matrixPos.Y - 1);
                    break;
                case 'r':
                    nextPoint = new Point(matrixPos.X, matrixPos.Y + 1);
                    break;
                default:
                    nextPoint = new Point(matrixPos.X, matrixPos.Y);
                    break;
            }

            if (Overlaping(nextPoint,character))
            {
                //Debug.WriteLine($"Overlaping!");
                return true;
            }


            return false;
        }

        private Boolean Overlaping(Point point, Character character)
        {
            if(character is Pacman pacman)
            {
                if (this.level[point.Y, point.X] == '2' || this.level[point.Y, point.X] == '3')
                {
                    return true;
                }
                return false;
            }
            else
            {
                if (this.level[point.Y, point.X] == '2')
                {
                    return true;
                }
                return false;
            }
            
        }


    }
}
