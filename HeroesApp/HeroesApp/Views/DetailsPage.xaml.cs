using HeroesApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HeroesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage()
        {
            InitializeComponent();
            BindingContext = new DetailsPageViewModel();
        }
    }
}