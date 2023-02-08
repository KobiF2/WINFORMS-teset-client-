using SharpDX.XAudio2;
using System;
using System.Drawing;
using System.Windows.Forms;
using WINFORMS_teset.Controllers;
using WINFORMS_teset.Entities;

namespace WINFORMS_teset.Entites
{
    public class Entity
    {
        public int posX;
        public int posY;

        public int dirX;
        public int dirY;
        public bool isMoving;

        public int flip;

        public int currentAnimation;
        public int currentFrame;
        public int currentLimit;

        public int idleFrames;
        public int runFrames;
        public int attackFrames;
        public int deathFrames;

        public int size;

        public Image spriteSheet;
    

        public Entity(int posX, int posY, int idleFrames, int runFrames, int attackFrames, int deathFrames, Image spriteSheet)
        {

            this.posX = posX;
            this.posY = posY;
            this.idleFrames = idleFrames;
            this.runFrames = runFrames;
            this.attackFrames = attackFrames;
            this.deathFrames = deathFrames;
            this.spriteSheet = spriteSheet;
            size = 64;
            currentAnimation = 0;
            currentFrame = 0;
            currentLimit = idleFrames;
            flip = 1;

        }

        public void Move()
        {
            posX += dirX;
            posY += dirY;
        }


        public void PlayAnimation(Graphics g)
        {
            if (currentFrame < currentLimit - 1)
                currentFrame++;
            else  currentFrame = 0;

            g.DrawImage(spriteSheet, new Rectangle(new Point(posX, posY), new Size(size, size)), 64 * currentFrame, 64 * currentAnimation, size, size , GraphicsUnit.Pixel);

        }


     
        public void SetAnimationConfiguration(int currentAnimation)
        {
           
            
            this.currentAnimation = currentAnimation;

            switch (currentAnimation)
            {
                case 0:
                    currentLimit = idleFrames;
                    break;
                // case 1:
                //currentLimit = runFrames;
                // break;
                case 2:
                    currentLimit = idleFrames;
                    break;
                case 8:
                    
                    currentLimit = runFrames;
                    break;
                case 9:
                    currentLimit = runFrames;
                    break;
                case 10:
                    currentLimit = runFrames;
                    break;
                case 11:
                    currentLimit = runFrames;
                    break;
                // case 12:
                // currentLimit = attackFrames;
                // break;
                case 13:
                    //size = 196;
                    currentLimit = attackFrames;
                    break;
                case 14:
                    //size = 196;
                    currentLimit = attackFrames;
                    break;
                case 15:
                   // size = 196;
                    currentLimit = attackFrames;
                    break;
                case 16:
                    currentLimit = attackFrames;
                    break;
            }
        }
    }
}
