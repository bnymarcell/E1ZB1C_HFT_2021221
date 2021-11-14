﻿using E1ZB1C_HFT_2021221.Data;
using E1ZB1C_HFT_2021221.Models;
using System;
using System.Linq;

namespace E1ZB1C_HFT_2021221.Repository
{
    public class CompanyRepository
    {
        CompanyDbContext db;

        public CompanyRepository(CompanyDbContext db)
        {
            this.db = db;
        }


        public void Create(Company company)
        {
            db.Companies.Add(company);
            db.SaveChanges();
        }

        public Company Read(int id)
        {
            return db.Companies.FirstOrDefault(t => t.Company_id == id);
        }
        
        public IQueryable<Company> ReadAll()
        {
            return db.Companies;
        }

        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }

        public void Update(Company company)
        {
            var oldcompany = Read(company.Company_id);
            oldcompany.Company_name = company.Company_name;
            oldcompany.Cars = company.Cars;

        }
    }
}