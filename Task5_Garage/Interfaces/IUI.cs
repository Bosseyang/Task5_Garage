namespace Task5_Garage.Interfaces
{
    public interface IUI
    {
        string GetInput(string prompt);
        void ShowMenu();
        void ShowMessage(string prompt);
        void ShowVehicleMenu();
        int GetIntInput(string prompt);
    }
}