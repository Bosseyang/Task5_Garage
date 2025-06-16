using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_Garage.Interfaces
{
    public interface IHandler
    {
        void ParkVehicle(IVehicle vehicle);
        bool RemoveVehicle(string registrationNumber);

        bool CheckIfFull();
        void ListParkedVehicles();
    }
}
