using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;

namespace Scroll
{
    public class Player
    {
        Sprite mainSprite, unmodifiedSprite;

        public float fPlayerPosX = 140.0f; //starting position
        public float fPlayerPosY = 140.0f;

        private float fPlayerVelX = 0.0f; //starting vel
        private float fPlayerVelY = 0.0f;
        float fNewPlayerPosX;
        float fNewPlayerPosY;
        public Boolean GoingDown { get; set; } = false;

        protected Vec2 changeVal;
        protected String currentWeapon = "pistol";
        protected char currentDir = 'r';
        protected int hittedCounter = 0;
        protected bool hitted = false;

        public Pistol pistol = new Pistol();

        public String playerName { get; set; }

        public Boolean isDead { get; set; } = false;
        public Sprite MainSprite
        {
            get { return mainSprite; }
        }

        public float FPlayerVelX
        {
            get { return fPlayerVelX; }
            set { fPlayerVelX = value; }
        }

        public float FPlayerVelY
        {
            get { return fPlayerVelY; }
            set { fPlayerVelY = value; }
        }

        public Player(string playerName, Bitmap right, Bitmap left)
        {                               //original size?
            mainSprite = new Sprite(new Size(48, 70), new Size(30, 35), new Point(), right, left);
            unmodifiedSprite = mainSprite;
            this.playerName = playerName;
        }

        public void Right(float fElapsedTime)
        {
            if (FPlayerVelX >= 10)
            {
                FPlayerVelX = 10;
                return;
            }
            FPlayerVelX += (bPlayerOnGround ? 25.0f : 15.0f) * fElapsedTime;
            if (bPlayerOnGround)
                mainSprite.MoveRight();

            currentDir = 'r';
        }

        public void Left(float fElapsedTime)
        {
            if (FPlayerVelX <= -10)
            {
                FPlayerVelX = -10;
                return;
            }
            FPlayerVelX += (bPlayerOnGround ? -25.0f : -15.0f) * fElapsedTime;
            if (bPlayerOnGround)
                mainSprite.MoveLeft();

            currentDir = 'l';
        }

        public void Frame(int x)
        {
            mainSprite.Frame(x);
        }
        public void Stop()
        {
            mainSprite.Frame(0);
        }

        public bool bPlayerOnGround = false;

        public void Update(float fElapsedTime, Map map, Vec2 changeVal)
        {
            //Gravity
            fPlayerVelY += 10.0f * fElapsedTime;//---------------

            // Drag
            if (bPlayerOnGround)
            {
                fPlayerVelX += -3.0f * fPlayerVelX * fElapsedTime;
                if (Math.Abs(fPlayerVelX) < 0.01f)
                    fPlayerVelX = 0.0f;
            }

            // Clamp velocities
            if(hitted)
            {
                hittedCounter++;
                if(hittedCounter > 1000)
                {
                    hittedCounter = 0;
                    hitted = false;
                }
            }
            else
            {
                ClampVelPos();
            }
            

            fNewPlayerPosX = fPlayerPosX + fPlayerVelX * fElapsedTime;
            fNewPlayerPosY = fPlayerPosY + fPlayerVelY * fElapsedTime;

            CheckPicks(map, fNewPlayerPosX, fNewPlayerPosY, 'p', '.'); //projectile
            CheckPicks(map, fNewPlayerPosX, fNewPlayerPosY, 'b', '.');
            

            // COLLISION
            if (fPlayerVelX <= 0)//left
            {
                if (
                    (map.GetTile((int)(fNewPlayerPosX + 0.0f), (int)(fPlayerPosY + 0.0f)) != '.') ||
                    (map.GetTile((int)(fNewPlayerPosX + 0.0f), (int)(fPlayerPosY + 0.9f)) != '.')
                    )
                {
                    if (
                    (map.GetTile((int)(fNewPlayerPosX + 0.0f), (int)(fPlayerPosY + 0.0f)) == 'f') ||
                    (map.GetTile((int)(fNewPlayerPosX + 0.0f), (int)(fPlayerPosY + 0.9f)) == 'f')
                    )
                    {
                        
                    }
                    else if (
                    (map.GetTile((int)(fNewPlayerPosX + 0.0f), (int)(fPlayerPosY + 0.0f)) == 'g') ||
                    (map.GetTile((int)(fNewPlayerPosX + 0.0f), (int)(fPlayerPosY + 0.9f)) == 'g')
                        )
                    {

                    }
                    else if (
                    (map.GetTile((int)(fNewPlayerPosX + 0.0f), (int)(fPlayerPosY + 0.0f)) == 'k') ||
                    (map.GetTile((int)(fNewPlayerPosX + 0.0f), (int)(fPlayerPosY + 0.9f)) == 'k')
                        )
                    {

                    }
                    else
                    {
                        if (fPlayerVelX != 0)
                            fNewPlayerPosX = (int)fNewPlayerPosX + 1;
                        fPlayerVelX = 0;
                    }

                    
                }
                
            }
            else//right
            {
                if ((map.GetTile((int)(fNewPlayerPosX + 1.0f), (int)(fPlayerPosY + 0.0f)) != '.') || (map.GetTile((int)(fNewPlayerPosX + 1.0f), (int)(fPlayerPosY + 0.9f)) != '.'))
                {
                    if (
                    (map.GetTile((int)(fNewPlayerPosX + 1.0f), (int)(fPlayerPosY + 0.0f)) == 'f') ||
                    (map.GetTile((int)(fNewPlayerPosX + 1.0f), (int)(fPlayerPosY + 0.9f)) == 'f')
                    )
                    {

                    }
                    else if(
                    (map.GetTile((int)(fNewPlayerPosX + 1.0f), (int)(fPlayerPosY + 0.0f)) == 'g') ||
                    (map.GetTile((int)(fNewPlayerPosX + 1.0f), (int)(fPlayerPosY + 0.9f)) == 'g')
                        )
                    {

                    }
                    else if (
                    (map.GetTile((int)(fNewPlayerPosX + 1.0f), (int)(fPlayerPosY + 0.0f)) == 'k') ||
                    (map.GetTile((int)(fNewPlayerPosX + 1.0f), (int)(fPlayerPosY + 0.9f)) == 'k')
                        )
                    {

                    }
                    else
                    {
                        if (fPlayerVelX != 0)
                            fNewPlayerPosX = (int)fNewPlayerPosX;

                        fPlayerVelX = 0;
                    }
                    
                }
            }

            //bPlayerOnGround = false;
            if (fPlayerVelY <= 0)// up
            {


            }
            else
            {

                if (this.fPlayerPosY >= 45)
                {
                    Debug.WriteLine("Player is dead");
                    this.PlayerDeadRoutine();
                }
                if ((map.GetTile((int)(fNewPlayerPosX + 0.0f), (int)(fNewPlayerPosY + 1.0f)) != '.') || (map.GetTile((int)(fNewPlayerPosX + 0.9f), (int)(fNewPlayerPosY + 1f)) != '.'))
                {
                    if (
                    (map.GetTile((int)(fNewPlayerPosX + 0.0f), (int)(fNewPlayerPosY + 1.0f)) == 'f') ||
                    (map.GetTile((int)(fNewPlayerPosX + 0.9f), (int)(fNewPlayerPosY + 1f)) == 'f')
                    )
                    {

                    }
                    else if (
                    (map.GetTile((int)(fNewPlayerPosX + 0.0f), (int)(fNewPlayerPosY + 1.0f)) == 'g') ||
                    (map.GetTile((int)(fNewPlayerPosX + 0.9f), (int)(fNewPlayerPosY + 1f)) == 'g')
                        )
                    {

                    }
                    else if (
                    (map.GetTile((int)(fNewPlayerPosX + 0.0f), (int)(fNewPlayerPosY + 1.0f)) == 'k') ||
                    (map.GetTile((int)(fNewPlayerPosX + 0.9f), (int)(fNewPlayerPosY + 1f)) == 'k')
                        )
                    {

                    }
                    else
                    {
                        fNewPlayerPosY = (int)fNewPlayerPosY;
                        fPlayerVelY = 0;


                        if (!bPlayerOnGround)
                            Frame(0);

                        bPlayerOnGround = true;
                    }
                    
                }
                else
                {
                    this.GoingDown = false;
                }
            }

            fPlayerPosX = fNewPlayerPosX;
            fPlayerPosY = fNewPlayerPosY;

            if (!this.isDead)
            {
                mainSprite.Display(map.g);

            }
            else
            {
                this.isDead = false;
            }
            
            
            switch(currentWeapon)
            {
                case "pistol":
                    pistol.ShowProjectiles(map.g,new Size(72*20,49*20),changeVal,map, fElapsedTime);

                    break;
            }
        }

        private  void CheckPicks(Map map, float fNewPlayerPosX, float fNewPlayerPosY, char c, char c2)
        {
            if (map.GetTile(fNewPlayerPosX + 0.0f, fNewPlayerPosY + 0.0f) == c)
            {
                map.SetTile(fNewPlayerPosX + 0.0f, fNewPlayerPosY + 0.0f, c2);
                if (c == 'p' && c2 == '.')
                {
                    if (map.GetTile(fPlayerPosX, fPlayerPosY) == '.')
                    {
                        this.Hitted('l');
                    }

                }
                if (c == 'b' && c2 == '.')
                {
                    if (map.GetTile(fPlayerPosX, fPlayerPosY) == '.')
                    {
                        this.Hitted('r');
                    }

                }
            }
                
            if (map.GetTile(fNewPlayerPosX + 0.0f, fNewPlayerPosY + 0.0f) == c)
            {
                map.SetTile(fNewPlayerPosX + 0.0f, fNewPlayerPosY + 0.0f, c2);
                if (c == 'p' && c2 == '.')
                {
                    if (map.GetTile(fPlayerPosX, fPlayerPosY) == '.')
                    {
                        this.Hitted('l');
                    }

                }
                if (c == 'b' && c2 == '.')
                {
                    if (map.GetTile(fPlayerPosX, fPlayerPosY) == '.')
                    {
                        this.Hitted('r');
                    }

                }
            }
                
            if (map.GetTile(fNewPlayerPosX+1.0f, fNewPlayerPosY) == c)
            {
                map.SetTile(fNewPlayerPosX+1.0f, fNewPlayerPosY, c2);
                if (c == 'p' && c2 == '.')
                {
                    if(map.GetTile(fPlayerPosX,fPlayerPosY) == '.')
                    {
                        this.Hitted('l');
                    }
                    
                }
                if (c == 'b' && c2 == '.')
                {
                    if (map.GetTile(fPlayerPosX, fPlayerPosY) == '.')
                    {
                        this.Hitted('r');
                    }

                }
            }
                
            if (map.GetTile(fNewPlayerPosX + 1.0f, fNewPlayerPosY + 0.0f) == c)
            {
                map.SetTile(fNewPlayerPosX + 1.0f, fNewPlayerPosY + 0.0f, c2);
                if (c == 'p' && c2 == '.')
                {
                    if (map.GetTile(fPlayerPosX, fPlayerPosY) == '.')
                    {
                        this.Hitted('l');
                    }

                }
                if (c == 'b' && c2 == '.')
                {
                    if (map.GetTile(fPlayerPosX, fPlayerPosY) == '.')
                    {
                        this.Hitted('r');
                    }

                }
            }
                
        }

        public void GoDown()
        {
            if (this.bPlayerOnGround)
            {
                fPlayerPosY += 1;
            }
        }

        public void Shoot()
        {

            switch(currentWeapon)
            {
                case "pistol":
                    
                    pistol.Shoot(currentDir,new Vec2(this.mainSprite.display.X,this.mainSprite.display.Y),Weapon.CameraPos,new Vec2(fPlayerPosX,fPlayerPosY));
                    break;
            }
        }

        public void PlayerDeadRoutine()
        {
            isDead = true;

            this.ResetPlayer();
            
        }

        protected void ResetPlayer()
        {
            this.fPlayerPosX = 140.0f;
            this.fPlayerPosY = 140.0f;
            this.fPlayerVelX = 0.0f; //starting vel
            this.fPlayerVelY = 0.0f;
            this.fNewPlayerPosX = 50;
            this.fNewPlayerPosY = 0;
            
            changeVal = new Vec2(0, 0);
            currentWeapon = "pistol";
            mainSprite = unmodifiedSprite;
        
 
        }

        protected void Hitted(char dir)
        {

            hitted = true;
            if(dir == 'r')
            {
                this.fPlayerVelX = -100;
                this.fPlayerVelY = -10;
                return;
            }

            this.fPlayerVelX = +100;
            this.fPlayerVelY = -10;


        }

        private void ClampVelPos()
        {
            if (fPlayerVelX > 10.0f)
                fPlayerVelX = 10.0f;

            if (fPlayerVelX < -10.0f)
                fPlayerVelX = -10.0f;

            if (fPlayerVelY > 100.0f)
                fPlayerVelY = 100.0f;

            if (fPlayerVelY < -100.0f)
                fPlayerVelY = -100.0f;
        }
    }
}
