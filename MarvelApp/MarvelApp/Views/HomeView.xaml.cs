using MarvelApp.DependencyServices;
using MarvelApp.Models;
using MarvelApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MarvelApp.Views
{
    [DesignTimeVisible(true)]
    public partial class HomeView : ContentPage
    {
        private HomeViewModel vm;

        public HomeViewModel VM {
            get => vm; set {
                vm = value;
            }
        }
        public HomeView()
        {
            InitializeComponent();
            VM = new HomeViewModel();
            BindingContext = VM;
            SelectFirstItem();
        }
        private void SelectFirstItem()
        {
            if (Footer.Children.FirstOrDefault() is StackLayout stackLayout)
                ChangeState(stackLayout, "Selected");
        }

        void CarouselView_CurrentItemChanged(System.Object sender, Xamarin.Forms.CurrentItemChangedEventArgs e)
        {
            if (e.CurrentItem is AppPage currentItem)
            {               
                var currentPageIndex = VM.Pages.IndexOf(currentItem);
                if (Footer.Children[currentPageIndex] is StackLayout stackLayout)
                    ChangeState(stackLayout, "Selected");
            }

            if (e.PreviousItem is AppPage previousItem)
            {
                var previousPageIndex = VM.Pages.IndexOf(previousItem);

                if (Footer.Children[previousPageIndex] is StackLayout stackLayout)
                    ChangeState(stackLayout, "UnSelected");
            }
        }

        private void ChangeState(StackLayout stackLayout, string stateName)
        {
            if (stackLayout.Children.FirstOrDefault() is Image icon)
                VisualStateManager.GoToState(icon, stateName);

            if (stackLayout.Children.LastOrDefault() is Label name)
                VisualStateManager.GoToState(name, stateName);
        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            if (sender is StackLayout stackLayout)
            {
                var index = Footer.Children.IndexOf(stackLayout);
                CarouselView.ScrollTo(index);
            }
        }
        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (await DisplayAlert("Atenção!", "Você quer mesmo sair do aplicativo?", "Sim", "Não"))
                {
                    base.OnBackButtonPressed();
                    var closeApplication = Xamarin.Forms.DependencyService.Get<ICloseApplication>();
                    if (closeApplication != null) closeApplication.CloseApp();
                }
            });

            return true;
        }
        bool started = false;
        int update = 0;
        protected async override void OnAppearing()
        {
            try
            {
                if (AppSettings.NewFavoriteAdd)
                {
                    await VM.LoadFavorites();
                    AppSettings.NewFavoriteAdd = false;

                }


            }
            catch (Exception exception)
            {
                var properties = new Dictionary<string, string> {
    { "HomeView.cs", "OnAppearingHomeView"}};
                //Crashes.TrackError(exception, properties);
            }
        }

    }
}