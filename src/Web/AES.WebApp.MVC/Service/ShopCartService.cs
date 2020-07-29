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

        public async Task<ResponseResult> AddItemOnShopCart(ProductItemViewModel product)
        {
            var itemContent = GetContent(product);
            var response = await _httpClient.PostAsync("/shopCart/", itemContent);

            if(!HandlingErrorsReponse(response)) return await DeserializeObjectResponse<ResponseResult>(response);

            return ReturnOk();
        }

        public async Task<ResponseResult> UpdateItemOnShopCart(Guid productId, ProductItemViewModel product)
        {
            var itemContent = GetContent(product);
            var response = await _httpClient.PutAsync($"/shopCart/{productId}", itemContent);

            if (!HandlingErrorsReponse(response)) return await DeserializeObjectResponse<ResponseResult>(response);

            return ReturnOk();
        }

        public async Task<ResponseResult> RemoveItemOnShopCart(ProductItemViewModel product)
        {
            var response = await _httpClient.DeleteAsync($"/shopCart/{product.ProductId}");

            if (!HandlingErrorsReponse(response)) return await DeserializeObjectResponse<ResponseResult>(response);

            return ReturnOk();
        }
    }
}