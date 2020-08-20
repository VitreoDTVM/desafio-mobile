using System;
using System.Collections.Generic;
using System.Text;
using VitreoMobile.ViewModel;

namespace VitreoMobile.Model
{
    public class Personagem
    {

        public string id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string UrlImagem { get; set; }
        public string UrlWiki { get; set; }

        public List<HQ> HQs { get; set; }

    }
}
