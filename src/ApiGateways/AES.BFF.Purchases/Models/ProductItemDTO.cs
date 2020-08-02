using System;
using System.Collections.Generic;

namespace AES.BFF.Purchases.Models
{
    public class ProductItemDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int StockQuantity { get; set; }
    }

    public class ShopCartItemDTO
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
    }

    public class ShopCartDTO
    {
        public decimal TotalPrice { get; set; }
        public decimal Discount { get; set; }
        public List<ShopCartItemDTO> Items { get; set; } = new List<ShopCartItemDTO>();
    }
}