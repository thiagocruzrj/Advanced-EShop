using AES.Core.Communication;
using AES.WebApp.MVC.Extensions;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AES.WebApp.MVC.Service
{
    public abstract class Service
    {
        protected StringContent GetContent(object data)
        {
            return new StringContent(
                JsonSerializer.Serialize(data),
                Encoding.UTF8,
                "application/json");
        }

        protected async Task<T> DeserializeObjectResponse<T>(HttpResponseMessage requestMessage)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<T>(await requestMessage.Content.ReadAsStringAsync(), options);
        }

        protected bool HandlingErrorsReponse(HttpResponseMessage response)
        {
            switch ((int)response.StatusCode)
            {
                case 401:
                case 403:
                case 404:
                case 500:
                    throw new CustomHttpResponseException(response.StatusCode);

                case 400:
                    return false;
            }

            response.EnsureSuccessStatusCode();
            return true;
        }

        protected ResponseResult ReturnOk()
        {
            return new ResponseResult();
        }
    }
}