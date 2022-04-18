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

        public Car selectedCar;

        public Car SelectedCar
        {
            get { return selectedCar; }
            set
            {
                selectedCar = new Car()
                {
                    Car_id = value.Car_id,
                    Car_Brand = value.Car_Brand,
                    Car_Type = value.Car_Type,
                    Company_id = value.Company_id,
                    Company = value.Company,
                    Driver = value.Driver
                };
                OnPropertyChanged();
                (DeleteCarCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }
        
        public ICommand CreateCompanyCommand { get; set; }

        public ICommand DeleteCompanyCommand { get; set; }
        
        public ICommand UpdateCompanyCommand { get; set; }


        public ICommand CreateCarCommand { get; set; }
        public ICommand DeleteCarCommand { get; set; }
        public ICommand UpdateCarCommand { get; set; }


        
        public MainWindowViewModel()
        {
            companies = new RestCollection<Company>("https://localhost:44375/","company","hub");
            cars = new RestCollection<Car>("https://localhost:44375/", "company", "hub");

            selectedCar = new Car();
            selectedCompany = new Company();
            
            CreateCompanyCommand = new RelayCommand(() =>
            {
                companies.Add(new Company()
                {
                    Company_name = SelectedCompany.Company_name
                });
            });

            CreateCarCommand = new RelayCommand(() =>
            {
                cars.Add(new Car()
                {
                    //Car_Brand = selectedCar.Car_Brand,
                    Car_Type = selectedCar.Car_Type,
                    //Company = selectedCompany,
                    Company_id = 2,
                    //Driver = selectedCar.Driver,
                });
            });

            UpdateCompanyCommand = new RelayCommand(() =>
            {
                companies.Update(SelectedCompany);
            });

            UpdateCarCommand = new RelayCommand(() =>
            {
                cars.Update(SelectedCar);
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
