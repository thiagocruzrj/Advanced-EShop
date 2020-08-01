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

        [HttpPost]
        [Route("purchases/shopCart/items")]
        public async Task<IActionResult> AddShopCartItem()
        {
            return CustomResponse();
        }

        [HttpPut]
        [Route("purchases/shopCart/items/{productId}")]
        public async Task<IActionResult> UpdateShopCartItem()
        {
            return CustomResponse();
        }

        [HttpDelete]
        [Route("purchases/shopCart/items/{productId}")]
        public async Task<IActionResult> RemoveShopCartItem()
        {
            return CustomResponse();
        }
    }
}