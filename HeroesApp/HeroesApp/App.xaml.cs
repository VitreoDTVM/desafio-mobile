using Acr.UserDialogs;
using HeroesApp.Interfaces;
using HeroesApp.Services;
using HeroesApp.Views;
using System;
using Xamarin.Forms;

namespace HeroesApp
{
    public partial class App : Application
    {
        public new static App Current;

        public App()
        {
            Xamarin.Forms.Device.SetFlags(new string[] { "Brush_Experimental", "Shapes_Experimental" });

            InitializeComponent();

            Current = this;

            RegisterServices();

            MainPage = new NavigationPage(new MainPage());
        }

        private void RegisterServices()
        {
            DependencyService.Register<INavigationService, NavigationService>();
            DependencyService.Register<IMarvelService, MarvelService>();
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

        #region [ Toasts ]

        public void ShowMessageError(string message)
        {
            ToastConfig toastConfig = new ToastConfig(message)
            {
                BackgroundColor = Color.Red,
                MessageTextColor = Color.White,
                Duration = TimeSpan.FromSeconds(3),
                Position = ToastPosition.Bottom

            };

            UserDialogs.Instance.Toast(toastConfig);
        }

        public void ShowMessageSuccess(string message)
        {
            ToastConfig toastConfig = new ToastConfig(message)
            {
                BackgroundColor = Color.ForestGreen,
                MessageTextColor = Color.White,
                Duration = TimeSpan.FromSeconds(3),
                Position = ToastPosition.Bottom

            };

            UserDialogs.Instance.Toast(toastConfig);
        }

        public void ShowMessage(string message)
        {
            ToastConfig toastConfig = new ToastConfig(message)
            {
                BackgroundColor = Color.FromHex("#F0F0F0"),
                MessageTextColor = Color.Black,
                Duration = TimeSpan.FromSeconds(3),
                Position = ToastPosition.Bottom

            };

            UserDialogs.Instance.Toast(toastConfig);
        }


        #endregion
    }
}
