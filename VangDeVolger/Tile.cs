using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VangDeVolger
{
    public class Tile
    {
        public int tileSize = 55;

        /*
        public Vector2 TilePosition = Vector2.Zero;
        public Texture2D tile;
        */

        public GameObject Contains;
        public Player ContainsPlayer;
        public Enemy ContainsEnemy;

        public Tile _topNeighbour;
        public Tile _rightNeighbour;
        public Tile _bottomNeighbour;
        public Tile _leftNeighbour;

        public Tile()
        {

        }

        public void SetNeighbours(string direction, ref Tile neighbour)
        {
            if (direction.Equals("top"))
            {
                _topNeighbour = neighbour;
            }
            else if (direction.Equals("right"))
            {
                _rightNeighbour = neighbour;
            }
            else if (direction.Equals("bottom"))
            {
                _bottomNeighbour = neighbour;
            }
            else if (direction.Equals("left"))
            {
                _leftNeighbour = neighbour;
            }
        }
    }
}
