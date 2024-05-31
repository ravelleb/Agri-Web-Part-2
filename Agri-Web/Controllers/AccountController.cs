using Microsoft.AspNetCore.Mvc;
using Agri_Web.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Collections.Generic;
using AgriWeb.Models;

namespace Agri_Web.Controllers
{
    public class AccountController : Controller
    {
        private static List<User> Users = new List<User>
        {
            new User { Id = 1, Username = "farmer", Password = "password", Role = Role.Farmer },
            new User { Id = 2, Username = "employee", Password = "password", Role = Role.Employee }
        };

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                HttpContext.Session.SetString("Username", user.Username);
                HttpContext.Session.SetString("Role", user.Role.ToString());
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "Invalid login attempt";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string username, string password, string role)
        {
            if (Users.Any(u => u.Username == username))
            {
                ViewBag.Error = "Username already exists";
                return View();
            }

            var userRole = (Role)Enum.Parse(typeof(Role), role, true);
            Users.Add(new User { Id = Users.Count + 1, Username = username, Password = password, Role = userRole });
            ViewBag.Success = "Registration successful. You can now login.";
            return View("Login");
        }
    }
}
