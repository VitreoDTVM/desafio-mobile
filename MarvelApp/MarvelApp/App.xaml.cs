using MarvelApp.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MarvelApp
{
    public partial class App : Application
    {
        public static string BaseUrl = "https://gateway.marvel.com/v1/public/";
        private NavigationService navigationService;

        public App()
        {
            InitializeComponent();
            navigationService = new NavigationService();

            navigationService.SetMainView("HomeView");
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
