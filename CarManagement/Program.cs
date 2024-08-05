using System;
using CarManagement.Core.Interface;
using CarManagement.Core.Models;
using CarManagement.Core.Repositories;
using CarManagement.Core.Services;
using CarManagement.Core.Enums;


namespace CarManagementConsoleApp;

public class Program
{
    public static void Main(string[] args)
    {
        IRentalService rentalService = SetupDependencies();
        List<ElectricCar> electricCars = new List<ElectricCar>();
        List<PetrolCar> petrolCars1 = new List<PetrolCar>();
        List<ElectricCar> electricCarsFromDB = rentalService.GetElectricCars();
        List<PetrolCar> petrolCarsFromDB = rentalService.GetPetrolCars();
        List<Staff> staffMembers = rentalService.GetStaff();
        List<Customer> allCustomers = rentalService.GetAlLCustomers();
        List<dynamic> allRentalOrders = rentalService.ShowAllRentalOrders();

        while (true)
        {
            Console.WriteLine("1. Show cars");
            Console.WriteLine("2. Customers");
            Console.WriteLine("3. Orders");
            Console.WriteLine("4. Add new car");
            Console.WriteLine("5. Modify a car");
            Console.WriteLine("6. Staff");
            Console.WriteLine("0. Exit");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("1. Show all electric cars.");
                    Console.WriteLine("2. Show all petrol cars.");
                    string showCarsInput = Console.ReadLine();
                    switch (showCarsInput)
                    {
                        case "1":
                            List<ElectricCar> electroCars = rentalService.GetElectricCars();
                            foreach (ElectricCar ecar in electroCars)
                            {
                                Console.WriteLine(ecar);
                            }
                            break;
                        case "2":
                                List<PetrolCar> petrolCars = rentalService.GetPetrolCars();
                                foreach (PetrolCar pcar in petrolCars)
                                {
                                    Console.WriteLine(pcar);
                                }
                                break;
                    }
                    break;
                case "2":
                    Console.WriteLine("1. Show all customers.");
                    Console.WriteLine("2. Add new customer.");
                    Console.WriteLine("3. Modify a customer.");
                    Console.WriteLine("4. Delete a customer.");
                    string customerInput = Console.ReadLine();
                    switch(customerInput)
                    {
                        case "1":
                            allCustomers = rentalService.GetAlLCustomers();
                            foreach (Customer a in allCustomers)
                            {
                                Console.WriteLine(a);
                            }
                            break;
                        case "2":
                            Console.WriteLine("Enter customers name: ");
                            string customerFirstName = Console.ReadLine();
                            Console.WriteLine("Enter customers last name: ");
                            string customerLastName = Console.ReadLine();
                            Console.WriteLine("Enter customers birth year(ex. 1991): ");
                            string BirthYearInput = Console.ReadLine();

                            if (int.TryParse(BirthYearInput, out int birthYear))
                            {
                                DateTime customerBirthYear = new DateTime(birthYear, 1, 1);
                                Customer newCustomer = new Customer(customerFirstName, customerLastName, customerBirthYear);
                                rentalService.AddCustomer(newCustomer);
                                Console.WriteLine("Customer successfully added.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Customer not added.");
                            }
                            break;
                        case "3":
                            allCustomers = rentalService.GetAlLCustomers();
                            Console.WriteLine("Input id of customer whom you wish to modify: ");
                            int customerId = int.Parse(Console.ReadLine());
                            Customer modifiedCustomer = allCustomers.FirstOrDefault(x => x.Id == customerId);
                            if (modifiedCustomer == null)
                            {
                                Console.WriteLine("Customer not found.");
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"Current name: {modifiedCustomer.FirstName}, enter new name: ");
                                modifiedCustomer.FirstName = Console.ReadLine();
                                Console.WriteLine($"Current last name: {modifiedCustomer.LastName}, enter new lats name: ");
                                modifiedCustomer.LastName = Console.ReadLine();
                                Console.WriteLine($"Current birthday: {modifiedCustomer.BirthYear}, enter new birthday(ex. 1991): ");
                                string newBirthYearInput = Console.ReadLine();
                                if (int.TryParse(newBirthYearInput, out int newBirthYear))
                                {
                                    modifiedCustomer.BirthYear = new DateTime(newBirthYear, 1, 1);
                                    rentalService.ModifyCustomer(modifiedCustomer);
                                    Console.WriteLine("Customer details successfully updated.");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Customers details not updated.");
                                }
                            }
                            break;
                        case "4":
                            Console.WriteLine("Please enter customer id to delete: ");
                            int customerToDeleteId = int.Parse(Console.ReadLine());
                            Customer customerToDelete = rentalService.GetAlLCustomers().FirstOrDefault(x => x.Id == customerToDeleteId);

                            if (customerToDelete == null)
                            {
                                Console.WriteLine("Customer not found.");
                            }
                            else
                            {
                                rentalService.DeleteCustomer(customerToDeleteId);
                                Console.WriteLine("Customer successfully deleted.");
                            }

                            break;
                    }

                    break;
                case "3":
                    Console.WriteLine("1. Add new order.");
                    Console.WriteLine("2. Show all orders.");
                    Console.WriteLine("3. Modify an order.");
                    Console.WriteLine("4. Delete an order.");

                    electricCarsFromDB = rentalService.GetElectricCars();
                    petrolCarsFromDB = rentalService.GetPetrolCars();
                    staffMembers = rentalService.GetStaff();
                    allCustomers = rentalService.GetAlLCustomers();

                    string orderInput = Console.ReadLine();
                    switch(orderInput)
                    {
                        case "1":
                            Console.WriteLine("Insert client id: ");
                            int orderClientId = int.Parse(Console.ReadLine());
                            Customer customer = allCustomers.FirstOrDefault(c => c.Id == orderClientId);

                            if (customer == null)
                            {
                                Console.WriteLine("This customer doesn't exist.");
                                return;
                            }

                            Console.WriteLine("Choose a car: ");
                            Console.WriteLine("1. Electro car");
                            Console.WriteLine("2. Petrol Car");
                            int choosingCar = int.Parse(Console.ReadLine());

                            Car car = null;

                            switch (choosingCar)
                            {
                                case 1:
                                    Console.WriteLine("Input electro car id: ");
                                    int orderElectricCarId = int.Parse(Console.ReadLine());
                                    car = electricCarsFromDB.FirstOrDefault(ec => ec.Id == orderElectricCarId);
                                    break;
                                case 2:
                                    Console.WriteLine("Input petrol car id: ");
                                    int orderPetrolCarId = int.Parse(Console.ReadLine());
                                    car = petrolCarsFromDB.FirstOrDefault(pc => pc.Id == orderPetrolCarId);
                                    break;
                                default:
                                    Console.WriteLine("Incorrect input.");
                                    return;
                            }

                            if (car == null)
                            {
                                Console.WriteLine("This car doesn't exist.");
                                return;
                            }

                            Console.WriteLine("Insert staff id: ");
                            int orderStaffId = int.Parse(Console.ReadLine());
                            Staff staff = staffMembers.FirstOrDefault(s => s.Id == orderStaffId);

                            if (staff == null)
                            {
                                Console.WriteLine("Staff member doesn't exist.");
                                return;
                            }

                            Console.WriteLine("Please enter the amount of days: ");
                            int orderDays = int.Parse(Console.ReadLine());

                            rentalService.AddRentalOrder(customer, staff, car, DateTime.Now, orderDays);
                            break;
                        case "2":
                            allRentalOrders = rentalService.ShowAllRentalOrders();
                            foreach(var order in allRentalOrders)
                            {
                                Console.WriteLine($"Employee id: {order.StaffId} car id: {order.CarId}, " +
                                $"customer id: {order.CustomerId}, rental start: {order.RentalStart}, days: {order.NumberOfDays}");
                            }
                            break;
                        case "3":
                            Console.WriteLine("Please enter the rental order id of the order you want to modify.");
                            int orderToModifyId = int.Parse(Console.ReadLine());

                            RentalOrder orderToModify = allRentalOrders.FirstOrDefault(x => x.Customer.Id == orderToModifyId);

                            if (orderToModify == null)
                            {
                                Console.WriteLine("Rental order not found.");
                                return;
                            }

                            Console.WriteLine("Choose a car: ");
                            Console.WriteLine("1. Electro car");
                            Console.WriteLine("2. Petrol Car");
                            int modifyingNewCar = int.Parse(Console.ReadLine());
                            Car car1 = null;

                            switch (modifyingNewCar)
                            {
                                case 1:
                                    Console.WriteLine("Input electro car id: ");
                                    int orderElectricCarId = int.Parse(Console.ReadLine());
                                    car1 = electricCarsFromDB.FirstOrDefault(ec => ec.Id == orderElectricCarId);
                                    break;
                                case 2:
                                    Console.WriteLine("Input petrol car id: ");
                                    int orderPetrolCarId = int.Parse(Console.ReadLine());
                                    car1 = petrolCarsFromDB.FirstOrDefault(pc => pc.Id == orderPetrolCarId);
                                    break;
                                default:
                                    Console.WriteLine("Incorrect input.");
                                    return;
                            }

                            if (car1 == null)
                            {
                                Console.WriteLine("This car doesn't exist.");
                                return;
                            }

                            Console.WriteLine("Insert staff id: ");
                            int modifiedStaffId = int.Parse(Console.ReadLine());
                            Staff staff1 = staffMembers.FirstOrDefault(s => s.Id == modifiedStaffId);

                            if (staff1 == null)
                            {
                                Console.WriteLine("Staff member doesn't exist.");
                                return;
                            }

                            Console.WriteLine("Please enter the amount of days: ");
                            int modifiedOrderDays = int.Parse(Console.ReadLine());

                            rentalService.ModifyContract(orderToModify.Customer, staff1, car1, DateTime.Now, modifiedOrderDays);

                            break;
                        case "4":
                            {
                                Console.WriteLine("Please enter customer ID: ");
                                int customerId = int.Parse(Console.ReadLine());
                                Customer customerToDelete = allCustomers.FirstOrDefault(x => x.Id == customerId);

                                if (customerToDelete == null)
                                {
                                    Console.WriteLine("This customer doesn't exist.");
                                    return;
                                }

                                rentalService.DeleteContract(customerId);
                                Console.WriteLine("Customer successfully deleted.");
                                break;
                            }
                    }


                    break;
                case "4":
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
                case "5":
                    Console.WriteLine("1. Modify a car.");
                    Console.WriteLine("2. Delete car.");
                    string modifyInput = Console.ReadLine();
                    switch (modifyInput)
                    {
                        case "1":
                            Console.WriteLine("Which car you would like to modify?");
                            Console.WriteLine("1. Electric car.");
                            Console.WriteLine("2. Petrol car.");
                            string modifyInput2 = Console.ReadLine();
                            switch (modifyInput2)
                            {
                                case "1":
                                    electricCarsFromDB = rentalService.GetElectricCars();
                                    Console.WriteLine("Please enter car ID that you want to modify");
                                    int checkId_1 = int.Parse(Console.ReadLine());
                                    ElectricCar newElectricCar = electricCarsFromDB.FirstOrDefault(x => x.Id == checkId_1);
                                    if (newElectricCar == null)
                                    {
                                        Console.WriteLine("Car not found.");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Current brand: {newElectricCar.Brand}, enter new brand: ");
                                        newElectricCar.Brand = Console.ReadLine();

                                        Console.WriteLine($"Current model: {newElectricCar.Model}, enter new model: ");
                                        newElectricCar.Model = Console.ReadLine();

                                        Console.WriteLine($"Current rental price: {newElectricCar.RentalPrice}, enter new rental price: ");
                                        newElectricCar.RentalPrice = decimal.Parse(Console.ReadLine());

                                        Console.WriteLine($"Current battery capacity: {newElectricCar.BatteryCapacity}, enter new battery capacity: ");
                                        newElectricCar.BatteryCapacity = int.Parse(Console.ReadLine());

                                        Console.WriteLine($"Current charging time: {newElectricCar.ChargingTime}, enter new charging time: ");
                                        newElectricCar.ChargingTime = int.Parse(Console.ReadLine());

                                        rentalService.ModifyElectricCar(newElectricCar);
                                        Console.WriteLine("Car details successfully updated.");
                                    }
                                    break;
                                case "2":
                                    petrolCarsFromDB = rentalService.GetPetrolCars();
                                    Console.WriteLine("Please enter car ID that you want to modify");
                                    int checkId_2 = int.Parse(Console.ReadLine());
                                    PetrolCar newPetrolCar = petrolCarsFromDB.FirstOrDefault(x => x.Id == checkId_2);
                                    if (newPetrolCar == null)
                                    {
                                        Console.WriteLine("Car not found.");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Current brand: {newPetrolCar.Brand}, enter new brand: ");
                                        newPetrolCar.Brand = Console.ReadLine();

                                        Console.WriteLine($"Current model: {newPetrolCar.Model}, enter new model: ");
                                        newPetrolCar.Model = Console.ReadLine();

                                        Console.WriteLine($"Current rental price: {newPetrolCar.RentalPrice}, enter new rental price: ");
                                        newPetrolCar.RentalPrice = decimal.Parse(Console.ReadLine());

                                        Console.WriteLine($"Current fuel consumption: {newPetrolCar.FuelConsumption}, enter new fuel consumption: ");
                                        newPetrolCar.FuelConsumption = double.Parse(Console.ReadLine());

                                        rentalService.ModifyPetrolCar(newPetrolCar);
                                        Console.WriteLine("Car details successfully updated.");
                                    }
                                    break;
                            } break;
                        case "2":
                            {
                                Console.WriteLine("Which type of car you want to delete?");
                                Console.WriteLine("Electric car.");
                                Console.WriteLine("Petrol car.");
                                string deleteCarInput = Console.ReadLine();
                                switch (deleteCarInput)
                                {
                                    case "1":
                                        Console.WriteLine("Please enter car id: ");
                                        int electricCarId = int.Parse(Console.ReadLine());
                                        ElectricCar carToDelete = rentalService.GetElectricCars().FirstOrDefault(x => x.Id == electricCarId);
                                        if (carToDelete == null)
                                        {
                                            Console.WriteLine("Car not found.");
                                        }
                                        else
                                        {
                                            rentalService.DeleteElectricCar(electricCarId);
                                            Console.WriteLine("Car successfully deleted.");
                                        }
                                        break;
                                    case "2":
                                        Console.WriteLine("Please enter car id: ");
                                        int petrolCarId = int.Parse(Console.ReadLine());
                                        PetrolCar pcarToDelete = rentalService.GetPetrolCars().FirstOrDefault(x => x.Id == petrolCarId);
                                        if (pcarToDelete == null)
                                        {
                                            Console.WriteLine("Car not found.");
                                        }
                                        else
                                        {
                                            rentalService.DeletePetrolCar(petrolCarId);
                                            Console.WriteLine("Car successfully deleted.");
                                        }
                                        break;
                                }
                                break;
                            }
                    }
                    break;
                case "6":
                    Console.WriteLine("1. Add staff member.");
                    Console.WriteLine("2. Show all staff.");
                    Console.WriteLine("3. Show staff member by id.");
                    string staffInput = Console.ReadLine();
                    switch(staffInput)
                    {
                        case "1":
                            Console.WriteLine("First name: ");
                            string staffFirstName = Console.ReadLine();
                            Console.WriteLine("Last name: ");
                            string staffLastName = Console.ReadLine();
                            Console.WriteLine("Job title (Manager, Director, Mechanic): ");
                            string staffJobTitle = Console.ReadLine();
                            if (Enum.TryParse(staffJobTitle, true, out StaffJobTitle jobTitle))
                            {
                                Staff newStaffMember = new Staff(staffFirstName, staffLastName, jobTitle);
                                rentalService.AddStaff(newStaffMember);
                                Console.WriteLine("New staff member created.");
                            }
                            else Console.WriteLine("Invalid job title entered.");
                            break;
                        case "2":
                            List<Staff> staffM = rentalService.GetStaff();
                            foreach (Staff s in staffM)
                            {
                                Console.WriteLine(s);
                            }
                            break;
                        case "3":
                            Console.WriteLine("Insert id: ");
                            int inputId = int.Parse(Console.ReadLine());
                            foreach (Staff s in staffMembers)
                            {
                                if (s.Id == inputId)
                                {
                                    Console.WriteLine(s);
                                    break;
                                }
                            }
                            break;
                    }

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
        string connectionLink = "Server=localhost;Database=CarManagement;Trusted_Connection=True;";
        ICustomerDBRepository customerDBRepository = new CustomerDBRepository(connectionLink);
        ICarRepository carDBRepository = new CarDBRepository(connectionLink);
        IStaffRepository staffRepository = new StaffDBRepository(connectionLink);
        IRentalOrdersRepository rentalOrdersRepository = new RentalOrdersRepository(connectionLink);
        ICustomerService customerService = new CustomerService(customerDBRepository);
        ICarService carService = new CarService(carDBRepository);
        IStaffService staffService = new StaffService(staffRepository);
        IRentalOrderService rentalOrderService = new RentalOrderService(rentalOrdersRepository);
        return new CarRentalService(customerService, carService, staffService, rentalOrderService);
    }
}
