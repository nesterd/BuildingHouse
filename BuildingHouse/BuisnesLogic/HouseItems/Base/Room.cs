using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnesLogic.HouseItems
{
    public class Room
        : Base.Location
    {
        string decoration;

        public Room(string name, string decoration)
            : base(name)
        {
            this.decoration = decoration;
        }

        public override string Description
        {
            get
            {
                return base.Description + $"В этой комнате вы видите {decoration}." ;
            }
        }
    }
}
