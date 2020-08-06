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

        public ShopCartController(IPurchaseBffService purchaseBffSService)
        {
            _purchaseBffService = purchaseBffSService;
        }

        [Route("shopCart")]
        public async Task<IActionResult> Index()
        {
            return View(await _purchaseBffService.GetShopCart());
        }

        [HttpPost]
        [Route("shopCart/add-item")]
        public async Task<IActionResult> AddShopCartItem(ShopCartItemViewModel shopCartItem)
        {
            var response = await _purchaseBffService.AddItemOnShopCart(shopCartItem);

            if (ResponseHasErrors(response)) return View("Index", await _purchaseBffService.GetShopCart());

            return RedirectToAction("Index");
        }

        [HttpPut]
        [Route("shopCart/update-item")]
        public async Task<IActionResult> UpdateShopCartItem(Guid productId, int quantity)
        {
            var item = new ShopCartItemViewModel { ProductId = productId, Quantity = quantity };
            var response = await _purchaseBffService.UpdateItemOnShopCart(productId, item);

            if (ResponseHasErrors(response)) return View("Index", await _purchaseBffService.GetShopCart());

            return RedirectToAction("Index");
        }

        [HttpDelete]
        [Route("shopCart/remove-item")]
        public async Task<IActionResult> RemoveShopCartItem(Guid productId)
        {
            var response = await _purchaseBffService.RemoveItemOnShopCart(productId);

            if (ResponseHasErrors(response)) return View("Index", await _purchaseBffService.GetShopCart());

            return RedirectToAction("Index");
        }
    }
}