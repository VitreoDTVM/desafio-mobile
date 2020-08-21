using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitreoMobile.Model;
using VitreoMobile.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VitreoMobile.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonagemDetalheView : ContentPage
    {

        public PersonagemDetalheView(Personagem p)
        {
            InitializeComponent();
            this.Title = "Detalhes";
            this.BindingContext = new PersonagemDetalheViewModel(p);
            listView.ItemsSource = p.HQs;


        }

        protected override void OnAppearing()
        {
            listView.EndRefresh();
        }
    }
}