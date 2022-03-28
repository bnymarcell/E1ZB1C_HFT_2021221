using E1ZB1C_HFT_2021221.Models;
using E1ZB1C_HFT_2021221.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E1ZB1C_HFT_2021221.WpfClient
{
    internal class MainWindowViewModel
    {
        public RestCollection<Company> companies { get; set; }

        public MainWindowViewModel()
        {
            companies = new RestCollection<Company>("https://localhost:5001/","company");
        }
    }
}
