using Microsoft.AspNetCore.Mvc;

namespace Agri_Web.Models
{
    public class CartItem : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
