using CarOnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarOnlineShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Product> PreferredCars { get; set; }
    }
}
