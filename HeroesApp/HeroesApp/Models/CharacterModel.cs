using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesApp.Models
{
    public class CharacterModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ImageModel Thumbnail { get; set; }
        public List<ComicModel> Comics { get; set; }
    }
}
