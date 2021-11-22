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

        public IEnumerable<string> CarCount(int id)
        {
            return from x in companyRepo.ReadAll()
                   where x.Company_id == id
                   select x.Company_name;
        }

        public IEnumerable<KeyValuePair<string,int>> HowMany(int id)
        {
            return
            from x in companyRepo.ReadAll()
            from y in x.Cars
            where y.Company_id == id
            group y by y.Car_Brand into g
            select new KeyValuePair<string,int>
            (
               g.Key,
               g.Count()
            );
        }  
        
        public IEnumerable<KeyValuePair<string,double>> IDAVG()
        {
            return
            from x in companyRepo.ReadAll()
            from y in x.Cars
            group y by x.Company_name into g
            select new KeyValuePair<string, double>
            (
                g.Key,
                g.Average(t => t.Car_id)
            );
        }


    }
}
