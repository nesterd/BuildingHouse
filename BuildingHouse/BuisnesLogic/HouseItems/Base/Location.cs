using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnesLogic.HouseItems.Base
{
    public abstract class Location
    {
        public string Name { get; private set; }
        public string[] Exits { get; set; }
    }
}
