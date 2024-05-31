using Microsoft.AspNetCore.Mvc;
using AgriWeb.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace AgriWeb.Controllers
{
    public class FarmersController : Controller
    {
        public static List<Farmer> Farmers = new List<Farmer>(); // Change this line

        public IActionResult Index()
        {
            var role = HttpContext.Session.GetString("Role");
            if (role == "Employee")
            {
                return View(Farmers);
            }
            return Unauthorized();
        }

        public IActionResult Add()
        {
            var role = HttpContext.Session.GetString("Role");
            if (role == "Employee")
            {
                return View();
            }
            return Unauthorized();
        }

        [HttpPost]
        public IActionResult Add(Farmer farmer)
        {
            var role = HttpContext.Session.GetString("Role");
            if (role == "Employee")
            {
                Farmers.Add(farmer);
                return RedirectToAction("Index");
            }
            return Unauthorized();
        }

        public IActionResult ViewProducts(int id)
        {
            var farmer = Farmers.FirstOrDefault(f => f.Id == id);
            if (farmer != null)
            {
                return View(farmer.Products);
            }
            return NotFound();
        }
    }
}
