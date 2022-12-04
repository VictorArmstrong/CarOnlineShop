using CarOnlineShop.Data.Interfaces;
using CarOnlineShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarOnlineShop.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CarOnlineShopContext _context;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(CarOnlineShopContext context, ShoppingCart shoppingCart)
        {
            _context = context;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            _context.Orders.Add(order);

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;

            foreach (var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = item.Amount,
                    CarId = item.Car.ProductId,
                    OrderId = order.OrderId,
                    Price = item.Car.Price
                };

                _context.OrderDetails.Add(orderDetail);
            }
            _context.SaveChanges();
        }
    }
}
