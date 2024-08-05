using CarManagement.Core.Enums;
using CarManagement.Core.Interface;
using CarManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Core.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal RentalPrice { get; set; }

        public Car(int id, string brand, string model, decimal rentalPrice) 
        {
            Id = id;
            Brand = brand;
            Model = model;
            RentalPrice = rentalPrice;
        }

        public Car(string brand, string model, decimal rentalPrice)
        {
            Brand = brand;
            Model = model;
            RentalPrice = rentalPrice;
        }

        public Car() { }
    }
}