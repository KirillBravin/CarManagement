using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarManagement.Core.Interface;
using CarManagement.Core.Models;

namespace CarManagement.Core.Repositories
{
    public class CarFileRepository : ICarRepository
    {
        private readonly string _filePath;
        public CarFileRepository(string autoFilePath)
        {
            _filePath = autoFilePath;
        }

        public List<ElectricCar> GetAllElectricCars()
        {
            List<ElectricCar> electricCars = new List<ElectricCar>();
            using (StreamReader sr = new StreamReader(_filePath))
            {
                while(!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] entries = line.Split(",", StringSplitOptions.RemoveEmptyEntries);
                    if (entries.Length == 6)
                    {
                        electricCars.Add(new ElectricCar(int.Parse(entries[0]), entries[1], entries[2], decimal.Parse(entries[3]),
                            int.Parse(entries[4]), int.Parse(entries[5])));
                    }
                }
            }
            return electricCars;
        }

        public List<PetrolCar> GetAllPetrolCars()
        {
            List<PetrolCar> petrolCars = new List<PetrolCar>();
            using (StreamReader sr = new StreamReader(_filePath))
            {
                while(!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] entries = line.Split(",", StringSplitOptions.RemoveEmptyEntries);
                    if (entries.Length < 6)
                    {
                        petrolCars.Add(new PetrolCar(int.Parse(entries[0]), entries[1], entries[2], decimal.Parse(entries[3]),
                            double.Parse(entries[4])));
                    }
                }
            }

            return petrolCars;
        }

        public void WriteElectricCar(ElectricCar electricCar)
        {
            throw new NotImplementedException();
        }

        public void WritePetrolCar(PetrolCar petrolCar)
        {
            throw new NotImplementedException();
        }

        public void WriteCar()
        {
            throw new NotImplementedException();
        }

        public List<Car> ReadCars()
        {
            List<Car> cars = new List<Car>();
            using (StreamReader sr = new StreamReader(_filePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] entries = line.Split(",", StringSplitOptions.RemoveEmptyEntries);
                    if (entries.Length == 6)
                    {
                        cars.Add(new ElectricCar(int.Parse(entries[0]), entries[1], entries[2], decimal.Parse(entries[3]),
                            int.Parse(entries[4]), int.Parse(entries[5])));
                    }
                    else
                    {
                        cars.Add(new PetrolCar(int.Parse(entries[0]), entries[1], entries[2], decimal.Parse(entries[3]),
                            double.Parse(entries[4])));
                    }
                }
            }
            return cars;
        }
    }
}
