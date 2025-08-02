using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Threading;
using System.Windows.Input;
using System.Diagnostics;



namespace Scroll
{
    public partial class MAIN : Form
    {
        Map map;
        Player player1;
        Player player2;
        Player player3;
        
        float fElapsedTime;

        // Parallax
        Graphics g;
        int turtleCoordinates;
        int seaweedCoordinates, seaweedCoordinates2, seaweedCoordinates3, seaweedCoordinates4, seaweedCoordinates5;
        int seaweedCoordinates6, seaweedCoordinates7, seaweedCoordinates8, seaweedCoordinates9, seaweedCoordinates10;
        int seaweedCoordinates11, seaweedCoordinates12, seaweedCoordinates13, seaweedCoordinates14, seaweedCoordinates15;
        int seaweedCoordinates16, seaweedCoordinates17, seaweedCoordinates18, seaweedCoordinates19, seaweedCoordinates20;
        int seaweedCoordinates21, seaweedCoordinates22, seaweedCoordinates23, seaweedCoordinates24, seaweedCoordinates25;
        int seaweedCoordinates26, seaweedCoordinates27, seaweedCoordinates28, seaweedCoordinates29, seaweedCoordinates30;
        int width;
        int motion1 = 2;
        int motion2 = 4;

        // Camera properties
        float fCameraPosX = 291.0f;
        float fCameraPosY = 0.0f;
        Vec2 prevCameraPos;
        bool left1, right1;
        bool left2, right2;
        bool left3, right3;
        Thread keyListenerThread;
        int JumpConstant = 13;
        public MAIN()
        {
            InitializeComponent();
            Init();

      
        }

        
        private void Init()
        {
            map                 = new Map(PCT_CANVAS.Size);
            player1              = new Player("player1", Resource1.BuzoGrisR, Resource1.BuzoGrisL);
            player2 = new Player("player2", Resource1.BuzoCafeR, Resource1.BuzoCafeL);
            player3 = new Player("player3", Resource1.BuzoMoradoR, Resource1.BuzoMoradoL);
            PCT_CANVAS.Image    = map.bmp;
            fElapsedTime        = 0.05f;
            left1                = false;
            right1               = false;
            prevCameraPos = new Vec2(fCameraPosX,fCameraPosY);
            // Parallax
            width = PCT_CANVAS.Width;
            turtleCoordinates = seaweedCoordinates = seaweedCoordinates2 = seaweedCoordinates3 = seaweedCoordinates4 = 0;
            seaweedCoordinates5 = seaweedCoordinates6 = seaweedCoordinates7 = seaweedCoordinates8 = 0;
            seaweedCoordinates9 = seaweedCoordinates10 = seaweedCoordinates11 = seaweedCoordinates12 = 0;
            seaweedCoordinates13 = seaweedCoordinates14 = seaweedCoordinates15 = seaweedCoordinates16 = 0;
            seaweedCoordinates17 = seaweedCoordinates18 = seaweedCoordinates19 = seaweedCoordinates20 = 0;
            seaweedCoordinates21 = seaweedCoordinates22 = seaweedCoordinates23 = seaweedCoordinates24 = 0;
            seaweedCoordinates25 = seaweedCoordinates26 = seaweedCoordinates27 = seaweedCoordinates28 = 0;
            seaweedCoordinates29 = seaweedCoordinates30 = 0;
        }

        private void MAIN_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:                    //player 1 controles
                    left1 = true;
                    right1 = false;
                    break;
                case Keys.Right:
                    right1 = true;
                    left1 = false;
                    break;
                case Keys.Up:
                    if (player1.FPlayerVelY == 0)// sin brincar o cayendo
                    {
                        player1.FPlayerVelY = -JumpConstant;
                        player1.Frame(2);
                        player1.bPlayerOnGround = false;
                    }
                    break;
                case Keys.Down:
                    player1.GoDown();
                    break;

                case Keys.A:
                    left2 = true;
                    right2 = false;
                    break;
                case Keys.D:
                    right2 = true;
                    left2 = false;
                    break;
                case Keys.W:
                    if (player2.FPlayerVelY == 0)// sin brincar o cayendo
                    {
                        player2.FPlayerVelY = -JumpConstant;
                        player2.Frame(2);
                        player2.bPlayerOnGround = false;
                    }
                    break;
                case Keys.S:
                    player2.GoDown();
                    break;

                case Keys.F:
                    left3 = true;
                    right3 = false;
                    break;
                case Keys.H:
                    right3 = true;
                    left3 = false;
                    break;
                case Keys.T:
                    if (player3.FPlayerVelY == 0)// sin brincar o cayendo
                    {
                        player3.FPlayerVelY = -JumpConstant;
                        player3.Frame(2);
                        player3.bPlayerOnGround = false;
                    }
                    break;
                case Keys.G:
                    player3.GoDown();
                    break;

            }
            
            UpdateEnv();
        }

        private void MAIN_KeyPress(object sender, KeyPressEventArgs e) //como hacer mas smooth las teclas...
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Space:
                    
                        player2.Shoot();
                      
                    break;
                case (char)Keys.Enter:
                   
                    player1.Shoot();

                    break;

                case (char)Keys.J:

                    player3.Shoot();

                    break;
            }
        }

        private void MAIN_KeyUp(object sender, KeyEventArgs e) //when a key is released
        {
            if (e.KeyCode == Keys.Space)
                return;
            if (e.KeyCode == Keys.Up)
                return;

            
            if (e.KeyCode == Keys.W)
                return;
            if(e.KeyCode == Keys.T)
            {
                return;
            }

            switch (e.KeyCode)
            {
                case Keys.Left:
                    left1 = false;
                    break;
                case Keys.Right:
                    right1 = false;
                    break;

                case Keys.A:
                    left2 = false;
                    break;
                case Keys.D:
                    right2 = false;
                    break;

                case Keys.F:
                    left3 = false;
                    break;
                case Keys.H:
                    right3 = false;
                    break;
            }

           

            player1.FPlayerVelX = 0;

            player1.Stop();

            player2.FPlayerVelX = 0;

            player2.Stop();

            player3.FPlayerVelX = 0;

            player3.Stop();
        }

        private void MAIN_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void PCT_CANVAS_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.DrawImage(Resource1.tortuga, turtleCoordinates, 100, 140, 50);
            g.DrawImage(Resource1.Alga, seaweedCoordinates, PCT_CANVAS.Height-120, 40, 150);
            g.DrawImage(Resource1.Alga, seaweedCoordinates2 + 40, PCT_CANVAS.Height - 120, 40, 150);
            g.DrawImage(Resource1.Alga, seaweedCoordinates3 + 80, PCT_CANVAS.Height - 120, 40, 150);
            g.DrawImage(Resource1.Alga, seaweedCoordinates4 + 120, PCT_CANVAS.Height - 120, 40, 150);
            g.DrawImage(Resource1.Alga, seaweedCoordinates5 + 160, PCT_CANVAS.Height - 120, 40, 150);
            g.DrawImage(Resource1.Alga, seaweedCoordinates6 + 200, PCT_CANVAS.Height - 120, 40, 150);
            g.DrawImage(Resource1.Alga, seaweedCoordinates7 + 240, PCT_CANVAS.Height - 120, 40, 150);
            g.DrawImage(Resource1.Alga, seaweedCoordinates8 + 280, PCT_CANVAS.Height - 120, 40, 150);
            g.DrawImage(Resource1.Alga, seaweedCoordinates9 + 320, PCT_CANVAS.Height - 120, 40, 150);
            g.DrawImage(Resource1.Alga, seaweedCoordinates10 + 360, PCT_CANVAS.Height - 120, 40, 150);
            g.DrawImage(Resource1.Alga, seaweedCoordinates11 + 400, PCT_CANVAS.Height - 120, 40, 150);
            g.DrawImage(Resource1.Alga, seaweedCoordinates12 + 440, PCT_CANVAS.Height - 120, 40, 150);
            g.DrawImage(Resource1.Alga, seaweedCoordinates13 + 480, PCT_CANVAS.Height - 120, 40, 150);
            g.DrawImage(Resource1.Alga, seaweedCoordinates14 + 520, PCT_CANVAS.Height - 120, 40, 150);
            g.DrawImage(Resource1.Alga, seaweedCoordinates15 + 560, PCT_CANVAS.Height - 120, 40, 150);
            g.DrawImage(Resource1.Alga, seaweedCoordinates16 + 600, PCT_CANVAS.Height - 120, 40, 150);
            g.DrawImage(Resource1.Alga, seaweedCoordinates17 + 640, PCT_CANVAS.Height - 120, 40, 150);
            g.DrawImage(Resource1.Alga, seaweedCoordinates18 + 680, PCT_CANVAS.Height - 120, 40, 150);
            g.DrawImage(Resource1.Alga, seaweedCoordinates19 + 720, PCT_CANVAS.Height - 120, 40, 150);
            g.DrawImage(Resource1.Alga, seaweedCoordinates20 + 760, PCT_CANVAS.Height - 120, 40, 150);
            g.DrawImage(Resource1.Alga, seaweedCoordinates21 + 800, PCT_CANVAS.Height - 120, 40, 150);
            g.DrawImage(Resource1.Alga, seaweedCoordinates22 + 840, PCT_CANVAS.Height - 120, 40, 150);
            g.DrawImage(Resource1.Alga, seaweedCoordinates23 + 880, PCT_CANVAS.Height - 120, 40, 150);
            g.DrawImage(Resource1.Alga, seaweedCoordinates24 + 920, PCT_CANVAS.Height - 120, 40, 150);
            g.DrawImage(Resource1.Alga, seaweedCoordinates25 + 960, PCT_CANVAS.Height - 120, 40, 150);
            g.DrawImage(Resource1.Alga, seaweedCoordinates26 + 1000, PCT_CANVAS.Height - 120, 40, 150);
            g.DrawImage(Resource1.Alga, seaweedCoordinates27 + 1040, PCT_CANVAS.Height - 120, 40, 150);
            g.DrawImage(Resource1.Alga, seaweedCoordinates28 + 1080, PCT_CANVAS.Height - 120, 40, 150);
            g.DrawImage(Resource1.Alga, seaweedCoordinates29 + 1120, PCT_CANVAS.Height - 120, 40, 150);
            g.DrawImage(Resource1.Alga, seaweedCoordinates30 + 1160, PCT_CANVAS.Height - 120, 40, 150);
        }

        private void TIMER_Tick(object sender, EventArgs e)
        {
         
            BackgroundMove();
            UpdateEnv();
            
            if(Map.updatePosProjectiles)
            {
                player1.pistol.AdjustPosition(Map.offX, Map.offY);
            }

            

        }

        private void MAIN_Load(object sender, EventArgs e)
        {

        }

        private void UpdateEnv()
        {
            map.g.Clear(Color.FromArgb(0, 0, 0, 0));
            if (left1)
                player1.Left(fElapsedTime);
            if (right1)
                player1.Right(fElapsedTime);

            if (left2)
                player2.Left(fElapsedTime);
            if (right2)
                player2.Right(fElapsedTime);

            if (left3)
                player3.Left(fElapsedTime);
            if (right3)
                player3.Right(fElapsedTime);


            fCameraPosX = (player1.fPlayerPosX + player2.fPlayerPosX + player3.fPlayerPosX)/3;
            fCameraPosY = (player1.fPlayerPosY + player2.fPlayerPosY + player3.fPlayerPosY)/3;
            Weapon.CameraPos = new Vec2(fCameraPosX*20,fCameraPosY*20);
       

            map.Draw(new PointF(fCameraPosX,fCameraPosY),player1.fPlayerPosX.ToString() , player1,true);
            map.Draw(new PointF(fCameraPosX, fCameraPosY), player2.fPlayerPosX.ToString(), player2,false);
            map.Draw(new PointF(fCameraPosX, fCameraPosY), player3.fPlayerPosX.ToString(), player3, false);

            player1.Update(fElapsedTime, map,Weapon.CameraPos);
            player2.Update(fElapsedTime, map, Weapon.CameraPos);
            player3.Update(fElapsedTime, map, Weapon.CameraPos);

            PCT_CANVAS.Invalidate();
        }

        private void BackgroundMove()
        {
            if (turtleCoordinates > width)
            {
                turtleCoordinates = motion1 - width;
            }
            turtleCoordinates += motion1;

            if (seaweedCoordinates > width)
            {
                seaweedCoordinates = motion2 - width;
            }
            seaweedCoordinates += motion2;

            if (seaweedCoordinates2 > width)
            {
                seaweedCoordinates2 = motion2 - width;
            }
            seaweedCoordinates2 += motion2;

            if (seaweedCoordinates3 > width)
            {
                seaweedCoordinates3 = motion2 - width;
            }
            seaweedCoordinates3 += motion2;

            if (seaweedCoordinates4 > width)
            {
                seaweedCoordinates4 = motion2 - width;
            }
            seaweedCoordinates4 += motion2;

            if (seaweedCoordinates5 > width)
            {
                seaweedCoordinates5 = motion2 - width;
            }
            seaweedCoordinates5 += motion2;

            if (seaweedCoordinates6 > width)
            {
                seaweedCoordinates6 = motion2 - width;
            }
            seaweedCoordinates6 += motion2;

            if (seaweedCoordinates7 > width)
            {
                seaweedCoordinates7 = motion2 - width;
            }
            seaweedCoordinates7 += motion2;

            if (seaweedCoordinates8 > width)
            {
                seaweedCoordinates8 = motion2 - width;
            }
            seaweedCoordinates8 += motion2;

            if(seaweedCoordinates9 > width)
            {
                seaweedCoordinates9 = motion2 - width;
            }
            seaweedCoordinates9 += motion2;

            if (seaweedCoordinates10 > width)
            {
                seaweedCoordinates10 = motion2 - width;
            }
            seaweedCoordinates10 += motion2;

            if (seaweedCoordinates11 > width)
            {
                seaweedCoordinates11 = motion2 - width;
            }
            seaweedCoordinates11 += motion2;

            if (seaweedCoordinates12 > width)
            {
                seaweedCoordinates12 = motion2 - width;
            }
            seaweedCoordinates12 += motion2;

            if (seaweedCoordinates13 > width)
            {
                seaweedCoordinates13 = motion2 - width;
            }
            seaweedCoordinates13 += motion2;

            if (seaweedCoordinates14 > width)
            {
                seaweedCoordinates14 = motion2 - width;
            }
            seaweedCoordinates14 += motion2;

            if (seaweedCoordinates15 > width)
            {
                seaweedCoordinates15 = motion2 - width;
            }
            seaweedCoordinates15 += motion2;

            if (seaweedCoordinates16 > width)
            {
                seaweedCoordinates16 = motion2 - width;
            }
            seaweedCoordinates16 += motion2;

            if (seaweedCoordinates17 > width)
            {
                seaweedCoordinates17 = motion2 - width;
            }
            seaweedCoordinates17 += motion2;

            if (seaweedCoordinates18 > width)
            {
                seaweedCoordinates18 = motion2 - width;
            }
            seaweedCoordinates18 += motion2;

            if (seaweedCoordinates19 > width)
            {
                seaweedCoordinates19 = motion2 - width;
            }
            seaweedCoordinates19 += motion2;

            if (seaweedCoordinates20 > width)
            {
                seaweedCoordinates20 = motion2 - width;
            }
            seaweedCoordinates20 += motion2;

            if (seaweedCoordinates21 > width)
            {
                seaweedCoordinates21 = motion2 - width;
            }
            seaweedCoordinates21 += motion2;

            if (seaweedCoordinates22 > width)
            {
                seaweedCoordinates22 = motion2 - width;
            }
            seaweedCoordinates22 += motion2;

            if (seaweedCoordinates23 > width)
            {
                seaweedCoordinates23 += motion2;
            }
            seaweedCoordinates23 += motion2;

            if (seaweedCoordinates24 > width)
            {
                seaweedCoordinates24 += motion2;
            }
            seaweedCoordinates24 += motion2;

            if (seaweedCoordinates25 > width)
            {
                seaweedCoordinates25 += motion2;
            }
            seaweedCoordinates25 += motion2;

            if (seaweedCoordinates26 > width)
            {
                seaweedCoordinates26 += motion2;
            }
            seaweedCoordinates26 += motion2;

            if (seaweedCoordinates27 > width)
            {
                seaweedCoordinates27 += motion2;
            }
            seaweedCoordinates27 += motion2;

            if (seaweedCoordinates28 > width)
            {
                seaweedCoordinates28 += motion2;
            }   
            seaweedCoordinates28 += motion2;

            if (seaweedCoordinates29 > width)
            {
                seaweedCoordinates29 += motion2;
            }
            seaweedCoordinates29 += motion2;

            if (seaweedCoordinates30 > width)
            {
                seaweedCoordinates30 += motion2;
            }
            seaweedCoordinates30 += motion2;

            Invalidate();
        }


    }
}
