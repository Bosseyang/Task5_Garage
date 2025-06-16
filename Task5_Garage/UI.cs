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
            Console.WriteLine("\n ---- Garage Menu ---- ");
            Console.WriteLine("1. Park Vehicle");
            Console.WriteLine("2. Remove Vehicle");
            Console.WriteLine("3. List Parked Vehicles");
            Console.WriteLine("4. Populate Garage with randomly generated vehicles");
        }
        public string GetInput(string input)
        {
            Console.Write($"{input}");
            return Console.ReadLine();
        }
        public void ShowMessage(string input)
        {
            Console.WriteLine($"{input}");
        }
    }
}
