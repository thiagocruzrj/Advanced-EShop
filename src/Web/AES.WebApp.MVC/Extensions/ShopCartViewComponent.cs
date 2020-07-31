using AES.WebApp.MVC.Models;
using AES.WebApp.MVC.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AES.WebApp.MVC.Extensions
{
    public class ShopCartViewComponent : ViewComponent
    {
        private readonly IShopCartService _shopCartService;

        public ShopCartViewComponent(IShopCartService shopCartService)
        {
            _shopCartService = shopCartService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _shopCartService.GetShopCart() ?? new ShopCartViewModel());
        }
    }
}