using AES.Core.Controllers;
using AES.ShopCart.API.Data;
using AES.ShopCart.API.Model;
using AES.WebApi.Core.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AES.ShopCart.API.Controllers
{
    [Authorize]
    public class ShopCartController : MainController
    {
        private readonly IAspNetUser _user;
        private readonly ShopCartContext _context;

        public ShopCartController(IAspNetUser user, ShopCartContext context)
        {
            _user = user;
            _context = context;
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

        private async Task<ShopCartClient> GetCartClient()
        {
            return await _context.ShopCartClients
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.ClientId == _user.GetUserId());
        }
    }
}
