using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace CardDownloader.Models
{
    public class Card
    {
        public static List<Set> Sets;
        [JsonIgnore] public Set CardSet => Sets.Single(s => s.Code == Set);
        [JsonProperty("number")] public string Number => $"{CollectorNumber}/{CardSet.CardCount}";
        [JsonProperty("legal")] public string Legal {get; private set; }
        [JsonProperty("restricted")] public string Restricted {get; private set; }
        [JsonProperty("banned")] public string Banned {get; private set; }

        //-----Core Card Fields-----
        [JsonProperty("arena_id")] public int? ArenaId;
        [JsonProperty("id")] public Guid Id;
        [JsonProperty("lang")] public string Lang;
        [JsonProperty("mtgo_id")] public int? MtgoId;
        [JsonProperty("mtgo_foil_id")] public int? MtgoFoilId;
        [JsonProperty("multiverse_ids")] public int[] MultiverseIds;
        [JsonProperty("tcgplayer_id")] public int? TcgplayerId;
        [JsonProperty("object")] public string ObjectType;
        [JsonProperty("oracle_id")] public Guid OracleId;
        [JsonProperty("prints_search_uri")] public string PrintsSearchUri;
        [JsonProperty("rulings_uri")] public string RulingsUri;
        [JsonProperty("scryfall_uri")] public string ScryfallUri;
        [JsonProperty("uri")] public string Uri;

        //-----Gameplay Fields-----
        [JsonProperty("all_parts")] public RelatedCardObject[] AllParts;
        [JsonProperty("card_faces")] public CardFace[] CardFaces;
        [JsonProperty("cmc")] public string Cmc;
        [JsonProperty("colors")] public string[] Colors;
        [JsonProperty("color_identity")] public string[] ColorIdentity;
        [JsonProperty("color_indicator")] public string[] ColorIndicator;
        [JsonProperty("edhrec_rank")] public int? EdhrecRank;
        [JsonProperty("foil")] public bool Foil;
        [JsonProperty("hand_modifier")] public string HandModifier;
        [JsonProperty("layout")] public string Layout;

        [JsonProperty("legalities")]
        public Dictionary<string, string> Legalities
        {
            get => null;
            set
            {
         Legal = StringifyLegality(value, "legal");
         Restricted = StringifyLegality(value, "restricted");
         Banned = StringifyLegality(value, "banned");
            }
        }

        [JsonProperty("life_modifier")] public string LifeModifier;
        [JsonProperty("loyalty")] public string Loyalty;
        [JsonProperty("mana_cost")] public string ManaCost;
        [JsonProperty("name")] public string Name;
        [JsonProperty("nonfoil")] public bool Nonfoil;
        [JsonProperty("oracle_text")] public string OracleText;
        [JsonProperty("oversized")] public bool Oversized;
        [JsonProperty("power")] public string Power;
        [JsonProperty("reserved")] public bool Reserved;
        [JsonProperty("toughness")] public string Toughness;
        [JsonProperty("type_line")] public string TypeLine;

        //-----Print Fields-----        
        [JsonProperty("artist")] public string Artist;
        [JsonProperty("booster")] public bool Booster;
        [JsonProperty("border_color")] public string BorderColor;
        [JsonProperty("card_back_id")] public Guid CardBackId;
        [JsonProperty("collector_number")] public string CollectorNumber;
        [JsonProperty("digital")] public bool Digital;
        [JsonProperty("flavor_text")] public string FlavorText;
        [JsonProperty("frame_effect")] public string FrameEffect;
        [JsonProperty("frame")] public string Frame;
        [JsonProperty("full_art")] public bool FullArt;
        [JsonProperty("games")] public string[] Games;
        [JsonProperty("highres_image")] public bool HighresImage;
        [JsonProperty("illustration_id")] public Guid? IllustrationId;
        [JsonProperty("image_uris")] public Object ImageUris;
        [JsonProperty("prices")] public Object Prices;
        [JsonProperty("printed_name")] public string PrintedName;
        [JsonProperty("printed_text")] public string PrintedText;
        [JsonProperty("printed_type_line")] public string PrintedTypeLine;
        [JsonProperty("promo")] public bool Promo;
        [JsonProperty("promo_types")] public string[] PromoTypes;
        [JsonProperty("purchase_uris")] public Object PurchaseUris;
        [JsonProperty("rarity")] public string Rarity;
        [JsonProperty("related_uris")] public Object RelatedUris;
        [JsonProperty("released_at")] public string ReleasedAt;
        [JsonProperty("reprint")] public bool Reprint;
        [JsonProperty("scryfall_set_uri")] public string ScryfallSetUri;
        [JsonProperty("set_name")] public string SetName;
        [JsonProperty("set_search_uri")] public string SetSearchUri;
        [JsonProperty("set_type")] public string SetType;
        [JsonProperty("set_uri")] public string SetUri;
        [JsonProperty("set")] public string Set;
        [JsonProperty("story_spotlight")] public bool StorySpotlight;
        [JsonProperty("textless")] public bool Textless;
        [JsonProperty("variation")] public bool Variation;
        [JsonProperty("variation_of")] public Guid? VariationOf;
        [JsonProperty("watermark")] public string Watermark;

        private string StringifyLegality(Dictionary<string, string> legalities, string value)
        {
            StringBuilder sb = new StringBuilder();
            foreach(var pair in legalities)
            {
                if (pair.Value == value)
                {
                    sb.Append(pair.Key);
                    sb.Append(' ');
                }
            }
            if (sb.Length > 0)
                return sb.ToString(0, sb.Length - 1);
            return "";
        }
    }
}