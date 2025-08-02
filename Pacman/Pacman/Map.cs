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
    internal class Map
    {
        public char[,] level = new char[,] { };
        public int size = 0;
        private int counter = 0;
        protected Collisions collisions;

        private RedGhost red;
        private Pinky pinky;
        private Inky inky;
        private Clayde clayde;

        public List<Ghost> ghosts = new List<Ghost>();
        private static Random random = new Random();

        private int counterCasaGhost = 0;
        private int counterSeconds = 0;
        private Pacman fakePacman;
        private Boolean scaterMode = false;
        private char[] ghostDirs = new char[4];

        private int scaterModeTime = 10;
        public Map(int celdaSize, int ghostsSpeed)
        {
            level = new char[,] {
                { '2','2','2','2','2','2','2','2','2','2','2','2','2','2','1','2','2','2','2','2','2','2','2','2','2','2','2','2','2','2','2'},
                { '2','p','p','w','p','i','p','p','p','2','1','1','1','2','1','2','1','1','1','2','p','p','p','w','2','2','p','p','p','p','2'},
                { '2','p','2','2','2','p','2','2','p','2','1','1','1','2','1','2','1','1','1','2','p','2','2','p','2','2','p','2','2','p','2'},
                { '2','p','2','2','2','p','2','2','p','2','1','1','1','2','1','2','1','1','1','2','p','2','2','p','p','p','i','2','2','p','2'},
                { '2','p','2','2','2','p','2','2','p','2','1','1','1','2','1','2','1','1','1','2','p','2','2','2','2','2','p','2','2','p','2'},
                { '2','p','2','2','2','p','2','2','p','2','2','2','2','2','2','2','2','2','2','2','p','2','2','2','2','2','p','2','2','p','2'},
                { '2','i','p','p','p','i','p','p','i','p','p','p','p','p','i','p','p','p','p','p','i','p','p','i','p','p','p','2','2','p','2'},
                { '2','p','2','2','2','p','2','2','2','2','2','2','2','2','1','2','2','2','2','2','p','2','2','p','2','2','2','2','2','p','2'},
                { '2','p','2','2','2','p','2','2','2','2','2','2','2','2','1','2','2','2','2','2','p','2','2','p','2','2','2','2','2','p','2'},
                { '2','p','2','2','2','i','p','p','p','2','2','1','1','1','l','1','1','l','1','1','i','2','2','i','p','p','p','2','2','p','2'},
                { '2','p','2','2','2','p','2','2','p','2','2','1','2','2','2','2','2','1','2','2','p','2','2','p','2','2','p','2','2','p','2'},
                { '2','p','2','2','2','p','2','2','p','2','2','1','2','1','1','1','2','1','2','2','p','2','2','p','2','2','p','2','2','p','2'},
                { '2','p','p','p','p','i','2','2','p','1','1','l','2','1','l','1','2','1','2','2','p','p','p','i','2','2','p','p','p','i','2'},
                { '2','2','2','2','2','p','2','2','2','2','2','5','3','1','1','1','2','1','2','2','2','2','2','p','2','2','2','2','2','p','2'},
                { '2','2','2','2','2','p','2','2','2','2','2','5','3','4','1','1','2','1','2','2','2','2','2','p','2','2','2','2','2','p','2'},
                { '2','p','p','p','p','i','2','2','p','1','1','l','2','1','l','1','2','1','2','2','p','p','p','i','2','2','p','p','p','i','2'},
                { '2','p','2','2','2','p','2','2','p','2','2','1','2','1','1','1','2','1','2','2','p','2','2','p','2','2','p','2','2','p','2'},
                { '2','p','2','2','2','p','2','2','p','2','2','1','2','2','2','2','2','1','2','2','p','2','2','p','2','2','p','2','2','p','2'},
                { '2','p','2','2','2','i','p','p','p','2','2','1','1','1','l','1','1','l','1','1','i','2','2','i','p','p','p','2','2','p','2'},
                { '2','p','2','2','2','p','2','2','2','2','2','2','2','2','1','2','2','2','2','2','p','2','2','p','2','2','2','2','2','p','2'},
                { '2','p','2','2','2','p','2','2','2','2','2','2','2','2','1','2','2','2','2','2','p','2','2','p','2','2','2','2','2','p','2'},
                { '2','i','p','p','p','i','p','p','i','p','p','p','p','p','i','p','p','p','p','p','i','p','p','i','p','p','p','2','2','p','2'},
                { '2','p','2','2','2','p','2','2','p','2','2','2','2','2','2','2','2','2','2','2','p','2','2','2','2','2','p','2','2','p','2'},
                { '2','p','2','2','2','p','2','2','p','2','1','1','1','2','1','2','1','1','1','2','p','2','2','2','2','2','p','2','2','p','2'},
                { '2','p','2','2','2','p','2','2','p','2','1','1','1','2','1','2','1','1','1','2','p','2','2','p','p','p','i','2','2','p','2'},
                { '2','p','2','2','2','p','2','2','p','2','1','1','1','2','1','2','1','1','1','2','p','2','2','p','2','2','p','2','2','p','2'},
                { '2','p','p','w','p','i','p','p','p','2','1','1','1','2','1','2','1','1','1','2','p','p','p','w','2','2','p','p','p','p','2'},
                { '2','2','2','2','2','2','2','2','2','2','2','2','2','2','1','2','2','2','2','2','2','2','2','2','2','2','2','2','2','2','2'}
            };

            size = celdaSize;
            collisions = new Collisions(this.level);


            red = new RedGhost(collisions, ghostsSpeed);
            pinky = new Pinky(collisions, ghostsSpeed);
            inky = new Inky(collisions, ghostsSpeed);
            clayde = new Clayde(collisions, ghostsSpeed);

            ghosts.Add(red);
            ghosts.Add(pinky);
            ghosts.Add(inky);
            ghosts.Add(clayde);

            fakePacman = new Pacman(0);
            fakePacman.pictureBoxPosition = new Point(0, 0);
        }

        public void DrawMap(Graphics graphics)
        {

            for (int y = 0; y < this.level.GetLength(0); y++)
            {

                for (int x = 0; x < this.level.GetLength(1); x++)
                {
                    switch (this.level[y, x])
                    {
                        case 'p':
                            Pill.DrawPill(graphics, y, x, size, y);
                            break;
                        case 'i':
                            Pill.DrawPill(graphics, y, x, size, y);
                            break;
                        case 'w':
                            graphics.DrawImage(Resource1.Beer, new PointF((y*size) + 12, (x*size) + 5));
                            break;
                        case 'l':
                            break;
                        default: break;
                    }
                }
            }
        }


        public void TimerCounter(Pacman pacman)
        {
            counter++;

            for (int i = 0; i < 4; i++)
            {
                GhostMovement(ghostDirs[i], ghosts[i], ghosts[i].leavingHouse);
            }
            if (counter == 25)
            {
                counterSeconds++;



                counter = 0;
                if (counterSeconds == 1 && counterCasaGhost < 4)
                {

                    ghosts[counterCasaGhost].leavingHouse = true;
                    counterCasaGhost++;
                  
                }
            }


            if(pacman.isBuffed)
            {
                if (counterSeconds == 10)
                {

                    for (int i = 0; i < 4; i++)
                    {
                        ghosts[i].isScared = false;
                    }
                    pacman.isBuffed = false;
                    counterSeconds = 0;
                }
            }
            else
            {
                if(counterSeconds == scaterModeTime && red.scaterMode == true)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        ghosts[i].scaterMode = false;
                    }

                    counterSeconds = 0;
                    scaterModeTime = 40;
                }
                else if (counterSeconds == scaterModeTime && red.scaterMode == false)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        ghosts[i].scaterMode = true;
                    }

                    counterSeconds = 0;
                    scaterModeTime = 5;
                }
            }
        }

        public void RenderGhosts(Graphics graphics)
        {
            for (int i = 0; i < ghosts.Count; i++)
            {
                ghosts[i].Render(graphics);
            }
        }

        public void SpawnPacman(Pacman pacman)
        {
            int x = pacman.pictureBoxPosition.X;
            int y = pacman.pictureBoxPosition.Y;
        }

        public void DrawFromResource(Graphics graphics, int x, int y, int size, Image image)
        {
            graphics.DrawImage(image, new Rectangle(x * size, y * size, size, size));
        }

        public Boolean MoveUp(Character character)
        {

            if (Math.Abs(character.pictureBoxPosition.Y - character.MatrixPosition.Y * 20) <= 10)
            {
                character.UpdateCurrentMatrixTile('u');

                if (!this.collisions.DetectCollision(character.MatrixPosition, 'u',character))
                {
                    character.pictureBoxPosition.Y = character.MatrixPosition.Y * 20;
                    character.pictureBoxPosition.X += character.BASE_SPEED; ;
                    if (character is Pacman pacman)
                    {
                        this.level[character.MatrixPosition.Y, character.MatrixPosition.X] = ReplaceTilePacman(this.level[character.MatrixPosition.Y, character.MatrixPosition.X], pacman);
                    }
                    return true;
                }
                else if (character.pictureBoxPosition.X < character.MatrixPosition.X * 20)
                {
                    character.pictureBoxPosition.X += character.BASE_SPEED;

                }


            }
            return false;
        }

        public Boolean MoveDown(Character character)
        {
            if (Math.Abs(character.pictureBoxPosition.Y - character.MatrixPosition.Y * 20) <= 10)
            {
                character.UpdateCurrentMatrixTile('d');
                
                if (!this.collisions.DetectCollision(character.MatrixPosition, 'd',character))
                {
                    character.pictureBoxPosition.Y = character.MatrixPosition.Y * 20;
                    character.pictureBoxPosition.X -= character.BASE_SPEED; ;
                    if (character is Pacman pacman)
                    {
                        this.level[character.MatrixPosition.Y, character.MatrixPosition.X] = ReplaceTilePacman(this.level[character.MatrixPosition.Y, character.MatrixPosition.X], pacman);
                    }
                    return true;
                }
                else if (character.pictureBoxPosition.X > character.MatrixPosition.X * 20)
                {
                    character.pictureBoxPosition.X -= character.BASE_SPEED; ;
                }

            }
            return false;

        }

        public Boolean MoveLeft(Character character)
        {


            if (Math.Abs(character.pictureBoxPosition.X - character.MatrixPosition.X * 20) <= 10)
            {
                character.UpdateCurrentMatrixTile('l');


                if (!this.collisions.DetectCollision(character.MatrixPosition, 'l', character))
                {
                    character.pictureBoxPosition.X = character.MatrixPosition.X * 20;
                    character.pictureBoxPosition.Y -= character.BASE_SPEED;
                    if (character is Pacman pacman)
                    {
                        this.level[character.MatrixPosition.Y, character.MatrixPosition.X] = ReplaceTilePacman(this.level[character.MatrixPosition.Y, character.MatrixPosition.X], pacman);
                    }

                    return true;
                }
                else if (character.pictureBoxPosition.Y > character.MatrixPosition.Y * 20)
                {
                    character.pictureBoxPosition.Y -= character.BASE_SPEED; ;
                }


            }
            return false;


        }

        public Boolean MoveRight(Character character)
        {
            if (Math.Abs(character.pictureBoxPosition.X - character.MatrixPosition.X * 20) <= 8)
            {
                character.UpdateCurrentMatrixTile('r');

                if (!this.collisions.DetectCollision(character.MatrixPosition, 'r', character))
                {
                    character.pictureBoxPosition.X = character.MatrixPosition.X * 20;
                    character.pictureBoxPosition.Y += character.BASE_SPEED;

                    if (character is Pacman pacman)
                    {
                        this.level[character.MatrixPosition.Y, character.MatrixPosition.X] = ReplaceTilePacman(this.level[character.MatrixPosition.Y, character.MatrixPosition.X],pacman);
                    }

                    return true;
                }
                else if (character.pictureBoxPosition.Y < character.MatrixPosition.Y * 20)
                {
                    character.pictureBoxPosition.Y += character.BASE_SPEED; ;
                }

            }
            return false;
        }
        bool togle = true;

        public void GhostBehaviour(Character pacman)
        {

            for (int i = 0; i < ghosts.Count; i++)
            {
                ghostDirs[i] = ghosts[i].currentDir;
                
                bool getClose;

                
                if(this.level[ghosts[i].MatrixPosition.Y, ghosts[i].MatrixPosition.X] == '5' && ghosts[i].isDead)
                {
                    ghosts[i].isDead = false;
                    getClose = false;
                    ghostDirs[i] = 'u';
                    ghosts[i].currentDir = ghostDirs[i];
                    togle = false;
                }
                else if (this.level[ghosts[i].MatrixPosition.Y, ghosts[i].MatrixPosition.X] == '4' && ghosts[i].leavingHouse == true)
                {
                    getClose = true;
                    ghostDirs[i] = 'd';
                    ghosts[i].currentDir = ghostDirs[i];
                    togle = false;

                }
                else if (this.level[ghosts[i].MatrixPosition.Y, ghosts[i].MatrixPosition.X] == 'i' || this.level[ghosts[i].MatrixPosition.Y, ghosts[i].MatrixPosition.X] == 'l') // when at desicion tile
                {
                    if (togle)
                    {
                        getClose = true;
                        ghostDirs[i] = ghosts[i].GoForPacman(pacman, this.level, getClose, red.pictureBoxPosition);
                        ghosts[i].currentDir = ghostDirs[i];
                        togle = false;
                    }
                }
                else
                {
                    if (collisions.DetectCollision(ghosts[i].MatrixPosition, ghostDirs[i]))
                    {
                        getClose = false;
                        ghostDirs[i] = ghosts[i].GoForPacman(pacman, this.level, getClose, red.pictureBoxPosition);
                        ghosts[i].currentDir = ghostDirs[i];
                    } 

                    togle = true;
                }
            }
        }


        private void GhostMovement(char redDir, Ghost ghost, Boolean leavingHouse)
        {
            switch (redDir)
            {
                case 'l':
                    this.MoveLeft(ghost);
                    break;
                case 'r':
                    this.MoveRight(ghost);
                    break;
                case 'd':
                    this.MoveDown(ghost);
                    break;
                case 'u':
                    this.MoveUp(ghost);
                    break;
                default:
                    break;
            }
        }

        private char ReplaceTilePacman(char tileValue,Pacman pacman)
        {
            if(tileValue == 'p')
            {
                return '1';
            }
            else if(tileValue == 'i')
            {
                return 'l';
            }
            else if (tileValue == 'l')
            {
                return 'l';
            }
            else if(tileValue == '1')
            {
                return '1';
            }
            else if( tileValue == 'w')
            {
                pacman.isBuffed = true;
                for (int i = 0; i < 4; i++)
                {
                    ghosts[i].isScared = true;
                }
                counterSeconds = 0;
                return '1';
            }

            return 'e';
        }

 
    }
}
