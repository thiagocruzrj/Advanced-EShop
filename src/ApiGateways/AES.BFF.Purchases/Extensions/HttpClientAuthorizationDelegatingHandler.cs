using AES.WebApi.Core.Users;
using System.Net.Http;

namespace AES.BFF.Purchases.Extensions
{
    public class HttpClientAuthorizationDelegatingHandler : DelegatingHandler
    {
        private readonly IAspNetUser _aspNetUser;

        public HttpClientAuthorizationDelegatingHandler(IAspNetUser aspNetUser)
        {
            _aspNetUser = aspNetUser;
        }
    }
}
