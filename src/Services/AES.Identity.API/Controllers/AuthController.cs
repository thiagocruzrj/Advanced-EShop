using AES.Identity.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AES.Identity.API.Controllers
{
    public class AuthController : Controller
    {
        public async Task<ActionResult> Register(UserRegister userRegister) { }
        public async Task<ActionResult> Login(UserLogin userLogin) { }
    }
}
