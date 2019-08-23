using System.Collections.Generic;
using System.IO;
using CardDownloader.Models;
using Newtonsoft.Json;

namespace CardDownloader
{
    public class CardReader
    {
        private readonly Stream _stream;

        public CardReader(Stream stream)
        {
            _stream = stream;
        }
        
        public IEnumerable<Card> GetCards()
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader sr = new StreamReader(_stream))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        yield return serializer.Deserialize<Card>(reader);
                    }
                }
            }
        }
    }
}