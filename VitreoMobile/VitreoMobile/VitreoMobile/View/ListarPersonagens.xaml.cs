using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VitreoMobile.Model;
using VitreoMobile.ViewModel;
using Xamarin.Forms;

namespace VitreoMobile
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ListarPersonagens : ContentPage
    {
        public ObservableCollection<Personagem> Personagem { get; set; }

        public ListarPersonagens()
        {
            InitializeComponent();
            this.Personagem = new ObservableCollection<Personagem>();
            this.BindingContext = this;

        }

        protected async override void OnAppearing()
        {
            this.Personagem = await new ListagemPersonagensViewModel().getPersonagens();
        }




    }
}
