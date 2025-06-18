using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_Garage.Models
{
    public class Motorcycle : Vehicle
    {

        public string CylinderVolume { get; }
        //TODO: Convert string to int cylinder volume
        public Motorcycle(string regNr, string color, int wheels, string cylinderVolume)
            : base(regNr, color, wheels)
        {
            CylinderVolume = cylinderVolume;
        }

        public override string GetVehicleInfo() =>
            $"Motorcycle: {RegistrationNumber} | Color: {Color}" +
                $" | Number of Wheels: {NumberOfWheels} | Cylinder volume: {CylinderVolume}";
    }
}
