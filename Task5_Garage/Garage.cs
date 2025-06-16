using System.Collections;
using Task5_Garage.Interfaces;

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
            //TODO: Test if this works
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

        public bool RemoveVehicle(string registrationNumber)
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i].RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Vehicle with registration: {vehicles[i].RegistrationNumber}");
                    vehicles[i] = default!;

                    count--;
                }
            }
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
                yield return vehicles[i];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }

}
