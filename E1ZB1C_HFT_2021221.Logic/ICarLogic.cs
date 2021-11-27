using E1ZB1C_HFT_2021221.Models;
using System.Collections.Generic;

namespace E1ZB1C_HFT_2021221.Logic
{
    public interface ICarLogic
    {
        void Create(Car car);
        void Delete(int id);
        IEnumerable<int> DriverSalary(int id);
        Car Read(int id);
        IEnumerable<Car> ReadAll();
        void Update(Car car);
        IEnumerable<string> WhoDrives(int id);
    }
}