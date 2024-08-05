using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarManagement.Core.Enums;


namespace CarManagement.Core.Models
{
    public class Staff
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public StaffJobTitle JobTitle { get; set; }

        public Staff(int id, string name, string lastName, StaffJobTitle jobTitle)
        {
            Id = id;
            FirstName = name;
            LastName = lastName;
            JobTitle = jobTitle;
        }

        public Staff(string name, string lastName, StaffJobTitle jobTitle)
        {
            FirstName = name;
            LastName = lastName;
            JobTitle = jobTitle;
        }

        public Staff() { }

        public override string ToString()
        {
            return $"id: {Id}, name: {FirstName}, last name: {LastName}, job title: {JobTitle}";
        }
    }
}
