using FFImageLoading;
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

namespace MarvelApp.Views.Template
{
    [DesignTimeVisible(true)]
    public partial class CharacterTemplateView : ContentView
    {
        public CharacterTemplateView()
        {
            InitializeComponent();

        }
        protected override async void OnBindingContextChanged()
        {
            await OnBindingContextChangedAsync();
        }

        private async Task OnBindingContextChangedAsync()
        {
            base.OnBindingContextChanged();
            //Analytics.TrackEvent("CharacterTemplate");

            if (BindingContext is AppPage appPage)
                if (appPage.ViewModel is CharacterViewModel viewModel)
                    await viewModel.InitializeAsync();
        }
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
        }
            private void Heroescollectionview_Scrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            var line = e.CenterItemIndex;

            var transY = Convert.ToInt32(SearchView.TranslationY);
            if (transY == 0 &&
                e.VerticalDelta > 15)
            {
                var trans = SearchView.Height + SearchView.Margin.Top;
                // need contentpage var safeInsets = On<Xamarin.Forms.PlatformConfiguration.iOS>().SafeAreaInsets();

                ImageService.Instance.SetPauseWork(false);

                Task.WhenAll(
                    SearchView.TranslateTo(0, -(trans + 8), 250, Easing.CubicIn),
                    SearchView.FadeTo(0, 200));               
            }
            else if (transY != 0 &&
                     e.VerticalDelta < 0 &&
                     Math.Abs(e.VerticalDelta) > 10)
            {
                Task.WhenAll(
                    SearchView.TranslateTo(0, 0, 250, Easing.CubicOut),
                    SearchView.FadeTo(1, 200));
                ImageService.Instance.SetPauseWork(true);

            }

            //else if(transY == 0 &&
            //        e.VerticalDelta <=1)
            //{
            //    Task.WhenAll(
            //        SearchView.TranslateTo(0, 0, 250, Easing.CubicOut),
            //        SearchView.FadeTo(1, 200));
            //}

            //precisão maior para validar.
            bool IsScrollUp = e.VerticalDelta < 0;

            if (IsScrollUp)
            {
                ImageService.Instance.SetPauseWork(true);
            }
            else
            {
                ImageService.Instance.SetPauseWork(false);
            }
        }
    }
}