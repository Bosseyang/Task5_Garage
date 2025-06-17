using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5_Garage.Interfaces;

namespace Task5_Garage
{
    public class UI : IUI
    {
        public void ShowMenu()
        {
            ShowMessage("\n ---- Garage Menu ---- ");
            ShowMessage("1. Park Vehicle");
            ShowMessage("2. Remove Vehicle");
            ShowMessage("3. List Parked Vehicles");
            ShowMessage("4. List Parked Vehicle Types and Their Corresponding Amount");
            ShowMessage("5. Populate Garage with randomly generated vehicles");


        }
        public void ShowVehicleMenu()
        {
            Console.WriteLine("\n ----- Vehicle Menu ----- ");
            Console.WriteLine("Which type of vehicle are you parking?");
            Console.WriteLine("1. Airplane");
            Console.WriteLine("2. Boat");
            Console.WriteLine("3. Buss");
            Console.WriteLine("4. Car");
            Console.WriteLine("5. Motorcycle");
            Console.WriteLine("0. Exit to Main Menu");
        }
        public string GetInput(string input)
        {
            //TODO: Fix and validate input here
            Console.Write($"{input}");
            return Console.ReadLine()!;
        }
        public void ShowMessage(string input)
        {
            Console.WriteLine($"{input}");
        }
    }
}
