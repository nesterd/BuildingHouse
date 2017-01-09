using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnesLogic.HouseItems.LocationsWithHidingPlaces
{
    public class RoomWithHidingPlace
        : Room, Interfaces.IHidingPlace
    {
        public RoomWithHidingPlace(string name, string decoration, string hidingPlace)
            : base(name, decoration)
        {
            HidingPlace = hidingPlace;
        }

        public string HidingPlace { get; private set; }
    }
}
