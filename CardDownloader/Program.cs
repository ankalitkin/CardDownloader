using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Xml;
using CardDownloader.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CardDownloader
{
    class Program
    {
        public static void Main(string[] args)
        {
            /*BulkListReader listReader = new BulkListReader();
            BulkData bulk = listReader.ReadBulkList().Data.Single(u => u.Type == "all_cards");
            Console.WriteLine("Last update: " + bulk.UpdatedAt);
            string filename = "all_cards_" + bulk.UpdatedAt.ToFileTime() + ".json";
            Stream bulkDataStream = new DataReader(bulk.PermalinkUri, filename).GetDataStream();*/

            Stream bulkDataStream = new DataReader("https://archive.scryfall.com/json/scryfall-all-cards.json",
                "all_cards_132107702036480000.json").GetDataStream();

            Stream setsDataStream = new DataReader("https://api.scryfall.com/sets", "sets_data.json").GetDataStream();
            CardReader cardReader = new CardReader(bulkDataStream);
            SetReader setReader = new SetReader(setsDataStream);
            Card.Sets = setReader.ReadSets().Data;
            //setReader.GroupSets();

            //IEnumerable<Card> cards = cardReader.GetCards().Where(c => c.Lang == "ru" && c.Set == "9ed");
            /*IEnumerable<Card> cards = cardReader.GetCards().Where(c => c.Name=="Island");

            int counter = 0;
            foreach (var card in cards)
            {
                Console.WriteLine(card.PrintedName + " - " + card.PrintedTypeLine + " - " + card.Number);
                counter++;
            }*/

            IEnumerable<Card> cards = cardReader.GetCards().Take(1000);

            /*Dictionary<Guid, int> dict = new Dictionary<Guid, int>();
            foreach (var card in cards)
            {
                var guid = card.CardBackId;
                if (!dict.ContainsKey(guid))
                {
                    Console.WriteLine(guid + " " + card.ScryfallUri);
                    dict.Add(guid, 0);
                }
                dict[guid]++;
            }*/

            /*foreach (var pair in dict)
            {
                Console.WriteLine(pair.Key + ": " + pair.Value);
            }*/

            Dictionary<string, List<Card>> dict = new Dictionary<string, List<Card>>();

            foreach (var card in cards)
            {
                string name = $"{card.SetName}.{card.Lang}".Replace('/', '_');
                if (!dict.ContainsKey(name))
                {
                    dict.Add(name, new List<Card>());
                    Console.WriteLine(name);
                }

                dict[name].Add(card);
            }

            foreach (KeyValuePair<string, List<Card>> pair in dict)
            {
                string filename = "database" + Path.DirectorySeparatorChar + pair.Key + ".xml";
                /*JsonSerializer serializer = new JsonSerializer();
                serializer.NullValueHandling = NullValueHandling.Ignore;
                serializer.DefaultValueHandling = DefaultValueHandling.Ignore;
                serializer.Formatting = Formatting.Indented;

                using (StreamWriter sw = new StreamWriter(filename))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, pair.Value);
                    Console.WriteLine(pair.Key + " Done");
                }
                */

                XmlDocument doc = new XmlDocument();

                XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlElement root = doc.DocumentElement;
                doc.InsertBefore(xmlDeclaration, root);

                XmlElement items = doc.CreateElement(string.Empty, "items", string.Empty);
                var first = pair.Value.First();
                items.SetAttribute("game", "mtg".ToUpperInvariant());
                items.SetAttribute("set", first.Set);
                items.SetAttribute("lang", first.Lang);
                items.SetAttribute("setname", first.SetName);
                items.SetAttribute("imagepath", first.SetName.Replace('/', '_'));
                items.SetAttribute("date", first.ReleasedAt.Replace('-', '.'));
                items.SetAttribute("border", first.BorderColor);
                doc.AppendChild(items);

                foreach (var next in pair.Value)
                {
                    XmlElement item = doc.CreateElement(string.Empty, "item", string.Empty);
                    VptCard card = new VptCard(next);
                    item.SetAttributeIfNotEmpty("foil", card.Foil);
                    //item.SetAttributeIfNotEmpty("icon", card.Icon);
                    item.SetAttributeIfNotEmpty("rarity", card.Rarity);
                    item.SetAttributeIfNotEmpty("booster", card.Booster ? "true" : "false");
                    item.SetAttributeIfNotEmpty("number", card.Number);
                    item.SetAttributeIfNotEmpty("artist", card.Artist);
                    item.SetAttributeIfNotEmpty("flavor", card.Flavor);
                    item.SetAttributeIfNotEmpty("text", card.Text);
                    item.SetAttributeIfNotEmpty("types", card.Types);
                    item.SetAttributeIfNotEmpty("type", card.Type);
                    item.SetAttributeIfNotEmpty("cmc", card.Cmc);
                    item.SetAttributeIfNotEmpty("cost", card.Cost);
                    item.SetAttributeIfNotEmpty("color", card.Color);
                    item.SetAttributeIfNotEmpty("name", card.Name);
                    item.SetAttributeIfNotEmpty("id", card.Id);
                    item.SetAttributeIfNotEmpty("toughness", card.Toughness);
                    item.SetAttributeIfNotEmpty("power", card.Power);
                    //item.SetAttributeIfNotEmpty("mana", card.Mana);
                    //item.SetAttributeIfNotEmpty("ver", card.Ver);
                    item.SetAttributeIfNotEmpty("loyalty", card.Loyalty);
                    items.AppendChild(item);
                }
                doc.Save(filename);
            }

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }

    static class XmlElementExtension
    {
        public static void SetAttributeIfNotEmpty(this XmlElement item, string arg, string value)
        {
            if(string.IsNullOrEmpty(value))
                return;
            item.SetAttribute(arg, value);

        }
    } 
}