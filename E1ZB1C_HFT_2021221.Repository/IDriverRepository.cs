using E1ZB1C_HFT_2021221.Models;
using System.Linq;

namespace E1ZB1C_HFT_2021221.Repository
{
    public interface IDriverRepository
    {
        void Create(Driver driver);
        void Delete(int id);
        Driver Read(int id);
        IQueryable<Driver> ReadAll();
        void Update(Driver driver);
    }
}