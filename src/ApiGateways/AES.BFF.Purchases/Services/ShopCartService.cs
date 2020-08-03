using AES.BFF.Purchases.Extensions;
using AES.BFF.Purchases.Models;
using AES.Core.Communication;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AES.BFF.Purchases.Services
{
    public class ShopCartService : Service, IShopCartService
    {
        private readonly HttpClient _httpClient;

        public ShopCartService(HttpClient httpClient, IOptions<AppServicesSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.ShopCartUrl);
        }

        public Task<ShopCartDTO> GetShopCart()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetShopCartQuantity()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseResult> AddItemOnShopCart(ShopCartItemDTO product)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseResult> UpdateItemOnShopCart(Guid productId, ShopCartItemDTO product)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseResult> RemoveItemOnShopCart(Guid productId)
        {
            throw new NotImplementedException();
        }
    }
}