using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5_Garage.Interfaces;

namespace Task5_Garage.Models
{
    public abstract class Vehicle : IVehicle
    {
        public string RegistrationNumber { get; }
        public string Color { get; }
        public int NumberOfWheels { get; }

        public Vehicle(string regNr, string color, int wheels)
        {
            RegistrationNumber = regNr;
            Color = color;
            NumberOfWheels = wheels;
        }

        public abstract string GetVehicleInfo();
    }
}
