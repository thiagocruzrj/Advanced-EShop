using AES.Core.Controllers;
using AES.ShopCart.API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AES.ShopCart.API.Controllers
{
    [Authorize]
    public class ShopCartController : MainController
    {
        [HttpGet("shopCart")]
        public async Task<ShopCartClient> GetShopCart()
        {
            return null;
        }

        [HttpPost("shopCart")]
        public async Task<IActionResult> AddCartItem(ShopCartItem item)
        {
            return CustomResponse();
        }

        [HttpPut("shopCart")]
        public async Task<IActionResult> UpdateCartItem(Guid productId, ShopCartItem item)
        {
            return CustomResponse();
        }

        [HttpDelete("shopCart")]
        public async Task<IActionResult> RemoveCartItem(Guid productId)
        {
            return CustomResponse();
        }
    }
}
