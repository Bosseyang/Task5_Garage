using Task5_Garage;
using Task5_Garage.Interfaces;

namespace GarageTest
{
    public class GarageTest
    {
        [Fact]
        public void ParkVehicle_AddsVehicleIfGarageNotFull()
        {
            // Arrange
            var garage = new Garage<IVehicle>(2);
            var vehicle = new TestVehicle
            {
                RegistrationNumber = "abc123",
                Color = "Red",
                NumberOfWheels = 4

            };
            // Act
            var result = garage.ParkVehicle(vehicle);

            // Assert
            Assert.Equal(1, result);
            Assert.Equal(1, garage.Count);
        }
        [Fact]
        public void ParkVehicle_ReturnsSpotIfValidVehicle()
        {
            var garage = new Garage<IVehicle>(2);
            var vehicle = new TestVehicle
            {
                RegistrationNumber = "abc123",
                Color = "Red",
                NumberOfWheels = 4
            };

            int result = garage.ParkVehicle(vehicle);

            Assert.Equal(1, result); // Should park at spot 1 (index 0 + 1)
        }

        [Fact]
        public void ParkVehicle_Returns0IfGarageIsFull()
        {
            var garage = new Garage<IVehicle>(1);

            var vehicle1 = new TestVehicle
            {
                RegistrationNumber = "abc123",
                Color = "Red",
                NumberOfWheels = 4

            };
            var vehicle2 = new TestVehicle
            {
                RegistrationNumber = "abc124",
                Color = "Red",
                NumberOfWheels = 4

            };
            garage.ParkVehicle(vehicle1);

            var result = garage.ParkVehicle(vehicle2);

            Assert.Equal(0, result);
        }

        [Fact]
        public void ParkVehicle_ReturnsMinus1IfRegistrationNotUnique()
        {
            var garage = new Garage<IVehicle>(2);
            var vehicle1 = new TestVehicle
            {
                RegistrationNumber = "abc123",
                Color = "Red",
                NumberOfWheels = 4

            };
            var vehicle2 = new TestVehicle
            {
                RegistrationNumber = "abc123",
                Color = "Red",
                NumberOfWheels = 4

            };
            garage.ParkVehicle(vehicle1);

            var result = garage.ParkVehicle(vehicle2);

            Assert.Equal(-1, result);
        }

        [Fact]
        public void RemoveVehicle_ReturnsEmptyIfGarageIsEmpty()
        {
            var garage = new Garage<IVehicle>(2);

            var result = garage.RemoveVehicle("aaa111");

            Assert.Equal("Empty", result);
        }

        [Fact]
        public void RemoveVehicle_ReturnsRemovedIfVehicleExists()
        {
            var garage = new Garage<IVehicle>(2);
            var vehicle = new TestVehicle
            {
                RegistrationNumber = "abc123",
                Color = "Red",
                NumberOfWheels = 4

            };
            garage.ParkVehicle(vehicle);

            var result = garage.RemoveVehicle("abc123");

            Assert.Equal("Removed", result);
            Assert.Equal(0, garage.Count);
        }

        [Fact]
        public void Find_ReturnsCorrectVehicle()
        {
            var garage = new Garage<IVehicle>(2);
            var vehicle = new TestVehicle
            {
                RegistrationNumber = "abc123",
                Color = "Red",
                NumberOfWheels = 4

            }; 
            garage.ParkVehicle(vehicle);

            var found = garage.Find("abc123");

            Assert.NotNull(found);
            Assert.Equal("abc123", found!.RegistrationNumber);
        }

        [Fact]
        public void CheckIfFull_ReturnsTrueIfGarageIsFull()
        {
            var garage = new Garage<IVehicle>(1);
            var vehicle = new TestVehicle
            {
                RegistrationNumber = "abc123",
                Color = "Red",
                NumberOfWheels = 4

            };

            garage.ParkVehicle(vehicle);

            Assert.True(garage.CheckIfFull());
        }

        [Fact]
        public void CheckIfEmpty_ReturnsTrueIfGarageIsEmpty()
        {
            var garage = new Garage<IVehicle>(1);

            Assert.True(garage.CheckIfEmpty());
        }
    }
    
}
