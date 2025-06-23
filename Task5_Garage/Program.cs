#region
// ------- Structure -------
//TODO: Update along the project

//Program
//  - Manager
//  - Garage
//  - GarageHandler


//  - Models/
//      - Car
//      - Airplane
//      - Vehicle
//      - Boat
//      - Motorcycle

//  - Interfaces/
//      -IUI
//      -IHandler
//      -IVehicle
//      -IGarage

//  - UI/
//      - ConsoleUI

// - Program
#endregion

using Task5_Garage;
using Task5_Garage.Interfaces;


class Program
{

    static void Main()
    {
        //TODO: Handle inputs other than int here, maybe loop until you get correct input?
        Console.Write("Please enter garage capacity: ");
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out var capacity))
            {
                Console.Clear();
                Console.WriteLine($"Garage capacity set to: {capacity}");
                var handler = new GarageHandler(capacity);
                var ui = new UI();
                var manager = new Manager(handler, ui, capacity);
                manager.Run();
            }
            Console.WriteLine("Please try again and enter an integer:");
        }
    }
}