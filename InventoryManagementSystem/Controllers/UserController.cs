using Microsoft.AspNetCore.Mvc;
using InventoryManagementSystem.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            return View(); // This should match "/Views/User/Login.cshtml"
        }
        // GET: /User/Register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                // Check if the email already exists
                var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("", "Email already exists.");
                    return View();
                }

                _context.Users.Add(user);
                await _context.SaveChangesAsync();  // ✅ FIXED ERROR: Now recognized

                return RedirectToAction("Login");
            }

            return View();
        }
    }
}
