using AES.WebApp.MVC.Extensions;
using AES.WebApp.MVC.Models;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AES.WebApp.MVC.Service
{
    public class ShopCartService : Service, IShopCartService
    {
        private readonly HttpClient _httpClient;

        public ShopCartService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.ShopCartUrl);
        }

        public async Task<ShopCartViewModel> GetShopCart()
        {
            var response = await _httpClient.GetAsync("/shopCart/");
            HandlingErrorsReponse(response);

            return await DeserializeObjectResponse<ShopCartViewModel>(response);
        }

        public Task<ResponseResult> AddItemOnShopCart(ProductItemViewModel product)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseResult> UpdateItemOnShopCart(Guid productId, ProductItemViewModel product)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseResult> RemoveItemOnShopCart(Guid productId)
        {
            throw new NotImplementedException();
        }
    }
}