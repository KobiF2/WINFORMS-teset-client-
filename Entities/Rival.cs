using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WINFORMS_teset.Entites;
using System.Drawing;
using System.Security.Policy;
using WINFORMS_teset.Controllers;
using System.IO;
using System.Threading;
using SharpDX.XAudio2;
using MonoGame.Extended.Sprites;

namespace WINFORMS_teset.Entities
{
    public class Rival
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
        public Rival(int posX, int posY, int idleFrames, int runFrames, int attackFrames, int deathFrames, Image spriteSheet)
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
            else currentFrame = 0;

           g.DrawImage(spriteSheet, new Rectangle(new Point(posX, posY), new Size(size, size)), 64 * currentFrame, 64 * currentAnimation, size, size, GraphicsUnit.Pixel);

        }


    }
}   
