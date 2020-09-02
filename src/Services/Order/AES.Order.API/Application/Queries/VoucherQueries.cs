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

        public async Task<VoucherDTO> GetVoucherByCode(string code)
        {
            var voucher = await _repository.GetVoucherByCode(code);

            if (voucher == null) return null;

            // Validating valid voucher

            return new VoucherDTO
            {
                Code = voucher.Code,
                DiscountType = (int)voucher.DiscountType,
                Percent = voucher.Percent,
                DiscountValue = voucher.DiscountValue
            };
        }
    }
}
