using System;
using System.Collections.Generic;

namespace AES.ShopCart.API.Model
{
    public class ShopCartClient
    {
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
    }
}
