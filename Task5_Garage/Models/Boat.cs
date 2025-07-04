﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_Garage.Models
{
    public class Boat : Vehicle
    {

        public string Length { get; }
        //TODO: Convert string to int for length
        public Boat(string regNr, string color, int wheels, string length)
            : base(regNr, color, wheels)
        {
            Length = length;
        }

        public override string GetVehicleInfo() =>
            $"Boat:       {RegistrationNumber} | Color: {Color}" +
                $" | Number of Wheels: {NumberOfWheels} | Length:          {Length}";
    }
}
