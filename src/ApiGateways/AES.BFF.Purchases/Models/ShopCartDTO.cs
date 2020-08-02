using System.Collections.Generic;

namespace AES.BFF.Purchases.Models
{
    public class ShopCartDTO
    {
        public decimal TotalPrice { get; set; }
        public decimal Discount { get; set; }
        public List<ShopCartItemDTO> Items { get; set; } = new List<ShopCartItemDTO>();
    }
}