using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuisnesLogic.HouseItems.Base;
using BuisnesLogic.HouseItems.LocationsWithHidingPlaces;

namespace BuisnesLogic.HouseItems
{
    public class RoomWithDoor
        : RoomWithHidingPlace, Interfaces.IHasExteriorDoor
    {
        public RoomWithDoor(string name, string decoration, string hidingPlace, string doorDescription)
            : base(name, decoration, hidingPlace)
        {
            DoorDescription = doorDescription;
        }

        //string doorDescription;

        //public RoomWithDoor(string name, string decoration, string doorDescription) : base(name, decoration)
        //{
        //    DoorDescription = doorDescription;
        //}

        public string DoorDescription { get; private set; }

        public Location DoorLocation { get; set; }
        
    }
}
