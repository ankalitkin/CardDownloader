using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Threading;
using CardDownloader.Models;
using Newtonsoft.Json;

namespace CardDownloader
{
    public class DataReader
    {
        private string _uri;
        private string _filename;

        public DataReader(string uri, string filename)
        {
            _uri = uri;
            _filename = filename;
        }

        private void DownloadBulkData()
        {
            WebClient client = new WebClient();
            client.DownloadFile(new Uri(_uri), _filename);
        }

        public FileStream GetDataStream()
        {
            if (!File.Exists(_filename))
            {
                Console.WriteLine("Downloading file...");
                DownloadBulkData();
                Console.WriteLine("Done");
            }
            else
            {
                Console.WriteLine("File is already downloaded");
            }
            return File.OpenRead(_filename);
        }
    }
}