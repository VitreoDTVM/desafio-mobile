using MarvelApp.Services;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MarvelApp.ViewModels
{
    public class SplashScreenViewModel : BaseViewModel
    {
        NavigationService NavigationService;
        public SplashScreenViewModel()
        {
            NavigationService = new NavigationService();
            GoToView();
        }
        public Task GoToView()
        {
                return MainThread.InvokeOnMainThreadAsync(async () =>
                {
                    await Task.Delay(8000);

                    NavigationService.SetMainView("HomeView");
                });          
        }
    }
}
