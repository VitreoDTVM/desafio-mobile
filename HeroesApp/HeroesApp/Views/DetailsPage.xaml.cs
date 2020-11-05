using HeroesApp.Models;
using HeroesApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HeroesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage(CharacterModel character)
        {
            InitializeComponent();
            BindingContext = new DetailsPageViewModel(character);
        }
    }
}