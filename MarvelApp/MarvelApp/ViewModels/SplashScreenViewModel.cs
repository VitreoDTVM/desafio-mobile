
using System.Threading.Tasks;
using Xamarin.Essentials;
using MarvelApp.Services;
using MvvmHelpers;
namespace MarvelApp.ViewModels
{
    public class SplashScreenViewModel : BaseViewModel
    {
        #region Attributes
        NavigationService NavigationService;

        #endregion
        #region Constructors
        public SplashScreenViewModel()
        {
            NavigationService = new NavigationService();
            GoToView();
        }
        #endregion
        #region Methods
        public Task GoToView()
        {
            return MainThread.InvokeOnMainThreadAsync(async () =>
            {
                await Task.Delay(8000);

                NavigationService.SetMainView("HomeView");
            });
        } 
        #endregion
    }
}
