using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarOnlineShop.Data.Interfaces;
using CarOnlineShop.Data.Models;
using CarOnlineShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarOnlineShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ICarRepository _carRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(ICarRepository carRepository, ShoppingCart shoppingCart)
        {
            _carRepository = carRepository;
            _shoppingCart = shoppingCart;
        }

        // GET: /<controller>/
        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var sCVM = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartItemTotal()
            };

            return View(sCVM);            
        }

        public RedirectToActionResult AddToShoppingCart(int carId)
        {
            var selectedCar = _carRepository.Cars.FirstOrDefault(f => f.ProductId == carId);

            if(selectedCar != null)
            {
                _shoppingCart.AddToCart(selectedCar, 1);
            }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int carId)
        {
            var selectedCar = _carRepository.Cars.FirstOrDefault(f => f.ProductId == carId);
            if(selectedCar != null)
            {
                _shoppingCart.RemoveFromCart(selectedCar);
            }

            return RedirectToAction("Index");
        }
    }
}
