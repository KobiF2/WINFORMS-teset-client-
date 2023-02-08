using WINFORMS_teset.Entites;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WINFORMS_teset.Controllers;
using System.Security.Policy;
using WINFORMS_teset.Entities;
using System.Runtime.CompilerServices;
using WINFORMS_teset.Models;
using MonoGame.Extended;

namespace WINFORMS_teset.Controllers
{
    public class PhysicsController
    {
        
        public Transform transform;


        public PhysicsController()
        {

        }

    
        public static bool IsCollide(Entity entity, Point dir)

        {

            if (entity.posX + dir.X <= 0 || entity.posX + dir.X >= MapController.cellSize * (MapController.mapWidth - 2) || entity.posY + dir.Y <= 0 || entity.posY + dir.Y >= MapController.cellSize * 1.03 * (MapController.mapHeight - 3))
                return true;

            for (int i = 0; i < MapController.mapObjects.Count; i++)
            {
                var currObject = MapController.mapObjects[i];



                PointF delta = new PointF

                {
                    X = (entity.posX + entity.size / 2) - (currObject.position.X + currObject.size.Width / 2),
                    Y = (entity.posY + entity.size / 2) - (currObject.position.Y + currObject.size.Height / 2)
                };

                if (Math.Abs(delta.X) <= entity.size / 2 + currObject.size.Width / 2)
                {

                    if (Math.Abs(delta.Y) <= entity.size / 2 + currObject.size.Height / 2)
                    {
                        if (delta.X < 0 && dir.X == 3 && entity.posY + entity.size / 2 > currObject.position.Y && entity.posY + entity.size / 2 < currObject.position.Y + currObject.size.Height)
                        {
                            return true;
                        }
                        if (delta.X > 0 && dir.X == -3 && entity.posY + entity.size / 2 > currObject.position.Y && entity.posY + entity.size / 2 < currObject.position.Y + currObject.size.Height)
                        {
                            return true;
                        }
                        if (delta.Y < 0 && dir.Y == 3 && entity.posX + entity.size / 2 > currObject.position.X && entity.posX + entity.size / 2 < currObject.position.X + currObject.size.Width)
                        {
                            return true;
                        }
                        if (delta.Y > 0 && dir.Y == -3 && entity.posX + entity.size / 2 > currObject.position.X && entity.posX + entity.size / 2 < currObject.position.X + currObject.size.Width)
                        {
                            return true;
                        }
                    }

                }

            

            }
            return false;

        }


    }
}



    


