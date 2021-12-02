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

            }
        }
    }
}
    