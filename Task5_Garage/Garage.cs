using System.Collections;
using Task5_Garage.Interfaces;
using Task5_Garage.Models;

namespace Task5_Garage
{
    public class Garage<T> : IEnumerable<T> where T : IVehicle
    {
        private T[] vehicles;
        private int count;

        public int Capacity { get; }

        public Garage(int capacity) 
        {
            Capacity = capacity;
            vehicles = new T[capacity];
            count = 0;

        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i< count; i++)
                yield return vehicles[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
