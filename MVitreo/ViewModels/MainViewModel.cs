using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MVitreo.Models;
using MVitreo.Services.Interfaces;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace MVitreo.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<Character> Characters { get; set; }
        IMarvelService MarvelService;

        private DelegateCommand<string> _SearchCharacterCommand;
        public DelegateCommand<string> SearchCharacterCommand => _SearchCharacterCommand ?? (_SearchCharacterCommand = new DelegateCommand<string>(async (TextChanged) => await SearchCharacter(TextChanged), (TextChanged) => !IsBusy));

        public MainViewModel(INavigationService navigationService,
                IPageDialogService pageDialogService, IMarvelService marvelService) : base(navigationService, pageDialogService)
        {
            Characters = new ObservableCollection<Character>();
            MarvelService = marvelService;
        }
        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            await LoadAsync();
        }
        private async Task ExecuteExibirPersonagemCommand(Character character)
        {
            var navigationParams = new NavigationParameters
            {
                {"character", character}
            };


            await NavigationService.NavigateAsync("DetalhesPage", navigationParams);
        }

        private async Task LoadAsync()
        {
            try
            {

                var personagensMarvel = await MarvelService.GetCharactersAsync("");

                Characters.Clear();

            }
            catch (Exception ex)
            {
                await PageDialogService.DisplayAlertAsync("Error", "Erro ao Carregar personagens:" + ex.Message, "OK");
            }
        }

        private async Task SearchCharacter(string text)
        {
            if (text.Length >= 3)
            {
                try
                {
                    IsBusy = true;

                    var a = await MarvelService.GetCharactersAsync(text);
                    Characters.Clear();
                    foreach (var item in a)
                    {
                        Characters.Add(item);
                    }

                }
                catch (Exception ex)
                {
                    await PageDialogService.DisplayAlertAsync("Erro", "Erro ao Carregar personagens:" + ex.Message, "OK");
                }
                finally
                {

                    IsBusy = false;
                }
            }
            else
            {
                Characters.Clear();
            }

        }
    }
}
