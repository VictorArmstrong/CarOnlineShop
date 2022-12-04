using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarOnlineShop.Data.Models;
using CarOnlineShop.Models;
using Microsoft.EntityFrameworkCore;

namespace CarOnlineShop.Data
{
    public class CarOnlineShopContext : DbContext
    {
        public CarOnlineShopContext (DbContextOptions<CarOnlineShopContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
