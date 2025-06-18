namespace Task5_Garage.Interfaces
{
    public interface IVehicle
    {
        string Color { get; }
        int NumberOfWheels { get; }
        string RegistrationNumber { get; }
        string GetVehicleInfo();
    }
    
}