using AES.WebApp.MVC.Models;
using AES.WebApp.MVC.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AES.WebApp.MVC.Controllers
{
    public class ShopCartController : MainController
    {
        private readonly IPurchaseBffService _purchaseBffService;
        private readonly ICatalogService _catalogService;

        public ShopCartController(IPurchaseBffService purchaseBffSService,
                                  ICatalogService catalogService)
        {
            _purchaseBffService = purchaseBffSService;
            _catalogService = catalogService;
        }

        [Route("shopCart")]
        public async Task<IActionResult> Index()
        {
            return View(await _purchaseBffService.GetShopCart());
        }

        [HttpPost]
        [Route("shopCart/add-item")]
        public async Task<IActionResult> AddShopCartItem(ProductItemViewModel productItem)
        {
            var product = await _catalogService.GetById(productItem.ProductId);

            ValidatingShopCartItem(product, productItem.Quantity);
            if (!ValidOperation()) return View("Index", await _purchaseBffService.GetShopCart());

            productItem.Name = product.Name;
            productItem.Price = product.Price;
            productItem.Image = product.Image;

            var response = await _purchaseBffService.AddItemOnShopCart(productItem);

            if (ResponseHasErrors(response)) return View("Index", await _purchaseBffService.GetShopCart());

            return RedirectToAction("Index");
        }

        [HttpPut]
        [Route("shopCart/update-item")]
        public async Task<IActionResult> UpdateShopCartItem(Guid productId, int quantity)
        {
            var product = await _catalogService.GetById(productId);

            ValidatingShopCartItem(product, quantity);
            if (!ValidOperation()) return View("Index", await _purchaseBffService.GetShopCart());

            var itemProduct = new ProductItemViewModel { ProductId = productId, Quantity = quantity };
            var response = await _purchaseBffService.UpdateItemOnShopCart(productId, itemProduct);

            if (ResponseHasErrors(response)) return View("Index", await _purchaseBffService.GetShopCart());

            return RedirectToAction("Index");
        }

        [HttpDelete]
        [Route("shopCart/remove-item")]
        public async Task<IActionResult> RemoveShopCartItem(Guid productId)
        {
            var product = await _catalogService.GetById(productId);
            if (product == null)
            {
                AddValidationError("Product doesnt exist");
                return View("Index", await _purchaseBffService.GetShopCart());
            }

            var response = await _purchaseBffService.RemoveItemOnShopCart(productId);

            if (ResponseHasErrors(response)) return View("Index", await _purchaseBffService.GetShopCart());

            return RedirectToAction("Index");
        }

        private void ValidatingShopCartItem(ProductViewModel product, int quantity)
        {
            if (product == null) AddValidationError("Product doesnt exist");
            if (quantity < 1) AddValidationError($"Choise at least an product unit {product.Name}");
            if (quantity > product.StockQuantity) AddValidationError($"Product {product.Name} has {quantity} units");
        }
    }
}