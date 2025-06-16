using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5_Garage.Interfaces;
using Task5_Garage.Models;

namespace Task5_Garage.UI
{
    public class ConsoleUI
    {
        private readonly IHandler? handler;

        public ConsoleUI(IHandler handler)
        {
            this.handler = handler;
        }
        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\n ---- Garage Menu ---- ");
                Console.WriteLine("1. Park Vehicle");
                Console.WriteLine("2. Remove Vehicle");
                //TODO: Add more as the application grows.

                var inputChoice = Console.ReadLine();
                switch (inputChoice)
                {
                    case "1":
                        if(handler.CheckIfFull())
                            break;
                        ParkVehicle();
                        break;
                    case "2":
                        Console.WriteLine("Enter registration number please");
                        var reg = Console.ReadLine();
                        handler.RemoveVehicle(reg);
                        break;
                    case "0":
                        Console.WriteLine("Exit Application");
                        Environment.Exit(0);
                        break;
                }
            }
        }

        private void ParkVehicle()
        {
            var reg = GetInput("Registration Number: ");
            var color = GetInput("Color: ");
            var wheels = GetInput("Number of Wheels: ");
            var fuelType = GetInput("Fuel Type: ");

            var car = new Car(reg, color, wheels, fuelType);
            handler.ParkVehicle(car);
        }

        private string GetInput(string input)
        {
            Console.Write($"{input}");
            return Console.ReadLine();
        }
    }
}
