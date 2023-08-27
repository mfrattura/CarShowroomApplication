using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarShowroomApplication;
using System.Collections.Generic;

namespace carShowroomTests
{
    [TestClass]
    public class VehicleDataTest
    {
        [TestMethod]
        public void GetVehicles_ReturnListOfVehicles()
        {
            //arrange
            Data data = new Data();

            //act
            List<Vehicle> result = data.GetVehicles();

            //assert
            Assert.IsInstanceOfType(result, typeof(List<Vehicle>));

        }
        [TestMethod]
        public void AddVehicle_VehicleAddedToArray()
        {
            //arrange
            Data data = new Data();
            Vehicle vehicle = new Vehicle(8, "0KUI28", "HONDA", "CIVIC", 2010, 42000.00, "HondaCivi.jpg");

            //act
            data.AddVehicle(vehicle);
            List<Vehicle> vehicles = data.GetVehicles();

            //assert
            Assert.IsNotNull(vehicles[7]);
            Assert.AreEqual(vehicle, vehicles[7]);

        }
        [TestMethod]
        public void AddVehicle

    }
}