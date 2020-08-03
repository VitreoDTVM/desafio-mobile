using MarvelApp.Models;
using MarvelApp.Services;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MarvelApp.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private DataService dataService;
        private NavigationService navigationService;
        private CharacterViewModel characterViewModel;
        private FavoriteViewModel favoriteViewModel;
        private ObservableRangeCollection<AppPage> _pages;

        public DataService DataService()
        {
            return dataService = Xamarin.Forms.DependencyService.Get<DataService>();
        }
        public NavigationService NavigationService()
        {
            return navigationService = Xamarin.Forms.DependencyService.Get<NavigationService>();

        }
        public HomeViewModel()
        {
            dataService = new DataService();
            navigationService = new NavigationService();
            characterViewModel = new CharacterViewModel(DataService(), NavigationService());
            favoriteViewModel = new FavoriteViewModel(DataService());
            Pages = GetPages();

        }
        public ObservableRangeCollection<AppPage> Pages {
            get {
                return _pages;
            }
            set {
                SetProperty(ref _pages, value);
            }
        }
        private ObservableRangeCollection<AppPage> GetPages()
        {
            return new ObservableRangeCollection<AppPage>
            {
                new AppPage
                {
                    Name = "PERSONAGENS",
                    Icon = "menu_heroe",
                    Type = AppPageType.Character,
                    ViewModel = characterViewModel
                },
                new AppPage
                {
                    Name = "FAVORITOS",
                    Icon = "menu_heart",
                    Type = AppPageType.Favorite,
                    ViewModel = favoriteViewModel
                }
            };
        }
        private async Task ExecuteSubmitAsync()
        {
            try
            {

            }
            catch (Exception exception)
            {
       
                var properties = new Dictionary<string, string> {
    { "HomeViewModel.cs", "ExecuteSubmitAsync"}};
                //Crashes.TrackError(exception, properties);
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert(
"Erro!",
"Atenção, ocorreu um erro, por favor, reinicie o app.",
"OK");
            }

        }
    }
}
