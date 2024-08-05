using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarManagement.Core.Models;

namespace CarManagement.Core.Interface
{
    public interface ICustomerDBRepository
    {
        List<Customer> GetAllCustomers();
        void AddCustomer(Customer customer);
        void ModifyCustomer(Customer customer);
        void DeleteCustomer(int id);
    }
}
