using AES.Core.DomainObjects;
using System;

namespace AES.Order.Domain.Vouchers
{
    public class Voucher : Entity, IAggregateRoot
    {
        public string Code { get; private set; }
        public decimal? Percent { get; private set; }
        public decimal? DiscountValue { get; private set; }
        public int Quantity { get; private set; }
        public TypeDiscountVoucher DiscountVoucher { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime? UseDate { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public bool Active { get; private set; }
        public bool Used { get; private set; }
    }
}