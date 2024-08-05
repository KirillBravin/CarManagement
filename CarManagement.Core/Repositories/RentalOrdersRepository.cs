using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarManagement.Core.Interface;
using CarManagement.Core.Models;
using Dapper;

namespace CarManagement.Core.Repositories
{
    public class RentalOrdersRepository : IRentalOrdersRepository
    {
        private readonly string _dbConnectionString;
        public RentalOrdersRepository(string dbConnectionString)
        {
            _dbConnectionString = dbConnectionString;
        }

        public void CreateRentContract(Customer customer, Staff staff, Car car, DateTime rentStart, int days)
        {
            int customerId = customer.Id;
            int staffId = staff.Id;
            int carId = car.Id;
            string sqlCommand = @"INSERT INTO rental_orders ([employee_id], [car_id], [customer_id], 
            [rental_started], [days]) VALUES (@StaffId, @CarId, @CustomerId, @RentStart, @Days)";
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                var parameters = new
                {
                    StaffId = staff.Id,
                    CarId = car.Id,
                    CustomerId = customer.Id,
                    RentStart = rentStart,
                    Days = days
                };

                connection.Execute(sqlCommand, parameters);
            }
        }

        public List<RentalOrder> ShowAllContracts()
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            var result = dbConnection.Query<RentalOrder>(@"SELECT id, employee_id, car_id, customer_id, 
            rental_started, days FROM rental_orders").ToList();
            dbConnection.Close();
            return result;
        }

        public void DeleteContract(int id)
        {
            string sqlCommand = $"DELETE FROM rental_orders WHERE id = @Id";
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                connection.Execute(sqlCommand, new { Id = id });
            }
        }

        public void ModifyContract (Customer customer, Staff staff, Car car, DateTime rentStart, int days)
        {
            string sqlCommand = @"UPDATE rental_orders SET employee_id = @StaffId, 
            car_id = @CarId, customer_id = @CustomerId, rental_started = @RentalStarted, days = @Days 
            WHERE id = @Id";
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                var parameters = new
                {
                    StaffId = staff.Id,
                    CarId = car.Id,
                    CustomerId = customer.Id,
                    RentStart = rentStart,
                    Days = days
                };

                connection.Execute(sqlCommand, parameters);
            }
        }
    }
}
