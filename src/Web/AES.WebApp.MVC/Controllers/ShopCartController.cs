using AES.WebApp.MVC.Models;
using AES.WebApp.MVC.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AES.WebApp.MVC.Controllers
{
    public class ShopCartController : MainController
    {
        private readonly IShopCartService _shopCartService;
        private readonly ICatalogService _catalogService;

        public ShopCartController(IShopCartService shopCartService,
                                  ICatalogService catalogService)
        {
            _shopCartService = shopCartService;
            _catalogService = catalogService;
        }

        [Route("shopCart")]
        public async Task<IActionResult> Index()
        {
            return View(await _shopCartService.GetShopCart());
        }

        [HttpPost]
        [Route("shopCart/add-item")]
        public async Task<IActionResult> AddShopCartItem(ProductItemViewModel productItem)
        {
            var product = await _catalogService.GetById(productItem.ProductId);

            productItem.Name = product.Name;
            productItem.Price = product.Price;
            productItem.Image = product.Image;

            var response = await _shopCartService.AddItemOnShopCart(productItem);

            if (ResponseHasErrors(response)) return View("Index", await _shopCartService.GetShopCart());

            return RedirectToAction("Index");
        }

        [HttpPut]
        [Route("shopCart/update-item")]
        public async Task<IActionResult> UpdateShopCartItem(Guid productId, int quantity)
        {
            return RedirectToAction("Index");
        }

        [HttpDelete]
        [Route("shopCart/remove-item")]
        public async Task<IActionResult> RemoveShopCartItem(Guid productId)
        {
            return RedirectToAction("Index");
        }
    }
}