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

            foreach (var item in resultado.data.results)
            {
                string thumbnailPath = item.thumbnail.path;
                personagem.Add(new Personagem
                {
                    id = item.id,
                    Nome = item.name,
                    Descricao = item.description,
                    UrlImagem = thumbnailPath.Replace("http", "https") + "." + item.thumbnail.extension,
                    UrlWiki = item.urls[1].url
                });
            }

            return personagem;
        }
    }
}
