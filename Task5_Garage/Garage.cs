﻿using System.Collections;
using Task5_Garage.Interfaces;
using Task5_Garage.Models;

namespace Task5_Garage
{
    public class Garage<T> : IEnumerable<T> where T : IVehicle
    {
        //Private arrace of vehicles using generics with IVehicle interface
        private T[] vehicles;
        private int count;

        public int Capacity { get; }

        public Garage(int capacity) 
        {
            Capacity = capacity;
            vehicles = new T[capacity];
            count = 0;

        }

        public bool Park(T vehicle)
        {
            //TODO: Test if this works
            //We check if the garage is full OR if our input vehicle has the same regNr
            //as any of the already parked ones.
            if (count >= Capacity || vehicles.Any(v => v?.RegistrationNumber == vehicle.RegistrationNumber))
                return false;
            vehicles[count++] = vehicle;
            return true;
        }

        public bool Remove(string regNr)
        {
            //TODO: Check vehicle and remove if regNr matches
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i< count; i++)
                yield return vehicles[i];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
    }

}
