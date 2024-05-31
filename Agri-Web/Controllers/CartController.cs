using Microsoft.AspNetCore.Mvc;

namespace Agri_Web.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
