using AES.WebApp.MVC.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AES.WebApp.MVC.Service
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<string> Login(UserLogin userLogin)
        {
            var loginContent = new StringContent(
                JsonSerializer.Serialize(userLogin),
                Encoding.UTF8,
                "application/json");
            var response = _httpClient.PostAsync("", loginContent);
        }

        public Task<string> Register(UserRegister userRegister)
        {
            throw new System.NotImplementedException();
        }
    }
}