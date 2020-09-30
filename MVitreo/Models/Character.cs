using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Newtonsoft.Json;

namespace MVitreo.Models
{
    public class Character
    {
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Description")]
        public string Description { get; set; }
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Thumbnail")]
        public Thumbnail Img { get; set; }
        public string Url { get { return string.Concat(Img.ImageUrl, ".jpg"); } }
        [JsonProperty("Comics")]
        public Comics Comics { get; set; }
    }
    public class Thumbnail
    {
        [JsonProperty("path")]
        public string ImageUrl
        { get; set; }


    }
    public class Comics
    {
        [JsonProperty("Items")]
        public ObservableCollection<Comic> Items { get; set; }
    }

    public class Comic
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

    }
}

