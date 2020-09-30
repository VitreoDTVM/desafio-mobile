using MVitreo.ViewModels;
using MVitreo.Views;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using Xamarin.Forms;
using MVitreo.Services.Interfaces;
using MVitreo.Services;

namespace MVitreo
{
    public partial class App : PrismApplication
    {
        public App()
            : this(null)
        {

        }

        public App(IPlatformInitializer initializer)
            : this(initializer, true)
        {

        }

        public App(IPlatformInitializer initializer, bool setFormsDependencyResolver)
            : base(initializer, setFormsDependencyResolver)
        {

        }


        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("/NavigationPage/Main");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();

            containerRegistry.RegisterForNavigation<Main, MainViewModel>();
            containerRegistry.RegisterForNavigation<Character, CharacterViewModel>();

            containerRegistry.RegisterSingleton<IMarvelService, MarvelService>();
        }
    }
}

