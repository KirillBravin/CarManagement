using CarManagement.Core.Interface;
using CarManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerDBRepository _customerRepository;
        private List<Customer> allCustomers = new List<Customer>();
        public CustomerService(ICustomerDBRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void ReadFromFile()
        {
            throw new NotImplementedException();
        }

        public void WriteToFile() 
        {
            throw new NotImplementedException();
        }

        public void AddCustomer(Customer customer)
        {
            _customerRepository.AddCustomer(customer);
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAllCustomers();
        }

        public void ModifyCustomer(Customer customer)
        {
            _customerRepository.ModifyCustomer(customer);
        }

        public void DeleteCustomer(int id)
        {
            _customerRepository.DeleteCustomer(id);
        }

        public Customer SearchByName(string firstName, string lastName)
        {
            Customer customer = new Customer();
            foreach (Customer client in allCustomers)
            {
                if (firstName.Equals(customer.FirstName) && lastName.Equals(customer.LastName))
                {
                    customer = client;
                    break;
                }
            }
            return customer;
        }


    }
}
