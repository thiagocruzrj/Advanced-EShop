using System;

namespace AES.Identity.API.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public decimal Price { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Image { get; set; }
        public int StockQuantity { get; set; }
    }
}
