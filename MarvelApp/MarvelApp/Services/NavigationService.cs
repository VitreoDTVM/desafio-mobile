namespace MarvelApp.Services
{
    using System.Threading.Tasks;
    using MarvelApp.Views;
    using Xamarin.Forms;

    public class NavigationService
    {
        public void SetMainView(string pageName)
        {
            switch (pageName)
            {
                case "HomeView":
                    Application.Current.MainPage = new NavigationPage(new HomeView());
                    break;
            }
        }
        public async Task NavigateOnView(string pageName)
        {
            switch (pageName)
            {
                case "":
                    //Details Page
                    break;
            }
        }
        public async Task NavigateBackView()
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}
