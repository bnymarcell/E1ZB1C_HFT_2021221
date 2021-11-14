using E1ZB1C_HFT_2021221.Models;
using System.Linq;

namespace E1ZB1C_HFT_2021221.Repository
{
    public interface ICompanyRepository
    {
        void Create(Company company);
        void Delete(int id);
        Company Read(int id);
        IQueryable<Company> ReadAll();
        void Update(Company company);
    }
}