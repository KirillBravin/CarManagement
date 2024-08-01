using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarManagement.Core.Models;


namespace CarManagement.Core.Interface
{
    public interface ICarRepository
    {
        List<Car> ReadCars();
        void WriteCar();
        void WriteElectricCar(ElectricCar electricCar);
        void WritePetrolCar(PetrolCar petrolCar);
        List<ElectricCar> GetAllElectricCars();
        List<PetrolCar> GetAllPetrolCars();
    }
}
