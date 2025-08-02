using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    internal class SquareDimensions
    {

        // class to keep track of square (tile) dimensions


        public int Top { get; private set; }
        public int Bottom { get; private set; }
        public int Left { get; private set; }
        public int Right { get; private set; }

        public SquareDimensions(int top, int botton, int left, int right) { 
            this.Top = top;
            this.Left = left;
            this.Bottom = botton;
            this.Right = right;
        }
    }
}
