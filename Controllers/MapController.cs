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

namespace WINFORMS_teset.Controllers
{
    public static class Map
    {

        // Constants declaration
        public const int mapHeight = 15;
        public const int mapWidth = 15;
        public static int cellSize = 36;

        // Two-dimensional array that will hold the map's data
        public static int[,] map = new int[mapHeight, mapWidth];

        // Sprite sheet image object and list of map objects
        public static Image spriteSheet;
        public static List<MapEntity> mapObjects;


        // Initialisation method
        public static void Init()
        {
            // Loads map data
            map = GetMap();
            spriteSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\map1.png"));
            // Initialise map objects list
            mapObjects = new List<MapEntity>();
        }

        // Method returns the map data in the form of a two-dimensional array
        public static int[,] GetMap()
        {
            return new int[,]
            {
                { 1,6,6,6,6,6,6,6,6,6,6,6,6,6,2},
                { 5,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                { 5,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                { 5,0,0,0,0,0,0,0,0,0,0,11,0,0,7},
                { 5,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                { 5,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                { 5,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                { 5,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                { 5,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                { 5,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                { 5,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                { 5,0,0,12,0,0,0,0,0,0,0,0,0,0,7},
                { 5,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                { 5,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                { 3,8,8,8,8,8,8,8,8,8,8,8,8,8,4},
            };
        }

        // Method that populates the mapObjects list and draws objects to the form
        public static void MapItem(Graphics g)
        {
            for (int i = 0; i < mapWidth; i++)
            {
                for (int j = 0; j < mapHeight; j++)
                {
                    // Draws objects to the form if the corresponding value is present in the map data array
                    if (map[i, j] == 10)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize * 3, cellSize * 3)), 202, 298, 107, 114, GraphicsUnit.Pixel);
                        MapEntity mapEntity = new MapEntity(new Point(j * cellSize, i * cellSize), new Size(cellSize * 3, cellSize * 3));
                        mapObjects.Add(mapEntity);
                    }
                    if (map[i, j] == 11)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(20, 12)), 581, 114, 19, 11, GraphicsUnit.Pixel);
                        MapEntity mapEntity = new MapEntity(new Point(j * cellSize, i * cellSize), new Size(20, 12));
                        mapObjects.Add(mapEntity);
                    }
                    if (map[i, j] == 12)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(20, 18)), 453, 225, 18, 22, GraphicsUnit.Pixel);
                        MapEntity mapEntity = new MapEntity(new Point(j * cellSize, i * cellSize), new Size(20, 18));
                        mapObjects.Add(mapEntity);
                    }
                }
            }
        }

        // This method draws objects onto to map
        public static void DrawMap(Graphics g)
        {
            // Nested for loop to iterate over each cell in the map
            for (int i = 0; i < mapWidth; i++)
            {
                for (int j = 0; j < mapHeight; j++)
                {
                    // Check the value of the current cell in the map array
                    // and draw corresponding rectangular area of the map image 
                    if (map[i, j] == 1)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 96, 0, 20, 20, GraphicsUnit.Pixel);

                    }
                    else
                    if (map[i, j] == 2)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 170, 0, 20, 20, GraphicsUnit.Pixel);
                    }
                    else
                    if (map[i, j] == 3)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 96, 75, 20, 20, GraphicsUnit.Pixel);
                    }
                    else
                    if (map[i, j] == 4)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 170, 75, 20, 20, GraphicsUnit.Pixel);
                    }
                    else
                    if (map[i, j] == 5)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 96, 20, 20, 20, GraphicsUnit.Pixel);
                    }
                    else
                    if (map[i, j] == 6)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 120, 0, 20, 20, GraphicsUnit.Pixel);
                    }
                    else
                    if (map[i, j] == 7)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 170, 30, 20, 20, GraphicsUnit.Pixel);
                    }
                    else
                    if (map[i, j] == 8)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 120, 75, 20, 20, GraphicsUnit.Pixel);
                    }
                    else
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 0, 0, 20, 20, GraphicsUnit.Pixel);
                    }
                }
            }


            // Call the MapItem method from the Map class to draw the seed location on the map
            Map.MapItem(g);
        }

        // This method returns the total width of the map in pixels
        public static int GetWidth()
        {
            return cellSize * (mapWidth) + 15;
        }
        // This method returns the total height of the map in pixels
        public static int GetHeight()
        {
            return cellSize * (mapHeight + 1);
        }


    }
}