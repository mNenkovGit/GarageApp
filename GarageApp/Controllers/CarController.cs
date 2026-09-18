using GarageApp.Data;
using GarageApp.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GarageApp.Controllers
{
    public class CarController : Controller
    {
        private readonly GarageDbContext _dbContext;
        public CarController(GarageDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var cars = _dbContext.Cars
                  .Include(c => c.Garage)
                  .OrderBy(c => c.Make)
                  .ThenBy(c => c.Model)
                  .ThenByDescending(c => c.Year)
                  .ToList();

            return View(cars);
        }

        public IActionResult Details (int id)
        {
            var car = _dbContext.Cars
                .Include(c => c.Garage)
                .FirstOrDefault(c => c.Id == id);

            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        public IActionResult Search (string make)
        {
            make = (make ?? string.Empty).Trim();


            var query = _dbContext.Cars.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(make))
            {
                query = query.Where(c => c.Make.Contains(make));
            }
            
            var cars = query
                .OrderBy(c => c.Make)
                .ThenBy (c => c.Model)
                .ToArray();

            return View("Index", cars);
        }

        //public IActionResult Search (string make)
        //{
        //    var cars = _dbContext.Cars
        //        .AsNoTracking()
        //        .Include(c => c.Garage)
        //        .Where(c => c.Make == make)
        //        .ToList();

        //    if (cars.Count == 0)
        //    {
        //        return NotFound();
        //    }
        //    return View(cars);
        //}
    }
}
