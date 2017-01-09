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
using BuisnesLogic.HouseItems.LocationsWithHidingPlaces;
using BuisnesLogic.HouseItems.Interfaces;

namespace BuildingHouse
{
    public partial class MainForm : Form
    {
        Location currentLocation;

        RoomWithDoor livingRoom;
        RoomWithDoor kitchen;
        Room diningRoom;
        Room secondFloorStairs;
        RoomWithHidingPlace secondFloorHall;
        RoomWithHidingPlace mainBedroom;
        RoomWithHidingPlace secondBedroom;
        RoomWithHidingPlace bathroom;

        OutsideWithDoor backYard;
        OutsideWithDoor frontYard;
        OutsideWithHidingPlace driveway;
        OutsideWithHidingPlace garden;

        public MainForm()
        {
            InitializeComponent();
            CreateObjects();
            currentLocation = livingRoom;
            MoveToANewLocation(livingRoom);
            
        }

        private void CreateObjects()
        {
            livingRoom = new RoomWithDoor("Гостинная", "Старинный ковер", "Чулан", "Дубовая дверь с латунной ручкой");
            kitchen = new RoomWithDoor("Кухня", "Плита из нержавеющей стали", "Шкаф", "Сетчатая дверь");
            diningRoom = new Room("Столовая", "Хрустальная люстра");
            secondFloorStairs = new Room("Лестница на второй этаж", "Деревянные перила");
            secondFloorHall = new RoomWithHidingPlace("корридор", "Картина с собакой", "шкаф");
            mainBedroom = new RoomWithHidingPlace("Главная спальня", "Большая кровать", "Под кроватью");
            secondBedroom = new RoomWithHidingPlace("Вторая спальня", "Небольшая кровать", "Под кроватью");
            bathroom = new RoomWithHidingPlace("Ванная комната", "Раковина и туалет", "В душе");

            backYard = new OutsideWithDoor("Задний двор", true, "Сетчатая дверь");
            frontYard = new OutsideWithDoor("Лужайка", false, "Дубовая дверь с латунной ручкой");
            driveway = new OutsideWithHidingPlace("Проезд", false, "Гараж");
            garden = new OutsideWithHidingPlace("Сад", false, "Сарай");

            livingRoom.exits = new Location[] { diningRoom, secondFloorStairs };
            secondFloorStairs.exits = new Location[] { livingRoom, secondFloorHall };
            secondFloorHall.exits = new Location[] { mainBedroom, secondBedroom, bathroom, secondFloorStairs };
            mainBedroom.exits = new Location[] { secondFloorHall };
            secondBedroom.exits = new Location[] { secondFloorHall };
            bathroom.exits = new Location[] { secondFloorHall };
            kitchen.exits = new Location[] { diningRoom};
            diningRoom.exits = new Location[] { livingRoom, kitchen };

            backYard.exits = new Location[] { frontYard, garden, driveway };
            frontYard.exits = new Location[] { backYard, garden, driveway };
            driveway.exits = new Location[] { frontYard, backYard };
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
