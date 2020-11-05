namespace HeroesApp.Models
{
    public class ImageModel
    {
        public string Path { get; set; }
        public string Extension { get; set; }
        public string UrlImage => Path + "." + Extension;
    }
}
