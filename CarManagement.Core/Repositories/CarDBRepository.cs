using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using CarManagement.Core.Interface;
using CarManagement.Core.Models;

namespace CarManagement.Core.Repositories
{
    public class CarDBRepository : ICarRepository
    {
        // Temporary id
        private int id = 2;
        private readonly string _dbConnectionString;
        public CarDBRepository(string connectionString)
        {
            _dbConnectionString = connectionString;
        }

        public void WriteCar()
        {
            throw new NotImplementedException();
        }

        public List<Car> ReadCars() 
        {
            throw new NotImplementedException(); 
        }

        public List<ElectricCar> GetAllElectricCars()
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            List<ElectricCar> result = dbConnection.Query<ElectricCar>(@"SELECT * FROM [dbo].[electro_cars]").ToList();
            dbConnection.Close();
            return result;
        }

        public List<PetrolCar> GetAllPetrolCars()
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            List<PetrolCar> result = dbConnection.Query<PetrolCar>(@"SELECT * FROM [dbo].[petrol_cars]").ToList();
            dbConnection.Close();
            return result;
        }

        public void WriteElectricCar(ElectricCar electricCar)
        {
            string sqlCommand = $"INSERT INTO electro_cars ([id], [brand], [model], [rental_price], [battery_capacity], [charging_time]) " +
                                $"VALUES ({id} @Brand, @Model, @RentalPrice, @BatteryCapacity, @ChargingTime)";

            using (var connection = new SqlConnection(_dbConnectionString))
            {
                connection.Execute(sqlCommand, electricCar);
            }
            id++;
        }

        public void WritePetrolCar(PetrolCar petrolCar)
        {
            string sqlCommand = $"INSERT INTO electro_cars ([id], [brand], [model], [rental_price], [battery_capacity], [charging_time]) " +
                    $"VALUES ({id} @Brand, @Model, @RentalPrice, @FuelConsumption)";

            using (var connection = new SqlConnection(_dbConnectionString))
            {
                connection.Execute(sqlCommand, petrolCar);
            }
            id++;
        }
    }
}
