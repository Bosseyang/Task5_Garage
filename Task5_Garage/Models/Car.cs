using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_Garage.Models
{
    public class Car : Vehicle
    {

        public string FuelType { get; }
        public Car(string regNr, string color, string wheels, string fuelType) 
            : base(regNr, color, wheels)
        {
            FuelType = fuelType;
        }

    }
}
