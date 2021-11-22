using System;
using E1ZB1C_HFT_2021221.Data;
using System.Collections.Generic;
using System.Linq;
using E1ZB1C_HFT_2021221.Logic;
using E1ZB1C_HFT_2021221.Repository;

namespace E1ZB1C_HFT_2021221.client
{
    class Program
    {
        static void Main(string[] args)
        {
            CompanyDbContext db = new CompanyDbContext();

            CompanyLogic cl = new CompanyLogic(new CompanyRepository(db));
            CarLogic carl = new CarLogic(new CarRepository(db));
            DriverLogic dl = new DriverLogic(new DriverRepository(db));
            var g = cl.HowMany(3);
            var t = cl.IDAVG();
            var z = carl.WhoDrives(6);
            var e = dl.DrivesWhat(6);
            var s = carl.DriverSalary(6);
            ;
        }

    }
}
    