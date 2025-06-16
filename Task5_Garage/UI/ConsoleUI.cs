using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5_Garage.Interfaces;
using Task5_Garage.Models;

namespace Task5_Garage.UI
{
    public class ConsoleUI()
    {
        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine(" ---- Garage Menu ---- ");
                Console.WriteLine("1. Park Vehicle");
                Console.WriteLine("2. Remove Vehicle");
                //TODO: Add more as the application grows.

                var inputChoice = Console.ReadLine();
                switch (inputChoice)
                {
                    case "1":
                        ParkVehicle();
                        break;
                        case "2":
                        RemoveVehicle();
                        break;
                }
            }
        }

        private void RemoveVehicle()
        {
            Console.WriteLine("Remove vehicle with registration number: ");
            var reg = Console.ReadLine();
        }

        private void ParkVehicle()
        {
            Console.WriteLine("Registration Number: ");
            var reg = Console.ReadLine();
            Console.WriteLine("Color: ");
            var color = Console.ReadLine();
            Console.WriteLine("Number of Wheels:");
            var wheels = Console.ReadLine();
            Console.WriteLine("Fuel Type: ");
            var fuelType = Console.ReadLine();

            var car = new Car(reg, color, wheels, fuelType);
        }
    }
}
