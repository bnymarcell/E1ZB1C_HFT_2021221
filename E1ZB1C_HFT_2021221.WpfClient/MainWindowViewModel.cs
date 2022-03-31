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
        
        public ICommand CreateCompanyCommand { get; set; }

        public ICommand DeleteCompanyCommand { get; set; }
        
        public ICommand UpdateCompanyCommand { get; set; }


        
        public MainWindowViewModel()
        {
            companies = new RestCollection<Company>("https://localhost:5001/","company");

            selectedCompany = new Company();
            
            CreateCompanyCommand = new RelayCommand(() =>
            {
                companies.Add(new Company()
                {
                    Company_name = SelectedCompany.Company_name
                });
            });

            UpdateCompanyCommand = new RelayCommand(() =>
            {
                companies.Update(SelectedCompany);
            });

            DeleteCompanyCommand = new RelayCommand(() =>
            {
                companies.Delete(SelectedCompany.Company_id);
            }, 
                ()=>
            {
                return SelectedCompany != null;
            });
        }
    }
}
