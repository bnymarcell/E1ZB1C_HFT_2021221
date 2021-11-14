using E1ZB1C_HFT_2021221.Data;
using E1ZB1C_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E1ZB1C_HFT_2021221.Repository
{
    public class DriverRepository : IDriverRepository
    {
        CompanyDbContext db;
        public DriverRepository(CompanyDbContext db)
        {
            this.db = db;
        }


        public void Create(Driver driver)
        {
            db.Driver.Add(driver);
            db.SaveChanges();
        }

        public Driver Read(int id)
        {
            return db.Driver.FirstOrDefault(t => t.Driver_id == id);
        }

        public IQueryable<Driver> ReadAll()
        {
            return db.Driver;
        }

        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }

        public void Update(Driver driver)
        {
            var olddriver = Read(driver.Driver_id);
            olddriver.Driver_name = driver.Driver_name;
            olddriver.Driver_salary = driver.Driver_salary;
        }
    }
}
