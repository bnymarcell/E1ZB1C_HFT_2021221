using E1ZB1C_HFT_2021221.Models;
using System.Linq;

namespace E1ZB1C_HFT_2021221.Repository
{
    public interface ICarRepository
    {
        void Create(Car car);
        void Delete(int id);
        Car Read(int id);
        IQueryable<Car> ReadAll();
        void Update(Car car);
    }
}