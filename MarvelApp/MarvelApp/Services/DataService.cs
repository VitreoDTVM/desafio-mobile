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

			var hash = GetHash($"{AppSettings.PrivateKey}{AppSettings.PublicKey}");


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
            //if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            //    list = Barrel.Current.Get<List<T>>(key);
            //else if (!forceRefresh && !Barrel.Current.IsExpired(key))
            //    list = Barrel.Current.Get<List<T>>(key);


        }
        private string GetHash(string input)
		{
			using (var hash = MD5.Create())
			{
				byte[] data = hash.ComputeHash(Encoding.UTF8.GetBytes(input));
				var strBuilder = new StringBuilder();

				for (int i = 0; i < data.Length; i++)
				{
					strBuilder.Append(data[i].ToString("x2"));
				}

				return strBuilder.ToString();
			}
		}
	}
}
