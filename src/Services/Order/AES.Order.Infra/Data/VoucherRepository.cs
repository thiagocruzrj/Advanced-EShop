using AES.Core.Data;
using AES.Order.Domain.Vouchers;

namespace AES.Order.Infra.Data
{
    public class VoucherRepository : IVoucherRepository
    {
        public IUnitOfWork UnitOfWork => throw new System.NotImplementedException();

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}