using HeroesApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace HeroesApp.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public List<CharacterModel> Characters { get; set; }

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

                Characters = res.Items.Results;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
