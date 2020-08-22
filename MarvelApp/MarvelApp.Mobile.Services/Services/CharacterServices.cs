using MarvelApp.Domain.Entities;
using MarvelApp.Mobile.Services.Base;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarvelApp.Mobile.Services.Services
{
    public class CharacterServices : ServiceBase
    {
        public async Task<Root> GetAll()
        {
            var result = await Httplicent.GetAsync(Httplicent.BaseAddress+"/characters?ts=1597812048&apikey=bae5d588e7e713d35dc61e37ba98d01f&hash=822fc9d8bb714265790f4130add38a40");
            return JsonConvert.DeserializeObject<Root>(await result.Content.ReadAsStringAsync(), new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        } 
    }
}
