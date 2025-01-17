﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarManagement.Core.Interface;
using CarManagement.Core.Models;

namespace CarManagement.Core.Interface
{
    public interface ICustomerService
    {
        void ReadFromFile();
        void WriteToFile();
        void AddCustomer(Customer customer);
        List<Customer> GetAllCustomers();
        Customer SearchByName(string firstName, string lastName);
        void ModifyCustomer(Customer customer);
        void DeleteCustomer(int id);
    }
}