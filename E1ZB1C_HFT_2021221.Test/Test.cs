using E1ZB1C_HFT_2021221.Logic;
using E1ZB1C_HFT_2021221.Models;
using E1ZB1C_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E1ZB1C_HFT_2021221.Test
{
    [TestFixture]
    public class Test
    {
        CompanyLogic cl1;
        CarLogic carl1;
        DriverLogic dl1;
        public Test()
        {
            var mockCompanyRepo = new Mock<ICompanyRepository>();
            mockCompanyRepo.Setup(x => x.Create(It.IsAny<Company>()));

            var mockCarRepo = new Mock<ICarRepository>();
            mockCarRepo.Setup(x => x.Create(It.IsAny<Car>()));

            var mockDriverRepo = new Mock<IDriverRepository>();
            mockDriverRepo.Setup(x => x.Create(It.IsAny<Driver>()));

            Company fakeCompany1 = new Company { Company_id = 1, Company_name = "KamuTaxi" };
            Company fakeCompany2 = new Company { Company_id = 2, Company_name = "HabiTaxi" };
            Driver fakeDriver1 = new Driver
            {
                Driver_id = 1,
                Driver_name = "Vajk",
                Driver_salary = 250,
                Car_id = 1,
            };
            Driver fakeDriver2 = new Driver
            {
                Driver_id = 2,
                Driver_name = "Pista",
                Driver_salary = 267,
                Car_id = 2,
            };
            Driver fakeDriver3 = new Driver
            {
                Driver_id = 3,
                Driver_name = "Miklós",
                Driver_salary = 123,
                Car_id = 3,
            };
            Driver fakeDriver4 = new Driver
            {
                Driver_id = 4,
                Driver_name = "László",
                Driver_salary = 111,
                Car_id = 4,
            };


            Car fakeCar1 = new Car
            {
                Car_id = 1,
                Car_Brand = "Skoda",
                Car_Type = "Sedan",
                Company_id = 1,
                Company = fakeCompany1,
                Driver = fakeDriver1
            };

            Car fakeCar2 = new Car
            {
                Car_id = 2,
                Car_Brand = "Renault",
                Car_Type = "Kombi",
                Company_id = 1,
                Company = fakeCompany1,
                Driver = fakeDriver2
            };

            Car fakeCar3 = new Car
            {
                Car_id = 3,
                Car_Brand = "Seat",
                Car_Type = "Sedan",
                Company_id = 2,
                Company = fakeCompany2,
                Driver = fakeDriver3
            };

            Car fakecar4 = new Car
            {
                Car_id = 4,
                Car_Brand = "Subaru",
                Car_Type = "Hatchback",
                Company_id = 2,
                Company = fakeCompany2,
                Driver = fakeDriver4
            };

            
            Company fakecomp3 = new Company { Cars = { fakeCar1, fakeCar2 }, Company_id = 3, Company_name = "MIVAN?" };

            var companies = new List<Company>()
            {
                fakeCompany1,
                fakeCompany2,
                fakecomp3
            }.AsQueryable();
            var cars = new List<Car>()
            {
               fakeCar1, fakeCar2, fakeCar3, fakecar4
            }.AsQueryable();

            var drivers = new List<Driver>()
            {
                fakeDriver1, fakeDriver2, fakeDriver3, fakeDriver4
            }.AsQueryable();

            mockCompanyRepo.Setup(x => x.ReadAll()).Returns(companies);
            mockCarRepo.Setup(x => x.ReadAll()).Returns(cars);
            mockDriverRepo.Setup(x => x.ReadAll()).Returns(drivers);

            cl1 = new CompanyLogic(mockCompanyRepo.Object);
            carl1 = new CarLogic(mockCarRepo.Object);
            dl1 = new DriverLogic(mockDriverRepo.Object);
        }


        [Test]
        public void WhoDrivesTest()
        {
            Assert.That(carl1.WhoDrives(2).FirstOrDefault(), Is.EqualTo("Pista"));
        }
        [Test]
        public void DriverSalaryTest()
        {
            Assert.That(carl1.DriverSalary(2).FirstOrDefault(), Is.EqualTo(267));
        }
        [Test]
        public void IDAVGTest()
        {
            IEnumerable<KeyValuePair<string,double>> expected = 
            from x in cl1.ReadAll()
            from y in x.Cars
            group y by x.Company_name into g
            select new KeyValuePair<string, double>
            (
                g.Key,
                g.Average(t => t.Car_id)
            );

            Assert.That(cl1.IDAVG(), Is.EqualTo(expected));

        }
        [Test]
        public void HowManyTest()
        {
            IEnumerable<KeyValuePair<string,int>> expected = 
                from x in cl1.ReadAll()
                from y in x.Cars
                where y.Company_id == 1
                group y by y.Car_Brand into g
                select new KeyValuePair<string, int>
                (
                    g.Key,
                    g.Count()
                );
            Assert.That(cl1.HowMany(1), Is.EqualTo(expected));
        }

        [Test]
        public void HowmanyCars()
        {
            Assert.That(cl1.CarCount(3).FirstOrDefault(), Is.EqualTo("MIVAN?"));
        }

        [Test]
        public void DriverisNotNull()
        {
            Assert.NotNull(carl1.GetDriverName(1).FirstOrDefault());
        }

        [Test]
        public void NullException()
        {
            try
            {
                carl1.Delete(98);
            }
            catch (Exception e)
            {

                Assert.Fail("Expected no exception, but got" + e.Message);
                Console.WriteLine(e.Message);
            }
                
        }

        [Test]
        public void NewTest()
        {

        }
    }
    

}
