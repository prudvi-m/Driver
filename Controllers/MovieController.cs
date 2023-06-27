using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Drivers.Models;

namespace Drivers.Controllers
{
    public class DriverController : Controller
    {
        private DriverContext context { get; set; }

        public DriverController(DriverContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Genres = context.Genres.OrderBy(g => g.Name).ToList();
            return View("Edit", new Driver());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Genres = context.Genres.OrderBy(g => g.Name).ToList();
            var driver = context.Drivers.Find(id);
            return View(driver);
        }

        [HttpPost]
        public IActionResult Edit(Driver driver)
        {
            if (ModelState.IsValid)
            {
                if (driver.DriverId == 0) 
                    context.Drivers.Add(driver);
                else 
                    context.Drivers.Update(driver);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (driver.DriverId == 0) ? "Add": "Edit";
                ViewBag.Genres = context.Genres.OrderBy(g => g.Name).ToList();
                return View(driver);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var driver = context.Drivers.Find(id);
            return View(driver);
        }

        [HttpPost]
        public IActionResult Delete(Driver driver)
        {
            context.Drivers.Remove(driver);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}