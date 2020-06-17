using System;

namespace AES.ShopCart.API.Model
{
    public class ShopCartItem
    {
        public ShopCartItem(Guid id)
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public Guid ShopCartId { get; set; }
    }
}
