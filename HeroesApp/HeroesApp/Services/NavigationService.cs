using HeroesApp.Interfaces;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HeroesApp.Services
{
    public class NavigationService : INavigationService
    {
        public async Task NavigateTo(Page page)
        {
            await App.Current.MainPage.Navigation.PushAsync(page);
        }

        public async Task NavigateToBack()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
