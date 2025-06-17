using System.ComponentModel.Design;
using System.Text.RegularExpressions;
using Task5_Garage.Interfaces;
using Task5_Garage.Models;

namespace Task5_Garage
{
    public class Manager
    {
        private readonly IHandler? handler;
        private readonly IUI ui;
        private readonly int capacity;

        public Manager(IHandler handler, IUI ui, int capacity)
        {
            this.handler = handler;
            this.ui = ui;
            this.capacity = capacity;
        }
        public void Run()
        {
            while (true)
            {
                ui.ShowMenu();
                //TODO: Add more as the application grows.

                var inputChoice = Console.ReadLine();
                switch (inputChoice)
                {
                    case "1":
                        if (handler.CheckIfFull())
                            break;
                        while (true)
                        {
                            ui.ShowVehicleMenu();
                            var inputVehicle = ui.GetInput("");
                            if (inputVehicle == "0")
                                break;
                            ParkVehicle(inputVehicle);
                            break;
                        }
                        break;
                    case "2":
                        ui.ShowMessage("Enter registration number please");
                        var reg = Console.ReadLine();
                        handler.RemoveVehicle(reg);
                        break;
                    case "3":
                        handler.ListParkedVehicles();
                        break;
                    case "4":
                        handler.ListVehicleTypes();
                        break;
                    case "5":
                        handler.RandomPopulateGarage(capacity);
                        break;
                    case "0":
                        ui.ShowMessage("Exit Application");
                        Environment.Exit(0);
                        break;
                }
            }
        }

        private void ParkVehicle(string inputVehicle)
        {
            var registrationNumber = IsValidRegNr();
            if (registrationNumber == "0")
            {
                ui.ShowMessage("No registration number entered, vehicle not parked");
                return;
            }
            var color = ui.GetInput("Color: ");
            var wheels = ui.GetInput("Number of Wheels: ");
            switch (inputVehicle)
            {
                case "1":
                    var wingspan = ui.GetInput("Wingspan: ");
                    var airplane = new Airplane(registrationNumber, color, wheels, wingspan);
                    handler.ParkVehicle(airplane);
                    break;
                case "2":
                    var length = ui.GetInput("Length: ");
                    var boat = new Boat(registrationNumber, color, wheels, length);
                    handler.ParkVehicle(boat);
                    break;
                case "3":
                    var numberOfSeats = ui.GetInput("Number of seats: ");
                    var buss = new Buss(registrationNumber, color, wheels, numberOfSeats);
                    handler.ParkVehicle(buss);
                    break;
                case "4":
                    var fuelType = ui.GetInput("Fuel Type: ");
                    var car = new Car(registrationNumber, color, wheels, fuelType);
                    handler.ParkVehicle(car);
                    break;
                case "5":
                    var cylinderVolume = ui.GetInput("Cylinder volume: ");
                    var motorcycle = new Motorcycle(registrationNumber, color, wheels, cylinderVolume);
                    handler.ParkVehicle(motorcycle);
                    break;
            }            
        }

        private string IsValidRegNr()
        {
            string registrationNumber;
            ui.ShowMessage("Enter 0 to exit to main menu");
            while (true)
            {
                registrationNumber = ui.GetInput("Registration Number: ");
                if (registrationNumber == "0")
                    break;
                else if (!System.Text.RegularExpressions.Regex.IsMatch(registrationNumber, @"^[A-Za-z]{3}[0-9]{3}$"))
                    ui.ShowMessage($"{registrationNumber} is not valid, please enter on the format abc123 (None case sensitive).");
                else
                    break;

            }
            return registrationNumber.ToUpper();
        }
    }
}

