using System;
using System.Collections.Generic;

namespace AES.WebApp.MVC.Models
{
    public class ShopCartViewModel
    {
        public decimal TotalPrice { get; set; }
        public VoucherViewModel Voucher { get; set; }
        public bool VoucherUsed { get; set; }
        public decimal Discount { get; set; }
        public List<ShopCartItemViewModel> Itens { get; set; } = new List<ShopCartItemViewModel>();
    }

    public class ShopCartItemViewModel
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
    }
}