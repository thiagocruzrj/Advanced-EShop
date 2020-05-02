using AES.Identity.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AES.Identity.API.Controllers
{
    public class AuthController : Controller
    {
        public async Task<ActionResult> Register(UserRegister userRegister) 
        {
            if (!ModelState.IsValid) return BadRequest();

            var user = new IdentityUser
            {
                UserName = userRegister.Email,
                Email = userRegister.Email,
                EmailConfirmed = true
            };
        }

        public async Task<ActionResult> Login(UserLogin userLogin)
        {

        }
    }
}
