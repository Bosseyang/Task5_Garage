using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5_Garage.Interfaces;

namespace Task5_Garage
{
    public class GarageHandler : IHandler
    {
        private Garage<IVehicle> garage;

        public GarageHandler(int capacity)
        {
            garage = new Garage<IVehicle>(capacity);
        }
        public bool CheckIfFull()
        {
            if (garage.Count() >= garage.Capacity)
            {
                Console.WriteLine("Garage is full, can not park any more vehicles");
                return true;
            }
            return false;
        }
        public void ParkVehicle(IVehicle vehicle)
        {
            int spot = garage.ParkVehicle(vehicle);
            Console.WriteLine(spot);
            if (spot == 0)
                Console.WriteLine("Failed to park vehicle, garage is full!");
            else if (spot == -1)
                Console.WriteLine("Failed to park vehicle. " +
                    "Vehicle with same registration number is already parked.");
            else
                Console.WriteLine($"Vehicle successfully parked at spot {spot}");
        }

        public bool RemoveVehicle(string registrationNumber)
        {
            if (garage.RemoveVehicle(registrationNumber))
            {
                Console.WriteLine($"Vehicle with registration number {registrationNumber} successfully removed");
                return true;
            }
            else
            {
                Console.WriteLine($"Vehicle with {registrationNumber} not found");
                return false;
            }
        }
    }
}
