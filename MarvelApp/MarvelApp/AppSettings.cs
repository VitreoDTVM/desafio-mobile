using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace MarvelApp
{
    public class AppSettings
    {
        public static string PublicKey = "a74cebac8fa9e066338acbe3985f47ef";
        public static string PrivateKey = "d7a72f66cde6663e6880b10b7ae73334cfd9174f";

        public static bool NewFavoriteAdd {
            get => Preferences.Get(nameof(NewFavoriteAdd), false);
            set => Preferences.Set(nameof(NewFavoriteAdd), value);
        }
    }
}
