using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Core.Models
{
    public class ElectricCar : Car
    {
        public int BatteryCapacity { get; set; }
        public int ChargingTime { get; set; }

        public ElectricCar(int id, string brand, string model, decimal rentalPrice, int batteryCapacity, int chargingTime) : base (id, brand, model, rentalPrice)
        {
            BatteryCapacity = batteryCapacity;
            ChargingTime = chargingTime;
        }

        public ElectricCar(string brand, string model, decimal rentalPrice, int batteryCapacity, int chargingTime) : base (brand, model, rentalPrice) 
        {
            BatteryCapacity = batteryCapacity;
            ChargingTime = chargingTime;
        }

        public ElectricCar() { }

        public override string ToString()
        {
            return $"id: {Id} brand: {Brand} model: {Model} rental price: {RentalPrice} eur/hr battery capacity: {BatteryCapacity} kwh charging time: {ChargingTime} hr";
        }
    }
}
