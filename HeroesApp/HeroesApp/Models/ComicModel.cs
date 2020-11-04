using System.Collections.Generic;

namespace HeroesApp.Models
{
    public class ComicModel
    {
        public int Available { get; set; }
        public List<ComicItemModel> Items { get; set; }
    }
}
