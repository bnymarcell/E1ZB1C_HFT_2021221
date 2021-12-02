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
            Console.WriteLine(">3> Update an existing item");
            Console.WriteLine(">4> Delete and existing item");

        }

    }
}
    