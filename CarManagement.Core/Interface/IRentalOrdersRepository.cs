using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarManagement.Core.Models;

namespace CarManagement.Core.Interface
{
    public interface IRentalOrdersRepository
    {
        void CreateRentContract(Customer customer, Staff staff, Car car, DateTime rentStart, int days);
        List<RentalOrder> ShowAllContracts();
        void DeleteContract(int id);
        void ModifyContract(Customer customer, Staff staff, Car car, DateTime rentStart, int days);
    }
}
