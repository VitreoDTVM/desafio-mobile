using HeroesApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesApp.ViewModels
{
    public class DetailsPageViewModel : BaseViewModel
    {
        public string UrlImage { get; set; }
        public string Description { get; set; }
        public List<ComicItemModel> Comics { get; set; }

        public DetailsPageViewModel(CharacterModel character)
        {
            Title = character.Name;
            UrlImage = character.Thumbnail.UrlImage;
            Description = character.Description;
        }
    }
}
