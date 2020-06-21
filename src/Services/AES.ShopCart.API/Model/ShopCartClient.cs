using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AES.ShopCart.API.Model
{
    public class ShopCartClient
    {
        internal const int MAX_QUANTITY_ITEM = 5;
        // EF ctor
        public ShopCartClient() { }

        public ShopCartClient(Guid clientId)
        {
            Id = Guid.NewGuid();
            ClientId = clientId;
        }

        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public decimal TotalPrice { get; set; }
        public List<ShopCartItem> Items { get; set; } = new List<ShopCartItem>();

        internal void CalculatingShopCartTotalPrice()
        {
            TotalPrice = Items.Sum(p => p.CalculatingQuantityPrice());
        }

        internal bool ShopCartItemExists(ShopCartItem item)
        {
            return Items.Any(p => p.ProductId == item.ProductId);
        }

        internal ShopCartItem GetByProductId(Guid productId)
        {
            return Items.FirstOrDefault(p => p.ProductId == productId);
        }

        internal void AddItem(ShopCartItem item)
        {
            // validating if item is ok
            item.AssociatingShopCart(Id);

            if (ShopCartItemExists(item))
            {
                var shopCartItemExist = GetByProductId(item.ProductId);
                shopCartItemExist.AddUnits(item.Quantity);

                item = shopCartItemExist;
                Items.Remove(item);
            }

            Items.Add(item);
            CalculatingShopCartTotalPrice();
        }
    }
}
