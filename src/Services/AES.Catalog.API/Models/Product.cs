using AES.Core.DomainObjects;
using System;

namespace AES.Catalog.API.Models
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public decimal Price { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Image { get; set; }
        public int Amount { get; set; }
    }
}
