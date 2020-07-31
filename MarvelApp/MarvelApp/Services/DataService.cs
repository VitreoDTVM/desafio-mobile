using MarvelApp.Services;
using Xamarin.Forms;
[assembly: Dependency(typeof(DataService))]
namespace MarvelApp.Services
{
    using MarvelApp.Models;
    using MonkeyCache;
    using MonkeyCache.SQLite;
    using Newtonsoft.Json;
    using System;
	using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Security.Cryptography;
	using System.Text;
    using System.Threading.Tasks;
    using Xamarin.Essentials;

    public class DataService
    {
		public class HttpResponseException : Exception
		{
			public HttpStatusCode StatusCode { get; private set; }

			public HttpResponseException(HttpStatusCode statusCode, string content) : base(content)
			{
				StatusCode = statusCode;
			}
		}
		IBarrel barrel;

		readonly HttpClient client;

		public DataService()
        {

            client = new HttpClient()
            {
                BaseAddress = new Uri(App.BaseUrl)
            };
            Barrel.ApplicationId = AppInfo.PackageName;
            barrel = Barrel.Create(FileSystem.AppDataDirectory);


        }
        public void ClearCache(string key)
        {
            Barrel.Current.Empty(key);
        }
        public async Task<Response> GetAsync<T>(string url, string key, int mins = 1, bool forceRefresh = false)
        {
            var json = string.Empty;

            List<T> list = new List<T>();
            list = Barrel.Current.Get<List<T>>(key);
            var check = Barrel.Current.IsExpired(key: key);
            if (list != null && !check)
            {
                return new Response
                {
                    IsSuccess = true,
                    Result = list,
                };
            }
            else
            {

                try
                {
                    if (string.IsNullOrWhiteSpace(json))
                    {
                        //await SetHeader();

                        json = await client.GetStringAsync(url);

                        Barrel.Current.Add(key, json, TimeSpan.FromMilliseconds(mins));
                    }
                    var response = JsonConvert.DeserializeObject<List<T>>(json);

                    return new Response
                    {
                        IsSuccess = true,
                        Result = response,
                    };
                    //return JsonConvert.DeserializeObject<T>(json);
                }
                catch (Exception ex)
                {
                    list = new List<T>();

                    return new Response
                    {
                        IsSuccess = true,
                        Result = list,
                    };
                }
            }
        }
       
    }
}
