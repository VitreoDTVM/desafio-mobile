using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace MarvelApp.UITest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp.Android.ApkFile(@"C:/Users/ANDERSON/Source/Repos/desafio-mobile/MarvelApp/MarvelApp.Android/bin/Debug/com.companyname.marvelapp-Signed.apk").EnableLocalScreenshots().StartApp();
            }

            return ConfigureApp.iOS.StartApp();
        }
    }
}