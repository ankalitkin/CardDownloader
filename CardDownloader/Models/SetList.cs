using System.Collections.Generic;
using Newtonsoft.Json;

namespace CardDownloader.Models
{
    public class SetList
    {
        [JsonProperty("object")] public string ObjectType;
        [JsonProperty("has_more")] public bool HasMore;
        [JsonProperty("data")] public List<Set> Data;
    }
}