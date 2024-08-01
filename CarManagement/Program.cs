using System;
using CarManagement.Core.Interface;
using CarManagement.Core.Models;
using CarManagement.Core.Repositories;
using CarManagement.Core.Services;


namespace CarManagementConsoleApp;

public class Program
{
    public static void Main(string[] args)
    {
        IRentalService rentalService = SetupDependencies();
        while (true)
        {
            Console.WriteLine("1. Show all cars");
            Console.WriteLine("2. Show all customers");
            Console.WriteLine("3. Show all electric cars");
            Console.WriteLine("4. Show all petrol cars");
            Console.WriteLine("5. Create new order");
            Console.WriteLine("6. Add new car");
            Console.WriteLine("0. Exit");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    List<Car> car = rentalService.GetAllCars();
                    foreach (Car a in car)
                    {
                        Console.WriteLine(a);
                    }
                    break;
                case "2":
                    List<Customer> customer = rentalService.GetAlLCustomers();
                    foreach (Customer a in customer)
                    {
                        Console.WriteLine(a);
                    }
                    break;
                case "3":
                    List<ElectricCar> electroCars = rentalService.GetElectricCars();
                    foreach(ElectricCar ecar in electroCars)
                    {
                        Console.WriteLine(ecar);
                    }
                    break;
                case "4":
                    List<PetrolCar> petrolCars = rentalService.GetPetrolCars();
                    foreach (PetrolCar pcar in petrolCars)
                    {
                        Console.WriteLine(pcar);
                    }
                    break;
                case "5":
                    Console.WriteLine("Rental order: ");
                    foreach (Customer client in rentalService.GetAlLCustomers())
                    {
                        Console.WriteLine(client);
                    }

                    Console.WriteLine("Insert clients name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Insert clients last name: ");
                    string lastName = Console.ReadLine();

                    foreach(Car auto in rentalService.GetAllCars())
                    {
                        Console.WriteLine(auto);
                    }

                    Console.WriteLine("Choose a car by its id: ");
                    int carId = int.Parse(Console.ReadLine()); ;

                    Console.WriteLine("Insert for how many days you want to rent a car: ");
                    int days = int.Parse(Console.ReadLine());

                    rentalService.CreateRentContract(name, lastName, carId, DateTime.Now, days);

                    break;
                case "6":
                    Car newCar = new Car();
                    int batteryCapacity = 0;
                    int chargingTime = 0;
                    int fuelConsumption = 0;
                    Console.WriteLine("1. Electric car.");
                    Console.WriteLine("2. Petrol car.");
                    string newCarInput = Console.ReadLine();
                    switch (newCarInput)
                    {
                        case "1":
                            Console.WriteLine("Insert battery capacity: ");
                            batteryCapacity = int.Parse(Console.ReadLine());
                            Console.WriteLine("Insert charging time: ");
                            chargingTime = int.Parse(Console.ReadLine());
                            break;
                        case "2":
                            Console.WriteLine("Insert fuel consumption: ");
                            fuelConsumption = int.Parse(Console.ReadLine());
                            break;
                    }

                    Console.WriteLine("Enter a brand: ");
                    string brand = Console.ReadLine();
                    Console.WriteLine("Enter a model: ");
                    string model = Console.ReadLine();
                    Console.WriteLine("Enter a rent price: ");
                    decimal rentPrice = decimal.Parse(Console.ReadLine());
                    switch (newCarInput)
                    {
                        case "1":
                            newCar = new ElectricCar(brand, model, rentPrice, batteryCapacity, chargingTime);
                            break;
                        case "2":
                            newCar = new PetrolCar(brand, model, rentPrice, fuelConsumption);
                            break;
                    }
                    rentalService.AddNewCar(newCar);
                    break;
                case "0":
                    {
                        Environment.Exit(0);
                        break;
                    }
            }
        }

    }

    public static IRentalService SetupDependencies()
    {
        ICustomerRepository customerRepository = new CustomerFileRepository("Customers.txt");
        ICarRepository carRepository = new CarDBRepository("Server=localhost;Database=CarManagement;Trusted_Connection=True;");
        ICustomerService customerService = new CustomerService(customerRepository);
        ICarService carService = new CarService(carRepository);
        return new CarRentalService(customerService, carService);
    }
}
