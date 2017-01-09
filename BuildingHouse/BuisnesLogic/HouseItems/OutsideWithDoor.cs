using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuisnesLogic.HouseItems.Base;

namespace BuisnesLogic.HouseItems
{
    public class OutsideWithDoor
        : Outside, Interfaces.IHasExteriorDoor
    {
        string doorDescription;
        public OutsideWithDoor(string name, bool hot, string doorDescription) : base(name, hot)
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
