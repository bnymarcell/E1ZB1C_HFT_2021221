using E1ZB1C_HFT_2021221.Models;
using E1ZB1C_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E1ZB1C_HFT_2021221.Logic
{
    public class DriverLogic
    {
        IDriverRepository driverRepo;
        public DriverLogic(IDriverRepository driverRepo)
        {
            this.driverRepo = driverRepo;
        }

        public void Create(Driver driver)
        {

            driverRepo.Create(driver);
        }

        public Driver Read(int id)
        {
            return driverRepo.Read(id);
        }

        public IEnumerable<Driver> ReadAll()
        {
            return driverRepo.ReadAll();
        }

        public void Delete(int id)
        {
            driverRepo.Delete(id);
        }

        public void Update(Driver company)
        {
            driverRepo.Update(company);
        }

        //Non CRUD methods

        public IEnumerable<string> DrivesWhat(int id)
        {
            return
            from x in driverRepo.ReadAll()
            where x.Driver_id == id
            select x.car.Car_Brand;
        }


    }
}
