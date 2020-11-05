using HeroesApp.Interfaces;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace HeroesApp.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public INavigationService NavigationService { get; set; }
        public IMarvelService MarvelService { get; set; }

        public string Title { get; set; }

        public BaseViewModel()
        {
            NavigationService = DependencyService.Get<INavigationService>();
            MarvelService = DependencyService.Get<IMarvelService>();

            Title = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
