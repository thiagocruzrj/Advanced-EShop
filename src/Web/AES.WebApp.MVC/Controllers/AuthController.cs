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
        public async Task<ActionResult> Register(UserRegister userRegister) { }

        [HttpGet]
        [Route("login")]
        public IActionResult Login() { return View(); }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserLogin userLogin) { }

        [HttpGet]
        [Route("exit")]
        public async Task<IActionResult> Logout() { }
    }
}
