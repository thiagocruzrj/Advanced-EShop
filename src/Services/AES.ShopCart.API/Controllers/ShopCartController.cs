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
            return await GetCartClient() ?? new ShopCartClient();
        }

        [HttpPost("shopCart")]
        public async Task<IActionResult> AddCartItem(ShopCartItem item)
        {
            var shopCart = await GetCartClient();

            if(shopCart == null)
            {
                HandleNewCartItem(item);
            } else
            {

            }

            if (!ValidOperation()) return CustomResponse();

            var result = await _context.SaveChangesAsync();
            if (result <= 0) AddProcessingError("Isn't possible to persist data on db");

            return CustomResponse();
        }

        private void HandleShopCart(ShopCartItem item)
        {
            var shopCart = new ShopCartClient(_user.GetUserId());
            shopCart.AddItem(item);

            _context.ShopCartClients.Add(shopCart);
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

        private void HandleNewCartItem(ShopCartItem item)
        {
            var cartItem = new ShopCartClient(_user.GetUserId());

            _context.ShopCartClients.Add(cartItem);
        }
    }
}