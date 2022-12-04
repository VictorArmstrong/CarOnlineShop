using CarOnlineShop.Data.Interfaces;
using CarOnlineShop.Data.Models;
using CarOnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarOnlineShop.Data.Repositories
{
    public class category : ICategoryRepository
    {
        public CarOnlineShopContext _context;

        public category(CarOnlineShopContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> Categories => _context.Category;
    }
}
