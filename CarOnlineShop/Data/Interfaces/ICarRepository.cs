using CarOnlineShop.Data.Models;
using CarOnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarOnlineShop.Data.Interfaces
{
    public interface ICarRepository
    {
        IEnumerable<Product> Cars { get; }
        IEnumerable<Product> PreferredCars { get; }

        Product getCar(int Id);
    }
}
