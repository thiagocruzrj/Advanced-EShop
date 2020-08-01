using AES.Core.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AES.BFF.Purchases.Controllers
{
    [Authorize]
    public class ShopCartController : MainController
    {
        [HttpGet]
        [Route("purchases/shopCart")]
        public async Task<IActionResult> Index()
        {
            return CustomResponse();
        }

        [HttpGet]
        [Route("purchases/shop-cart-quantity")]
        public async Task<IActionResult> GetShopCartQuantity()
        {
            return CustomResponse();
        }
    }
}