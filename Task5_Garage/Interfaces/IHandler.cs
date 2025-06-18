using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_Garage.Interfaces
{
    public interface IHandler
    {
        bool ParkVehicle(IVehicle vehicle);
        bool RemoveVehicle(string registrationNumber);

        bool CheckIfFull();
        void ListParkedVehicles();
        void ListVehicleTypes();

        void RandomPopulateGarage(int capacity);

        void FindVehicle(string registrationNumber);
    }
}
