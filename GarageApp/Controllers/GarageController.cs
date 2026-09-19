using GarageApp.Data;
using GarageApp.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GarageApp.Controllers
{
    public class GarageController : Controller
    {
        private readonly GarageDbContext _dbContext;

        public GarageController(GarageDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ICollection<Garage> garages = _dbContext.Garages
                .Include(g => g.Cars)
                .OrderBy(g => g.Name)
                .ThenBy(g => g.Location)
                .Take(25)
                .ToList();
            return View(garages);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if(id <= 0)
            {
                return BadRequest("Id must be positive number!");
            }

            var garage = _dbContext.Garages
                         .Include(g => g.Cars)
                         .SingleOrDefault(g => g.Id == id);

            if (garage == null)
            {
                return NotFound("The garage was not found. Try again!");
            }
            return View(garage);
        }
    }
}
