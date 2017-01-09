using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnesLogic.HouseItems
{
    public class Outside
        : Base.Location
    {
        bool hot;

        public Outside(string name, bool hot)
            : base(name)
        {
            this.hot = hot;
        }

        public override string Description
        {
            get
            {
                string description = base.Description;
                if (hot)
                    description += "Тут очень жарко!";
                return description;
                //return base.Description +(hot ? "Здесь жарко!":"Здесь прохладно.");
            }
        }
    }
}
