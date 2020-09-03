using AES.Core.Controllers;
using AES.Order.API.Application.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AES.Order.API.Controllers
{
    [Authorize]
    public class VoucherController : MainController
    {
        private readonly IVoucherQueries _voucherQueries;

        public VoucherController(IVoucherQueries voucherQueries)
        {
            _voucherQueries = voucherQueries;
        }

        public async Task<IActionResult> GetByCode(string code)
        {
            if (string.IsNullOrEmpty(code)) return NotFound();

            var voucher = await _voucherQueries.GetVoucherByCode(code);

            return voucher == null ? NotFound() : CustomResponse();
        }
    }
}