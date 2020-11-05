using Acr.UserDialogs;
using HeroesApp.Models;
using HeroesApp.Views;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HeroesApp.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public List<CharacterModel> Characters { get; set; }

        public bool IsBusy { get; set; }

        private CharacterModel _character;
        public CharacterModel Character
        {
            get => _character;
            set
            {
                if(value != null)
                {
                    _character = value;
                    NavigateToDetail(value);
                }
            }
        }

        private string _textFilter { get; set; }
        public string TextFilter
        {
            get
            {
                return _textFilter;
            }
            set
            {
                _textFilter = value;

                if(value.Count() >= 3)
                {
                    SearchText(value);
                }
            }
        }

        public Command RefreshingCommand { get; set; }
        public Command MoreDataCommand { get; set; }

        public MainPageViewModel()
        {

            RefreshingCommand = new Command(LoadData);
            MoreDataCommand = new Command(MoreData);
            //Characters = new List<CharacterModel>();

            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                UserDialogs.Instance.ShowLoading("Loading...");

                IsBusy = true;

                var current = Connectivity.NetworkAccess;
                if (current != NetworkAccess.Internet)
                {
                    App.Current.ShowMessageError("No internet access");
                    return;
                }

                var res = await MarvelService.GetCharacters();

                if (res == null)
                {
                    App.Current.ShowMessageError("Failed to load characters");
                    return;
                }

                Characters = res.Data.Results.ToList();
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string>
                {
                    {"Issue", $"Falha ao carregar a lista de personagens" }
                });
                
                Characters = new List<CharacterModel>();
            }
            finally
            {
                IsBusy = false;
                UserDialogs.Instance.HideLoading();
            }
        }

        private async void MoreData()
        {
            try
            {
                UserDialogs.Instance.ShowLoading("Loading...");

                IsBusy = true;

                var current = Connectivity.NetworkAccess;
                if (current != NetworkAccess.Internet)
                {
                    App.Current.ShowMessageError("No internet access");
                    return;
                }

                var res = await MarvelService.GetCharacters(100);

                if (res == null)
                {
                    App.Current.ShowMessageError("Failed to load characters");
                    return;
                }

                if (!res.Data.Results.ToList().Any())
                {
                    App.Current.ShowMessage("All characters have already been loaded");
                    return;
                }
                Characters.Clear();
                Characters = res.Data.Results.ToList();

            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string>
                {
                    {"Issue", $"Falha ao carregar a lista de personagens" }
                });
            }
            finally
            {
                IsBusy = false;
                UserDialogs.Instance.HideLoading();
            }
        }

        private async void SearchText(string filter)
        {
            try
            {
                //UserDialogs.Instance.ShowLoading("Searching...");

                IsBusy = true;

                var current = Connectivity.NetworkAccess;
                if (current != NetworkAccess.Internet)
                {
                    App.Current.ShowMessageError("No internet access");
                    return;
                }

                var res = await MarvelService.GetCharacters(filter);

                if (res == null)
                {
                    App.Current.ShowMessageError("Failed to load characters");
                    return;
                }

                Characters.Clear();
                Characters = res.Data.Results.ToList();
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string>
                {
                    {"Issue", $"Falha ao carregar a lista de personagens filtrados por {filter}" }
                });

                Characters = new List<CharacterModel>();
            }
            finally
            {
                IsBusy = false;
                //UserDialogs.Instance.HideLoading();
            }
        }

        private async void NavigateToDetail(CharacterModel character)
        {
            await NavigationService.NavigateTo(new DetailsPage(character));
        }
    }
}
