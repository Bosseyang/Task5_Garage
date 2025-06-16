using Task5_Garage.Interfaces;
using Task5_Garage.Models;

namespace Task5_Garage
{//TODO: Bryt ut consoleUI och döp om till manager
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
                        ParkVehicle();
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
                        handler.RandomPopulateGarage(capacity);
                        break;
                    case "5":

                        break;
                    case "0":
                        ui.ShowMessage("Exit Application");
                        Environment.Exit(0);
                        break;
                }
            }
        }

        private void ParkVehicle()
        {
            //regNr = ui.GetInput("Registration Number: ");
            var regNr = " ";
            while (true)
            {
                regNr = ui.GetInput("Registration Number: ");
                if (!IsValidRegNr(regNr))
                    ui.ShowMessage($"{regNr} not valid, please enter on the format abc123 (None case sensitive).");
                else
                    break;

            }
            var color = ui.GetInput("Color: ");
            var wheels = ui.GetInput("Number of Wheels: ");
            var fuelType = ui.GetInput("Fuel Type: ");

            var car = new Car(regNr, color, wheels, fuelType);
            handler.ParkVehicle(car);
        }

        private bool IsValidRegNr(string registrationNumber)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(registrationNumber, @"^[A-Za-z]{3}[0-9]{3}$");
        }
    }
}

