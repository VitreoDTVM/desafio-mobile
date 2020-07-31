using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelApp.Models
{
    public class AppPage
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public AppPageType Type { get; set; }
        public object ViewModel { get; set; }
    }

    public enum AppPageType
    {
        Character,
        Favorite
    }
}
