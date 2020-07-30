using AES.Core.Controllers;
using AES.ShopCart.API.Data;
using AES.ShopCart.API.Model;
using AES.WebApi.Core.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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
            return await GetShopCartClient() ?? new ShopCartClient();
        }

        [HttpPost("shopCart")]
        public async Task<IActionResult> AddShopCartItem(ShopCartItem item)
        {
            var shopCart = await GetShopCartClient();

            if (shopCart == null)
                HandleNewCartItem(item);
            else
                HandlerExistentShopCart(shopCart, item);

            if (!ValidOperation()) return CustomResponse();

            await PersistData();

            return CustomResponse();
        }

        [HttpPut("shopCart/{productId}")]
        public async Task<IActionResult> UpdateShopCartItem(Guid productId, ShopCartItem item)
        {
            var shopCart = await GetShopCartClient();
            var itemShopCart = await GetValidShopCartItem(productId, shopCart, item);
            if(itemShopCart == null) return CustomResponse();

            shopCart.UpdateUnits(item, item.Quantity);

            ValidatingShopCart(shopCart);
            if (!ValidOperation()) return CustomResponse();

            _context.ShopCartItems.Update(itemShopCart);
            _context.ShopCartClients.Update(shopCart);

            await PersistData();

            return CustomResponse();
        }

        [HttpDelete("shopCart/{productId}")]
        public async Task<IActionResult> RemoveShopCartItem(Guid productId)
        {
            var shopCart = await GetShopCartClient();

            var itemShopCart = await GetValidShopCartItem(productId, shopCart);
            if (itemShopCart == null) return CustomResponse();

            shopCart.RemoveItem(itemShopCart);

            ValidatingShopCart(shopCart);
            if (!ValidOperation()) return CustomResponse();

            _context.ShopCartItems.Remove(itemShopCart);
            _context.ShopCartClients.Update(shopCart);

            await PersistData();

            return CustomResponse();
        }

        private async Task<ShopCartClient> GetShopCartClient()
        {
            return await _context.ShopCartClients
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.ClientId == _user.GetUserId());
        }

        private void HandleNewCartItem(ShopCartItem item)
        {
            var cartItem = new ShopCartClient(_user.GetUserId());
            cartItem.AddItem(item);

            ValidatingShopCart(cartItem);
            _context.ShopCartClients.Add(cartItem);
        }

        private void HandlerExistentShopCart(ShopCartClient cart, ShopCartItem item)
        {
            var productItemExistent = cart.ShopCartItemExists(item);

            cart.AddItem(item);
            ValidatingShopCart(cart);

            if (productItemExistent)
            {
                _context.ShopCartItems.Update(cart.GetByProductId(item.ProductId));
            }
            else
            {
                _context.ShopCartItems.Add(item);
            }

            _context.ShopCartClients.Update(cart);
        }

        private async Task<ShopCartItem> GetValidShopCartItem(Guid productId, ShopCartClient shopCart, ShopCartItem item = null)
        {
            if(item != null && productId != item.ProductId)
            {
                AddProcessingError("Item doesn't match with to the informed");
                return null;
            }

            if(shopCart == null)
            {
                AddProcessingError("Shop cart not found");
                return null;
            }

            var shopCartItem = await _context.ShopCartItems
                .FirstOrDefaultAsync(i => i.ShopCartId == shopCart.Id && i.ProductId == productId);

            if(shopCartItem == null || !shopCart.ShopCartItemExists(shopCartItem))
            {
                AddProcessingError("Item isn't on shop cart");
                return null;
            }

            return shopCartItem;
        }

        private async Task PersistData()
        {
            var result = await _context.SaveChangesAsync();
            if (result <= 0) AddProcessingError("Isn't possible to persist data on db");
        }

        private bool ValidatingShopCart(ShopCartClient shopCart)
        {
            if (shopCart.IsValid()) return true;

            shopCart.ValidationResult.Errors.ToList().ForEach(e => AddProcessingError(e.ErrorMessage));
            return false;
        }
    }
}