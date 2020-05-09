using AES.WebApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AES.WebApp.MVC.Controllers
{
    public class MainController : Controller
    {
        protected bool ResponseHasErrors(ResponseResult response)
        {
            if (response != null && response.Errors.Messages.Any())
            {
                return true;
            }

            return false;
        }
    }
}
