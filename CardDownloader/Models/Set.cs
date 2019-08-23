using System;
using Newtonsoft.Json;

namespace CardDownloader.Models
{
    public class Set
    {
        [JsonProperty("id")] public Guid Id;
        [JsonProperty("code")] public string Code;
        [JsonProperty("mtgo_code")] public string MtgoCode;
        [JsonProperty("tcgplayer_id")] public int? TcgplayerId;
        [JsonProperty("name")] public string Name;
        [JsonProperty("set_type")] public string SetType;
        [JsonProperty("released_at")] public DateTime? ReleasedAt;
        [JsonProperty("block_code")] public string BlockCode;
        [JsonProperty("block")] public string Block;
        [JsonProperty("parent_set_code")] public string ParentSetCode;
        [JsonProperty("card_count")] public int CardCount;
        [JsonProperty("digital")] public bool Digital;
        [JsonProperty("foil_only")] public bool FoilOnly;
        [JsonProperty("scryfall_uri")] public string ScryfallUri;
        [JsonProperty("uri")] public string Uri;
        [JsonProperty("icon_svg_uri")] public string IconSvgUri;
        [JsonProperty("search_uri")] public string SearchUri;
    }
}