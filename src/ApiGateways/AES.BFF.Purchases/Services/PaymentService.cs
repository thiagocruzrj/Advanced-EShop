using AES.BFF.Purchases.Extensions;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;

namespace AES.BFF.Purchases.Services
{
    public interface IPaymentService { }

    public class PaymentService : Service, IPaymentService
    {
        private readonly HttpClient _httpClient;

        public PaymentService(HttpClient httpClient, IOptions<AppServicesSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.PaymentUrl);
        }
    }
}