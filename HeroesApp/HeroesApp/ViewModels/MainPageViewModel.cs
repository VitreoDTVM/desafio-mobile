using HeroesApp.Models;
using HeroesApp.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public MainPageViewModel()
        {
            LoadData();
        }

        private async void LoadData()
        {
            try
            {
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
            }
        }

        private async void NavigateToDetail(CharacterModel character)
        {
            await NavigationService.NavigateTo(new DetailsPage(character));
        }
    }
}
