using AES.Core.Controllers;
using AES.ShopCart.API.Model;
using AES.WebApi.Core.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AES.ShopCart.API.Controllers
{
    [Authorize]
    public class ShopCartController : MainController
    {
        private readonly IAspNetUser _user;

        public ShopCartController(IAspNetUser user)
        {
            _user = user;
        }

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

        [HttpPut("shopCart/{productId}")]
        public async Task<IActionResult> UpdateCartItem(Guid productId, ShopCartItem item)
        {
            return CustomResponse();
        }

        [HttpDelete("shopCart/{productId}")]
        public async Task<IActionResult> RemoveCartItem(Guid productId)
        {
            return CustomResponse();
        }
    }
}
