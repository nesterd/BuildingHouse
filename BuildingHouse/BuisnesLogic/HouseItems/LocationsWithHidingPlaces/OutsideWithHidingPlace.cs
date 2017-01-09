﻿using BuisnesLogic.HouseItems.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnesLogic.HouseItems.LocationsWithHidingPlaces
{
    public class OutsideWithHidingPlace
        : Outside, IHidingPlace
    {
        public OutsideWithHidingPlace(string name, bool hot, string hidingPlace)
            : base(name, hot)
        {
            HidingPlace = hidingPlace;
        }

        public string HidingPlace { get; private set; }
    }
}
