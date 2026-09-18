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

        public IActionResult Index()
        {
            ICollection<Garage> garages = _dbContext.Garages
                .Include(g => g.Cars)
                .OrderBy(g => g.Name)
                .ToList();
            return View(garages);
        }

        public IActionResult Details(int id)
        {
            var garage = _dbContext.Garages
                         .Include(g => g.Cars)
                         .FirstOrDefault(g => g.Id == id);

            if (garage == null)
            {
                return NotFound();
            }
            return View(garage);
        }
    }
}
