﻿using System;

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
}