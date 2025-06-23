namespace Task5_Garage.Interfaces
{
    public interface IGarage<T> where T : IVehicle
    {
        int Capacity { get; }
        int Count { get; }

        bool CheckIfFull();
        bool CheckIfEmpty();
        T? Find(string registrationNumber);
        IEnumerator<T> GetEnumerator();
        int ParkVehicle(T vehicle);
        string RemoveVehicle(string registrationNumber);
    }
}