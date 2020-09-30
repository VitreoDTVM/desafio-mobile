using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace MVitreo.Models
{
    public class Character
    {
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Thumbnail")]
        public Thumbnail Img { get; set; }
        public string Url { get { return string.Concat(Img.ImageUrl, ".jpg"); } }

        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

    }
    public class Thumbnail
    {
        [JsonProperty("path")]
        public string ImageUrl
        { get; set; }


    }
}

