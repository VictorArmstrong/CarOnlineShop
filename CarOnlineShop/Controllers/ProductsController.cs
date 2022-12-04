using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarOnlineShop.Models;
using CarOnlineShop.Data.Models;
using Microsoft.AspNetCore.Http;
using CarOnlineShop.Data.Interfaces;
using CarOnlineShop.ViewModels;

namespace CarOnlineShop.Controllers
{
    public class ProductsController : Controller
    {        
        private readonly ICarRepository _carRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductsController(ICarRepository carRepository, ICategoryRepository categoryRepository)
        {
            _carRepository = carRepository;
            _categoryRepository = categoryRepository;           
        }

        // GET: Products
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Product> cars;

            string currentCategory = string.Empty;

            if(string.IsNullOrEmpty(category))
            {
                cars = _carRepository.Cars.OrderBy(o => o.ProductId);
                currentCategory = "All cars";
            }
            else
            {
                if(string.Equals("Hyundai", _category, StringComparison.OrdinalIgnoreCase)) 
                {
                    cars = _carRepository.Cars.Where(w => w.Category.CategoryName.Equals("Hyundai")).OrderBy(o => o.Name);
                }
                else if (string.Equals("Toyota", _category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _carRepository.Cars.Where(w => w.Category.CategoryName.Equals("Toyota")).OrderBy(o => o.Name);
                }
                else
                {
                    cars = _carRepository.Cars.Where(w => w.Category.CategoryName.Equals("Subaru")).OrderBy(o => o.Name);
                }

                currentCategory = _category;
            }
            
            var carsListViewModel = new CarsListViewModel
            {
                Cars = cars,
                CurrentCategory = currentCategory
            };
            
            return View(carsListViewModel);
        }

        // GET: Products/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var product = await _context.Product
        //        .Include(p => p.Category)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(product);
        //}

        // GET: Products/Create
        //public IActionResult Create()
        //{
        //    ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "CategoryId", "CategoryId");
        //    return View();
        //}

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,ImageUrl,ImageThumbnailUrl,IsPreferredCar,CategoryId")] Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(product);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(List));
        //    }
        //    ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "CategoryId", "CategoryId", product.CategoryId);
        //    return View(product);
        //}

        // GET: Products/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var product = await _context.Product.FindAsync(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "CategoryId", "CategoryId", product.CategoryId);
        //    return View(product);
        //}

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,ImageUrl,ImageThumbnailUrl,IsPreferredCar,CategoryId")] Product product)
        //{
        //    if (id != product.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(product);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ProductExists(product.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(List));
        //    }
        //    ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "CategoryId", "CategoryId", product.CategoryId);
        //    return View(product);
        //}

        // GET: Products/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var product = await _context.Product
        //        .Include(p => p.Category)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(product);
        //}

        // POST: Products/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var product = await _context.Product.FindAsync(id);
        //    _context.Product.Remove(product);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(List));
        //}

        //private bool ProductExists(int id)
        //{
        //    return _context.Product.Any(e => e.Id == id);
        //}
    }
}
