using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AES.ShopCart.API.Model
{
    public class ShopCartClient
    {
        internal const int MAX_QUANTITY_ITEM = 5;
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
        public ValidationResult ValidationResult { get; set; }
        public bool UsedDiscount { get; set; }
        public decimal DiscountValue { get; set; }
        public Voucher Voucher { get; set; }

        internal void CalculatingShopCartTotalPrice()
        {
            TotalPrice = Items.Sum(p => p.CalculatingQuantityPrice());
        }

        internal bool ShopCartItemExists(ShopCartItem item)
        {
            return Items.Any(p => p.ProductId == item.ProductId);
        }

        internal ShopCartItem GetByProductId(Guid productId)
        {
            return Items.FirstOrDefault(p => p.ProductId == productId);
        }

        internal void AddItem(ShopCartItem item)
        {
            item.AssociatingShopCart(Id);

            if (ShopCartItemExists(item))
            {
                var shopCartItemExist = GetByProductId(item.ProductId);
                shopCartItemExist.AddUnits(item.Quantity);

                item = shopCartItemExist;
                Items.Remove(item);
            }

            Items.Add(item);
            CalculatingShopCartTotalPrice();
        }

        internal void UpdateItem(ShopCartItem item)
        {
            item.AssociatingShopCart(Id);

            var existentItem = GetByProductId(item.ProductId);

            Items.Remove(existentItem);
            Items.Add(item);

            CalculatingShopCartTotalPrice();
        }

        internal void UpdateUnits(ShopCartItem item, int units)
        {
            item.UpdateUnits(units);
            UpdateItem(item);
        }

        internal void RemoveItem(ShopCartItem item)
        {
            Items.Remove(GetByProductId(item.ProductId));
            CalculatingShopCartTotalPrice();
        }

        internal bool IsValid()
        {
            var errors = Items.SelectMany(i => new ShopCartItem.ShopCartItemValidation().Validate(i).Errors).ToList();
            errors.AddRange(new ShopCartClientValidation().Validate(this).Errors);
            ValidationResult = new ValidationResult(errors);

            return ValidationResult.IsValid;
        }

        public class ShopCartClientValidation : AbstractValidator<ShopCartClient>
        {
            public ShopCartClientValidation()
            {
                RuleFor(c => c.ClientId)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Client unknown");

                RuleFor(c => c.Items.Count)
                    .GreaterThan(0)
                    .WithMessage("Cart hasn't items");

                RuleFor(c => c.TotalPrice)
                    .GreaterThan(0)
                    .WithMessage("Total cart price should be greater than 0");
            }
        }
    }
}