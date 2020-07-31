using MarvelApp.Services;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelApp.ViewModels
{
    public class HomeViewModel: BaseViewModel
    {
        private DataService dataService;
        private CharacterViewModel characterViewModel;
        private FavoriteViewModel favoriteViewModel;
        public DataService DataService()
        {
            return dataService = Xamarin.Forms.DependencyService.Get<DataService>();
        }
        public HomeViewModel()
        {
            dataService = new DataService();
            characterViewModel = new CharacterViewModel(DataService());
            favoriteViewModel = new FavoriteViewModel(DataService());

        }
    }
}
