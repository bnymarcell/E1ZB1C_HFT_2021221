using E1ZB1C_HFT_2021221.Models;
using System.Collections.Generic;

namespace E1ZB1C_HFT_2021221.Logic
{
    public interface ICompanyLogic
    {
        IEnumerable<string> CarCount(int id);
        void Create(Company company);
        void Delete(int id);
        IEnumerable<KeyValuePair<string, int>> HowMany(int id);
        IEnumerable<KeyValuePair<string, double>> IDAVG();
        Company Read(int id);
        IEnumerable<Company> ReadAll();
        void Update(Company company);
    }
}