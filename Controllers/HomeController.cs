using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Drivers.Models;

namespace Drivers.Controllers
{
    public class HomeController : Controller
    {
        private DriverContext context { get; set; }

        public HomeController(DriverContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var drivers = context.Drivers
                .Include(m => m.Genre)
                .OrderBy(m => m.Name)
                .ToList();
            return View(drivers);
        }
    }
}