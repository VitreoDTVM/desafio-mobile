using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace MarvelApp.Interfaces
{
    [Preserve(AllMembers = true)]
    public interface IMessage
    {
        Task DisplayAlert(string title, string message, string cancel);

        Task<bool> DisplayAlert(string title, string message, string accept, string cancel);
    }
}
