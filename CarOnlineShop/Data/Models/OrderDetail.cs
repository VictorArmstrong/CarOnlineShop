﻿using CarOnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarOnlineShop.Data.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }       
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public int CarId { get; set; }
        public virtual Product Car { get; set; }
        public virtual Order Order { get; set; }
    }
}
