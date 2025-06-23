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
            ShowMessage("\n ----- Vehicle Menu ----- ");
            ShowMessage("Which type of vehicle are you parking?");
            ShowMessage("1. Airplane");
            ShowMessage("2. Boat");
            ShowMessage("3. Buss");
            ShowMessage("4. Car");
            ShowMessage("5. Motorcycle");
            ShowMessage("0. Exit to Main Menu");
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
