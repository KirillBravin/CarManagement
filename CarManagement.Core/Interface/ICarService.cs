using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarManagement.Core.Models;


namespace CarManagement.Core.Interface
{
    public interface ICarService
    {
        void ReadFromFile();
        void WriteToFile();
        void AddCar(Car car);
        List<Car> SearchByBrand(String brand);
        List<Car> GetAllCars();
        List<ElectricCar> GetElectricCars();
        List<PetrolCar> GetPetrolCars();

        void ModifyElectricCar(ElectricCar electricCar);
        void ModifyPetrolCar(PetrolCar petrolCar);
    }
}
