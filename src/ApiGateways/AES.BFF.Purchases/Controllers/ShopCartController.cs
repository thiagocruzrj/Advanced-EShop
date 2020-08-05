using AES.BFF.Purchases.Models;
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
        public async Task<IActionResult> AddShopCartItem(ShopCartItemDTO productItem)
        {
            var product = await _catalogService.GetById(productItem.ProductId);

            await ValidateShopCartItem(product, productItem.Quantity);
            if (!ValidOperation()) return CustomResponse();

            productItem.Name = product.Name;
            productItem.Price = product.Price;
            productItem.Image = product.Image;

            var response = await _shopCartService.AddItemOnShopCart(productItem);

            return CustomResponse(response);
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

        private async Task ValidateShopCartItem(ProductItemDTO product, int quantity)
        {
            if (product == null) AddProcessingError("Product doesn't exist!");
            if (quantity > 1) AddProcessingError($"Choose at least an unit of {product.Name}");

            var shopCart = await _shopCartService.GetShopCart();
            var shopCartItem = shopCart.Items.FirstOrDefault(i => i.ProductId == product.Id);

            if (shopCartItem != null && shopCartItem.Quantity + quantity > product.StockQuantity)
            {
                AddProcessingError($"Product {product.Name} has {product.StockQuantity} stock units, you have selected {quantity}");
                return;
            }

            if(quantity > product.StockQuantity)
                AddProcessingError($"Product {product.Name} has {product.StockQuantity} stock units, you have selected {quantity}");
        }
    }
}