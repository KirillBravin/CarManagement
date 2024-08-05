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
        private readonly IStaffService _staffService;
        private readonly IRentalOrderService _rentalOrderService;

        private List<Car> allCars = new List<Car>();
        private List<RentalOrder> allOrders = new List<RentalOrder>();

        public CarRentalService(ICustomerService customerService, ICarService carService, IStaffService staffService, IRentalOrderService rentalOrderService)
        {
            _carService = carService;
            _customerService = customerService;
            _staffService = staffService;
            _rentalOrderService = rentalOrderService;
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

        public void CreateRentContract(Customer customer, Staff staff, Car car, DateTime rentStart, int days)
        {
            
        }

        public void ModifyElectricCar(ElectricCar electricCar)
        {
            _carService.ModifyElectricCar(electricCar);
        }

        public void ModifyPetrolCar(PetrolCar petrolCar)
        {
            _carService.ModifyPetrolCar(petrolCar);
        }

        public void DeleteElectricCar(int id)
        {
            _carService.DeleteElectricCar(id);
        }

        public void DeletePetrolCar(int id)
        {
            _carService.DeletePetrolCar(id);
        }

        public void AddStaff(Staff staff)
        {
            _staffService.AddStaff(staff);
        }

        public List<Staff> GetStaff()
        {
            return _staffService.GetStaff();
        }

        public Staff GetStaffById(int id)
        {
            return _staffService.GetStaffById(id);
        }

        public void AddCustomer(Customer customer)
        {
            _customerService.AddCustomer(customer);
        }

        public void ModifyCustomer(Customer customer)
        {
            _customerService.ModifyCustomer(customer);
        }

        public void DeleteCustomer(int id)
        {
            _customerService.DeleteCustomer(id);
        }

        public void AddRentalOrder(Customer customer, Staff staff, Car car, DateTime rentStart, int days)
        {
            _rentalOrderService.AddRentalOrder(customer, staff, car, rentStart, days);
        }

        public List<dynamic> ShowAllRentalOrders()
        {
            return _rentalOrderService.ShowAllRentalOrders();
        }

        public void ModifyContract(Customer customer, Staff staff, Car car, DateTime rentStart, int days)
        {
            _rentalOrderService.ModifyContract(customer, staff, car, rentStart, days);
        }

        public void DeleteContract(int id)
        {
            _rentalOrderService.DeleteContract(id);
        }
    }
}
