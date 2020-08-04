using MarvelApp.Models;
using MarvelApp.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelApp.ViewModels
{
    public class FavoriteViewModel : BaseViewModel
    {
        private DataService dataService;
        private ObservableRangeCollection<Result> _favorite;
        private bool _Click;
        private string _message;

        public ObservableRangeCollection<Result> Favorites {
            get {
                return _favorite;
            }
            set {
                SetProperty(ref _favorite, value);
            }
        }
        public bool IsClick {
            get {
                return _Click;
            }
            set {
                SetProperty(ref _Click, value);
            }
        }
        public string Message {
            get {
                return _message;
            }
            set {
                SetProperty(ref _message, value);
            }
        }
        public Command<Result> GoToDetails { get; set; }

        public FavoriteViewModel(DataService dataService)
        {
            Message = "CARREGANDO OS PERONAGENS..";

            this.dataService = dataService;
            GoToDetails = new Command<Result>(async (heroe) => await GoToHeroesDetails(heroe));
            Favorites = new ObservableRangeCollection<Result>();

        }
        public async Task LoadFavorites()
        {
            try
            {
                var favorite = await App.Database.GetFavorites();
                if (favorite.Count > 0 && favorite.Any())
                    foreach (var item in favorite)
                    {
                        if (item != null)
                        {
                            var thum = new Thumbnail
                            {
                                ImagePath = item.ImagePath,
                            };

                            var favorites = new Result
                            {
                                Name = item.Name,
                                Thumbnail = thum,

                            };
                            Favorites.Add(favorites);
                        }

                    }
                else
                    Message = "VOCÊ AINDA NÃO ADICIONOU FAVORITOS";
            }
            catch (Exception exception)
            {
                Favorites = new ObservableRangeCollection<Result>();
                Favorites.AddRange(Favorites);
                var properties = new Dictionary<string, string> {
                                    { "FavoriteViewModel.cs", "LoadFavorites" }};
                // Crashes.TrackError(exception, properties);
            }

        }
        public async Task GoToHeroesDetails(Result result)
        {
            if (!IsClick)
            {
                IsClick = true;
                return;
            }
            IsClick = false;

            //
            IsClick = true;

        }
    }
}
    
