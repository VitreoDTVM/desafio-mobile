using HeroesApp.Interfaces;
using HeroesApp.Models;
using Flurl;
using Flurl.Http;

using System;
using System.Threading.Tasks;
using System.Diagnostics;
using HeroesApp.Helpers;
using System.Security.Cryptography;
using System.Text;

namespace HeroesApp.Services
{
    public class MarvelService : IMarvelService
    {
        public async Task<BaseModel<CharacterModel>> GetCharacters()
        {
            try
            {
                //string timestamp = (DateTime.Now.ToUniversalTime() - new DateTime(2020, 1, 1)).TotalSeconds.ToString();
                string timestamp = "1";
                string hash = CreateHash(String.Format("{0}{1}{2}", timestamp, Constants.PRIVATE_KEY, Constants.API_KEY));

                var characters = await Url.Combine(Constants.BASE_URL + "/characters")
                    .SetQueryParams(new
                    {
                        ts = timestamp,
                        apikey = Constants.API_KEY,
                        hash = hash,
                    })
                    .GetJsonAsync<BaseModel<CharacterModel>>();

                return characters;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

                return null;
            }
        }

        private string CreateHash(string value)
        {
            string hash = "";

            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(value));

                StringBuilder sBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                hash = sBuilder.ToString();
            }

            return hash;
        }

        public Task GetCharactersById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
