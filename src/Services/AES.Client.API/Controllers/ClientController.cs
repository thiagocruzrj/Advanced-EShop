using Microsoft.AspNetCore.Mvc;


namespace AES.Clients.API.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
