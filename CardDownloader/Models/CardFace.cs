using System;
using Newtonsoft.Json;

namespace CardDownloader.Models
{
    public class CardFace
    {
        [JsonProperty("artist")] public string Artist;
        [JsonProperty("color_indicator")] public string[] ColorIndicator;
        [JsonProperty("colors")] public string[] Colors;
        [JsonProperty("flavor_text")] public string FlavorText;
        [JsonProperty("illustration_id")] public Guid? IllustrationId;
        [JsonProperty("image_uris")] public Object ImageUris;
        [JsonProperty("loyalty")] public string Loyalty;
        [JsonProperty("mana_cost")] public string ManaCost;
        [JsonProperty("name")] public string Name;
        [JsonProperty("object")] public string ObjectType;
        [JsonProperty("oracle_text")] public string OracleText;
        [JsonProperty("power")] public string Power;
        [JsonProperty("printed_name")] public string PrintedName;
        [JsonProperty("printed_text")] public string PrintedText;
        [JsonProperty("printed_type_line")] public string PrintedTypeLine;
        [JsonProperty("toughness")] public string Toughness;
        [JsonProperty("type_line")] public string TypeLine;
        [JsonProperty("watermark")] public string Watermark;
    }
}