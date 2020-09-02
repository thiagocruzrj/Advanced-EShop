using AES.Order.API.Application.DTO;
using System.Threading.Tasks;

namespace AES.Order.API.Application.Queries
{
    public interface IVoucherQueries
    {
        Task<VoucherDTO> GetVoucherByCode(string code);
    }

    public class VoucherQueries
    {
    }
}
