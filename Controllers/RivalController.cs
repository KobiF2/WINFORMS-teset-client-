using WINFORMS_teset.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using WINFORMS_teset.Models;
using System.Windows.Forms;
using WINFORMS_teset.Entites;

namespace WINFORMS_teset.Controllers
{
    public  class RivalController
    {
        public const int rHeight = 0;
        public const int rWidth = 0;
        public static int rSize = 36;
        public static int[,] rMap = new int[rHeight, rWidth];
        public static Image RivalspriteSheet;
        public static List<Rival> rivals = new List<Rival>();

        //public static Image enemy1Sheet;
        public static void Init()
        {
            rMap = GetRival();
            //RivalspriteSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\3.png"));


        }

        public static int[,] GetRival()
        {
            return new int[,]
            {
             //   {1}
            };

        }




        public static void DrawRival(Graphics g)
        {
            for (int i = 0; i < rWidth; i++)
            {
                for (int j = 0; j < rHeight; j++)
                {

                    if (rMap[i, j] == 1)
                    {
                        g.DrawImage(RivalspriteSheet, new Rectangle(new Point(j * rSize, i * rSize), new Size(rSize, rSize)), 96, 110, 160, 160, GraphicsUnit.Pixel);

                    }
                    else
                     if (rMap[i, j] == 3)
                    {

                        g.DrawImage(RivalspriteSheet, new Rectangle(new Point(j * rSize, i * rSize), new Size(rSize, rSize)), 90, 110, 20, 20, GraphicsUnit.Pixel);
                    }
                    else break;
                }
            }


        }


    }
}