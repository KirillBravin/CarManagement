using CarManagement.Core.Interface;
using CarManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Core.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService (ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public void ReadFromFile()
        {
            throw new NotImplementedException();
        }

        public void WriteToFile() 
        {
            throw new NotImplementedException();
        }

        public void AddCar(Car car) 
        {
            if (car is ElectricCar)
            {
                _carRepository.WriteElectricCar((ElectricCar)car);
            } else
            {
                _carRepository.WritePetrolCar((PetrolCar)car);
            }
        }

        public List<Car> GetAllCars() 
        {
            return _carRepository.ReadCars();
        }

        public List<ElectricCar> GetElectricCars()
        {
            return _carRepository.GetAllElectricCars();
        }

        public List<PetrolCar> GetPetrolCars()
        {
            return _carRepository.GetAllPetrolCars();
        }

        public void ModifyElectricCar(ElectricCar electricCar)
        {
            _carRepository.ModifyElectricCar(electricCar);
        }

        public void ModifyPetrolCar(PetrolCar petrolCar)
        {
            _carRepository.ModifyPetrolCar(petrolCar);
        }

        public List<Car> SearchByBrand(string brand) 
        {
            List<Car> filteredCars = new List<Car>();
            List<Car> cars = new List<Car>();

            foreach (Car car in cars)
            {
                if (car.Brand == brand)
                {
                    filteredCars.Add(car);
                }
            }
            return filteredCars;
        }
    }
}
