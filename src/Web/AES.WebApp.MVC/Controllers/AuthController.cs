using AES.WebApp.MVC.Models;
using AES.WebApp.MVC.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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

            // Register app
            await LogIn(response);
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

            // Login app
            await LogIn(response);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("exit")]
        public async Task<IActionResult> Logout() 
        {
            return RedirectToAction("Index", "Home");
        }

        private async Task LogIn(UserLoginResponse response)
        {
            var token = GetFormattedToken(response.AccessToken);

            var claims = new List<Claim>();
            claims.Add(new Claim("JWT", response.AccessToken));
            claims.AddRange(token.Claims);

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60),
                IsPersistent = true
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }

        private static JwtSecurityToken GetFormattedToken(string jwtToken)
        {
            return new JwtSecurityTokenHandler().ReadToken(jwtToken) as JwtSecurityToken;
        }
    }
}
