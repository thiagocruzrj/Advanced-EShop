using AES.WebApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public async Task<IActionResult> AddShopCartItem(ProductItemViewModel productItem)
        {
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