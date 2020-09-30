using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public async Task<ObservableCollection<Character>> GetCharactersAsync(string value)
        {
            var ret = new ObservableCollection<Character>();

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(CompleteUrl(string.Concat(MarvelAuthenticationHelper.Character, MarvelAuthenticationHelper.NameStartsWith, value)));
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var jObject = JObject.Parse(content);
                    var jArray = (JArray)jObject["data"]["results"];

                    ret = JsonConvert.DeserializeObject<ObservableCollection<Character>>(jArray.ToString());

                }
                return ret;
            }
        }

        private string CompleteUrl(string values)
        {
            string urlFinal = $"{MarvelAuthenticationHelper.BaseUrl}{values}&ts={1}&apikey={MarvelAuthenticationHelper.PublicKey}&hash={MarvelAuthenticationHelper.Hash}";
            return urlFinal;
        }
    }
}
