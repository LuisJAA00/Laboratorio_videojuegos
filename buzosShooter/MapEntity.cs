using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scroll
{
    public class MapEntity
    {
        public Sprite mainSprite;

        public float fPlayerPosX = 22.0f; //starting position
        public float fPlayerPosY = 22.0f;

        private float fPlayerVelX = 0.0f; //starting vel
        private float fPlayerVelY = 0.0f;

        Char currentDir = ' ';
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

      

        public void Right(float fElapsedTime)
        {
            FPlayerVelX += (bPlayerOnGround ? 25.0f : 15.0f) * fElapsedTime;
            if (bPlayerOnGround)
                mainSprite.MoveRight();

            currentDir = 'r';
        }

        public void Left(float fElapsedTime)
        {
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

        public void Update(float fElapsedTime, Map map)
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
            if (fPlayerVelX > 10.0f)
                fPlayerVelX = 10.0f;

            if (fPlayerVelX < -10.0f)
                fPlayerVelX = -10.0f;

            if (fPlayerVelY > 100.0f)
                fPlayerVelY = 100.0f;

            if (fPlayerVelY < -100.0f)
                fPlayerVelY = -100.0f;

            float fNewPlayerPosX = fPlayerPosX + fPlayerVelX * fElapsedTime;
            float fNewPlayerPosY = fPlayerPosY + fPlayerVelY * fElapsedTime;

            CheckPicks(map, fNewPlayerPosX, fNewPlayerPosY, '.', 'p');
     


            // COLLISION
            if (fPlayerVelX <= 0)//left
            {
                if ((map.GetTile((int)(fNewPlayerPosX + 0.0f), (int)(fPlayerPosY + 0.0f)) != '.') || (map.GetTile((int)(fNewPlayerPosX + 0.0f), (int)(fPlayerPosY + 0.9f)) != '.'))
                {
                    if (fPlayerVelX != 0)
                        fNewPlayerPosX = (int)fNewPlayerPosX + 1;
                    fPlayerVelX = 0;
                }
            }
            else//right
            {
                if ((map.GetTile((int)(fNewPlayerPosX + 1.0f), (int)(fPlayerPosY + 0.0f)) != '.') || (map.GetTile((int)(fNewPlayerPosX + 1.0f), (int)(fPlayerPosY + 0.9f)) != '.'))
                {
                    if (fPlayerVelX != 0)
                        fNewPlayerPosX = (int)fNewPlayerPosX;

                    fPlayerVelX = 0;
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
                }
                if ((map.GetTile((int)(fNewPlayerPosX + 0.0f), (int)(fNewPlayerPosY + 1.0f)) != '.') || (map.GetTile((int)(fNewPlayerPosX + 0.9f), (int)(fNewPlayerPosY + 1f)) != '.'))
                {

                    fNewPlayerPosY = (int)fNewPlayerPosY;
                    fPlayerVelY = 0;


                    if (!bPlayerOnGround)
                        Frame(0);

                    bPlayerOnGround = true;
                }
           
            }

            fPlayerPosX = fNewPlayerPosX;
            fPlayerPosY = fNewPlayerPosY;

            mainSprite.Display(map.g);

           
        }

        public static void CheckPicks(Map map, float fNewPlayerPosX, float fNewPlayerPosY, char c, char c2)
        {
            // Check for pickups!
            if (map.GetTile(fNewPlayerPosX + 0.0f, fNewPlayerPosY + 0.0f) == c)
                map.SetTile(fNewPlayerPosX + 0.0f, fNewPlayerPosY + 0.0f, c2);

            if (map.GetTile(fNewPlayerPosX + 0.0f, fNewPlayerPosY + 1.0f) == c)
                map.SetTile(fNewPlayerPosX + 0.0f, fNewPlayerPosY + 1.0f, c2);

            if (map.GetTile(fNewPlayerPosX + 1.0f, fNewPlayerPosY + 0.0f) == c)
                map.SetTile(fNewPlayerPosX + 1.0f, fNewPlayerPosY + 0.0f, c2);

            if (map.GetTile(fNewPlayerPosX + 1.0f, fNewPlayerPosY + 1.0f) == c)
                map.SetTile(fNewPlayerPosX + 1.0f, fNewPlayerPosY + 1.0f, c2);
        }

        public void GoDown()
        {
            if (this.bPlayerOnGround)
            {
                fPlayerPosY += 1;
            }
        }

    
      


    }
}
