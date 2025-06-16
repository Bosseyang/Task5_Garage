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

        public void ParkVehicle(IVehicle vehicle)
        {
            int spot = garage.Park(vehicle);
            Console.WriteLine(spot);
            if (spot != 0)
            {
                Console.WriteLine($"Vehicle successfully parked at spot {spot}");
            }
            else
                Console.WriteLine("Failed to park vehicle. Garage may be full.\n" +
                    "or vehicle with same registration number is already parked.");
        }

        public bool RemoveVehicle(string registrationNumber)
        {
            if (garage.RemoveVehicle(registrationNumber))
            {
                Console.WriteLine("Vehicle successfully removed");
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
