using AES.BFF.Purchases.Extensions;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;

namespace AES.BFF.Purchases.Services
{
    public interface IOrderService
    {
    }

    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;

        public OrderService(HttpClient httpClient, IOptions<AppServicesSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.OrderUrl);
        }
    }
}