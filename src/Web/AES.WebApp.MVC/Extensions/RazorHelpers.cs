using Microsoft.AspNetCore.Mvc.Razor;
using System.Threading;

namespace AES.WebApp.MVC.Extensions
{
    public static class RazorHelpers
    {
        public static string StockMessage(this RazorPage page, int amount)
        {
            return amount > 0 ? $"Only {amount} on stock!" : "Sold out product!";
        }

        public static string CoinFormat(this RazorPage page, decimal price)
        {
            return price > 0 ? string.Format(Thread.CurrentThread.CurrentCulture, "{0:C}", price) : "Free";
        }
    }
}
