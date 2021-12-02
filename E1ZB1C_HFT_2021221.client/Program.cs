using ConsoleTools;
using E1ZB1C_HFT_2021221.Client;
using E1ZB1C_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace E1ZB1C_HFT_2021221.client
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);

            RestService rt = new RestService("http://localhost:50212");

            bool menu = true;
            while (menu)
            {
                menu = ShowMenu();
            }

        }


        private static bool ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose a menupoint");
            Console.WriteLine(">1> Create a new Company, Car, or Driver");
            Console.WriteLine(">2> Read everything from selected table");
            Console.WriteLine(">3> Update an existing model");
            Console.WriteLine(">4> Delete and existing model");
            Console.WriteLine(">5> Read an item from a model");
            Console.WriteLine(">6> Non Cruds");
            Console.WriteLine(">E> Exit");
            switch (Console.ReadLine())
            {
                case "1":
                    Create();
                    return true;
                case "2":
                    GetAll();
                    return true;
                case "3":
                    Update();
                    return true;
                case "4":
                    Delete();
                    return true;
                case "5":
                    GetOne();
                    return true;

                default:
                    Console.WriteLine("Not an option");
                    return true;
            }
        }

        private static void Create()
        {
            Console.Clear();
            RestService rest = new RestService("http://localhost:50212");
            Console.WriteLine("Where do you want to create model");
            string whereto = Console.ReadLine();
            Console.Clear();
            if ( whereto == "company")
            {
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Clear();
                Company creating = new Company()
                {
                    Company_name = name
                };
                rest.Post<Company>(creating, "Company");
                Console.Clear();
                Console.WriteLine("Process done!");
                Console.ReadKey();
            }
            else if( whereto == "Car")
            {
                Console.WriteLine("Brand:");
                string brad = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Type:");
                string type = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Company ID");
                int id = int.Parse(Console.ReadLine());
                Car creating = new Car()
                {
                    Company_id = id,
                    Car_Brand = brad,
                    Car_Type = type
                };
                rest.Post<Car>(creating, "Car");
                Console.Clear();
                Console.WriteLine("Process done!");
                Console.ReadKey();
            }
            else if(whereto == "Driver")
            {
                Console.WriteLine("Name:");
                string name = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Salary:");
                int salary = int.Parse(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("Car ID:");
                int id = int.Parse(Console.ReadLine());
                Driver creating = new Driver()
                {
                    Car_id = id,
                    Driver_name = name,
                    Driver_salary = salary
                };
                rest.Post<Driver>(creating, "Driver");
                Console.Clear();
                Console.WriteLine("Process done!");
                Console.ReadKey();
            }
           
           
        }

        private static void GetAll()
        {
            Console.Clear();
            RestService rest = new RestService("http://localhost:50212");
            Console.WriteLine("From which table do you want to get all from?");
            string wherefrom = Console.ReadLine();
            Console.Clear();
            if (wherefrom == "company")
            {
                Console.WriteLine("Companies:");
                Console.WriteLine();
                var query = rest.Get<Company>(wherefrom);
                foreach(var x in query)
                {
                    Console.WriteLine("Company_ID: " + x.Company_id + " " + "Company_Name:" + x.Company_name);
                }
            }
            else if(wherefrom == "car")
            {
                Console.WriteLine("Cars:");
                Console.WriteLine();
                var query = rest.Get<Car>(wherefrom);
                foreach(var x in query)
                {
                    Console.WriteLine("Car_ID: " + x.Car_id + " " + "Car Brand: " + x.Car_Brand +" " + "Car Type: " + x.Car_Type);
                }

            }
            else if(wherefrom == "driver")
            {
                Console.WriteLine("Drivers:");
                Console.WriteLine();
                var query = rest.Get<Driver>(wherefrom);
                foreach(var x in query)
                {
                    Console.WriteLine("Driver_ID: " + x.Driver_id + " " + "Driver Name: " + x.Driver_name +" "+"Driver Salary: " + x.Driver_name );
                }
            }
            Console.ReadKey();
        }

        private static void GetOne()
        {
            Console.Clear();
            RestService rest = new RestService("http://localhost:50212");
            Console.WriteLine("Where do you want to read from?");
            string wherefrom = Console.ReadLine();
            Console.Clear();
            if (wherefrom == "company")
            {
                Console.WriteLine("Enter company_ID: ");
                int id = int.Parse(Console.ReadLine());
                Console.Clear();
                var query = rest.Get<Company>(id, wherefrom);
                Console.WriteLine("ID: " + query.Company_id +" "+"Name: "+ query.Company_name);
            }
            else if (wherefrom == "car")
            {
                Console.WriteLine("Enter car_ID: ");
                int id = int.Parse(Console.ReadLine());
                Console.Clear();
                var query = rest.Get<Car>(id, wherefrom);
                Console.WriteLine("ID: " + query.Car_id + " " + "Brand: " + query.Car_Brand+" "+ "Type" + query.Car_Type);
            }
            if (wherefrom == "driver")
            {
                Console.WriteLine("Enter driver_ID: ");
                int id = int.Parse(Console.ReadLine());
                Console.Clear();
                var query = rest.Get<Driver>(id, wherefrom);
                Console.WriteLine("ID: " + query.Driver_name + " " + "Name: " + query.Driver_name + " " + "Salary:" + query.Driver_salary);
            }
            Console.ReadKey();
        }

        private static void Update()
        {
            Console.Clear();
            RestService rest = new RestService("http://localhost:50212");
            Console.WriteLine("Which table to update:");
            string which = Console.ReadLine();
            Console.Clear();
            if (which == "company")
            {
                Console.WriteLine("What Id: ");
                int id = int.Parse(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("What name: ");
                string name = Console.ReadLine();
                Company updating = new Company()
                {
                    Company_id = id,
                    Company_name = name
                };
                rest.Put<Company>(updating, "company");
                Console.Clear();
                Console.WriteLine("Process done!");
            }
            else if (which == "car")
            {
                Console.WriteLine("What Id: ");
                int id = int.Parse(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("What brand: ");
                string brand = Console.ReadLine();
                Console.WriteLine("What type: ");
                string type = Console.ReadLine();
                Car updating = new Car()
                {
                    Car_id = id,
                    Car_Brand = brand,
                    Car_Type = type
                };
                rest.Put<Car>(updating, "car");
                Console.Clear();
                Console.WriteLine("Process done!");
            }
            if (which == "driver")
            {
                Console.WriteLine("What Id: ");
                int id = int.Parse(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("What name: ");
                string name = Console.ReadLine();
                Driver updating = new Driver()
                {
                    Driver_id = id,
                    Driver_name = name
                };
                rest.Put<Driver>(updating, "driver");
                Console.Clear();
                Console.WriteLine("Process done!");
            }
            Console.ReadKey();
        }

        private static void Delete()
        {
            Console.Clear();
            RestService rest = new RestService("http://localhost:50212");
            Console.WriteLine("Which table to delete from?");
            string todelete = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("ID of the model to be deleted:");
            int id = int.Parse(Console.ReadLine());
            rest.Delete(id, todelete);
            Console.Clear();
            Console.WriteLine("Process done!");
            Console.ReadKey();
        }

        private static void NonCrud()
        {
            Console.Clear();
            RestService rest = new RestService("http://localhost:50212");
            Console.WriteLine("Table of the NonCrud method");
            string which = Console.ReadLine();
            Console.Clear();
            if (which == "company")
            {
                Console.WriteLine(">1> Car count");
                Console.WriteLine(">2> How Many cars does the company have");
                Console.WriteLine(">3> Average of the car id-s");
                string choice = Console.ReadLine();
                Console.Clear();
                if (choice == "1")
                {
                    Console.WriteLine("Company id:");
                    int id = int.Parse(Console.ReadLine());
                    var query = rest.Get<IEnumerable<string>>(id, "/stat/carcount");
                    foreach (var x in query)
                    {
                        Console.WriteLine(x);
                    }
                    Console.ReadKey();
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Company id:");
                    int id = int.Parse(Console.ReadLine());
                    var query = rest.Get <IEnumerable<KeyValuePair<string, int>>>(id, "/stat/howmany");
                    foreach(var x in query)
                    {
                        Console.WriteLine(x);
                    }
                    Console.ReadKey();
                }
                else if (choice == "3")
                {
                    var got = rest.Get<IEnumerable<KeyValuePair<string, double>>>("/stat/idavg");
                    Console.WriteLine(got);
                    Console.ReadKey();
                }
            }
            else if(which == "car")
            {
                Console.WriteLine(">1> Who Drives");
                Console.WriteLine(">2> Driver Salary");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.WriteLine("Car ID:");
                    int id = int.Parse(Console.ReadLine());
                    var query = rest.Get<IEnumerable<string>>(id, "/stat/whodrives");
                    foreach(var x in query)
                    {
                        Console.WriteLine(x);
                    }
                    Console.ReadKey();
                }
                else if(choice == "2")
                {
                    Console.WriteLine("Car Id: ");
                    int id = int.Parse(Console.ReadLine());
                    var query = rest.Get<IEnumerable<int>>(id, "/stat/driversalary");
                    foreach(var x in query)
                    {
                        Console.WriteLine(x);
                    }
                    Console.ReadKey();
                }
            }
        }
    }
}
    