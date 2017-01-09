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
using BuisnesLogic.HouseItems.Interfaces;

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
            currentLocation = livingRoom;
            MoveToANewLocation(livingRoom);
            
        }

        private void CreateObjects()
        {
            livingRoom = new RoomWithDoor("Гостинная", "Старинный ковер", "Дубовая дверь с латунной ручкой");
            kitchen = new RoomWithDoor("Кухня", "Плита из нержавеющей стали", "Сетчатая дверь");
            diningRoom = new Room("Столовая", "Хрустальная люстра");
            backYard = new OutsideWithDoor("Задний двор", true, "Сетчатая дверь");
            frontYard = new OutsideWithDoor("Лужайка", false, "Дубовая дверь с латунной ручкой");
            garden = new Outside("Сад", false);

            livingRoom.exits = new Location[] { diningRoom };
            kitchen.exits = new Location[] { diningRoom};
            diningRoom.exits = new Location[] { livingRoom, kitchen };
            backYard.exits = new Location[] { frontYard, garden };
            frontYard.exits = new Location[] { backYard, garden };
            garden.exits = new Location[] { frontYard, backYard };

            livingRoom.DoorLocation = frontYard;
            frontYard.DoorLocation = livingRoom;

            kitchen.DoorLocation = backYard;
            backYard.DoorLocation = kitchen;
        }

        void MoveToANewLocation(Location newLocation)
        {
            currentLocation = newLocation;
            description.Text = currentLocation.Description;
            //exits.Items.Clear();
            exits.DataSource = currentLocation.exits.Select(x => x.Name).ToArray();
            //exits.Items.AddRange(currentLocation.exits/*.Select(x => x.Name).ToArray()*/);
            exits.SelectedIndex = 0;
            if (currentLocation is IHasExteriorDoor)
                goThroughTheDoor.Visible = true;
            else
                goThroughTheDoor.Visible = false;
        }

        private void goHere_Click(object sender, EventArgs e)
        {
            //currentLocation = currentLocation.exits.FirstOrDefault(x => x.Name == exits.SelectedItem);
            //currentLocation = exits.SelectedItem as Location;
            MoveToANewLocation(currentLocation.exits.FirstOrDefault(x => x.Name == exits.SelectedItem));
        }

        private void goThroughTheDoor_Click(object sender, EventArgs e)
        {
            //currentLocation = (currentLocation as IHasExteriorDoor).DoorLocation;
            IHasExteriorDoor hasDoor = currentLocation as IHasExteriorDoor;
            //currentLocation = currentLocation.exits.FirstOrDefault(x => x is OutsideWithDoor);
            MoveToANewLocation(hasDoor.DoorLocation);
        }
    }
}
