using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VangDeVolger
{
    public class Player
    {
        public Tile CurrentTile { get; set; }

        /// <summary>
        /// constructor voor player class
        /// </summary>
        /// <param name="currentTile"></param>
        public Player(ref Tile currentTile)
        {
            CurrentTile = currentTile;
        }

        /// <summary>
        /// Used to move the player
        /// </summary>
        /// <param name="direction"></param>
        public void Move(string direction)
        {
            if (direction.Equals("top"))
            {
                //set the new tiles to player
                CurrentTile._topNeighbour.ContainsPlayer = this;
                //old tiles player container null
                CurrentTile.ContainsPlayer = null;
                //set old tile container to the new tiles container
                CurrentTile.Contains = CurrentTile._topNeighbour.Contains;
                // set new tile container to null beacause player is in another container
                CurrentTile._topNeighbour.Contains = null;
                //edits currentTile from player object to new tile
                CurrentTile = CurrentTile._topNeighbour;
            }

            if (direction.Equals("right"))
            {
                CurrentTile._rightNeighbour.ContainsPlayer = this;
                CurrentTile.ContainsPlayer = null;
                CurrentTile.Contains = CurrentTile._rightNeighbour.Contains;
                CurrentTile._rightNeighbour.Contains = null;
                CurrentTile = CurrentTile._rightNeighbour;
            }
            if (direction.Equals("bottom"))
            {

                CurrentTile._bottomNeighbour.ContainsPlayer = this;
                CurrentTile.ContainsPlayer = null;
                CurrentTile.Contains = CurrentTile._bottomNeighbour.Contains;
                CurrentTile._bottomNeighbour.Contains = null;
                CurrentTile = CurrentTile._bottomNeighbour;
            }
            if (direction.Equals("left"))
            {
                CurrentTile._leftNeighbour.ContainsPlayer = this;
                CurrentTile.ContainsPlayer = null;
                CurrentTile.Contains = CurrentTile._leftNeighbour.Contains;
                CurrentTile._leftNeighbour.Contains = null;
                CurrentTile = CurrentTile._leftNeighbour;
            }
        }

        /// <summary>
        /// used to move a box
        /// </summary>
        /// <param name="direction"></param>
        public void Push(string direction)
        {
            if (direction.Equals("top"))
            {
                if (CurrentTile._topNeighbour.Contains.pushBox(direction))
                {
                    Move(direction);
                }
            }

            if (direction.Equals("right"))
            {
                if (CurrentTile._rightNeighbour.Contains.pushBox(direction))
                {
                    Move(direction);
                }
            }
            if (direction.Equals("bottom"))
            {
                if (CurrentTile._bottomNeighbour.Contains.pushBox(direction))
                {
                    Move(direction);
                }
            }
            if (direction.Equals("left"))
            {
                if (CurrentTile._leftNeighbour.Contains.pushBox(direction))
                {
                    Move(direction);
                }
            }
        }

        /// <summary>
        /// used to check neighbours
        /// </summary>
        /// <param name="direction"></param>
        public void CheckNeighbours(string direction)
        {
            //vraag tile in direction van current tile
            if (direction.Equals("top"))
            {
                if (CurrentTile._topNeighbour != null)
                {
                    if (CurrentTile._topNeighbour.Contains.IsTile)
                    {
                        Move(direction);
                    }
                    else if (CurrentTile._topNeighbour.Contains.IsBox)
                    {
                        Push(direction);
                    }
                }
            }

            if (direction.Equals("right"))
            {
                if (CurrentTile._rightNeighbour != null)
                {
                    if (CurrentTile._rightNeighbour.Contains.IsTile)
                    {
                        Move(direction);
                    }
                    else if (CurrentTile._rightNeighbour.Contains.IsBox)
                    {
                        Push(direction);
                    }
                }
            }

            if (direction.Equals("bottom"))
            {
                if (CurrentTile._bottomNeighbour != null)
                {
                    if (CurrentTile._bottomNeighbour.Contains.IsTile)
                    {
                        Move(direction);
                    }
                    else if (CurrentTile._bottomNeighbour.Contains.IsBox)
                    {
                        Push(direction);
                    }
                }
            }

            if (direction.Equals("left"))
            {
                if (CurrentTile._leftNeighbour != null)
                {
                    if (CurrentTile._leftNeighbour.Contains.IsTile)
                    {
                        Move(direction);
                    }
                    else if (CurrentTile._leftNeighbour.Contains.IsBox)
                    {
                        Push(direction);
                    }
                }
            }
        }
    }

}
