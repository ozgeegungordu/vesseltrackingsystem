using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VesselTrackingSystem.Models;

namespace VesselTrackingSystem.Controllers
{
    public class AccountController : Controller
    {
        private LimakPortContext _context;

        public AccountController(LimakPortContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public async Task<ActionResult> Login(Users model)
        {
            if (ModelState.IsValid)
            {
                string PasswordHash = CreateMD5(model.Password);
                var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == model.Username && u.Password == PasswordHash);

                if (user != null)
                {
                    return RedirectToAction("Map", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid credentials");
                    return View(model);
                }
            }

            return View(model);
        }

        public static string CreateMD5(string input)
        {

            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes); 
            }
        }
    }
}

