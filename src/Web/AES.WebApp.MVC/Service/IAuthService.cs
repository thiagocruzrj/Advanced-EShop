using AES.WebApp.MVC.Models;
using System.Threading.Tasks;

namespace AES.WebApp.MVC.Service
{
    public interface IAuthService
    {
        Task<string> Login(UserLogin userLogin);
        Task<string> Register(UserRegister userRegister);
    }
}
