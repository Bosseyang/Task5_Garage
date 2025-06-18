using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_Garage.Models
{
    public class Airplane : Vehicle
    {
        public string WingSpan { get; }
        //TODO: Convert string to int for numberOfSeats
        public Airplane(string regNr, string color, int wheels, string wingSpan)
            : base(regNr, color, wheels)
        {
            WingSpan = wingSpan;
        }

        public override string GetVehicleInfo() =>
            $"Airplane:   {RegistrationNumber} | Color: {Color}" +
                $" | Number of Wheels: {NumberOfWheels} | Wingspan:        {WingSpan}";
    }
}

