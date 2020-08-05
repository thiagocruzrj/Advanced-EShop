using AES.BFF.Purchases.Services;
using AES.Core.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AES.BFF.Purchases.Controllers
{
    [Authorize]
    public class ShopCartController : MainController
    {
        private readonly IShopCartService _shopCartService;
        private readonly ICatalogService _catalogService;

        public ShopCartController(IShopCartService shopCartService, ICatalogService catalogService)
        {
            _shopCartService = shopCartService;
            _catalogService = catalogService;
        }

        [HttpGet]
        [Route("purchases/shopCart")]
        public async Task<IActionResult> Index()
        {
            return CustomResponse(await _shopCartService.GetShopCart());
        }

        [HttpGet]
        [Route("purchases/shop-cart-quantity")]
        public async Task<int> GetShopCartQuantity()
        {
            var quantity = await _shopCartService.GetShopCart();
            return quantity?.Items.Sum(i => i.Quantity) ?? 0;
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