using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VitreoMobile.Model;
using VitreoMobile.Service;
using Xamarin.Forms;

namespace VitreoMobile.ViewModel
{
    public class ListagemPersonagensViewModel
    {
        private MarvelService service;
        public ListagemPersonagensViewModel()
        {
            this.service = new MarvelService();
        }


        public async Task<ObservableCollection<Personagem>> getPersonagens()
        {
                HttpResponseMessage response = await service.requisição();
                string conteudo = response.Content.ReadAsStringAsync().Result;
                dynamic resultado = JsonConvert.DeserializeObject(conteudo);
                ObservableCollection<Personagem> personagem = new ObservableCollection<Personagem>();
                foreach (var per in resultado.data.results)
                {
                    //adicionando lista de HQ'S referente ao  personagem
                    ObservableCollection<HQ> hq = new ObservableCollection<HQ>();
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
            return personagem;
        }
    }
}
