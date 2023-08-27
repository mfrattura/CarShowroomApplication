using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroomApplication
{
    public class Vehicle
    {
        public int Key { get; set; }
        public string RegistrationNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }  
        public int Year { get; set; }
        public Double Price { get; set; }
        public string FilePath { get; set; }

        public Vehicle()
        {

        }
        public Vehicle(int key, string registrationNumber, string make, string model, int year,  Double price, string filePath)
        {
            Key = key;
            RegistrationNumber = registrationNumber;
            Make = make;
            Model = model;
            Year = year;
            Price = price;
            FilePath = filePath;
               
        }
        public override string ToString()
        {
            return $"Key No. {Key} : [{RegistrationNumber}] {Make} : {Model} : {Year} : ${Price}";
        }
    }
}
