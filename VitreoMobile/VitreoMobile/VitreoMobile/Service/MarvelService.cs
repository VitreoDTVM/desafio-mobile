using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VitreoMobile.Model;

namespace VitreoMobile.Service
{
    public  class MarvelService
    {
        public async Task<HttpResponseMessage> requisição( string URL = "https://gateway.marvel.com:443/v1/public/characters")
        {

            using (HttpClient client = new HttpClient())
            {
                string url = GerarURL(DateTime.Now.Ticks.ToString() , URL);
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return response;
            }
        }

        private string GerarURL(string ts , string URL , string publicKey = "50f78e20640f0b2782a97cebd009a1a1", string privateKey = "27d21327814209141611e24c02cecefac1c5d0c7")
        {
            byte[] bytes = Encoding.UTF8.GetBytes(ts + privateKey + publicKey);
            var gerador = MD5.Create();
            byte[] bytesHash = gerador.ComputeHash(bytes);
            string hash =  BitConverter.ToString(bytesHash).ToLower().Replace("-", String.Empty);

            string url = $"{URL}?ts={ts}&apikey={publicKey}&hash={hash}";
            return  url;
        }
    }
}
