using MarvelApp.Views;
using Xamarin.Forms;

namespace MarvelApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new CharactersListView());
        }
    }
}
