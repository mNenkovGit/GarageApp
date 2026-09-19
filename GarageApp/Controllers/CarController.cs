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

        /*optional add attributes to specify the request*/

        [HttpGet]
        public IActionResult Index(string? make)
        {
            var query = _dbContext.Cars
                  .Include(c => c.Garage)
                  .OrderBy(c => c.Make)
                  .ThenBy(c => c.Model)
                  .ThenByDescending(c => c.Year)
                  .Take(25);

            if (!string.IsNullOrEmpty(make))
            {
                query = query
                    .Where(c => c.Make.ToString().ToLower().Contains(make.ToLower()));
            }
            
              var cars = query
                  .ToList();

            return View(cars);
        }

        [HttpGet]
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
    }
}
