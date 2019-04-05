using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VangDeVolger
{
    public class GameObject
    {
        public bool IsWall { get; set; }
        public bool IsBox { get; set; }
        public bool IsTile { get; set; }
        public Tile CurrentTile { get; set; }

        /// <summary>
        /// constructor voor gameobject
        /// </summary>
        /// <param name="isWall"></param>
        /// <param name="isBox"></param>
        /// <param name="isTile"></param>
        /// <param name="tile"></param>
        public GameObject(bool isWall, bool isBox, bool isTile, ref Tile tile)
        {
            IsWall = isWall;
            IsBox = isBox;
            IsTile = isTile;
            CurrentTile = tile;
        }

        /// <summary>
        /// used to push the box and check if another box need to be pushed
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public bool pushBox(string direction)
        {
            //check if the direction is top
            if (direction.Equals("top"))
            {
                //checks if neighbour exists
                if (CurrentTile._topNeighbour != null)
                {
                    //if the neighbour is a tile you can move else if the next tile is a box move that box first
                    if (CurrentTile._topNeighbour.Contains.IsTile)
                    {
                        //current tile becomes new path
                        CurrentTile.Contains = CurrentTile._topNeighbour.Contains;

                        //new tile becomes box
                        CurrentTile._topNeighbour.Contains = this;

                        //changes current tile in box object
                        CurrentTile = CurrentTile._topNeighbour;
                        //return true that you moved
                        return true;
                    }
                    else if (CurrentTile._topNeighbour.Contains.IsBox)
                    {
                        //push next box and check if box is moved
                        if (CurrentTile._topNeighbour.Contains.pushBox(direction))
                        {
                            //return result from the move
                             return pushBox(direction);
                        }
                    }
                }
            }

            if (direction.Equals("right"))
            {
                if (CurrentTile._rightNeighbour != null)
                {
                    if (CurrentTile._rightNeighbour.Contains.IsTile)
                    {
                        //current tile becomes new path
                        CurrentTile.Contains = CurrentTile._rightNeighbour.Contains;

                        //new tile becomes box
                        CurrentTile._rightNeighbour.Contains = this;

                        //changes current tile in box object
                        CurrentTile = CurrentTile._rightNeighbour;
                        return true;
                    }
                    else if (CurrentTile._rightNeighbour.Contains.IsBox)
                    {
                        if (CurrentTile._rightNeighbour.Contains.pushBox(direction))
                        {
                             return pushBox(direction);
                        }
                    }
                }
            }

            if (direction.Equals("bottom"))
            {
                if (CurrentTile._bottomNeighbour != null)
                {
                    if (CurrentTile._bottomNeighbour.Contains.IsTile)
                    {
                        CurrentTile.Contains = CurrentTile._bottomNeighbour.Contains;

                        //new tile becomes box
                        CurrentTile._bottomNeighbour.Contains = this;

                        //changes current tile to the new tile
                        CurrentTile = CurrentTile._bottomNeighbour;
                        return true;
                    }
                    else if (CurrentTile._bottomNeighbour.Contains.IsBox)
                    {
                        if (CurrentTile._bottomNeighbour.Contains.pushBox(direction))
                        {
                            return pushBox(direction);
                        }
                    }
                }
            }


            if (direction.Equals("left"))
            {
                if (CurrentTile._leftNeighbour != null)
                {
                    if (CurrentTile._leftNeighbour.Contains.IsTile)
                    {
                        CurrentTile.Contains = CurrentTile._leftNeighbour.Contains;

                        //new tile becomes box
                        CurrentTile._leftNeighbour.Contains = this;

                        //changes current tile to the new tile
                        CurrentTile = CurrentTile._leftNeighbour;
                        return true;
                    }
                    else if (CurrentTile._leftNeighbour.Contains.IsBox)
                    {
                        if (CurrentTile._leftNeighbour.Contains.pushBox(direction))
                        {
                            return pushBox(direction);
                        }
                    }
                }
            }
            //if you can't move return false
            return false;
        }
    }
}
