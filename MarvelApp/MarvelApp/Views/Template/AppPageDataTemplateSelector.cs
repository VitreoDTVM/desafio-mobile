using MarvelApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MarvelApp.Views.Template
{
    public class AppPageDataTemplateSelector : DataTemplateSelector
    {
        private readonly DataTemplate _character;
        private readonly DataTemplate _favorite;
        public AppPageDataTemplateSelector()
        {
            _character = new DataTemplate(typeof(CharacterTemplateView));
            _favorite = new DataTemplate(typeof(FavoriteTemplateView));

        }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is AppPage appPage)
            {
                if (appPage.Type == AppPageType.Character)
                    return _character;
                if (appPage.Type == AppPageType.Favorite)
                    return _favorite;
                return new DataTemplate(typeof(ContentView));
            }
            return new DataTemplate(typeof(ContentView));
        }
    }
}