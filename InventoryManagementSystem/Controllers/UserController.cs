using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class UserController : Controller
    {
        // GET: /User/Login
        public IActionResult Login()
        {
            return View();
        }

        // GET: /User/Register
        public IActionResult Register()
        {
            return View();
        }
    }
}
