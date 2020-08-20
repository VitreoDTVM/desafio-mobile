using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitreoMobile.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VitreoMobile.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonagemDetalheView : ContentPage
    {

        public Personagem Personagem { get; set; }
        public PersonagemDetalheView(Personagem personagem)
        {
            InitializeComponent();
            this.Title = "Detalhes";
            this.Personagem = personagem;
            this.BindingContext = this;
            listView.ItemsSource = Personagem.HQs;
        }

        protected override void OnAppearing()
        {
            this.Personagem = Personagem;



        }
    }
}