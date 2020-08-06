using AES.Core.Communication;
using AES.WebApp.MVC.Extensions;
using AES.WebApp.MVC.Models;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AES.WebApp.MVC.Service
{
    public class PurchaseBffService : Service, IPurchaseBffService
    {
        private readonly HttpClient _httpClient;

        public PurchaseBffService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.PurchasesBffUrl);
        }

        public async Task<ShopCartViewModel> GetShopCart()
        {
            var response = await _httpClient.GetAsync("/shopCart/");
            HandlingErrorsReponse(response);

            return await DeserializeObjectResponse<ShopCartViewModel>(response);
        }

        public async Task<ResponseResult> AddItemOnShopCart(ShopCartItemViewModel shopCartItem)
        {
            var itemContent = GetContent(shopCartItem);
            var response = await _httpClient.PostAsync("/shopCart/", itemContent);

            if(!HandlingErrorsReponse(response)) return await DeserializeObjectResponse<ResponseResult>(response);

            return ReturnOk();
        }

        public async Task<ResponseResult> UpdateItemOnShopCart(Guid productId, ShopCartItemViewModel shopCartItem)
        {
            var itemContent = GetContent(shopCartItem);
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