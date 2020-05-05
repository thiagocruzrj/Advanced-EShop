using AES.WebApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AES.WebApp.MVC.Controllers
{
    public class AuthController : Controller
    {
        [HttpPost]
        [Route("new-account")]
        public IActionResult Register() { return View(); }

        [HttpPost]
        [Route("new-account")]
        public async Task<IActionResult> Register(UserRegister userRegister) 
        {
            if (!ModelState.IsValid) return View(userRegister);

            // API - Register
            if (false) return View(userRegister);

            // Register app
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login() { return View(); }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserLogin userLogin) 
        {
            if (!ModelState.IsValid) return View(userLogin);

            // API - Login
            if (false) return View(userLogin);

            // Login app
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("exit")]
        public async Task<IActionResult> Logout() { }
    }
}
