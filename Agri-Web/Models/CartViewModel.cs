using Microsoft.AspNetCore.Mvc;

namespace Agri_Web.Models
{
    public class CartViewModel : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
