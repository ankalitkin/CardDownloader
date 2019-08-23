using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using CardDownloader.Models;
using Newtonsoft.Json;

namespace CardDownloader
{
    public class SetReader
    {
        private readonly Stream _stream;
        private SetList _cached;

        public SetReader(Stream stream)
        {
            _stream = stream;
        }

        public SetList ReadSets()
        {
            if (_cached != null)
                return _cached;
            
            string json = new StreamReader(_stream).ReadToEnd();
            return _cached = JsonConvert.DeserializeObject<SetList>(json);
        }

        public void GroupSets()
        {
            List<Set> data = ReadSets().Data;
            List<Set> core = new List<Set>();
            List<Set> promo = new List<Set>();
            List<Set> special = new List<Set>();
            foreach (Set set in data)
            {
                switch (set.SetType)
                {
                    case "core":
                    case "expansion":
                        core.Add(set);
                        break;

                    case "promo":
                        promo.Add(set);
                        break;

                    default:
                        special.Add(set);
                        break;
                }
            }

            core.Sort((set1, set2) =>
            {
                if (set1.ReleasedAt != null && set2.ReleasedAt != null)
                    return set1.ReleasedAt.Value.CompareTo(set2.ReleasedAt.Value);
                return 0;
            });
            
            OrderedDictionary dict = new OrderedDictionary();
            foreach (Set set in core)
            {
                var name = set.Block ?? set.Name;
                if(!dict.Contains(name))
                    dict.Add(name, new List<Set>());
                
                ((List<Set>)dict[name]).Add(set);
            }
            
            Console.WriteLine("Expansions & Core Sets");
            foreach (DictionaryEntry de in dict)
            {
                Console.WriteLine(de.Key);
                foreach (var set in (List<Set>)de.Value)
                    Console.WriteLine("  " + set.Code + "  " + set.Name);
            }
        }
    }
}