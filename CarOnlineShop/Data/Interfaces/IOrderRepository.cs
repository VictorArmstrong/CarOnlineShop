using CarOnlineShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarOnlineShop.Data.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
