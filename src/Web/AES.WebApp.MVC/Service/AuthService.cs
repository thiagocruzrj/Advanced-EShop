using AES.WebApp.MVC.Extensions;
using AES.WebApp.MVC.Models;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AES.WebApp.MVC.Service
{
    public class AuthService : Service, IAuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient,
                           IOptions<AppSettings> settings)
        {
            httpClient.BaseAddress = new Uri(settings.Value.AuthUrl);
            _httpClient = httpClient;
        }

        public async Task<UserLoginResponse> Login(UserLogin userLogin)
        {
            var loginContent = GetContent(userLogin);

            var response = await _httpClient.PostAsync("/api/identity/authenticate", loginContent);

            if (!HandlingErrorsReponse(response))
            {
                return new UserLoginResponse
                {
                    ResponseResult = await DeserializeObjectResponse<ResponseResult>(response)
                };
            }
            return await DeserializeObjectResponse<UserLoginResponse>(response);
        }

        public async Task<UserLoginResponse> Register(UserRegister userRegister)
        {
            var registerContent = GetContent(userRegister);

            var response = await _httpClient.PostAsync("/api/identity/new-account", registerContent);

            if (!HandlingErrorsReponse(response))
            {
                return new UserLoginResponse
                {
                    ResponseResult = await DeserializeObjectResponse<ResponseResult>(response)
                };
            }
            return await DeserializeObjectResponse<UserLoginResponse>(response);
        }
    }
}