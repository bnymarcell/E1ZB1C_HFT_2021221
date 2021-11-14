using E1ZB1C_HFT_2021221.Data;
using E1ZB1C_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            db.Remove(Read(id));
            db.SaveChanges();
        }

        public void Update(Car car)
        {
            var oldcar = Read(car.Car_id);
            oldcar.Car_Brand = car.Car_Brand;
            oldcar.Car_Type = car.Car_Type;

        }
    }
}
