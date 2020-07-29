using AES.WebApp.MVC.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AES.WebApp.MVC.Service
{
    public class ShopCartService : IShopCartService
    {
        private readonly HttpClient _httpClient;

        public ShopCartService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<ShopCartViewModel> GetShopCart()
        {
            throw new NotImplementedException();
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