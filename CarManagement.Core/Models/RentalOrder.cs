using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Core.Models
{
    public class RentalOrder
    {
        public Car NewCar { get; set; }
        public Customer NewCustomer { get; set; }
        public DateTime RentalStart { get; set; }
        public int NumberOfDays { get; set; }

        //public RentalOrder(DateTime rentalStart, int numberOfDays)
        //{
        //    RentalStart = rentalStart;
        //    NumberOfDays = numberOfDays;
        //}

        public decimal calculateRentalPrice()
        {
            return Math.Round(NewCar.RentalPrice * NumberOfDays, 2);
        }

        public DateTime GetEndDate()
        {
            return RentalStart.AddDays(NumberOfDays);
        }
    }
}
