﻿using Newtonsoft.Json;

using System.Diagnostics;
using WinFormsApp1;

namespace SPTLauncher.Components.Caching
{
    public class Cache
    {
        public Dictionary<string, string> TypeReference = new();
        public static Dictionary<string, CacheEntry> ReferenceNodes = new(); // id, ReferenceType
        public static Dictionary<string, CacheEntry> ItemDictionary = new();
        public static Dictionary<string, CacheItem> tarkovCache = new(); // default tarkov items (id, CacheItem)

        public static void Initialize()
        {
            StoreLocaleNames();
            string jsonData = File.ReadAllText(Paths.itemsPath);
            Dictionary<string, CacheEntry>? entries = JsonConvert.DeserializeObject<Dictionary<string, CacheEntry>>(jsonData);
            if (entries == null) { Debug.WriteLine("Null for items"); return; }
            ItemDictionary = entries.Values.Where(o => !o.Type.Equals("node", StringComparison.OrdinalIgnoreCase)).ToDictionary(item => item.ID, item => item);
            ReferenceNodes = entries.Values.Where(o => o.Type.Equals("node", StringComparison.OrdinalIgnoreCase)).ToDictionary(item => item.ID, item => item);
            Form1.log($"Cached {ReferenceNodes.Count} reference nodes and {ItemDictionary.Count} items.");
        }

        public static void StoreLocaleNames()
        {
            tarkovCache.Clear();
            Dictionary<string, string> localesCache = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(Paths.localesFile)) ?? new();
            foreach(var entry in localesCache.Where(o => o.Key.EndsWith("Name") || o.Key.EndsWith("Description")))
            {
                string[] split = entry.Key.Split(" ");
                if (entry.Value == null || split.Length < 2) continue;
                string id = split[0];
                AddToEntry(id, split[1], entry.Value);
            }
        }
        private static void AddToEntry(string id, string key, string value)
        {
            if (!tarkovCache.ContainsKey(id)) tarkovCache.Add(id, new(id));
            CacheItem item = tarkovCache[id];
            switch (key)
            {
                case "ShortName":
                    item.ShortName = value;
                    break;
                case "Name":
                    item.Name = value;
                    break;
                case "Description":
                    item.Description = value;
                    break;
            }
        }

        public static string GetReadableNameFromID(string id, bool shortName = false)
        {
            string name = id;
            if (tarkovCache.ContainsKey(id)) name = (shortName ? tarkovCache[id]?.ShortName : tarkovCache[id]?.Name) ?? id;
            return name;
        }
        public static string GetReferenceNameFromID(string id)
        {
            CacheEntry? entry = GetReferenceFromID(id);
            return entry != null ? entry.Name : string.Empty;
        }
        public static CacheEntry? GetReferenceFromID(string id) => ReferenceNodes[id];
        public static Dictionary<string, object> GetNecessaryProp(string id) => ReferenceNodes[id].Props;
    }

    public class CacheItem
    {
        public string ID { get; set; }
        public string? Name { get; set; }
        public string? ShortName { get; set; }
        public string? Description { get; set; }

        public CacheItem(string ID)
        {
            this.ID = ID;
        }

        public override string ToString() => Name ?? ID;
    }
}
