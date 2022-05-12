using E1ZB1C_HFT_2021221.Data;
using E1ZB1C_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace E1ZB1C_HFT_2021221.Repository
{
    public class CarRepository : ICarRepository
    {
        CompanyDbContext db;
        

        public CarRepository(CompanyDbContext db)
        {
            this.db = db;
        }


        public void Create(Car car)
        {
            db.Cars.Add(car);
            db.SaveChanges();
        }

        public Car Read(int id)
        {
            return db.Cars.FirstOrDefault(t => t.Car_id == id);
        }

        public IQueryable<Car> ReadAll()
        {
            return db.Cars;
        }

        public void Delete(int id)
        {
            db.Set<Car>().Remove(Read(id));
            db.SaveChanges();
        }

        public void Update(Car car)
        {
            var oldcar = Read(car.Car_id);
            if (oldcar == null)
            {
                throw new ArgumentException("Item doesn't exist");
            }

            foreach (var prop in oldcar.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(oldcar, prop.GetValue(car));
                }
            }
            db.SaveChanges();
        }
    }
}
