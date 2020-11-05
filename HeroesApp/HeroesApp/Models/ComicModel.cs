using System.Collections.Generic;

namespace HeroesApp.Models
{
    public class ComicModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ImageModel Thumbnail { get; set; }
    }
}
