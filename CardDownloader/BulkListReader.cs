using System.Net;
using CardDownloader.Models;
using Newtonsoft.Json;

namespace CardDownloader
{
    public class BulkListReader
    {
        private const string BulkDataUri = @"https://api.scryfall.com/bulk-data";
        private readonly WebClient _client;

        public BulkListReader()
        {
            _client = new WebClient();
        }

        public BulkList ReadBulkList()
        {
            string json = _client.DownloadString(BulkDataUri);
            return JsonConvert.DeserializeObject<BulkList>(json);
        }
        
    }
}