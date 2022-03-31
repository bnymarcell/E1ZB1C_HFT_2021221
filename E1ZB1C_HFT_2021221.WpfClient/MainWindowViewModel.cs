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

        private Company selectedCompany;

        public Company SelectedCompany
        {
            get { return selectedCompany; }
            set
            {
                SetProperty(ref selectedCompany, value);
                (DeleteCompanyCommand as RelayCommand).NotifyCanExecuteChanged();
            }
            
        }
        
        public ICommand CreateCompanyCommand { get; set; }

        public ICommand DeleteCompanyCommand { get; set; }
        
        public ICommand UpdateCompanyCommand { get; set; }


        
        public MainWindowViewModel()
        {
            companies = new RestCollection<Company>("https://localhost:5001/","company");
            
            
            
            CreateCompanyCommand = new RelayCommand(() =>
            {
                companies.Add(new Company()
                {
                    Company_name = "MenőCég"
                });
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
