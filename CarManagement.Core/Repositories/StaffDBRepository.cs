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
    public class StaffDBRepository: IStaffRepository
    {
        private readonly string _dbConnectionString;

        public StaffDBRepository(string connectionString)
        {
            _dbConnectionString = connectionString;
        }

        public void AddStaff(Staff staff)
        {
            string sqlCommand = @"INSERT INTO staff ([id], [first_name], [last_name], [job_title]) 
            VALUES (@Id, @FirstName, @LastName, @JobTitle)";
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                connection.Execute(sqlCommand, staff);
            }
        }

        public List<Staff> GetStaff()
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            var result = dbConnection.Query<Staff>(@"SELECT id, first_name AS FirstName, 
                                                    last_name AS LastName, job_title AS JobTitle
                                                    FROM staff").ToList();
            dbConnection.Close();
            return result;
        }

        public Staff GetStaffById(int id)
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            var result = dbConnection.QueryFirst<Staff>(@"SELECT id, first_name AS FirstName, 
                                                    last_name AS LastName, job_title AS JobTitle
                                                    FROM staff WHERE Id = @id", new { Id = id });
            dbConnection.Close();
            return result;
        }
    }
}
