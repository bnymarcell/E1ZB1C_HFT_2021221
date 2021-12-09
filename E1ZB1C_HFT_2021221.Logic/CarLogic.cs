using E1ZB1C_HFT_2021221.Models;
using E1ZB1C_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E1ZB1C_HFT_2021221.Logic
{
    public class CarLogic : ICarLogic
    {
        ICarRepository carRepo;
        public CarLogic(ICarRepository carRepo)
        {
            this.carRepo = carRepo;
        }

        public void Create(Car car)
        {

            carRepo.Create(car);
        }

        public Car Read(int id)
        {
            return carRepo.Read(id);
        }

        public IEnumerable<Car> ReadAll()
        {
            return carRepo.ReadAll();
        }

        public void Delete(int id)
        {
            carRepo.Delete(id);
        }

        public void Update(Car car)
        {
            carRepo.Update(car);
        }

        //Non CRUD methods

        public IEnumerable<string> WhoDrives(int id)
        {
            return
            from x in carRepo.ReadAll()
            where x.Car_id == id
            select x.Driver.Driver_name;
        }

        public IEnumerable<int> DriverSalary(int id)
        {
            return
            from x in carRepo.ReadAll()
            where x.Car_id == id
            select x.Driver.Driver_salary;
        }


        public IEnumerable<string> GetDriverName(int id)
        {
            return
                from x in carRepo.ReadAll()
                where x.Car_id == id
                select x.Driver.Driver_name.ToString();
        }

    }
}
