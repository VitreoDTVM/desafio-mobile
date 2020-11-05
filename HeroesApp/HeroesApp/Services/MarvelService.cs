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
                string timestamp = "1";
                string hash = CreateHash(String.Format("{0}{1}{2}", timestamp, Constants.PRIVATE_KEY, Constants.API_KEY));

                var characters = await Url.Combine(Constants.BASE_URL + "/characters")
                    .SetQueryParams(new
                    {
                        ts = timestamp,
                        apikey = Constants.API_KEY,
                        hash = hash,
                        limit = 100,
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

        public async Task<BaseModel<CharacterModel>> GetCharacters(string filter)
        {
            try
            {
                string timestamp = "1";
                string hash = CreateHash(String.Format("{0}{1}{2}", timestamp, Constants.PRIVATE_KEY, Constants.API_KEY));

                var characters = await Url.Combine(Constants.BASE_URL + "/characters")
                    .SetQueryParams(new
                    {
                        ts = timestamp,
                        apikey = Constants.API_KEY,
                        hash = hash,
                        limit = 100,
                        nameStartsWith = filter,
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

        public async Task<BaseModel<CharacterModel>> GetCharacters(int offset)
        {
            try
            {
                string timestamp = "1";
                string hash = CreateHash(String.Format("{0}{1}{2}", timestamp, Constants.PRIVATE_KEY, Constants.API_KEY));

                var characters = await Url.Combine(Constants.BASE_URL + "/characters")
                    .SetQueryParams(new
                    {
                        ts = timestamp,
                        apikey = Constants.API_KEY,
                        hash = hash,
                        limit = offset,
                        offset = offset,
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

        public async Task<BaseModel<ComicModel>> GetComicById(long characterId)
        {
            try
            {
                string timestamp = "1";
                string hash = CreateHash(String.Format("{0}{1}{2}", timestamp, Constants.PRIVATE_KEY, Constants.API_KEY));

                var characters = await Url.Combine(Constants.BASE_URL + $"/characters/{characterId}/comics")
                    .SetQueryParams(new
                    {
                        ts = timestamp,
                        apikey = Constants.API_KEY,
                        hash = hash,
                    })
                    .GetJsonAsync<BaseModel<ComicModel>>();

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

        
    }
}
