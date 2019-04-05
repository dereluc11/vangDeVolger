using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VangDeVolger
{
    public class Enemy
    {
        public Tile CurrentTile { get; set; }

        public Enemy(ref Tile currentTile)
        {
            CurrentTile = currentTile;
        }
    }
}
