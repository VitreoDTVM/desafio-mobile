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
    public partial class CharacterDetailView : ContentPage
    {
        public CharacterDetailView()
        {
            InitializeComponent();
        }
        bool IsBottomSheetVisible = false;
        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!IsBottomSheetVisible)
            {
                BottomSheetId.IsVisible = IsBottomSheetVisible = true;
                await Task.Delay(100);
                await BottomSheetId.TranslateTo(0, 400, 400, Easing.SinIn);

            }
            else
            {

                await BottomSheetId.TranslateTo(0, 600, 550, Easing.SinOut);
                await Task.Delay(100);
                BottomSheetId.IsVisible = IsBottomSheetVisible = false;

            }

        }
    }
}