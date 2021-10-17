using E1ZB1C_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E1ZB1C_HFT_2021221.Data
{
    class CompanyDbContext : DbContext
    {
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Driver> Driver {get;set;}

        public CompanyDbContext()
        {
            Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.
                    UseLazyLoadingProxies().
                    UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            }
        }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Company FoTaxi = new Company { Company_id = 1, Company_name = "FőTaxi" };
            Company CityTaxi = new Company { Company_id = 2, Company_name = "CityTaxi" };
            Company PestFuvar = new Company { Company_id = 3, Company_name = "PestFuvar" };

            Car taxi1 = new Car { Car_id = 1, Car_Brand = "Citroen", Car_Type = "Sedan", Driver_id = 1, Company_id = 1 };
            Car taxi2 = new Car { Car_id = 2, Car_Brand = "Peugeot", Car_Type = "Kombi", Driver_id = 2, Company_id = 1 };
            Car taxi3 = new Car { Car_id = 3, Car_Brand = "Renault", Car_Type = "Hatch Back", Driver_id = 3, Company_id = 2 };
            Car taxi4 = new Car { Car_id = 4, Car_Brand = "Seat", Car_Type = "Sedan", Driver_id = 4, Company_id = 2 };
            Car taxi5 = new Car { Car_id = 5, Car_Brand = "Renault", Car_Type = "Kombi", Driver_id = 5, Company_id = 3 };
            Car taxi6 = new Car { Car_id = 6, Car_Brand = "Skoda", Car_Type = "Sedan", Driver_id = 5, Company_id = 3 };

            Driver driver1 = new Driver { Driver_id = 1, Driver_name = "Sanyi", Driver_salary = 200000 };
            Driver driver2 = new Driver { Driver_id = 2, Driver_name = "Pista", Driver_salary = 200000 };
            Driver driver3 = new Driver { Driver_id = 3, Driver_name = "Karcsi", Driver_salary = 200000 };
            Driver driver4 = new Driver { Driver_id = 4, Driver_name = "József", Driver_salary = 200000 };
            Driver driver5 = new Driver { Driver_id = 5, Driver_name = "Elemér", Driver_salary = 200000 };
            Driver driver6 = new Driver { Driver_id = 6, Driver_name = "Demeter", Driver_salary = 200000 };

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasMany(Company => Cars)
                      .WithOne(Car => Car.Company);
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasOne(Car => Car.driver)
                      .WithOne(Driver => Driver.car);
            });

            modelBuilder.Entity<Company>().HasData(FoTaxi,PestFuvar, CityTaxi);
            modelBuilder.Entity<Car>().HasData(taxi1,taxi2,taxi3,taxi4,taxi5,taxi6);
            modelBuilder.Entity<Driver>().HasData(driver1,driver2,driver3,driver4,driver5,driver6);

        }
    }
}
