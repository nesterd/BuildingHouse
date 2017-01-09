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
        public Location[] exits;

        public Location (string name)
        {
            Name = name;
        }

        public virtual string Description
        {
            get
            {
                string description = $"Вы находитесь в {Name}. Вы видите двери ведущие в: ";
                foreach (var exit in exits)
                {
                    description += $" {exit.Name},";
                }
                description.TrimEnd(',');
                description += ".";
                return description;
            }
        }


    }
}
