using CarOnlineShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarOnlineShop.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string  ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public bool IsPreferredCar { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
