﻿using Task5_Garage.Interfaces;
using Task5_Garage.Models;

namespace Task5_Garage
{
    public class GarageHandler(int capacity) : IHandler
    {
        private Garage<IVehicle> garage = new Garage<IVehicle>(capacity);
        private UI ui = new UI();
        public int Spot { get; private set; }

        public bool CheckIfFull()
        {
            if (garage.CheckIfFull())
            {
                ui.ShowMessage("Garage is full, can not park any more vehicles");
                return true;
            }
            return false;
        }
        public bool CheckIfEmpty()
        {
            if (garage.CheckIfEmpty())
            {
                ui.ShowMessage("Garage is empty.");
                return true;
            }
            return false;
        }
        public bool ParkVehicle(IVehicle vehicle)
        {
            bool parked = false;
            Spot = garage.ParkVehicle(vehicle);
            if (Spot == 0)
                Console.WriteLine("Failed to park vehicle, garage is full!");
            else if (Spot == -1)
                Console.WriteLine("Failed to park vehicle. " +
                    "Vehicle with same registration number is already parked.");
            else
                parked = true;
            return parked;
        }
        public void ListParkedVehicles()
        {
            foreach (var v in garage)
                ui.ShowMessage(v.GetVehicleInfo());
        }
        public void ListVehicleTypes()
        {
            var vehicleGroup = garage.GroupBy(v => v.GetType().Name);
            foreach (var vehicleType in vehicleGroup)
            {
                ui.ShowMessage($"{vehicleType.Key}: {vehicleType.Count()}");
            }
        }

        //public IVehicle FindVehicle(string registrationNumber) => garage.Find(registrationNumber);
        public void FindVehicle(string registrationNumber)
        {
            var vehicle = garage.Find(registrationNumber);
            if (vehicle != default)
            {
                ui.ShowMessage($"Found: {vehicle.GetVehicleInfo()}");
            }
            else
                ui.ShowMessage($"No parked vehicle found with the given registration number: {registrationNumber}");
        }

        public bool RemoveVehicle(string regNr)
        {
            if (garage.RemoveVehicle(regNr) == "Removed")
            {
                Console.WriteLine($"Vehicle with registration number: {regNr} successfully removed.");
                return true;
            }
            else if (garage.RemoveVehicle(regNr) == "Empty")
            {
                Console.WriteLine($"Garage is empty");
                return false;
            }
            else
            {
                Console.WriteLine($"Vehicle with registration number: {regNr} not found.");
                return false;
            }
        }
        public void RandomPopulateGarage(int capacity)
        {
            var random = new Random();
            var colors = new[] { "Red   ", "Orange", "Yellow", "Green ", "Blue  ", "Black ", "White ", "Gray  " };
            var numberWheels = new[] { 2, 3, 4, 6, 8 };
            var fuelTypes = new[] { "Diesel", "Gasoline", "Ethanol", "Electric" };
            int count = 0;
            for (int i = 0; i < capacity; i++)
            {
                if (CheckIfFull())
                    break;
                count++;
                string regNr = RandomRegNr(random);
                string color = colors[random.Next(colors.Length)];
                int wheels = numberWheels[random.Next(numberWheels.Length)];
                //Might have to fix potential Null here
                string randomVehicleType = random.Next(1, 5).ToString()!;

                switch (randomVehicleType)
                {
                    case "1":
                        string wingspan = random.Next(10, 40).ToString();
                        IVehicle airplane = new Airplane(regNr, color, wheels, wingspan);
                        ParkVehicle(airplane);
                        break;
                    case "2":
                        string length = random.Next(5, 40).ToString();
                        IVehicle boat = new Boat(regNr, color, wheels, length);
                        ParkVehicle(boat);
                        break;
                    case "3":
                        string numberOfSeat = random.Next(8, 80).ToString();
                        IVehicle buss = new Bus(regNr, color, wheels, numberOfSeat);
                        ParkVehicle(buss);
                        break;
                    case "4":
                        string fuelType = fuelTypes[random.Next(fuelTypes.Length)];
                        IVehicle car = new Car(regNr, color, wheels, fuelType);
                        ParkVehicle(car);
                        break;
                    case "5":
                        string cylinderVolume = random.Next(50, 1500).ToString();
                        IVehicle motorcycle = new Motorcycle(regNr, color, wheels, cylinderVolume);
                        ParkVehicle(motorcycle);
                        break;
                }
            }
            Console.Clear();
            if (count == 1)
                ui.ShowMessage($"{count} vehicle successfully parked.");
            else
                ui.ShowMessage($"{count} vehicles successfully parked.");


        }

        public void VehicleSearch(string? color = null, int? wheels = null, string? type = null)
        {
            //Here we match Color, Wheels and type. If user just skips (presses enter without input)
            //It considers it a match with every propertie just skipped.
            var searchResults = garage.Where(vehicle => vehicle != null &&
            (string.IsNullOrWhiteSpace(color) ||
     (!string.IsNullOrWhiteSpace(vehicle.Color) &&
      vehicle.Color.Trim().Equals(color.Trim(), StringComparison.OrdinalIgnoreCase))) && 
            (!wheels.HasValue || vehicle.NumberOfWheels == wheels) && 
            (string.IsNullOrWhiteSpace(type) || vehicle.GetType().Name.Equals(type, StringComparison.OrdinalIgnoreCase))
            );

            if (!searchResults.Any())
            {
                ui.ShowMessage("No vehicles for the given search criteria found");
                return;
            }

            ui.ShowMessage("Matching vehicles: ");
            foreach (var v in searchResults)
            {
                ui.ShowMessage(v.GetVehicleInfo());
            }
        }

        private static string RandomRegNr(Random random)
        {
            string letters = new string(Enumerable.Range(0, 3).Select(r => (char)random.Next('A', 'Z' + 1)).ToArray());
            //(100, 1000) makes it within range of three digits.
            string numbers = random.Next(100, 1000).ToString();
            return letters + numbers;
        }
    }
}
