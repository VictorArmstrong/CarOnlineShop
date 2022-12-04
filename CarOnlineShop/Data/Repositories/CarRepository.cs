using CarOnlineShop.Data.Interfaces;
using CarOnlineShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarOnlineShop.Data.Repositories
{
    public class CarRepository : ICarRepository
    {        
        private readonly CarOnlineShopContext _context;

        public CarRepository(CarOnlineShopContext context)
        {
            _context = context;
        }


        public IEnumerable<Product> Cars => _context.Product.Include(c => c.Category);

        public IEnumerable<Product> PreferredCars => _context.Product.Where(p => p.IsPreferredCar == true).Include(c => c.Category);


        public Product getCar(int Id) => _context.Product.FirstOrDefault(i => i.ProductId == Id);
        
    }
}
