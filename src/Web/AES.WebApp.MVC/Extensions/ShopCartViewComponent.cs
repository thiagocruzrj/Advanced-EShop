using AES.WebApp.MVC.Models;
using AES.WebApp.MVC.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AES.WebApp.MVC.Extensions
{
    public class ShopCartViewComponent : ViewComponent
    {
        private readonly IPurchaseBffService _purchaseBffService;

        public ShopCartViewComponent(IPurchaseBffService purchaseBffService)
        {
            _purchaseBffService = purchaseBffService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _purchaseBffService.GetShopCart() ?? new ShopCartViewModel());
        }
    }
}