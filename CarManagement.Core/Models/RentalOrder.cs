using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Core.Models
{
    public class RentalOrder
    {
        public Car Car { get; set; }
        public int CarId { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public Staff Staff { get; set; }
        public int StaffId { get; set; }
        public DateTime RentalStart { get; set; }
        public int NumberOfDays { get; set; }

        public RentalOrder(Car newCar, Customer newCustomer, Staff newStaff, DateTime rentalStart, int numberOfDays)
        {
            Car = newCar;
            Customer = newCustomer;
            Staff = newStaff;
            RentalStart = rentalStart;
            NumberOfDays = numberOfDays;
        }

        public RentalOrder(int carId, int customerId, int staffId, DateTime rentalStart, int numberOfDays)
        {
            CarId = carId;
            StaffId = staffId;
            CustomerId = customerId;
            RentalStart = rentalStart;
            NumberOfDays = numberOfDays;
        }

        public RentalOrder() { }

        public decimal calculateRentalPrice()
        {
            return Math.Round(Car.RentalPrice * NumberOfDays, 2);
        }

        public DateTime GetEndDate()
        {
            return RentalStart.AddDays(NumberOfDays);
        }
    }
}
