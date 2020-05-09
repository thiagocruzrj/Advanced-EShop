using System;
using System.Net.Http;

namespace AES.WebApp.MVC.Service
{
    public abstract class Service
    {
        protected bool HandlingErrorsReponse(HttpResponseMessage response)
        {
            switch ((int)response.StatusCode)
            {
                case 401:
                case 403:
                case 404:
                case 500:
                    throw new Exception();

                case 400:
                    return false;
            }

            response.EnsureSuccessStatusCode();
            return true;
        }
    }
}
