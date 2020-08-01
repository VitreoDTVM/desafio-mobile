using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelApp.Models
{
    public class Thumbnail
    {

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("extension")]
        public string Extension { get; set; }
        public string ImagePath {
            get {
                if (string.IsNullOrEmpty(Path))
                {
                    return "noimage";
                }

                return string.Format($"{Path.Replace("http","https")}{"."}{Extension}");
            }
        }
    }

    public class Item
    {

        [JsonProperty("resourceURI")]
        public string ResourceURI { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Comics
    {

        [JsonProperty("available")]
        public int Available { get; set; }

        [JsonProperty("collectionURI")]
        public string CollectionURI { get; set; }

        [JsonProperty("items")]
        public IList<Item> Items { get; set; }

        [JsonProperty("returned")]
        public int Returned { get; set; }
    }

    public class Item1
    {

        [JsonProperty("resourceURI")]
        public string ResourceURI { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Series
    {

        [JsonProperty("available")]
        public int Available { get; set; }

        [JsonProperty("collectionURI")]
        public string CollectionURI { get; set; }

        [JsonProperty("items")]
        public IList<Item> Items { get; set; }

        [JsonProperty("returned")]
        public int Returned { get; set; }
    }

    public class Item3
    {

        [JsonProperty("resourceURI")]
        public string ResourceURI { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class Stories
    {

        [JsonProperty("available")]
        public int Available { get; set; }

        [JsonProperty("collectionURI")]
        public string CollectionURI { get; set; }

        [JsonProperty("items")]
        public IList<Item2> Items { get; set; }

        [JsonProperty("returned")]
        public int Returned { get; set; }
    }

    public class Item2
    {

        [JsonProperty("resourceURI")]
        public string ResourceURI { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Events
    {

        [JsonProperty("available")]
        public int Available { get; set; }

        [JsonProperty("collectionURI")]
        public string CollectionURI { get; set; }

        [JsonProperty("items")]
        public IList<Item> Items { get; set; }

        [JsonProperty("returned")]
        public int Returned { get; set; }
    }

    public class Url
    {

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("url")]
        public string Urll { get; set; }
    }

    public class Result
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("modified")]
        public DateTime Modified { get; set; }

        [JsonProperty("thumbnail")]
        public Thumbnail Thumbnail { get; set; }

        [JsonProperty("resourceURI")]
        public string ResourceURI { get; set; }

        [JsonProperty("comics")]
        public Comics Comics { get; set; }

        [JsonProperty("series")]
        public Series Series { get; set; }

        [JsonProperty("stories")]
        public Stories Stories { get; set; }

        [JsonProperty("events")]
        public Events Events { get; set; }

        [JsonProperty("urls")]
        public IList<Url> Urls { get; set; }
    }

    public class Data
    {

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("results")]
        public IList<Result> Results { get; set; }
    }

    public class Character
    {

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("copyright")]
        public string Copyright { get; set; }

        [JsonProperty("attributionText")]
        public string AttributionText { get; set; }

        [JsonProperty("attributionHTML")]
        public string AttributionHTML { get; set; }

        [JsonProperty("etag")]
        public string Etag { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }
    }
}
