using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    internal class Character
    {
        public Point pictureBoxPosition; 
        protected Char dir;
        protected double movementVariable = 0;
        public double x = 0;
        public double y = 0;
        public int size = 0; // Size del frame de pacman
        public Boolean pacmanIsDead = false;

        public Point MatrixPosition; // La posicion del personaje en la matriz de colisiones
        public Point PreviousMatrixPos =new Point(0,0);
        public int BASE_SPEED = 0;
        public char charCurrentDir;
       public void UpdateCurrentMatrixTile(char dir)
        {
            
            this.MatrixPosition = new Point(RoundUpDown((double)this.pictureBoxPosition.X / 20,dir),RoundUpDown((double)this.pictureBoxPosition.Y / 20,dir));         
        }

        public Boolean UpdateCurrentMatrixTileBool(char dir)
        {

            this.MatrixPosition = new Point(RoundUpDown((double)this.pictureBoxPosition.X / 20, dir), RoundUpDown((double)this.pictureBoxPosition.Y / 20, dir));

            if (MatrixPosition != PreviousMatrixPos)
            {
                PreviousMatrixPos = MatrixPosition;
                return true;
            }
            return false;

        }
        private int RoundUpDown(double number,char dir)
        {
            int integerPart = (int)number;
            double decimalPart = number - integerPart;

            this.charCurrentDir = dir;

            if (decimalPart >= 0.5)
            {
                // Round up
                return (int)Math.Ceiling(number);
            }
            else 
            {
                // Round down
                return (int)Math.Floor(number);
            }
        }


    }
}
