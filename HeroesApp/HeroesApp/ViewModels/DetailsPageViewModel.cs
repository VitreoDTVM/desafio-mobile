using Acr.UserDialogs;
using HeroesApp.Models;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace HeroesApp.ViewModels
{
    public class DetailsPageViewModel : BaseViewModel
    {
        public string UrlImage { get; set; }
        public string Description { get; set; }
        public List<ComicModel> Comics { get; set; }

        public DetailsPageViewModel(CharacterModel character)
        {
            Title = character.Name;
            UrlImage = character.Thumbnail.UrlImage;
            Description = character.Description;

            LoadData(character.Id);
        }

        private async void LoadData(long characterId)
        {
            try
            {
                UserDialogs.Instance.ShowLoading("Loading...");

                Comics = new List<ComicModel>();

                var current = Connectivity.NetworkAccess;
                if (current != NetworkAccess.Internet)
                {
                    App.Current.ShowMessageError("No internet access");
                    return;
                }

                var comics = await MarvelService.GetComicById(characterId);

                if (comics == null)
                {
                    App.Current.ShowMessage("No comic found");
                    return;
                }

                Comics = comics.Data.Results.ToList();

            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string>
                {
                    {"Issue", $"Falha ao carregar a lista de HQ's do personagem{Title}" }
                });

                Comics = new List<ComicModel>();
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
        }
    }
}
