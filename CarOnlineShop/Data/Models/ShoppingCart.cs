using CarOnlineShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarOnlineShop.Data.Models
{
    public class ShoppingCart
    {
        private readonly CarOnlineShopContext _contex;

        private ShoppingCart(CarOnlineShopContext contex)
        {
            _contex = contex;
        }

        public string  ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public static ShoppingCart GetCart(IServiceProvider provider)
        {
            ISession session = provider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var contex = provider.GetService<CarOnlineShopContext>();
            string cartId = session.GetString("cartId") ?? Guid.NewGuid().ToString();

            session.SetString("cartId", cartId);

            return new ShoppingCart(contex) { ShoppingCartId = cartId };
        }

        public void AddToCart(Product car, int amount)
        {
            var ShoppingCartItem = _contex.ShoppingCartItems.SingleOrDefault(c => c.Car.ProductId == car.ProductId && c.ShoppingCartId == ShoppingCartId);

            if(ShoppingCartItem == null)
            {
                ShoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Car = car,
                    Amount = 1
                };
                _contex.ShoppingCartItems.Add(ShoppingCartItem);                
            }
            else
            {
                ShoppingCartItem.Amount++;
            }

            _contex.SaveChanges();
        }

        public int RemoveFromCart(Product car)
        {
            var ShoppingCartItem = _contex.ShoppingCartItems.SingleOrDefault(s => s.Car.ProductId == car.ProductId && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if(ShoppingCartItem !=null)
            {
                if (ShoppingCartItem.Amount > 1)
                {
                    ShoppingCartItem.Amount--;
                    localAmount = ShoppingCartItem.Amount;
                }
                else
                {
                    _contex.ShoppingCartItems.Remove(ShoppingCartItem);
                }
            }

            _contex.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                (ShoppingCartItems =
                    _contex.ShoppingCartItems.Where(w => w.ShoppingCartId == ShoppingCartId)
                    .Include(i => i.Car)
                    .ToList());
        }

        public void ClearCart()
        {
            var cartItems = _contex.ShoppingCartItems.Where(w => w.ShoppingCartId == ShoppingCartId);
            _contex.ShoppingCartItems.RemoveRange(cartItems);

            _contex.SaveChanges();
        }

        public decimal GetShoppingCartItemTotal()
        {
            var total = _contex.ShoppingCartItems.Where(w => w.ShoppingCartId == ShoppingCartId).Select(s => s.Car.Price * s.Amount).Sum();

            return total;
        }
    }
    
}
