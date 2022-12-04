using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarOnlineShop.Models;
using CarOnlineShop.Data.Interfaces;
using CarOnlineShop.ViewModels;

namespace CarOnlineShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarRepository _carRepository;

        public HomeController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                PreferredCars = _carRepository.PreferredCars
            };

            return View(homeViewModel);
        }       

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
