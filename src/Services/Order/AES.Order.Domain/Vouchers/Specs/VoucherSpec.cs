﻿using NetDevPack.Specification;
using System;
using System.Linq.Expressions;

namespace AES.Order.Domain.Vouchers.Specs
{
    public class VoucherDataSpecification : Specification<Voucher>
    {
        public override Expression<Func<Voucher, bool>> ToExpression()
        {
            return voucher => voucher.ExpirationDate >= DateTime.Now;
        }
    }

    public class VoucherQuantitySpecification : Specification<Voucher>
    {
        public override Expression<Func<Voucher, bool>> ToExpression()
        {
            return voucher => voucher.Quantity > 0;
        }
    }

    public class VoucherActiveSpecification : Specification<Voucher>
    {
        public override Expression<Func<Voucher, bool>> ToExpression()
        {
            return voucher => voucher.Active;
        }
    }
}