using System.Collections.ObjectModel;
using MVitreo.Models;
using MVitreo.Services.Interfaces;
using Prism.Navigation;
using Prism.Services;

namespace MVitreo.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<Character> Characters { get; }
        IMarvelService MarvelService;
        public MainViewModel(INavigationService navigationService,
                IPageDialogService pageDialogService, IMarvelService marvelService) : base(navigationService, pageDialogService)
        {
            Characters = new ObservableCollection<Character>();
            MarvelService = marvelService;
        }
    }
}
