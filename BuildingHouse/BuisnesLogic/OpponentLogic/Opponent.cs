using BuisnesLogic.HouseItems.Base;
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

        public Opponent(Location startPosition)
        {
            myLocation = startPosition;
            random = new Random();
            
        }
    }
}
