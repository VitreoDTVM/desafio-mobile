using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelApp.Models
{
    public class Character
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description ")]
        public string Description { get; set; }

        [JsonProperty("thumbnail ")]
        public string Thumbnail { get; set; }

        [JsonProperty("modified ")]
        public string Modified { get; set; }

        [JsonProperty("resourceURI ")]
        public string ResourceURI { get; set; }

        [JsonProperty("urls ")]
        public string Urls { get; set; }

        [JsonProperty("events ")]
        public string Events { get; set; }
        [JsonProperty("stories  ")]
        public string Stories { get; set; }
        [JsonProperty("comics  ")]
        public string Comics { get; set; }
        [JsonProperty("series  ")]
        public string Series { get; set; }
    }
}
