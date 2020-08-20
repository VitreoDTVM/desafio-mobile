using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using VitreoMobile.Model;
using VitreoMobile.View;
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


        private bool aguarde;

        public bool Aguarde
        {
            get { return aguarde; }


            set {
                aguarde = value;
                OnPropertyChanged();
            }
        }



        public ListarPersonagens()
        {
            InitializeComponent();
            //this.Personagem = await new ListagemPersonagensViewModel().getPersonagens();
            this.BindingContext = this;
            this.Title = "Personagens";
            aguarde = true;
        }

        protected async override void OnAppearing()
        {
            aguarde = true;
            this.Personagem = await new  ListagemPersonagensViewModel().getPersonagens();

            ListPersonagem.ItemsSource = Personagem;
            ListPersonagem.EndRefresh();
            aguarde = false;

        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(e.NewTextValue) && e.NewTextValue.Length >= 3)
                 ListPersonagem.ItemsSource = Personagem.Where(i => i.Nome.Contains(e.NewTextValue));
            else
                ListPersonagem.ItemsSource = Personagem;

            ListPersonagem.EndRefresh();
        }

        private void ListPersonagem_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Personagem personagem = (Personagem)e.Item;
            //DisplayAlert("Teste", $"Voce tocou{personagem.Nome} ", "ok");

              Navigation.PushAsync(new PersonagemDetalheView(personagem),true );
        }

        //public event PropertyChangedEventHandler PropertyChanged;
        //public void OnPropertyChanged([CallerMemberName] string name = "")
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        //}
    }
}
