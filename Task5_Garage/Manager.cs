using System.ComponentModel.Design;
using System.Text.RegularExpressions;
using Task5_Garage.Interfaces;
using Task5_Garage.Models;

namespace Task5_Garage
{
    public class Manager
    {
        private readonly IHandler handler;
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
                        Console.Clear();
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
                        var reg = ui.GetInput("Enter registration number: ");
                        handler.RemoveVehicle(reg);
                        break;
                    case "3":
                        handler.ListParkedVehicles();
                        break;
                    case "4":
                        handler.ListVehicleTypes();
                        break;
                    case "5":
                        //var regFind = ui.GetInput("Enter the registration number: ");
                        var regFind = IsValidRegNr();
                        if (regFind == "0")
                            break;
                        else
                            handler.FindVehicle(regFind);
                        break;
                    case "6":
                        handler.RandomPopulateGarage(capacity);
                        break;
                    case "0":
                        Console.Clear();
                        ui.ShowMessage("Exiting application...");
                        Environment.Exit(0);
                        break;
                }
            }
        }

        private void ParkVehicle(string input)
        {
            string inputVehicle = input;
            while (true)
            {
                if (inputVehicle == "0")
                {
                    ui.ShowMessage("Exited to main menu");
                    return;
                }
                if (new[] { "1", "2", "3", "4", "5" }.Contains(inputVehicle))
                {
                    break;
                    
                }
                inputVehicle = ui.GetInput("Invalid vehicle selected, please try again: ");
            }
                var registrationNumber = IsValidRegNr();
            if (registrationNumber == "0")
            {
                ui.ShowMessage("Exited to main menu");
                return;
            }
            var color = ui.GetInput("Color: ");
            var wheels = ui.GetIntInput("Number of wheels: ");
            bool parked = false;
            switch (inputVehicle)
            {
                case "1":
                    var wingspan = ui.GetInput("Wingspan: ");
                    var airplane = new Airplane(registrationNumber, color, wheels, wingspan);
                    parked = handler.ParkVehicle(airplane);
                    break;
                case "2":
                    var length = ui.GetInput("Length: ");
                    var boat = new Boat(registrationNumber, color, wheels, length);
                    parked = handler.ParkVehicle(boat);
                    break;
                case "3":
                    var numberOfSeats = ui.GetInput("Number of seats: ");
                    var buss = new Buss(registrationNumber, color, wheels, numberOfSeats);
                    parked = handler.ParkVehicle(buss);
                    break;
                case "4":
                    var fuelType = ui.GetInput("Fuel Type: ");
                    var car = new Car(registrationNumber, color, wheels, fuelType);
                    parked = handler.ParkVehicle(car);
                    break;
                case "5":
                    var cylinderVolume = ui.GetInput("Cylinder volume: ");
                    var motorcycle = new Motorcycle(registrationNumber, color, wheels, cylinderVolume);
                    parked = handler.ParkVehicle(motorcycle);
                    break;
            }
            if(parked == true)
            {
                ui.ShowMessage($"Vehicle successfully parked.");
            }
            
        }

        private string IsValidRegNr()
        {
            string registrationNumber;
            ui.ShowMessage("Enter 0 to exit to main menu");
            while (true)
            {
                registrationNumber = ui.GetInput("Enter registration number: ");
                if (registrationNumber == "0")
                    break;
                else if (!System.Text.RegularExpressions.Regex.IsMatch(registrationNumber, @"^[A-Za-z]{3}[0-9]{3}$"))
                {
                    ui.ShowMessage($"{registrationNumber} is not valid, please enter on the format abc123 (None case sensitive).");
                }
                else
                {
                    ui.ShowMessage($"Successfully entered registration number: {registrationNumber}");
                    break;
                }

            }
            return registrationNumber.ToUpper();
        }
    }
}

