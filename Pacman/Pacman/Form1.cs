using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        Bitmap bitmapBlank;
        Graphics graphics;
        Pacman pacman;
        Map map;
        Char currentDir = '0';
        Char previousDir = '0';
        int counterSegs = 0;
        public Form1()
        {
            InitializeComponent();
            pacman = new Pacman(2);

            bitmap = new Bitmap(pictureBox2.Width,pictureBox2.Height);
           

            pictureBox2.Image = bitmap;
            graphics = Graphics.FromImage(bitmap);

            map = new Map(20,2);
          
            map.SpawnPacman(pacman);

         
            pictureBox2.Invalidate();
        }
        public void ClearImage()
        {
            pictureBox2.Image.Dispose();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                if (Math.Abs(map.ghosts[i].pictureBoxPosition.X - pacman.pictureBoxPosition.X) < 5 && Math.Abs(map.ghosts[i].pictureBoxPosition.Y - pacman.pictureBoxPosition.Y) < 5 && !map.ghosts[i].isDead)
                {
                    if(pacman.isBuffed)
                    {
                        map.ghosts[i].isDead = true;
                    }
                    else
                    {
                        pacman.pacmanIsDead = true;
                    }
                    
                }
            }
            graphics.Clear(pictureBox2.BackColor);
            map.DrawMap(graphics);

            counterSegs++;
            if(counterSegs == 10)
            {
                map.GhostBehaviour(pacman);
                counterSegs = 0;
            }

            
            

            map.RenderGhosts(graphics);
           

            map.TimerCounter(pacman);

            Mover();
            pacman.DrawPacman(graphics, counterSegs);

            pictureBox2.Invalidate();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                
                case Keys.Left:
                    currentDir = 'l';
                    break;
                case Keys.Right:
                    currentDir = 'r';
                    break;
                case Keys.Up:
                    currentDir = 'd';
                    break;
                case Keys.Down:
                    currentDir = 'u';
                    break;
                default:             
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void Mover()
        {
            if(pacman.pacmanIsDead)
            {
                return;
            }

            switch(currentDir)
            {
                case 'l':
                    
                    if (map.MoveLeft(pacman))
                    {
                        previousDir = 'l';
                    }
                    else
                    {
                        currentDir = previousDir;
                    }
                    break;
                case 'r':
                    
                    if (map.MoveRight(pacman))
                    {
                        previousDir = 'r';
                    }
                    else
                    {
                        currentDir = previousDir;
                    }
                    break;
                case 'd':
                    
                    if (map.MoveDown(pacman))
                    {
                        previousDir = 'd';
                    }
                    else
                    {
                        currentDir = previousDir;
                    }
                    break;
                case 'u':
                    if(map.MoveUp(pacman))
                    {
                        previousDir = 'u';
                    }
                    else
                    {
                        currentDir = previousDir;
                    }
                    break;
                default:
                    break;

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

}
    


