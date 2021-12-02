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
            switch (Console.ReadLine())
            {
                case "1":
                    Create();
                    return true;
                case "2":
                    GetAll();
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
                    Console.WriteLine("Car_ID: " + x.Car_id + " " + "Car Brand: " + x.Car_Brand +" " + "Car Type: ");
                }
            }
        }

    }
}
    