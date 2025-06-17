using Task5_Garage.Interfaces;
using Task5_Garage.Models;

namespace Task5_Garage
{
    public class GarageHandler : IHandler
    {
        private Garage<IVehicle> garage;
        private UI ui;
        public int spot { get; }


        public GarageHandler(int capacity)
        {
            garage = new Garage<IVehicle>(capacity);
            ui = new UI();

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

        public bool RemoveVehicle(string regNr)
        {
            if (garage.RemoveVehicle(regNr))
            {
                Console.WriteLine($"Vehicle with registration number: {regNr} successfully removed");
                return true;
            }
            else
            {
                Console.WriteLine($"Vehicle with registration number: {regNr} not found");
                return false;
            }
        }
        public void RandomPopulateGarage(int capacity)
        {
            var random = new Random();
            var colors = new[] { "Red   ", "Orange", "Yellow", "Green ", "Blue  ", "Black ", "White ", "Gray  " };
            var numberWheels = new[] { "3", "4", "6", "8" };
            var fuelTypes = new[] { "Diesel", "Gasoline", "Ethanol", "Electric" };
            //var vehicleTypes = new[] { Enumerable.Range(1, 5).ToString() };
            //var wingspans = new[] { Enumerable.Range(10, 40).ToString() };
            //var lengths = new[] { Enumerable.Range(5, 40).ToString() };
            //var cylinderVolumes = new[] {Enumerable.Range(49, 1500).ToString() };
            //var numberOfSeats = new[] { Enumerable.Range(6, 80).ToString() };

            for (int i = 0; i < capacity; i++)
            {
                if (CheckIfFull())
                    break;
                string regNr = RandomRegNr(random);
                string color = colors[random.Next(colors.Length)];
                string wheels = numberWheels[random.Next(numberWheels.Length)];
                //Might have to fix potential Null here
                string randomVehicleType = random.Next(1, 5).ToString()!;

                switch (randomVehicleType)
                {
                    case "1":
                        string wingspan = random.Next(10, 40).ToString();
                        IVehicle airplane = new Airplane(regNr, color, wheels, wingspan);
                        ParkVehicle(airplane);
                        break;
                    case "2":
                        string length = random.Next(5, 40).ToString();
                        IVehicle boat = new Boat(regNr, color, wheels, length);
                        ParkVehicle(boat);
                        break;
                    case "3":
                        string numberOfSeat = random.Next(8, 80).ToString();
                        IVehicle buss = new Buss(regNr, color, wheels, numberOfSeat);
                        ParkVehicle(buss);
                        break;
                    case "4":
                        string fuelType = fuelTypes[random.Next(fuelTypes.Length)];
                        IVehicle car = new Car(regNr, color, wheels, fuelType);
                        ParkVehicle(car);
                        break;
                    case "5":
                        string cylinderVolume = random.Next(50, 1500).ToString();
                        IVehicle motorcycle = new Motorcycle(regNr, color, wheels, cylinderVolume);
                        ParkVehicle(motorcycle);
                        break;
                }

                //TODO: Add more vehicles as we go
                //IVehicle vehicle = new Car("abc123", "Red", "4", "Diesel");

                //if (typeof(T) == typeof(Car))
                //    vehicle = new Car(regNr, color, wheels, fuel);
                //ParkVehicle((T)vehicle);
            }

        }
        private string RandomRegNr(Random random)
        {
            string letters = new string(Enumerable.Range(0, 3).Select(r => (char)random.Next('A', 'Z' + 1)).ToArray());
            //(100, 1000) makes it within range of three digits.
            string numbers = random.Next(100, 1000).ToString();
            return letters + numbers;
        }
    }
}
