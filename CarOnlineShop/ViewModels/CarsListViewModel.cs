using CarOnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarOnlineShop.ViewModels
{
    public class CarsListViewModel
    {
        public IEnumerable<Product> Cars { get; set; }
        public string CurrentCategory { get; set; }
    }
}
