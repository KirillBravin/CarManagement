using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Core.Models
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthYear { get; set; }

        public Customer() { }

        public Customer (string firstName, string lastName, DateOnly birthYear)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthYear = birthYear;
        }

        public override string ToString()
        {
            return $"Name: {FirstName} last name: {LastName} year of birth: {BirthYear.ToString("yyy")} months: {BirthYear.ToString("MM")}";
        }
    }
}
