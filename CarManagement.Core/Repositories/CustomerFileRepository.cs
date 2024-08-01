using CarManagement.Core.Interface;
using CarManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Core.Repositories
{
    public class CustomerFileRepository : ICustomerRepository
    {
        private readonly string _filePath;
        public CustomerFileRepository(string filePath)
        {
            _filePath = filePath;
        }
        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            using (StreamReader sr = new StreamReader(_filePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (string.IsNullOrEmpty(line))
                        continue;
                    string[] entries = line.Split(",");
                    if (entries.Length < 3)
                        continue;
                    try
                    {
                        string fistName = entries[0].Trim();
                        string lastName = entries[1].Trim();
                        DateOnly birthdate = DateOnly.Parse(entries[2].Trim());

                        customers.Add(new Customer(fistName, lastName, birthdate));
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return customers;
        }
    }
}
