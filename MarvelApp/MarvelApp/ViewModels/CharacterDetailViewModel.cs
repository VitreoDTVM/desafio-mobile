using MarvelApp.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MarvelApp.ViewModels
{
    public class CharacterDetailViewModel : BaseViewModel
    {
        private ObservableRangeCollection<Item> _items;
        private string _IconFavoriteValue;

        public string ImagePath { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ObservableRangeCollection<Item> Items {
            get {
                return _items;
            }
            set {
                SetProperty(ref _items, value);
            }
        }
        public string IconFavoriteValue {
            get {
                return _IconFavoriteValue;
            }
            set {
                SetProperty(ref _IconFavoriteValue, value);
            }
        }
        public Command GoToFavorite { get; private set; }
        Result result;
        public CharacterDetailViewModel(Result result)
        {
            Items = new ObservableRangeCollection<Item>();
            this.result = result;
            this.ImagePath = result.Thumbnail.ImagePath;
            this.Description = result.Description;
            this.Name = result.Name;
            Items.AddRange(result.Comics.Items);
            GoToFavorite = new Command(async () => { await Favorite(); });
            _ = UpdateIconFavorite();
        }
        public async Task<bool> UpdateIconFavorite()
        {
            var listfavorite = await App.Database.CheckFavorite(this.result.Id);
            if (listfavorite != null)
            {
                IconFavoriteValue = "ic_favorite2";
                return true;
            }
            else
            {
                IconFavoriteValue = "ic_no_favorite";
                return false;

            }
        }
        public async Task Favorite()
        {
            try
            {
                var character = new Charactters
                {
                    Id = result.Id,
                    ImagePath = result.Thumbnail.ImagePath,
                    Description = result.Description,
                    Name = result.Name
                };
                var check = await UpdateIconFavorite();
                if (check)
                {

                    await App.Database.DeleteFavorite(character);

                    await App.Current.MainPage.DisplayAlert("Sucesso!", "Removido com sucesso", "OK");
                    AppSettings.NewFavoriteAdd = true;
                }
                else
                {
                    AppSettings.NewFavoriteAdd = true;
                    await App.Database.SaveFavorite(character);
                    await App.Current.MainPage.DisplayAlert("Sucesso!", "Adicionado com sucesso", "OK");
                }
                await UpdateIconFavorite();

            }
            catch (Exception exception)
            {
                var properties = new Dictionary<string, string> {
                                    { "CharacterDetailViewModel.cs", "Favorite" }};
               // Crashes.TrackError(exception, properties);
            }
        }
    }
}
