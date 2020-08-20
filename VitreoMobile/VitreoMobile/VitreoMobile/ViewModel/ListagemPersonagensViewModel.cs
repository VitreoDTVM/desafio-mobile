using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VitreoMobile.Model;

namespace VitreoMobile.ViewModel
{
    public class ListagemPersonagensViewModel
    {


        public async Task<ObservableCollection<Personagem>> getPersonagens()
        {
            string url = "https://gateway.marvel.com:443/v1/public/characters?ts=1597712570&apikey=50f78e20640f0b2782a97cebd009a1a1&hash=82ed952e1439226a7eee8f28a7d04629";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            string conteudo = response.Content.ReadAsStringAsync().Result;

            dynamic resultado = JsonConvert.DeserializeObject(conteudo);
            ObservableCollection<Personagem> personagem = new ObservableCollection<Personagem>();

            foreach (var per in resultado.data.results)
            {
                //adicionando lista de HQ'S referente ao  personagem
                List<HQ> hq = new List<HQ>();
                foreach (dynamic hqs in per.comics.items)
                {
                    hq.Add(new HQ { Nome = hqs.name, Url = hqs.resourceURI });
                }

                string thumbnailPath = per.thumbnail.path;
                personagem.Add(new Personagem
                {
                    id = per.id,
                    Nome = per.name,
                    Descricao = per.description,
                    UrlImagem = thumbnailPath.Replace("http", "https") + "." + per.thumbnail.extension,
                    UrlWiki = per.urls[1].url,
                    HQs = hq
                });
            }
            return  personagem;
        }
    }
}
