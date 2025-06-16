using Task5_Garage.Interfaces;
using Task5_Garage.Models;

namespace Task5_Garage
{
    public class GarageHandler : IHandler
    {
        private Garage<IVehicle> garage;
        public int spot { get; }

        public GarageHandler(int capacity)
        {
            garage = new Garage<IVehicle>(capacity);

        }
        public bool CheckIfFull()
        {
            if (garage.CheckIfFull()) 
            { 
                Console.WriteLine("Garage is full, can not park any more vehicles");
                return true;
            }
     
            return false;
        }
        public void ParkVehicle(IVehicle vehicle)
        {
            int spot = garage.ParkVehicle(vehicle);
            if (spot == 0)
                Console.WriteLine("Failed to park vehicle, garage is full!");
            else if (spot == -1)
                Console.WriteLine("Failed to park vehicle. " +
                    "Vehicle with same registration number is already parked.");
            else
                Console.WriteLine($"Vehicle successfully parked at spot {spot}");
        }
        public void ListParkedVehicles()
        {
            foreach (var v in garage)
                Console.WriteLine(v.GetVehicleInfo());
        }

        public bool RemoveVehicle(string registrationNumber)
        {
            if (garage.RemoveVehicle(registrationNumber))
            {
                Console.WriteLine($"Vehicle with registration number: {registrationNumber} successfully removed");
                return true;
            }
            else
            {
                Console.WriteLine($"Vehicle with registration number: {registrationNumber} not found");
                return false;
            }
        }

        public void RandomPopulateGarage(int capacity)
        {
            var random = new Random();
            var colors = new[] { "Red   ", "Orange", "Yellow", "Green ", "Blue  ", "Black ", "White ", "Gray  " };
            var numberWheels = new[] { "3", "4", "6", "8" };
            var fuelType = new[] { "Diesel", "Gasoline", "Ethanol", "Electric" };

            for (int i = 0; i < capacity; i++)
            {
                if (CheckIfFull())
                    break;
                string color = colors[random.Next(colors.Length)];
                string regNr = RandomRegNr(random);
                string wheels = numberWheels[random.Next(numberWheels.Length)];
                string fuel = fuelType[random.Next(fuelType.Length)];

                //IVehicle vehicle = new Car("abc123", "Red", "4", "Diesel");

                //if (typeof(T) == typeof(Car))
                //    vehicle = new Car(regNr, color, wheels, fuel);
                //ParkVehicle((T)vehicle);
                IVehicle vehicle = new Car(regNr, color, wheels, fuel);
                ParkVehicle(vehicle);

            }

        }
        private string RandomRegNr(Random random)
        {
            string letters = new string(Enumerable.Range(0, 3).Select(r => (char)random.Next('A', 'Z' + 1)).ToArray());
            string numbers = random.Next(100, 1000).ToString();
            return letters + numbers;
        }

    }
}
