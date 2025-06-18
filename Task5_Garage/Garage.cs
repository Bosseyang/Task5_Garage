using System.Collections;
using System.Diagnostics.Metrics;
using System.Transactions;
using Task5_Garage.Interfaces;
using Task5_Garage.Models;

namespace Task5_Garage
{
    public class Garage<T> : IEnumerable<T> where T : IVehicle
    {
        //Private array of vehicles using generics with IVehicle interface
        private T[] vehicles;
        private int count;

        public int Capacity { get; }
        public int Count => count;

        public Garage(int capacity)
        {
            Capacity = capacity;
            vehicles = new T[capacity];
            count = 0;

        }

        public int ParkVehicle(T vehicle)
        {
            //TODO: Validate with following Abc123 format
            //We check if the garage is full OR if our input vehicle has the same regNr
            //as any of the already parked ones.
       
            if (count >= Capacity)
                return 0;
            else if (vehicles.Any(v => v?.RegistrationNumber == vehicle.RegistrationNumber))
                return -1;

            int firstEmptyIndex = Array.FindIndex(vehicles, v => v == null);
            vehicles[firstEmptyIndex] = vehicle;
            count++;
            return firstEmptyIndex + 1;
        }

        public string RemoveVehicle(string registrationNumber)
        {

            if (count == 0)
                return "Empty";
            
            for (int i = 0; i < Capacity; i++)
            {
                if (vehicles[i] != null && vehicles[i].RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Removing {vehicles[i].GetType().Name} with registration number: {registrationNumber}... ");
                    vehicles[i] = default!;
                    count--;
                    Console.WriteLine("Press a key to continue");
                    Console.ReadLine();
                    Console.Clear();
                    return "Removed";
                }
            }
            return "Not Found";
        }

        public T? Find(string registrationNumber)
        {
            foreach (var v in vehicles)
            {
                if (v != null && v.RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase))
                    return v;
            }
            return default;
        }

        //public T Find(string registrationNumber)
        //{


        //    return vehicles.FirstOrDefault(vehicle => 
        //    vehicle.RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase) == true);


        //}


        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Capacity; i++)
            {
                if (vehicles[i] != null)
                    yield return vehicles[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();



        public bool CheckIfFull()
        {
            if (count >= Capacity)
            {
                return true;
            }
            return false;
        }

    }

}
