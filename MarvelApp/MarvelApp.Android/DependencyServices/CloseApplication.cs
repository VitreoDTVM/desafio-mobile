using MarvelApp.DependencyServices;
using MarvelApp.Droid.DependencyServices;
using Xamarin.Forms;

[assembly: Dependency(typeof(CloseApplication))]

namespace MarvelApp.Droid.DependencyServices
{
    public class CloseApplication : ICloseApplication
    {
        public void CloseApp()
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());

        }
    }
}