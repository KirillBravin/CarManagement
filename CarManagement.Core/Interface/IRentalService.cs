using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarManagement.Core.Models;

namespace CarManagement.Core.Interface
{
    public interface IRentalService
    {
        void AddNewCar(Car car);
        List<Car> GetAllCars();
        List<Customer> GetAlLCustomers();
        void CreateRentContract( string customerName, string customerLastName, int carId, DateTime rentStart, int days);
        List<ElectricCar> GetElectricCars();
        List<PetrolCar> GetPetrolCars();
        void ModifyElectricCar(ElectricCar electricCar);
        void ModifyPetrolCar(PetrolCar petrolCar);
    }
}
