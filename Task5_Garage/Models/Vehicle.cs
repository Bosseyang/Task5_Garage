using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5_Garage.Interfaces;

namespace Task5_Garage.Models
{
    public class Vehicle : IVehicle
    {
        public string RegistrationNumber { get; }
        public string Color { get; }
        public string NumberOfWheels { get; }

        public Vehicle(string regNr, string color, string wheels)
        {
            RegistrationNumber = regNr;
            Color = color;
            NumberOfWheels = wheels;
        }

    }
}
