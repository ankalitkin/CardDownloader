using System.Text;
using static System.Globalization.CultureInfo;

namespace CardDownloader.Models
{
    public class VptCard
    {
        public string Foil;

        //public string Icon;
        public string Rarity;
        public bool Booster;
        public string Number;
        public string Artist;
        public string Flavor;
        public string Text;
        public string Types;
        public string Type;
        public string Cmc;
        public string Cost;
        public string Color;
        public string ColorIdentity;
        public string ColorIndicator;
        public string Name;
        public string Id;
        public string Toughness;

        public string Power;

        //public string Mana;
        //public string Ver;
        public string Loyalty;
        public string CardBack;

        public VptCard(Card card)
        {
            if (card.Foil && card.Nonfoil) Foil = "false|true";
            else if (card.Foil && !card.Nonfoil) Foil = "true";
            else Foil = "false";
            //Icon = icon;
            Rarity = CurrentCulture.TextInfo.ToTitleCase(card.Rarity.ToLower());
            Booster = card.Booster;
            Number = $"{card.CollectorNumber}/{card.CardSet.CardCount}";
            Artist = card.Artist;
            Flavor = card.FlavorText;
            Text = card.PrintedText;
            Types = card.TypeLine;
            Type = card.PrintedTypeLine;
            Cmc = card.Cmc;
            Cost = card.ManaCost;
            Color = ColorsToString(card.Colors);
            ColorIdentity = ColorsToString(card.ColorIdentity);
            ColorIndicator = ColorsToString(card.ColorIndicator);
            Name = card.PrintedName;
            Id = card.Name;
            Toughness = card.Toughness;
            Power = card.Power;
            //Mana = mana;
            //Ver = ver;
            Loyalty = card.Loyalty;
            CardBack = CardBacks.GetCardBackNameByGuid(card.CardBackId);
        }

        private static string ColorsToString(string[] colors)
        {
            StringBuilder sb = new StringBuilder();
            if (colors != null)
            {
                foreach (var color in colors)
                {
                    if (color == "W") sb.Append("White ");
                    else if (color == "U") sb.Append("Blue ");
                    else if (color == "B") sb.Append("Black ");
                    else if (color == "R") sb.Append("Red ");
                    else if (color == "G") sb.Append("Green ");
                }
            }

            if (sb.Length > 0)
                return sb.ToString(0, sb.Length - 1);
            return "Colorless";
        }
    }
}