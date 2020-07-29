using AES.WebApp.MVC.Models;
using System;
using System.Threading.Tasks;

namespace AES.WebApp.MVC.Service
{
    public interface IShopCartService
    {
        Task<ShopCartViewModel> GetShopCart();
        Task<ResponseResult> AddItemOnShopCart(ProductItemViewModel product);
        Task<ResponseResult> UpdateItemOnShopCart(Guid productId, ProductItemViewModel product);
        Task<ResponseResult> RemoveItemOnShopCart(Guid productId);
    }
}