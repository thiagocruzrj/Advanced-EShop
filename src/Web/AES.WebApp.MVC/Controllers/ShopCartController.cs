using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AES.WebApp.MVC.Controllers
{
    public class ShopCartController : MainController
    {
        [Route("shopCart")]
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
