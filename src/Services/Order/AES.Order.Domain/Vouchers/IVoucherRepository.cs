using AES.Core.Data;
using System.Threading.Tasks;

namespace AES.Order.Domain.Vouchers
{
    public interface IVoucherRepository : IRepository<Voucher> 
    {
        Task<Voucher> GetVoucherByCode(string code);
    }
}