using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarShowroomApplication
{
    public class Data
    {
       private List<Vehicle> soldVehicles = new List<Vehicle>();
       
       Vehicle[] vehiclesArray = new Vehicle[20];

        public Data()
        {
            vehiclesArray[0] = new Vehicle(1, "1GVM00", "FORD", "BRONCO", 2020, 28076.80, "FordBronco.jpg");
            vehiclesArray[1] = new Vehicle(2, "3GHT65", "JEEP", "WRANGLER", 2019, 37894.50, "JeepWrangler.jpg");
            vehiclesArray[2] = new Vehicle(3, "6QWE78", "LANDROVER", "DEFENDER", 2006, 56432.75, "LandroverDefender.jpg");
            vehiclesArray[3] = new Vehicle(4, "8LOP98", "SUZUKI", "JIMNY", 2022, 26599.99, "SuzukiJimny.jpg");
            vehiclesArray[4] = new Vehicle(5, "3KSR56", "TOYOTA", "HILUX", 2015, 33900.00, "ToyotaHilux.jpg");
            vehiclesArray[5] = new Vehicle(6, "6RTG47", "TOYOTA", "LANDCRUISER", 2013, 54659.45, "ToyotaLandcruiser.jpg");
            vehiclesArray[6] = new Vehicle(7, "0GKI28", "TOYOTA", "PRADO", 2008, 40700.00, "ToyotaPrado.jpg");
            //vehiclesArray[7] = new Vehicle(8, "0KUI28", "HONDA", "CIVIC", 2010, 42000.00, "HondaCivi.jpg");

        }

        public List<Vehicle> GetVehicles()
        {

            return vehiclesArray.ToList();   
        }

        public void AddVehicle(Vehicle newVehicle)
        {
            //if vehicle not null
            // if (vehicle.key != null && vehicle.key >=0 && vehicles[vehicle.key.Value])
            // {
            //   vehiclesarray[vehicle.key] = vehicle
            // }
            for (int i = 0; i < vehiclesArray.Length; i++)
            { 
                if (vehiclesArray[i] == null)
                {
                    newVehicle.Key = i + 1;
                    vehiclesArray[i] = newVehicle;
                    return;
                }
            }
        }

        public void RemoveVehicle(Vehicle soldVehicle)
        {
            // if vehicle != null --> do the thing
            for (int i = 0; i < vehiclesArray.Length; i++)
            {
                if (soldVehicle.Key == vehiclesArray[i].Key)
                {
                    vehiclesArray[i] = null;
                    break;
                }
            }
            soldVehicles.Add(soldVehicle);
        }

        public Vehicle RetrieveKey(int key)
        {
           return vehiclesArray[key - 1];
        }
        
        public Vehicle RetrieveRego(string registrationNumber)
        {
            // if registrationNumber < 
            for (int i = 0; i < vehiclesArray.Length; i++)
            {
                if(vehiclesArray[i] != null && registrationNumber == vehiclesArray[i].RegistrationNumber)
                {
                    return vehiclesArray[i];
                }
            }
            return null;
        }
        public List<Vehicle> RetrievePrice(Double maxPrice, double minPrice)
        {
            List<Vehicle> result = new List<Vehicle>();

            for (int i = 0; i < vehiclesArray.Length; i++)
            {
                if (vehiclesArray[i] != null && vehiclesArray[i].Price >= minPrice && vehiclesArray[i].Price <= maxPrice)
                {
                    result.Add(vehiclesArray[i]);
                }
            }
            return result;
        }

    }
}
