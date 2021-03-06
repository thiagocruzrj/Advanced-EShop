﻿using Microsoft.AspNetCore.Mvc.Razor;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace AES.WebApp.MVC.Extensions
{
    public static class RazorHelpers
    {
        public static string HashEmailForGravatar(this RazorPage page, string email)
        {
            var md5Hasher = MD5.Create();
            var data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(email));
            var sBuilder = new StringBuilder();
            foreach (var t in data)
            {
                sBuilder.Append(t.ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public static string StockMessage(this RazorPage page, int amount)
        {
            return amount > 0 ? $"Only {amount} on stock!" : "Sold out product!";
        }

        public static string UnitsByProduct(this RazorPage page, int units)
        {
            return units > 1 ? $"{units} units" : $"{units} unit";
        }

        public static string CoinFormat(this RazorPage page, decimal price)
        {
            return price > 0 ? string.Format(Thread.CurrentThread.CurrentCulture, "{0:C}", price) : "Free";
        }

        public static string SelectOptionsByQuantity(this RazorPage page, int quantity, int selectedValue = 0)
        {
            var sb = new StringBuilder();
            for (var i = 1; i <= quantity; i++)
            {
                var selected = "";
                if (i == selectedValue) selected = "selected";
                sb.Append($"<option {selected} value='{i}'>{i}</option>");
            }

            return sb.ToString();
        }
    }
}