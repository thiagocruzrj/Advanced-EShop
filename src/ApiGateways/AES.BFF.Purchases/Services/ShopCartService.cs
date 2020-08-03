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


        public async Task<ShopCartDTO> GetShopCart()
        {
            var response = await _httpClient.GetAsync("/shopCart/");
            HandlingErrorsReponse(response);

            return await DeserializeObjectResponse<ShopCartDTO>(response);
        }

        public async Task<ResponseResult> AddItemOnShopCart(ShopCartItemDTO product)
        {
            var itemContent = GetContent(product);
            var response = await _httpClient.PostAsync("/shopCart/", itemContent);

            if (!HandlingErrorsReponse(response)) return await DeserializeObjectResponse<ResponseResult>(response);

            return ReturnOk();
        }

        public async Task<ResponseResult> UpdateItemOnShopCart(Guid productId, ShopCartItemDTO product)
        {
            var itemContent = GetContent(product);
            var response = await _httpClient.PutAsync($"/shopCart/{productId}", itemContent);

            if (!HandlingErrorsReponse(response)) return await DeserializeObjectResponse<ResponseResult>(response);

            return ReturnOk();
        }

        public async Task<ResponseResult> RemoveItemOnShopCart(Guid productId)
        {
            var response = await _httpClient.DeleteAsync($"/shopCart/{productId}");

            if (!HandlingErrorsReponse(response)) return await DeserializeObjectResponse<ResponseResult>(response);

            return ReturnOk();
        }
    }
}