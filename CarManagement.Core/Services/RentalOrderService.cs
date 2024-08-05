using CarManagement.Core.Interface;
using CarManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Core.Services
{
    public class RentalOrderService : IRentalOrderService
    {
        private readonly IRentalOrdersRepository _orderRepository;
        public RentalOrderService(IRentalOrdersRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public void ReadFromFile()
        {
            throw new NotImplementedException();
        }

        public void WriteToFile()
        {
            throw new NotImplementedException();
        }

        public void AddRentalOrder(Customer customer, Staff staff, Car car, DateTime rentStart, int days)
        {
            _orderRepository.CreateRentContract(customer, staff, car, rentStart, days);
        }

        public List<RentalOrder> ShowAllRentalOrders()
        {
            return _orderRepository.ShowAllContracts();
        }

        public void ModifyContract(Customer customer, Staff staff, Car car, DateTime rentStart, int days)
        {
            _orderRepository.ModifyContract(customer, staff, car, rentStart, days);
        }

        public void DeleteContract(int id)
        {
            _orderRepository.DeleteContract(id);
        }
    }
}
