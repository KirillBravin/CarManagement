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
            List<ElectricCar> result = dbConnection.Query<ElectricCar>(
                @"SELECT id, brand, model, rental_price AS RentalPrice, battery_capacity AS BatteryCapacity,
                charging_time AS ChargingTime FROM [dbo].[electro_cars]").ToList();
            dbConnection.Close();
            return result;
        }

        public List<PetrolCar> GetAllPetrolCars()
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            List<PetrolCar> result = dbConnection.Query<PetrolCar>(@"SELECT id, brand, model, 
            rental_price AS RentalPrice, fuel_consumption AS FuelConsumption FROM [dbo].[petrol_cars]").ToList();
            dbConnection.Close();
            return result;
        }

        public void WriteElectricCar(ElectricCar electricCar)
        {
            string sqlCommand = $"INSERT INTO electro_cars ([id], [brand], [model], [rental_price], [battery_capacity], [charging_time]) " +
                                $"VALUES (@Id, @Brand, @Model, @RentalPrice, @BatteryCapacity, @ChargingTime)";

            using (var connection = new SqlConnection(_dbConnectionString))
            {
                connection.Execute(sqlCommand, electricCar);
            }
        }

        public void WritePetrolCar(PetrolCar petrolCar)
        {
            string sqlCommand = $"INSERT INTO petrol_cars ([id], [brand], [model], [rental_price], [fuel_consumption]) " +
                                $"VALUES (@Id, @Brand, @Model, @RentalPrice, @FuelConsumption)";

            using (var connection = new SqlConnection(_dbConnectionString))
            {
                connection.Execute(sqlCommand, petrolCar);
            }
        }

        public void ModifyElectricCar(ElectricCar electricCar)
        {
            string sqlCommand = $"UPDATE electro_cars " +
                                $"SET brand = @Brand, " +
                                     $"model = @Model, " +
                                     $"rental_price = @RentalPrice, " +
                                     $"battery_capacity = @BatteryCapacity, " +
                                     $"charging_time = @ChargingTime " +
                                     $"WHERE id = @Id";
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                connection.Execute(sqlCommand, electricCar);
            }
        }

        public void ModifyPetrolCar(PetrolCar petrolCar)
        {
            string sqlCommand = $"UPDATE petrol_cars " +
                                $"SET brand = @Brand, " +
                                     $"model = @Model, " +
                                     $"rental_price = @RentalPrice, " +
                                     $"fuel_consumption = @FuelConsumption " +
                                     $"WHERE id = @Id";
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                connection.Execute(sqlCommand, petrolCar);
            }
        }
    }
}
