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

        [HttpPost]
        [Route("shopCart/add-item")]
        public async Task<IActionResult> AddShopCartItem()
        {
            return RedirectToAction("Index");
        }
    }
}
