using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace MarvelApp.Domain.Entities
{
    public class Root
    {
        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("copyright")]
        public string Copyright { get; set; }

        [JsonProperty("attributionText")]
        public string AttributionText { get; set; }

        [JsonProperty("attributionHTML")]
        public string AttributionHtml { get; set; }

        [JsonProperty("etag")]
        public string Etag { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public class Data
    {
        [JsonProperty("offset")]
        public long Offset { get; set; }

        [JsonProperty("limit")]
        public long Limit { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("results")]
        public Character[] Characters { get; set; }
    }

    public class Character
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("modified")]
        public string Modified { get; set; }

        private Thumbnail thumbnail;
        [JsonProperty("thumbnail")]
        public Thumbnail Thumbnail 
        {
            get;set;
        }

        public string Url { get {return Thumbnail?.Path?.AbsoluteUri + "/portrait_medium.jpg"; } }

        [JsonProperty("resourceURI")]
        public Uri ResourceUri { get; set; }

        [JsonProperty("comics")]
        public Comics Comics { get; set; }

        [JsonProperty("series")]
        public Comics Series { get; set; }

        [JsonProperty("stories")]
        public Stories Stories { get; set; }

        [JsonProperty("events")]
        public Comics Events { get; set; }

        [JsonProperty("urls")]
        public Url[] Urls { get; set; }
    }

    public class Comics
    {
        [JsonProperty("available")]
        public long Available { get; set; }

        [JsonProperty("collectionURI")]
        public Uri CollectionUri { get; set; }

        [JsonProperty("items")]
        public List<ComicsItem> Items { get; set; }

        [JsonProperty("returned")]
        public long Returned { get; set; }
    }

    public class ComicsItem
    {
        [JsonProperty("resourceURI")]
        public Uri ResourceUri { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class Stories
    {
        [JsonProperty("available")]
        public long Available { get; set; }

        [JsonProperty("collectionURI")]
        public Uri CollectionUri { get; set; }

        [JsonProperty("items")]
        public List<StoriesItem> Items { get; set; }

        [JsonProperty("returned")]
        public long Returned { get; set; }
    }

    public class StoriesItem
    {
        [JsonProperty("resourceURI")]
        public Uri ResourceUri { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class Thumbnail
    {
        [JsonProperty("path")]
        public Uri Path { get; set; }

        public string Url { get; set; }

        [JsonProperty("extension")]
        public Extension Extension { get; set; }
    }

    public class Url
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("url")]
        public Uri UrlUrl { get; set; }
    }

    public enum ItemType { Cover, Empty, InteriorStory };

    public enum Extension { Gif, Jpg };

    public enum UrlType { Comiclink, Detail, Wiki };

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                ItemTypeConverter.Singleton,
                ExtensionConverter.Singleton,
                UrlTypeConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ItemTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ItemType) || t == typeof(ItemType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "":
                    return ItemType.Empty;
                case "cover":
                    return ItemType.Cover;
                case "interiorStory":
                    return ItemType.InteriorStory;
            }
            throw new Exception("Cannot unmarshal type ItemType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ItemType)untypedValue;
            switch (value)
            {
                case ItemType.Empty:
                    serializer.Serialize(writer, "");
                    return;
                case ItemType.Cover:
                    serializer.Serialize(writer, "cover");
                    return;
                case ItemType.InteriorStory:
                    serializer.Serialize(writer, "interiorStory");
                    return;
            }
            throw new Exception("Cannot marshal type ItemType");
        }

        public static readonly ItemTypeConverter Singleton = new ItemTypeConverter();
    }

    internal class ExtensionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Extension) || t == typeof(Extension?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "gif":
                    return Extension.Gif;
                case "jpg":
                    return Extension.Jpg;
            }
            throw new Exception("Cannot unmarshal type Extension");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Extension)untypedValue;
            switch (value)
            {
                case Extension.Gif:
                    serializer.Serialize(writer, "gif");
                    return;
                case Extension.Jpg:
                    serializer.Serialize(writer, "jpg");
                    return;
            }
            throw new Exception("Cannot marshal type Extension");
        }

        public static readonly ExtensionConverter Singleton = new ExtensionConverter();
    }

    internal class UrlTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(UrlType) || t == typeof(UrlType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "comiclink":
                    return UrlType.Comiclink;
                case "detail":
                    return UrlType.Detail;
                case "wiki":
                    return UrlType.Wiki;
            }
            throw new Exception("Cannot unmarshal type UrlType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (UrlType)untypedValue;
            switch (value)
            {
                case UrlType.Comiclink:
                    serializer.Serialize(writer, "comiclink");
                    return;
                case UrlType.Detail:
                    serializer.Serialize(writer, "detail");
                    return;
                case UrlType.Wiki:
                    serializer.Serialize(writer, "wiki");
                    return;
            }
            throw new Exception("Cannot marshal type UrlType");
        }

        public static readonly UrlTypeConverter Singleton = new UrlTypeConverter();
    }
}
