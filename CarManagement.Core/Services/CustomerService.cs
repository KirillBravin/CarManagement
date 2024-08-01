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
        private readonly ICustomerRepository _customerRepository;
        private List<Customer> allCustomers = new List<Customer>();
        public CustomerService(ICustomerRepository customerRepository)
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
            allCustomers.Add(customer);
        }

        public List<Customer> GetAllCustomers()
        {
            if (allCustomers.Count == 0)
            {
                allCustomers = _customerRepository.GetAllCustomers();
            }
            return allCustomers;
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
