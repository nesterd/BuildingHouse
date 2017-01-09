using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuisnesLogic.HouseItems.Base;

namespace BuisnesLogic.HouseItems
{
    public class RoomWithDoor
        : Room, Interfaces.IHasExteriorDoor
    {
        string doorDescription;

        public RoomWithDoor(string name, string decoration, string doorDescription) : base(name, decoration)
        {
            this.doorDescription = doorDescription;
        }

        public string DoorDescription
        {
            get
            {
                return doorDescription;
            }
        }

        public Location DoorLocation
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
