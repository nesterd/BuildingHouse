using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BuisnesLogic.HouseItems;
using BuisnesLogic.HouseItems.Base;

namespace BuildingHouse
{
    public partial class MainForm : Form
    {
        Location currentLocation;

        RoomWithDoor livingRoom;
        RoomWithDoor kitchen;
        Room diningRoom;
        OutsideWithDoor backYard;
        OutsideWithDoor frontYard;
        Outside garden;
        public MainForm()
        {
            InitializeComponent();
            CreateObjects();
            currentLocation = frontYard;
            exits.Items.AddRange(currentLocation.exits);
        }

        private void CreateObjects()
        {
            livingRoom = new RoomWithDoor("Гостинная", "Старинный ковер", "Дубовая дверь с латунной ручкой");
            kitchen = new RoomWithDoor("Кухня", "Плита из нержавеющей стали", "Сетчатая дверь");
            diningRoom = new Room("Столовая", "Хрустальная люстра");
            backYard = new OutsideWithDoor("Задний двор", true, "Сетчатая дверь");
            frontYard = new OutsideWithDoor("Лужайка", false, "Дубовая дверь с латунной ручкой");
            garden = new Outside("Сад", false);

            livingRoom.exits = new Location[] { frontYard, diningRoom };
            kitchen.exits = new Location[] { diningRoom, backYard };
            diningRoom.exits = new Location[] { livingRoom, kitchen };
            backYard.exits = new Location[] { kitchen, garden };
            frontYard.exits = new Location[] { livingRoom, garden };
            garden.exits = new Location[] { frontYard, backYard };
        }
    }
}
