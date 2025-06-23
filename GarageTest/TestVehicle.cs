using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5_Garage.Interfaces;

namespace GarageTest
{
    internal class TestVehicle : IVehicle
    {
        public string RegistrationNumber { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public int NumberOfWheels { get; set; } 

        public string GetVehicleInfo()
        {
            return $"TestVehicle: {RegistrationNumber}, Color: {Color}, Wheels: {NumberOfWheels}";
        }
    }
}
