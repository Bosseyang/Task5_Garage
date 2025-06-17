using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_Garage.Models
{
    public class Buss : Vehicle
    {
        public string NumberOfSeats { get; }
        public Buss(string regNr, string color, string wheels, string numberOfSeats)
            : base(regNr, color, wheels)
        {
            NumberOfSeats = numberOfSeats;
        }

        public override string GetVehicleInfo() =>
            $"Buss:       {RegistrationNumber} | Color: {Color}" +
                $" | Number of Wheels: {NumberOfWheels} | Number of seats: {NumberOfSeats}";
    }
}
