using AES.WebApp.MVC.Models;
using System.Threading.Tasks;

namespace AES.WebApp.MVC.Service
{
    public class AuthService : IAuthService
    {
        public Task<string> Login(UserLogin userLogin)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> Register(UserRegister userRegister)
        {
            throw new System.NotImplementedException();
        }
    }
}