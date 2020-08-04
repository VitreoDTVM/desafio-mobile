using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarvelApp.Models;
using MarvelApp.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;
namespace MarvelApp.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        #region Attributes
        private DataService dataService;
        private NavigationService navigationService;
        private CharacterViewModel characterViewModel;
        private FavoriteViewModel favoriteViewModel;
        private ObservableRangeCollection<AppPage> _pages;
        private bool _isBusy;
        #endregion
        #region Properties
        public ObservableRangeCollection<AppPage> Pages {
            get {
                return _pages;
            }
            set {
                SetProperty(ref _pages, value);
            }
        }
        public new bool IsBusy {
            get => _isBusy;
            private set => SetProperty(ref _isBusy, value);
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
        #endregion
        #region Commands
        public IAsyncCommand ReloadFavorites { get; private set; }

        #endregion
        #region Singleton
        public DataService DataService()
        {
            return dataService = Xamarin.Forms.DependencyService.Get<DataService>();
        }
        public NavigationService NavigationService()
        {
            return navigationService = Xamarin.Forms.DependencyService.Get<NavigationService>();

        } 
        #endregion
        #region Constructors
        public HomeViewModel()
        {
            dataService = new DataService();
            navigationService = new NavigationService();
            characterViewModel = new CharacterViewModel(DataService(), NavigationService());
            favoriteViewModel = new FavoriteViewModel(DataService());
            ReloadFavorites = new AsyncCommand(LoadFavorites, CanExecuteSubmit);
            Pages = GetPages();
        }

        #endregion
        #region Methods
        public async Task LoadFavorites()
        {
            await favoriteViewModel.LoadFavorites();
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

        public bool CanExecuteSubmit(object tr)
        {
            return !IsBusy;
        } 
        #endregion
    }
}
