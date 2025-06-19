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
            ShowMessage("5. Find Vehicle with Registration Number");
            ShowMessage("6. Find Vehicle with properties");
            ShowMessage("7. Populate Garage with randomly generated vehicles");
            ShowMessage("0. Exit Application");

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
        public string GetInput(string prompt)
        {
            //TODO: Fix and validate input here (We are validating int down in GetIntInput())
            Console.Write($"{prompt}");
            return Console.ReadLine()!;
        }
        public int GetIntInput(string prompt)
        {
            int value = 0;
            while (true)
            {
                string input = GetInput(prompt);
                if (int.TryParse(input, out value))
                    return value;
                Console.WriteLine("Invalid input, please enter an integer: ");
            }

        }
        public void ShowMessage(string prompt)
        {
            Console.WriteLine($"{prompt}");
        }
    }
}
