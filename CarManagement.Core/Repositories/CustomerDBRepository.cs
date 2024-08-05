using CarManagement.Core.Interface;
using CarManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace CarManagement.Core.Repositories
{
    public class CustomerDBRepository : ICustomerDBRepository
    {
        private readonly string _dbConnectionString;

        public CustomerDBRepository(string dbConnectionString)
        {
            _dbConnectionString = dbConnectionString;
        }

        public void AddCustomer(Customer customer)
        {
            string sqlCommand = @"INSERT INTO customers ([first_name], [last_name], [birth_year]) 
            VALUES (@FirstName, @LastName, @BirthYear)";
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                connection.Execute(sqlCommand, customer);
            }
        }

        public List<Customer> GetAllCustomers()
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            var result = dbConnection.Query<Customer>(@"SELECT id, first_name AS FirstName, 
            last_name AS LastName, birth_year AS BirthYear FROM customers").ToList();
            dbConnection.Close();
            return result;
        }

        public void ModifyCustomer(Customer customer)
        {
            string sqlCommand = @"UPDATE customers SET first_name = @FirstName, 
            last_name = @LastName, birth_year = @BirthYear WHERE id = @Id";
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                connection.Execute(sqlCommand, customer);
            }
        }

        public void DeleteCustomer(int id)
        {
            string sqlCommand = $"DELETE FROM customers WHERE id = @Id";
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                connection.Execute(sqlCommand, new { Id = id });
            }
        }
    }
}
