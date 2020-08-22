using MarvelApp.Domain.Entities;
using MarvelApp.Interfaces;
using MarvelApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MarvelApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterView : ContentPage, IMessage
    {
        public CharacterView(Character character)
        {
            InitializeComponent();
            BindingContext = new CharacterViewModel(character) { Message = this, Navigation = this.Navigation };
        }
    }
}