using Microsoft.AspNetCore.Mvc.Razor;

namespace AES.WebApp.MVC.Extensions
{
    public static class RazorHelpers
    {
        public static string StockMessage(this RazorPage page, int amount)
        {
            return amount > 0 ? $"Only {amount} on stock!" : "Sold out product";
        }
    }
}
