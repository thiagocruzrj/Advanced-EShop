using FluentValidation;
using System;

namespace AES.ShopCart.API.Model
{
    public class ShopCartItem
    {
        public ShopCartItem()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        // Foreach key
        public Guid ShopCartId { get; set; }
        public ShopCartClient ShopCartClient { get; set; }

        internal void AssociatingShopCart(Guid shopCartId)
        {
            ShopCartId = shopCartId;
        }

        internal decimal CalculatingQuantityPrice()
        {
            return Quantity * Price;
        }

        internal void AddUnits(int units)
        {
            Quantity += units;
        }

        internal void UpdateUnits(int units)
        {
            Quantity = units;
        }

        internal bool IsValid()
        {
            return new ShopCartItemOrderValidation().Validate(this).IsValid;
        }

        public class ShopCartItemOrderValidation : AbstractValidator<ShopCartItem>
        {
            public ShopCartItemOrderValidation()
            {
                RuleFor(c => c.ProductId)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Product Id can't be invalid");

                RuleFor(c => c.Name)
                    .NotEmpty()
                    .WithMessage("Product name wasn't informed");

                RuleFor(c => c.Quantity)
                    .GreaterThan(0)
                    .WithMessage(item => $"Minimum {item.Name} quantity is 1");

                RuleFor(c => c.Quantity)
                    .LessThan(ShopCartClient.MAX_QUANTITY_ITEM)
                    .WithMessage(item => $"Maximum {item.Name} quantity is {ShopCartClient.MAX_QUANTITY_ITEM}");

                RuleFor(c => c.Price)
                    .GreaterThan(0)
                    .WithMessage(item => $"{item.Name} price need to be greater than 0");
            }
        }
    }
}