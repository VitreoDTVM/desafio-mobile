using System.Threading.Tasks;
using Xamarin.Forms;

namespace HeroesApp.Interfaces
{
    public interface INavigationService
    {
        Task NavigateTo(Page page);
        Task NavigateToBack();
    }
}
