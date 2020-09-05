using System.Collections.Generic;

namespace AES.BFF.Purchases.Models
{
    public class ShopCartDTO
    {
        public decimal TotalPrice { get; set; }
        public VoucherDTO Voucher { get; set; }
        public decimal Discount { get; set; }
        public bool UsedVoucher { get; set; }
        public List<ShopCartItemDTO> Items { get; set; } = new List<ShopCartItemDTO>();
    }
}