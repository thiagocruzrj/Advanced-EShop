using AES.BFF.Purchases.Extensions;
using AES.BFF.Purchases.Models;
using AES.WebApp.MVC.Models;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AES.BFF.Purchases.Services
{
    public interface IShopCartService 
    {
        Task<ShopCartDTO> GetShopCart();
        Task<int> GetShopCartQuantity();
        Task<ResponseResult> AddItemOnShopCart(ShopCartItemDTO product);
        Task<ResponseResult> UpdateItemOnShopCart(Guid productId, ShopCartItemDTO product);
        Task<ResponseResult> RemoveItemOnShopCart(Guid productId);
    }

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