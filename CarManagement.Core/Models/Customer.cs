using CarManagement.Core.Interface;
using CarManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Core.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthYear { get; set; }

        public Customer() { }

        public Customer(int id, string firstName, string lastName, DateTime birthYear)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthYear = birthYear;
        }

        public Customer (string firstName, string lastName, DateTime birthYear)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthYear = birthYear;
        }

        public override string ToString()
        {
            return $"Id: {Id}, name: {FirstName} last name: {LastName} year of birth: {BirthYear.ToString("yyyy")}";
        }
    }
}