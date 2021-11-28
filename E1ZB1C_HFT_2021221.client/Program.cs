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

            RestService rest = new RestService("http://localhost:50212");

            var cars = rest.Get<Car>("car");
            

           
        }

    }
}
    