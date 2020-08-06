using AES.Core.Communication;
using AES.WebApp.MVC.Models;
using System;
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
    }
}