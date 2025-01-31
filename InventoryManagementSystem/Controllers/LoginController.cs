using Microsoft.AspNetCore.Mvc;
using InventoryManagementSystem.Models;
using System.Linq;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace InventoryManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home"); // Redirect to Index.cshtml after logout
        }


        [HttpPost]
        public IActionResult Authenticate(User user)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Email == user.Email && u.PasswordHash == user.PasswordHash);
            if (existingUser != null)
            {
                return RedirectToAction("Home", "Home");
            }

            ViewBag.Error = "Invalid email or password.";
            return View("Index");
        }
    }
}
