using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Content.Res;
using FFImageLoading.Forms.Platform;
namespace MarvelApp.Droid
{
    [Activity(Label = "Marvel", 
        Icon = "@mipmap/icon", 
        Theme = "@style/MainTheme", 
        MainLauncher = true,
        //Android 7+ 
        RoundIcon = "@mipmap/launcher_foreground",
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            if (IsTablet(ApplicationContext))
                RequestedOrientation = ScreenOrientation.Landscape;
            else
                RequestedOrientation = ScreenOrientation.Portrait;
            int uiOptions = (int)Window.DecorView.SystemUiVisibility;
            //uiOptions |= (int)SystemUiFlags.LowProfile;
            uiOptions |= (int)SystemUiFlags.Fullscreen;
            uiOptions |= (int)SystemUiFlags.HideNavigation;
            uiOptions |= (int)SystemUiFlags.ImmersiveSticky;
            uiOptions |= (int)SystemUiFlags.LayoutFullscreen;
            Window.DecorView.SystemUiVisibility = (StatusBarVisibility)uiOptions;

            Window.AddFlags(WindowManagerFlags.Fullscreen);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            CachedImageRenderer.Init(true);

            Xamarin.Forms.DependencyService.Register<DependencyServices.FileStore>();

            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public static bool IsTablet(Context context)
        {
            ScreenLayout screenSize = context.Resources.Configuration.ScreenLayout & ScreenLayout.SizeMask;
            bool tablet = false;

            switch (screenSize)
            {
                case ScreenLayout.SizeXlarge:
                    tablet = true;
                    break;
                case ScreenLayout.SizeLarge:
                    tablet = true;
                    break;
            }
            return tablet;
        }
        public override void OnTrimMemory(TrimMemory level)
        {
            FFImageLoading.ImageService.Instance.InvalidateMemoryCache();
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            base.OnTrimMemory(level);
        }
        public override void OnLowMemory()
        {
            FFImageLoading.ImageService.Instance.InvalidateMemoryCache();
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            base.OnLowMemory();
        }
    }
}