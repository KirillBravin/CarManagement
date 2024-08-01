using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarManagement.Core.Models;
using CarManagement.Core.Interface;

namespace CarManagement.Core.Services
{
    public class CarRentalService : IRentalService
    {
        private readonly ICustomerService _customerService;
        private readonly ICarService _carService;

        private List<Car> allCars = new List<Car>();
        private List<RentalOrder> allOrders = new List<RentalOrder>();

        public CarRentalService(ICustomerService customerService, ICarService carService)
        {
            _carService = carService;
            _customerService = customerService;
        }

        public List<Car> GetAllCars()
        {
            if (allCars.Count == 0)
            {
                allCars = _carService.GetAllCars();
            }
            return allCars;
        }

        public void AddNewCar(Car car)
        {
            _carService.AddCar(car);
        }

        public List<Customer> GetAlLCustomers()
        {
            return _customerService.GetAllCustomers();
        }

        public List<ElectricCar> GetElectricCars()
        {
            return _carService.GetElectricCars();
        }

        public List<PetrolCar> GetPetrolCars()
        {
            return _carService.GetPetrolCars();
        }

        public void CreateRentContract(string customerName, string customerLastName, int carId, DateTime rentStart, int days)
        {
            Customer customer = _customerService.SearchByName(customerName, customerLastName);

            Car car = new Car();

            foreach(Car a in allCars)
            {
                if (a.Id == carId)
                {
                    car = a;
                }
            }

            RentalOrder rentalOrder = new RentalOrder
            {
                NewCustomer = customer,
                NewCar = car,
                RentalStart = rentStart,
                NumberOfDays = days
            };
            allOrders.Add(rentalOrder);
        }


    }
}
