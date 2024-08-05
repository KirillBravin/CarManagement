using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarManagement.Core.Models;


namespace CarManagement.Core.Interface
{
    public interface IRentalOrderService
    {
        void ReadFromFile();
        void WriteToFile();
        void AddRentalOrder(Customer customer, Staff staff, Car car, DateTime rentStart, int days);
        List<RentalOrder> ShowAllRentalOrders();
        void ModifyContract(Customer customer, Staff staff, Car car, DateTime rentStart, int days);
        void DeleteContract(int id);
    }
}
