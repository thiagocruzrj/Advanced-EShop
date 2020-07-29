using System.Collections.Generic;

namespace AES.WebApp.MVC.Models
{
    public class ShopCartViewModel
    {
        public decimal TotalPrice { get; set; }
        public List<ProductItemViewModel> Itens { get; set; } = new List<ProductItemViewModel>();
    }
}
