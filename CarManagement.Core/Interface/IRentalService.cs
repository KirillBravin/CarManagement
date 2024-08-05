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
        List<Customer> GetAlLCustomers();
        void CreateRentContract(Customer customer, Staff staff, Car car, DateTime rentStart, int days);
        List<ElectricCar> GetElectricCars();
        List<PetrolCar> GetPetrolCars();
        void ModifyElectricCar(ElectricCar electricCar);
        void ModifyPetrolCar(PetrolCar petrolCar);

        void DeleteElectricCar(int id);
        void DeletePetrolCar(int id);

        void AddStaff(Staff staff);

        List<Staff> GetStaff();
        Staff GetStaffById(int id);
        void AddCustomer(Customer customer);
        void ModifyCustomer(Customer customer);
        void DeleteCustomer(int id);

        void AddRentalOrder(Customer customer, Staff staff, Car car, DateTime rentStart, int days);
        List<RentalOrder> ShowAllRentalOrders();
        void ModifyContract(Customer customer, Staff staff, Car car, DateTime rentStart, int days);
        void DeleteContract(int id);
    }
}
