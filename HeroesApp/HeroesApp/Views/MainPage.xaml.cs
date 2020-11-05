using FormsControls.Base;
using HeroesApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace HeroesApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : AnimationPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }
    }
}
