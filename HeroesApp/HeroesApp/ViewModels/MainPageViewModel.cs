using Acr.UserDialogs;
using HeroesApp.Models;
using HeroesApp.Views;
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

        public Command RefreshingCommand { get; set; }

        public MainPageViewModel()
        {
            RefreshingCommand = new Command(LoadData);

            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                UserDialogs.Instance.ShowLoading("Carregando...");

                var current = Connectivity.NetworkAccess;
                if (current != NetworkAccess.Internet)
                {
                    App.Current.ShowMessageError("Sem acesso a internet");
                    return;
                }

                var res = await MarvelService.GetCharacters();

                if (res == null)
                {
                    App.Current.ShowMessageError("Falha ao carregar os personagens");
                    return;
                }

                Characters = res.Data.Results.ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

                Characters = new List<CharacterModel>();
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
        }

        private async void NavigateToDetail(CharacterModel character)
        {
            await NavigationService.NavigateTo(new DetailsPage(character));
        }
    }
}
