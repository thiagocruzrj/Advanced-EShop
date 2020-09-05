using AES.Core.Communication;
using AES.WebApp.MVC.Extensions;
using AES.WebApp.MVC.Models;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AES.WebApp.MVC.Service
{
    public interface IPurchaseBffService
    {
        Task<ShopCartViewModel> GetShopCart();
        Task<int> GetQuantityOnShopCart();
        Task<ResponseResult> AddItemOnShopCart(ShopCartItemViewModel product);
        Task<ResponseResult> UpdateItemOnShopCart(Guid productId, ShopCartItemViewModel product);
        Task<ResponseResult> RemoveItemOnShopCart(Guid productId);
        Task<ResponseResult> ApplyVoucherOnShopCart(string voucher);
    }

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
            var response = await _httpClient.GetAsync("/puchases/shopCart/");
            HandlingErrorsReponse(response);

            return await DeserializeObjectResponse<ShopCartViewModel>(response);
        }

        public async Task<int> GetQuantityOnShopCart()
        {
            var response = await _httpClient.GetAsync("/purchases/shopCart-quantity/");
            HandlingErrorsReponse(response);

            return await DeserializeObjectResponse<int>(response);
        }

    public async Task<ResponseResult> AddItemOnShopCart(ShopCartItemViewModel shopCartItem)
        {
            var itemContent = GetContent(shopCartItem);
            var response = await _httpClient.PostAsync("/purchases/shopCart/items/", itemContent);

            if (!HandlingErrorsReponse(response)) return await DeserializeObjectResponse<ResponseResult>(response);

            return ReturnOk();
        }

        public async Task<ResponseResult> UpdateItemOnShopCart(Guid productId, ShopCartItemViewModel shopCartItem)
        {
            var itemContent = GetContent(shopCartItem);
            var response = await _httpClient.PutAsync($"/purchases/shopCart/items/{productId}", itemContent);

            if (!HandlingErrorsReponse(response)) return await DeserializeObjectResponse<ResponseResult>(response);

            return ReturnOk();
        }

        public async Task<ResponseResult> RemoveItemOnShopCart(Guid productId)
        {
            var response = await _httpClient.DeleteAsync($"/purchases/shopCart/items/{productId}");

            if (!HandlingErrorsReponse(response)) return await DeserializeObjectResponse<ResponseResult>(response);

            return ReturnOk();
        }

        public async Task<ResponseResult> ApplyVoucherOnShopCart(string voucher)
        {
            var itemContent = GetContent(voucher);

            var response = await _httpClient.PostAsync("/purchases/shopCart/apply-voucher", itemContent);

            if (!HandlingErrorsReponse(response)) return await DeserializeObjectResponse<ResponseResult>(response);

            return ReturnOk();
        }
    }
}