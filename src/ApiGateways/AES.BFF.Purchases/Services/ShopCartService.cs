using AES.BFF.Purchases.Extensions;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;

namespace AES.BFF.Purchases.Services
{
    public interface IShopCartService { }

    public class ShopCartService : Service, IShopCartService
    {
        private readonly HttpClient _httpClient;

        public ShopCartService(HttpClient httpClient, IOptions<AppServicesSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.ShopCartUrl);
        }
    }
}