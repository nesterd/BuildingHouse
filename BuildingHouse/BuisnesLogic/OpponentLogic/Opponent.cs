using BuisnesLogic.HouseItems.Base;
using BuisnesLogic.HouseItems.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnesLogic.OpponentLogic
{
    public class Opponent
    {
        Location myLocation;
        Random random;
        bool hide = false;
        int numberOfTurns;

        public Opponent(Location startPosition, int numberOfTurns)
        {
            myLocation = startPosition;
            random = new Random();
            this.numberOfTurns = numberOfTurns;
        }

        private void Move()
        {
            
            if(myLocation is IHasExteriorDoor && random.Next(2) == 1)
            {
                    IHasExteriorDoor hasDoor = myLocation as IHasExteriorDoor;
                    myLocation = hasDoor.DoorLocation;
                    return;
            }

            Location[] exits = myLocation.exits;
            int index = random.Next(exits.Length);
            myLocation = exits[index];
        }

        private void NextAction()
        {
            if (myLocation is IHidingPlace && random.Next(2) == 1)
            {
                hide = true;
                return;
            }
            Move();
        }

        public Location Hiding()
        {
            while(!hide)
            {
                NextAction();
            }
            return myLocation;
        }
    }
}
