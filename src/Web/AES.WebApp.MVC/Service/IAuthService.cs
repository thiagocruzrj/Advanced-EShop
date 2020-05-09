using AES.WebApp.MVC.Models;
using System.Threading.Tasks;

namespace AES.WebApp.MVC.Service
{
    public interface IAuthService
    {
        Task<UserLoginResponse> Login(UserLogin userLogin);
        Task<UserLoginResponse> Register(UserRegister userRegister);
    }
}