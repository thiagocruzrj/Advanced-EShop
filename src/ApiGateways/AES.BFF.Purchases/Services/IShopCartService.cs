using AES.BFF.Purchases.Models;
using AES.Core.Communication;
using System;
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
}