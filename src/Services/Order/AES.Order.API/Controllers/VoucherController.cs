using AES.Core.Controllers;
using AES.Order.API.Application.Queries;
using Microsoft.AspNetCore.Authorization;

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
    }
}