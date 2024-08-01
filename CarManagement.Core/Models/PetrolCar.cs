using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Core.Models
{
    public class PetrolCar : Car
    {
        public double FuelConsumption { get; set; }

        public PetrolCar (int id, string brand, string model, decimal rentalPrice, double fuelConsumption) 
            : base (id, brand, model, rentalPrice)
        {
            Id = id;
            Brand = brand;
            Model = model;
            RentalPrice = rentalPrice;
            FuelConsumption = fuelConsumption;
        }

        public PetrolCar(string brand, string model, decimal rentalPrice, double fuelConsumption)
    : base(brand, model, rentalPrice)
        {
            Brand = brand;
            Model = model;
            RentalPrice = rentalPrice;
            FuelConsumption = fuelConsumption;
        }

        public PetrolCar() { }

        public string GetInformation()
        {
            return $"Id: {Id} brand: {Brand} model: {Model} rental price: {RentalPrice} fuel consumption: {FuelConsumption.ToString("F1")} L/100km";
        }

        public override string ToString()
        {
            return $"id: {Id} brand: {Brand} model: {Model} rental price: {RentalPrice} eur/hr fuel consumption: {FuelConsumption} / 100 km";
        }
    }
}
