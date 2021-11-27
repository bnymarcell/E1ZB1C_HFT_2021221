using E1ZB1C_HFT_2021221.Models;
using System.Collections.Generic;

namespace E1ZB1C_HFT_2021221.Logic
{
    public interface IDriverLogic
    {
        void Create(Driver driver);
        void Delete(int id);
        IEnumerable<string> DrivesWhat(int id);
        Driver Read(int id);
        IEnumerable<Driver> ReadAll();
        void Update(Driver company);
    }
}