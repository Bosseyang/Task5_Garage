#region
// ------- Structure -------
//TODO: Update along the project

//Program
//  - Manager/
//      - Garage
//      - GarageHandler
//      - UI

//  - Models/
//      - Car
//      - Airplane
//      - Vehicle

//  - Interfaces/
//      -IUI
//      -IHandler
//      -IVehicle

//  - UI/
//      - ConsoleUI

// - Program
#endregion

using Task5_Garage;
using Task5_Garage.UI;

class Program
{
    static void Main()
    {
        //TODO: Handle inputs other than int here, maybe loop until you get correct input?
        Console.WriteLine("Please enter garage capacity: ");
        int capacity = int.Parse(Console.ReadLine());
        var handler = new GarageHandler(capacity);
        var ui = new ConsoleUI(handler);
        ui.ShowMenu();

    }
}