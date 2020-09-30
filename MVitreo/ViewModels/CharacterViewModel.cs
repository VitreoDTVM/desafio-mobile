using System;
using System.Collections.ObjectModel;
using MVitreo.Models;
using Prism.Navigation;
using Prism.Services;

namespace MVitreo.ViewModels
{
    public class CharacterViewModel : BaseViewModel
    {
        private Character _character;
        public Character Character 
        {
            get => _character;
            set => SetProperty(ref _character, value);
        }

        


        protected CharacterViewModel(INavigationService navigationService,
                IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("character"))
            {
                Character = (Character)parameters["character"];
                                IsNotEmptyData = Character.Comics != null && Character.Comics.Items.Count > 0;
            }

        }
        public bool IsNotEmptyData = false;

    }
}
