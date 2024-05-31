using Microsoft.AspNetCore.Mvc;
using AgriWeb.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace AgriWeb.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            var role = HttpContext.Session.GetString("Role");
            if (role == "Farmer")
            {
                var username = HttpContext.Session.GetString("Username");
                var farmer = FarmersController.Farmers.FirstOrDefault(f => f.Name == username);
                if (farmer != null)
                {
                    return View(farmer.Products);
                }
                return NotFound();
            }
            else if (role == "Employee")
            {
                return View(FarmersController.Farmers.SelectMany(f => f.Products));
            }
            return Unauthorized();
        }

        public IActionResult Add()
        {
            var role = HttpContext.Session.GetString("Role");
            if (role == "Farmer")
            {
                return View();
            }
            return Unauthorized();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            var role = HttpContext.Session.GetString("Role");
            if (role == "Farmer")
            {
                var username = HttpContext.Session.GetString("Username");
                var farmer = FarmersController.Farmers.FirstOrDefault(f => f.Name == username);
                if (farmer != null)
                {
                    farmer.Products.Add(product);
                    return RedirectToAction("Index");
                }
                return NotFound();
            }
            return Unauthorized();
        }
    }
}
