using E1ZB1C_HFT_2021221.Models;
using E1ZB1C_HFT_2021221.Repository;
using System;
using System.Linq;
using System.Collections.Generic;

namespace E1ZB1C_HFT_2021221.Logic
{
    public class CompanyLogic
    {
        ICompanyRepository companyRepo;
        public CompanyLogic(ICompanyRepository companyRepo)
        {
            this.companyRepo = companyRepo;
        }

        public void Create(Company company)
        {

            companyRepo.Create(company);
        }

        public Company Read(int id)
        {
            return companyRepo.Read(id);
        }

        public IEnumerable<Company> ReadAll()
        {
            return companyRepo.ReadAll();
        }

        public void Delete(int id)
        {
            companyRepo.Delete(id);
        }   

        public void Update(Company company)
        {
            companyRepo.Update(company);
        }



        //Non CRUD methods

        public IQueryable EarnsMost()
        {
            return 
            from x in companyRepo.ReadAll()
            group x by x.Company_name into g
            select new
            {
                CompanyName = g.Key,
                CompanyAVGid = g.Average(t => t.Company_id)
            };
        }   


    }
}
