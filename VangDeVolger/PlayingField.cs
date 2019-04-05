using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VangDeVolger
{
    public class PlayingField
    {
        public Tile[,] TileGrid;
        public int Width { get; set; }
        public int Height { get; set; }
        private Random _rndInt;
        public Player player;
        public Enemy enemy;

        /// <summary>
        /// constructor for playingfield
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        public PlayingField(int height, int width)
        {
            Width = width;
            Height = height;

            TileGrid = new Tile[height, width];

            CreateTiles(height, width);

            _rndInt = new Random();

            FillTiles(height, width);
        }

        /// <summary>
        /// makes tile array with width and height from constructor and set the neighbours for the tiles
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void CreateTiles(int width, int height)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    TileGrid[i, j] = new Tile();
                }
            }

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (j - 1 >= 0)
                    {
                        TileGrid[i, j].SetNeighbours("top", ref TileGrid[i, j - 1]);
                    }
                    if (i + 1 < width)
                    {
                        TileGrid[i, j].SetNeighbours("right", ref TileGrid[i + 1 , j]);
                    }
                    if (j + 1 < height)
                    {
                        TileGrid[i, j].SetNeighbours("bottom", ref TileGrid[i , j + 1 ]);
                    }
                    if (i - 1 >= 0)
                    {
                        TileGrid[i, j].SetNeighbours("left", ref TileGrid[i - 1 , j]);
                    }
                }
            }
        }

        /// <summary>
        /// fills the tiles with objects
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        public void FillTiles(int height, int width)
        { 
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int r = _rndInt.Next(0, 100);

                    if(i == 0 && j == 0)
                    {
                        TileGrid[i, j].ContainsPlayer = (player = new Player(ref TileGrid[i, j]));
                    }
                    else if (i == height -1 && j == width -1)
                    {
                        TileGrid[i, j].ContainsEnemy = (enemy = new Enemy(ref TileGrid[i, j]));
                    }
                    else if (r >= 0 && r <= 5)
                    {
                        TileGrid[i, j].Contains = new GameObject(true, false, false, ref TileGrid[i, j]);
                    }

                    else if(r > 5 && r <= 25)
                    {
                        TileGrid[i, j].Contains = new GameObject(false, true, false, ref TileGrid[i, j]);
                    }

                    else if(r > 25 && r <= 100)
                    {
                        TileGrid[i, j].Contains = new GameObject(false, false, true, ref TileGrid[i, j]);
                    }

                    Debug.WriteLine(r.ToString());
                }
            }
        }

        public void RandomGenerator()
        {
            
        }
    }
}
