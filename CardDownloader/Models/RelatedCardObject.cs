using System;
using Newtonsoft.Json;

namespace CardDownloader.Models
{
    public class RelatedCardObject
    {
        [JsonProperty("id")] public Guid Id;
        [JsonProperty("object")] public string ObjectType;
        [JsonProperty("component")] public string Component;
        [JsonProperty("name")] public string Name;
        [JsonProperty("type_line")] public string TypeLine;
        [JsonProperty("uri")] public string Uri;
    }
}