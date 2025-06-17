using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_Garage.Models
{
    public class Boat : Vehicle
    {

        public string Length { get; }
        public Boat(string regNr, string color, string wheels, string length)
            : base(regNr, color, wheels)
        {
            Length = length;
        }

        public override string GetVehicleInfo() =>
            $"Car: {RegistrationNumber} | Color: {Color}" +
                $" | Number of Wheels: {NumberOfWheels} | Fuel Type: {Length}";
    }
}
