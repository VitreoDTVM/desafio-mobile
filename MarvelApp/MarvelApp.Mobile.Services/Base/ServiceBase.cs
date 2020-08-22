using MarvelApp.Mobile.Services.Resources;
using System;
using System.Net.Http;

namespace MarvelApp.Mobile.Services.Base
{
    public class ServiceBase
    {
        protected string UrlServico = "";
        private HttpClient _httpClient;
        public HttpClient Httplicent
        {
            get
            {
                _httpClient = _httpClient ?? new HttpClient
                (
                    new HttpClientHandler()
                    {
                        ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
                        {
                            return true;
                        },
                    }
                    , false
                )
                {
                    BaseAddress = new Uri(UrlResources.BaseUrl),
                };

                //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", "token");
                return _httpClient;
            }
        }
    }
}
