using AES.Core.DomainObjects;
using AES.Order.Domain.Vouchers.Specs;
using System;

namespace AES.Order.Domain.Vouchers
{
    public class Voucher : Entity, IAggregateRoot
    {
        public string Code { get; private set; }
        public decimal? Percent { get; private set; }
        public decimal? DiscountValue { get; private set; }
        public int Quantity { get; private set; }
        public TypeDiscountVoucher DiscountType { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime? UseDate { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public bool Active { get; private set; }
        public bool Used { get; private set; }

        public bool IsValidToUse()
        {
            return new VoucherActiveSpecification()
                .And(new VoucherDataSpecification())
                .And(new VoucherQuantitySpecification()).IsSatisfiedBy(this);
        }

        public void MarkAsUsed()
        {
            Active = false;
            Used = true;
            Quantity = 0;
        }
    }
}