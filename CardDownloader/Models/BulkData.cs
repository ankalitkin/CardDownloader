using System;
using Newtonsoft.Json;

namespace CardDownloader.Models
{
    public class BulkData
    {
        [JsonProperty("object")] public string ObjectType;
        [JsonProperty("id")] public string Id;
        [JsonProperty("type")] public string Type;
        [JsonProperty("name")] public string Name;
        [JsonProperty("description")] public string Description;
        [JsonProperty("permalink_uri")] public string PermalinkUri;
        [JsonProperty("updated_at")] public DateTime UpdatedAt;
        [JsonProperty("compressed_size")] public int CompressedSize;
        [JsonProperty("content_type")] public string ContentType;
        [JsonProperty("content_encoding")] public string ContentEncoding;
    }
}