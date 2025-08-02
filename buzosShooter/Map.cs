using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Media;
using System.Diagnostics;
using System.Windows.Forms;

namespace Scroll
{
    public class Map
    {
        int divs = 1;
        public int nTileWidth = 20;
        public int nTileHeight = 20;
        int nLevelWidth, nLevelHeight;
        private string sLevel;
        public Bitmap bmp;
        public Graphics g;
        public static Boolean updatePosProjectiles = false;
        public static float offX = 0;
        public static float offY = 0;
        Sprite coin;
        public Brush transparentBrush = new SolidBrush(Color.FromArgb(0, 255, 255, 255));
        int score;
        Vec2 lastCameraChanged = new Vec2(0,0);
        protected Boolean flagActive = false;
        protected Vec2 flagPos;
        protected Random random = new Random();

        public String CurrentPlayerOnFlag { get; set; } = "none";
        public Boolean IsFlagDisputed { get; set; } = false;
        public int FlagCaptureCounter { get; set; } = 0;

        protected int player1Score = 0;
        protected int player2Score = 0;
        protected int player3Score = 0;
        protected int player4Score = 0;

        private Boolean changeFlagPos = false;
        public Map(Size size)
        {            
            coin        = new Sprite(new Size(35, 33), new Size(nTileWidth, nTileHeight), new Point(), Resource1.coin, Resource1.coin);
            score       = 0;

            sLevel = "";
            sLevel += "#................................................................................................................................#";
            sLevel += "#................................................................................................................................#";
            sLevel += "#................................................................................................................................#";
            sLevel += "#................................................................................................................................#";
            sLevel += "#................................................................................................................................#";
            sLevel += "#................................................................................................................................#";
            sLevel += "#................................................................................................................................#";
            sLevel += "#................................................................................................................................#";
            sLevel += "#................................................................................................................................#";
            sLevel += "#................................................................................................................................#";
            sLevel += "#................................................................................................................................#";
            
            sLevel += "#................................................................................................................................#";
            sLevel += "#................................................................................................................................#";
            sLevel += "#................................................................................................................................#";
            sLevel += "#................................................................................................................................#";
            sLevel += "#...............................................f................................................................................#";
            sLevel += "#..........................................############################################..........................................#";
            sLevel += "#................................................................................................................................#";
            sLevel += "#................................................................................................................................#";
            sLevel += "#................................................................................................................................#";
            sLevel += "#................................................................................................................................#";
            sLevel += "#................................................................................................................................#";

            sLevel += "#................................................................................................................................#";
            sLevel += "#.......................................................................................f........................................#";
            sLevel += "#....................................############..........###########...........############....................................#";
            sLevel += "#................................................................................................................................#";
            sLevel += "#................................................................................................................................#";
            sLevel += "#................................................................................................................................#";
            sLevel += "#................................................................................................................................#";
            sLevel += "#................................########....########........................########....########................................#";
            sLevel += "#................................................................................................................................#";
            sLevel += "#................................................................................................................................#";
            sLevel += "#................................................................................................................................#";
            sLevel += "#...............................................................f................................................................#";
            sLevel += "#...................................................##########################...................................................#";
            sLevel += "#................................................................................................................................#";
            sLevel += "#................................................................................................................................#";
            sLevel += "#................................................................................................................................#";
            sLevel += "#................................................................................................................................#";
            sLevel += "#......................................f.........................................................................................#"; 
            sLevel += "#...................................##################......................##################...................................#";
            sLevel += "#................................................................................................................................#";
            sLevel += "#................................................................................................................................#";
            sLevel += "#...............................................................f................................................................#";

            sLevel += "#.........................................................##############.........................................................#";
            sLevel += "#................................................................................................................................#";
            sLevel += "#................................................................................................................................#";

            sLevel += "#................................................................................................................................#";
            sLevel += "#................................................................................................................................#";
            sLevel += "#................................................................................................................................#";

            nLevelWidth = 130;
            nLevelHeight = 49;

            bmp = new Bitmap(size.Width / divs, size.Height / divs);

            g = Graphics.FromImage(bmp);
            g.PixelOffsetMode = PixelOffsetMode.HighSpeed;
            g.SmoothingMode = SmoothingMode.HighSpeed;
        }

        public void Draw(PointF cameraPos, string message, Player player, bool draw)
        {

            // Draw Level based on the visible tiles on our picturebox (canvas)
            int nVisibleTilesX = bmp.Width / nTileWidth;
            int nVisibleTilesY = bmp.Height / nTileHeight;

            // Calculate Top-Leftmost visible tile
            float fOffsetX = cameraPos.X - (float)nVisibleTilesX / 2.0f;
            float fOffsetY = cameraPos.Y - (float)nVisibleTilesY / 2.0f;
            

            // Clamp camera to game boundaries
            if (fOffsetX < 0)
            {
                fOffsetX = 0;
              
            }
            if (fOffsetY < 0)
            {
                fOffsetY = 0;
               
            }

            if (fOffsetX > nLevelWidth - nVisibleTilesX)
            {
                fOffsetX = nLevelWidth - nVisibleTilesX;
            
            }

            if (fOffsetY > nLevelHeight - nVisibleTilesY)
            {

                fOffsetY = nLevelHeight - nVisibleTilesY;
            
            }

            float fTileOffsetX = (fOffsetX - (int)fOffsetX) * nTileWidth;
            float fTileOffsetY = (fOffsetY - (int)fOffsetY) * nTileHeight;
            CaptureFlag(player);
            //Draw visible tile map//*--------------------DRAW------------------------------
            char c;
            float stepX, stepY;

            


            if (draw)
            {
                CameraMovement(fOffsetX, fOffsetY);
            }

            

            for (int x = -1; x < nVisibleTilesX + 2 && draw == true; x++)
            {
                for (int y = -1; y < nVisibleTilesY + 2; y++)
                {
                    c       = GetTile(x + (int)fOffsetX, y + (int)fOffsetY);
                    stepX   = x * nTileWidth - fTileOffsetX;
                    stepY   = y * nTileHeight - fTileOffsetY;


                    switch (c)
                    {

                        case '#':
                            
                            //g.DrawImage(Resource1.plataforma, stepX, stepX, nTileWidth, nTileHeight);
                            g.FillRectangle(Brushes.DarkOliveGreen, stepX, stepY, nTileWidth, nTileHeight);
                            

                            //g.FillRectangle(Brushes.Black, stepX , stepY , nTileWidth , nTileHeight );
                            //g.FillRectangle(Brushes.DarkRed, stepX+1, stepY+1, nTileWidth-2, nTileHeight-2);                            
                            //g.FillEllipse(Brushes.DarkRed, stepX, stepY, nTileWidth, nTileHeight);
                            //g.FillEllipse(Brushes.DarkSlateGray, stepX, stepY, nTileWidth/2, nTileHeight/2);
                            //g.DrawLine(Pens.Black, stepX + nTileHeight / 2, stepY + nTileHeight / 2, stepX + nTileHeight, stepY + nTileHeight -3);
                            //g.DrawLine(Pens.Maroon, stepX + nTileHeight / 2, 2+stepY + nTileHeight / 2,1+ stepX + nTileHeight, stepY + nTileHeight - 2);
                            //g.DrawLine(Pens.Black, stepX + nTileHeight / 2, stepY, stepX + nTileHeight / 2, stepY + nTileHeight * 2 / 3);
                            //g.DrawLine(Pens.Black, 1+stepX + nTileHeight / 2, stepY+1, 2+stepX + nTileHeight / 2,3+ stepY + nTileHeight * 2 / 3);
                            //g.DrawLine(Pens.Maroon, 2+stepX + nTileHeight / 2, stepY, 1+stepX + nTileHeight / 2, stepY + nTileHeight * 2 / 3);
                            //g.DrawLine(Pens.Black, stepX + nTileHeight / 2, stepY + nTileHeight * 2 / 3, stepX, stepY + nTileHeight / 3);
                            //g.DrawRectangle(Pens.Black, stepX + nTileHeight / 2, stepY, nTileWidth, nTileHeight-1);
                            //g.DrawRectangle(Pens.Gray, stepX, stepY, nTileWidth, nTileHeight-1);
                            break;

                        case 'B':
                            g.FillRectangle(Brushes.Black, stepX, stepY, nTileWidth, nTileHeight);
                            g.FillPolygon(Brushes.Gray, new PointF[] { new PointF(stepX, stepY), new PointF(stepX + nTileWidth, stepY), new PointF(stepX, stepY + nTileHeight) });
                            g.FillRectangle(Brushes.DarkGray, stepX + nTileHeight / 4, stepY + nTileHeight / 4, nTileWidth / 2, nTileHeight / 2);
                            g.DrawLine(Pens.DarkGray, stepX, stepY, stepX + nTileWidth, stepY + nTileHeight);
                            break;

                        case 'p': //projectile
                            //g.FillRectangle(Brushes.Black, stepX, stepY, nTileWidth, nTileHeight);
                            g.DrawImage(Resource1.ArponRight, stepX, stepY, nTileWidth, nTileHeight);
                            
                            break;
                        case 'b': //projectile
                            //g.FillRectangle(Brushes.Black, stepX, stepY, nTileWidth, nTileHeight);
                            g.DrawImage(Resource1.ArponLeft, stepX, stepY, nTileWidth, nTileHeight);

                            break;
                        case 'f':
                            
                            if(flagActive == true)
                            {
                                if(this.changeFlagPos)
                                {
                                    this.SetTile(flagPos.X, flagPos.Y, '.');

                                    this.SetTile(flagPos.X + 7, flagPos.Y + 0, '.');
                                    this.SetTile(flagPos.X + 7, flagPos.Y - 10, '.');
                                    this.SetTile(flagPos.X - 7, flagPos.Y + 0, '.');
                                    this.SetTile(flagPos.X - 7, flagPos.Y - 10, '.');
                                    this.changeFlagPos = false;
                                    this.flagActive = false;
                                }
                                
                                 
                            }
                            else
                            {
                                flagActive = GenerateBoolean(0.01);
                                if (flagActive)
                                {
                                    this.SetTile(x + (int)fOffsetX, y + (int)fOffsetY, 'g');

                                    this.SetTile(x + (int)fOffsetX+7, y + (int)fOffsetY+0, 'k');
                                    this.SetTile(x + (int)fOffsetX+7, y + (int)fOffsetY-10, 'k');
                                    this.SetTile(x + (int)fOffsetX-7, y + (int)fOffsetY+0, 'k');
                                    this.SetTile(x + (int)fOffsetX-7, y + (int)fOffsetY-10, 'k');
                                    flagPos = new Vec2(x + (int)fOffsetX, y + (int)fOffsetY);
                                }
                              
                                
                            }
                            break;
                        case 'g':
                            if(flagActive)
                            {
                                //g.FillRectangle(Brushes.Green, stepX, stepY, nTileWidth, nTileHeight);
                                g.DrawImage(Resource1.flag, stepX, stepY, nTileWidth, nTileHeight);
                            }
                            
                            break;
                        case 'k':
                            if(flagActive)
                            {
                                // Draw a bubble
                                g.FillEllipse(Brushes.Aqua, stepX, stepY, nTileWidth, nTileHeight);
                            }
                            break;
                        default:
                            //g.FillRectangle(Brushes.DarkCyan, stepX, stepY, nTileWidth, nTileHeight);
                            break;
                    }            
                }
            }

            g.DrawString("Flag capture counter:: " + this.FlagCaptureCounter + "/500", new Font("Consolas", 10, FontStyle.Italic), Brushes.Black, 5, 5);
            g.DrawString("Player1 Score:: " + this.player1Score, new Font("Consolas", 10, FontStyle.Italic), Brushes.Black, 300, 5);
            g.DrawString("Player2 Score:: " + this.player2Score, new Font("Consolas", 10, FontStyle.Italic), Brushes.Black, 600, 5);
            g.DrawString("Player3 Score:: " + this.player3Score, new Font("Consolas", 10, FontStyle.Italic), Brushes.Black, 900, 5);
            //Debug.WriteLine($"player pos iss : {player.fPlayerPosX} {player.fPlayerPosY}");
            player.MainSprite.posX = (player.fPlayerPosX - fOffsetX) * nTileWidth;
            player.MainSprite.posY = (player.fPlayerPosY - fOffsetY) * nTileHeight;
        }

        public void SetTile(float x, float y, char c)//changes the tile
        {
            if (x >= 0 && x < nLevelWidth && y >= 0 && y < nLevelHeight)
            {
                int index = (int)y * nLevelWidth + (int)x;
                sLevel = sLevel.Remove(index, 1).Insert(index, c.ToString());         
             
            }
        }

        public char GetTile(float x, float y)
        {
            if (x >= 0 && x < nLevelWidth && y >= 0 && y < nLevelHeight)
                return sLevel[(int)y * nLevelWidth + (int)x];
            else
                return ' ';
        }

        public void CameraMovement(float x, float y)
        {
            if(lastCameraChanged.X != x || lastCameraChanged.Y != y)
            {
         
                offX = (lastCameraChanged.X - x) * 20;
                offY = (lastCameraChanged.Y - y) * 20;
                lastCameraChanged.X = x;
                lastCameraChanged.Y = y;
                
             
                updatePosProjectiles = true;
                
                return;
            }
            updatePosProjectiles = false;



        }

        private bool GenerateBoolean(double probability)
        {
          
            double randomValue = random.NextDouble();

          
            return randomValue < probability;
        }


        private void CaptureFlag(Player player)
        {
            if(!flagActive )
            {
                return;
            }

            if (Math.Abs(player.fPlayerPosX - flagPos.X) < 7 && Math.Abs(player.fPlayerPosY - flagPos.Y) < 10)
            {
                

                if (IsFlagDisputed)
                {
                
                    if (CurrentPlayerOnFlag != player.playerName) // 2 players on flag pos, if one leaves the other start capturing
                    {
                       
                       return; 
                    }
                    else
                    {
                        Debug.WriteLine($"Flag being capture by {player.playerName}.");
                        this.FlagCaptureCounter++;
                        if(this.FlagCaptureCounter > 500)
                        {
                            switch(player.playerName)
                            {
                                case "player1":
                                    this.player1Score++;
                                    break;

                                case "player2":
                                    this.player2Score++;
                                    break;
                                case "player3":
                                    this.player3Score++;
                                    break;
                            }
                            ChangeFlagPos();
                            this.FlagCaptureCounter = 0;
                        }
                    }
                }
                else // first player to arrive starts caputre
                {
                    IsFlagDisputed = true;
                    CurrentPlayerOnFlag = player.playerName;
                    this.FlagCaptureCounter = 0;
                }
            }
            else
            {
                if (IsFlagDisputed && CurrentPlayerOnFlag == player.playerName)
                {
                    IsFlagDisputed = false;
                    this.FlagCaptureCounter = 0;
                }
            }
        }

        private void ChangeFlagPos()
        {
            changeFlagPos = true;
        
        }
        
    }
}
