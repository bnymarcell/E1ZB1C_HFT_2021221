using E1ZB1C_HFT_2021221.Models;
using E1ZB1C_HFT_2021221.RestClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace E1ZB1C_HFT_2021221.WpfClient
{
    internal class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<Company> companies { get; set; }
        public RestCollection<Car> cars { get; set; }
        
        public RestCollection<Driver> drivers { get; set; }

        public Company selectedCompany;

        public Company SelectedCompany
        {
            get { return selectedCompany; }
            set
            {
                if (value != null)
                {
                    selectedCompany = new Company()
                    {
                        Company_name = value.Company_name,
                        Company_id = value.Company_id
                    };
                    OnPropertyChanged();
                    (DeleteCompanyCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public Driver selectedDriver;

        public Driver SelectedDriver
        {
            get { return selectedDriver; }
            set
            {
                if (value != null)
                {
                    selectedDriver = new Driver()
                    {
                        Driver_id = value.Driver_id,
                        Driver_name = value.Driver_name,
                        Driver_salary = value.Driver_salary,
                        Car_id = value.Car_id
                    };
                    OnPropertyChanged();
                    (DeleteDriverCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public Car selectedCar;

        public Car SelectedCar
        {
            get { return selectedCar; }
            set
            {
                if (value != null)
                {
                    selectedCar = new Car()
                    {
                        Car_id = value.Car_id,
                        Car_Brand = value.Car_Brand,
                        Car_Type = value.Car_Type,
                        Company_id = value.Company_id,

                    };
                    OnPropertyChanged();
                    (DeleteCarCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        
        public ICommand CreateCompanyCommand { get; set; }

        public ICommand DeleteCompanyCommand { get; set; }
        
        public ICommand UpdateCompanyCommand { get; set; }


        public ICommand CreateCarCommand { get; set; }
        public ICommand DeleteCarCommand { get; set; }
        public ICommand UpdateCarCommand { get; set; }

        public ICommand CreateDriverCommand { get; set; }
        public ICommand DeleteDriverCommand { get; set; }
        public ICommand UpdateDriverCommand { get; set; }



        public MainWindowViewModel()
        {
            companies = new RestCollection<Company>("https://localhost:50212/", "company","hub");
            cars = new RestCollection<Car>("https://localhost:50212/", "company", "hub");
            drivers = new RestCollection<Driver>("https://localhost:50212/", "driver", "hub");

            selectedCar = new Car();
            selectedCompany = new Company();
            selectedDriver = new Driver();
            
            CreateCompanyCommand = new RelayCommand(() =>
            {
                companies.Add(new Company()
                {
                    Company_name = SelectedCompany.Company_name
                });
            });

            CreateDriverCommand = new RelayCommand(() =>
            {
                drivers.Add(new Driver()
                {
                    Driver_name = SelectedDriver.Driver_name,
                    Car_id = 10,
                }) ;
            });

            CreateCarCommand = new RelayCommand(() =>
            {
                cars.Add(new Car()
                {
                    Car_Type = selectedCar.Car_Type,
                    Company_id = 2,
                }) ;
            });

            UpdateCompanyCommand = new RelayCommand(() =>
            {
                companies.Update(SelectedCompany);
            });

            UpdateDriverCommand = new RelayCommand(() =>
            {
                drivers.Update(SelectedDriver);
            });

            UpdateCarCommand = new RelayCommand(() =>
            {
                cars.Update(SelectedCar);
            });

            DeleteDriverCommand = new RelayCommand(() =>
            {
                drivers.Delete(SelectedDriver.Driver_id);
            },
            () =>
            {
                return SelectedCompany != null;
            });

            DeleteCompanyCommand = new RelayCommand(() =>
            {
                companies.Delete(SelectedCompany.Company_id);
            }, 
            ()=>
            {
                return SelectedCompany != null;
            });

            DeleteCarCommand = new RelayCommand(() =>
            {
                cars.Delete(SelectedCar.Car_id);
            },
            ()=>
            {
                return SelectedCar != null;
            });
        }
    }
}
