﻿using E1ZB1C_HFT_2021221.Models;
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
        
        public RestCollection<Car> cars { get; set; }

        public Car selectedCar;

        public Car SelectedCar
        {
            get { return SelectedCar; }
            set
            {
                if (value != null)
                {
                    selectedCar = new Car()
                    {
                        Car_id = value.Car_id,
                        Car_Brand = value.Car_Brand,
                        Car_Type = value.Car_Type
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
        
        public ICommand UpdateCarCommand { get; set; }
        
        public ICommand DeleteCarCommand { get; set; }

        
        public MainWindowViewModel()
        {
            companies = new RestCollection<Company>("https://localhost:5001/","company","hub");

            selectedCompany = new Company();
            
            CreateCompanyCommand = new RelayCommand(() =>
            {
                companies.Add(new Company()
                {
                    Company_name = SelectedCompany.Company_name
                });
            });

            selectedCar = new Car();
            cars = new RestCollection<Car>("https://localhost:5001", "Car", "hub");

            CreateCarCommand = new RelayCommand(() =>
            {
                cars.Add(new Car()
                {
                    Car_id = selectedCar.Car_id
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
                () =>
                {
                    return SelectedCar != null;
                });

        }
    }
}
