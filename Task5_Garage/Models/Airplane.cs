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
        public Airplane(string regNr, string color, string wheels, string wingSpan)
            : base(regNr, color, wheels)
        {
            WingSpan = wingSpan;
        }

        public override string GetVehicleInfo() =>
            $"Car: {RegistrationNumber} | Color: {Color}" +
                $" | Number of Wheels: {NumberOfWheels} | Fuel Type: {WingSpan}";
    }
}
}
