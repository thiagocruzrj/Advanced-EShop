using AES.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AES.Clients.API.Controllers
{
    public class ClientController : MainController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
