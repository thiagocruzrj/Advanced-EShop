using AES.Core.Controllers;
using Microsoft.AspNetCore.Authorization;

namespace AES.ShopCart.API.Controllers
{
    [Authorize]
    public class ShopCartController : MainController
    {
    }
}
