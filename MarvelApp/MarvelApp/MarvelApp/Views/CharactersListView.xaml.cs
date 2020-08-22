using MarvelApp.Interfaces;
using MarvelApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MarvelApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharactersListView : ContentPage, IMessage
    {
        CharactersViewModel charactersViewModel;
        public CharactersListView()
        {
            InitializeComponent();
            BindingContext = charactersViewModel = new CharactersViewModel { Navigation = this.Navigation, Message = this };
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            charactersViewModel.SearchCommand.Execute(e.NewTextValue);
        }
    }
}