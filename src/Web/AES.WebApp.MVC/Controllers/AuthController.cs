using AES.WebApp.MVC.Models;
using AES.WebApp.MVC.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AES.WebApp.MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("new-account")]
        public IActionResult Register() { return View(); }

        [HttpPost]
        [Route("new-account")]
        public async Task<IActionResult> Register(UserRegister userRegister) 
        {
            if (!ModelState.IsValid) return View(userRegister);

            // API - Register
            var response = await _authService.Register(userRegister); 
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
            var response = await _authService.Login(userLogin);

            if (false) return View(userLogin);

            // Login app
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("exit")]
        public async Task<IActionResult> Logout() 
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
