using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MVitreo.Helpers;
using MVitreo.Models;
using MVitreo.Services.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MVitreo.Services
{
    public class MarvelService : IMarvelService
    {
        public async Task<List<Character>> GetCharactersAsync(string value)
        {
            var ret = new List<Character>();

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(CompleteUrl(MarvelAuthenticationHelper.Character, MarvelAuthenticationHelper.NameStartsWith, value));
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var jObject = JObject.Parse(content);
                    var jArray = (JArray)jObject["data"]["results"];

                    ret = JsonConvert.DeserializeObject<List<Character>>(jArray.ToString());

                }
                return ret;
            }
        }

        private string CompleteUrl(params string[] values)
        {
            string urlFinal = $"{MarvelAuthenticationHelper.BaseUrl}{values}&ts={1}&apiKey={MarvelAuthenticationHelper.PublicKey}&hash{MarvelAuthenticationHelper.Hash}";
            return urlFinal;
        }
    }
}
