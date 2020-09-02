using AES.Order.API.Application.DTO;
using AES.Order.Domain.Vouchers;
using System.Threading.Tasks;

namespace AES.Order.API.Application.Queries
{
    public interface IVoucherQueries
    {
        Task<VoucherDTO> GetVoucherByCode(string code);
    }

    public class VoucherQueries : IVoucherQueries
    {
        private readonly IVoucherRepository _repository;

        public VoucherQueries(IVoucherRepository repository)
        {
            _repository = repository;
        }

        public Task<VoucherDTO> GetVoucherByCode(string code)
        {
            throw new System.NotImplementedException();
        }
    }
}
