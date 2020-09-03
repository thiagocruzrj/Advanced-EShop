using AES.BFF.Purchases.Models;
using AES.BFF.Purchases.Services;
using AES.Core.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AES.BFF.Purchases.Controllers
{
    [Authorize]
    public class ShopCartController : MainController
    {
        private readonly IShopCartService _shopCartService;
        private readonly ICatalogService _catalogService;
        private readonly IOrderService _orderService;

        public ShopCartController(IShopCartService shopCartService, ICatalogService catalogService,
                                IOrderService orderService)
        {
            _shopCartService = shopCartService;
            _catalogService = catalogService;
            _orderService = orderService;
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
        public async Task<IActionResult> UpdateShopCartItem(Guid productId, ShopCartItemDTO productItem)
        {
            var product = await _catalogService.GetById(productId);

            await ValidateShopCartItem(product, productItem.Quantity);
            if (!ValidOperation()) return CustomResponse();

            var response = await _shopCartService.UpdateItemOnShopCart(productId, productItem);

            return CustomResponse(response);

        }

        [HttpDelete]
        [Route("purchases/shopCart/items/{productId}")]
        public async Task<IActionResult> RemoveShopCartItem(Guid productId)
        {
            var product = await _catalogService.GetById(productId);

            if (product == null)
            {
                AddProcessingError("Product doesn't exist");
                return CustomResponse();
            }

            var response = await _shopCartService.RemoveItemOnShopCart(productId);

            return CustomResponse(response);
        }

        [HttpPost]
        [Route("purchases/shopCart/apply-voucher")]
        public async Task<IActionResult> ApplyVouchers([FromBody]string voucherCode)
        {
            var voucher = await _orderService.GetVoucherByCode(voucherCode);
            if(voucher is null)
            {
                AddProcessingError("Invalid voucher or not found!");
                return CustomResponse();
            }

            var response = await _shopCartService.ApplyVoucherOnShopCart(voucher);

            return CustomResponse(response);
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