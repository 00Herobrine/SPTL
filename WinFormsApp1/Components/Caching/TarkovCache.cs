using Newtonsoft.Json;
using SPTLauncher.Components.QuestManagement;
using WinFormsApp1;

namespace SPTLauncher.Components.Caching
{
    public class TarkovCache
    {
        public static Dictionary<CacheType, CacheTab> tabs = new Dictionary<CacheType, CacheTab>
        {
        { CacheType.ARMOR, CacheTab.ARMOR },
        { CacheType.BACKPACKS, CacheTab.WEARABLES },
        { CacheType.CLOTHING, CacheTab.WEARABLES },
        { CacheType.HEADPHONES, CacheTab.WEARABLES },
        { CacheType.HELMETS, CacheTab.WEARABLES },
        { CacheType.RIGS, CacheTab.WEARABLES },
        { CacheType.FIREARMS, CacheTab.WEAPONS },
        { CacheType.AMMO, CacheTab.WEAPONS },
        { CacheType.MAGAZINES, CacheTab.WEAPONS },
        { CacheType.GRENADES, CacheTab.WEAPONS },
        { CacheType.FOOD, CacheTab.CONSUMABLES },
        { CacheType.CONTAINERS, CacheTab.MISC },
        { CacheType.ITEMS, CacheTab.MISC },
        { CacheType.KNIVES, CacheTab.WEAPONS },
        { CacheType.KEYS, CacheTab.KEYS },
        { CacheType.MAPS, CacheTab.MISC },
        { CacheType.MEDICALS, CacheTab.CONSUMABLES },
        { CacheType.MODS, CacheTab.MISC },
        { CacheType.MONEY, CacheTab.MISC }
        };
        public Dictionary<string, string> TypeReference = new();
        public static Dictionary<string, CacheEntry> ReferenceNodes = new(); // id, ReferenceType
        public static Dictionary<string, CacheEntry> ItemDictionary = new(); // id, Item
        public static Dictionary<string, CacheItem> tarkovCache = new(); // default tarkov items (id, CacheItem)
        public static Dictionary<string, CachedQuest> questCache = new(); 
        // need to store all locale IDs might as well just just parse it as a JObject and generate the required path. GetShortName(string id) => JObject[$"{id} ShortName"]
        // I only need to worry about this for the Recipe builder as the requirements have messages that are just IDs in that file so I'd just GetValue(string id) => JObject[id]
        // think this will result in me deleting questCache and tarkovCache then calling them localeCache as that's what they are

        public static void Initialize()
        {
            StoreLocaleNames();
            StoreQuests();
            string jsonData = File.ReadAllText(Paths.itemsPath);
            Dictionary<string, CacheEntry>? entries = JsonConvert.DeserializeObject<Dictionary<string, CacheEntry>>(jsonData);
            if (entries == null) return;
            ItemDictionary = entries.Values.Where(o => !o.Type.Equals("node", StringComparison.OrdinalIgnoreCase)).ToDictionary(item => item.ID, item => item); // Item lang reference
            ReferenceNodes = entries.Values.Where(o => o.Type.Equals("node", StringComparison.OrdinalIgnoreCase)).ToDictionary(item => item.ID, item => item); // UI, Quest, Message, etc. lang referenes
            Form1.log($"Cached {ReferenceNodes.Count} reference nodes and {tarkovCache.Count} items.");
            // Tarkov stores everything as itemID shortName,Description,etc.
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

        public static string[] questValues = { "name", "description", "acceptPlayerMessage", "completePlayerMessage", "declinePlayerMessage", "failMessageText", "successMessageText" };
        public static void StoreQuests()
        {
            questCache.Clear();
/*            Dictionary<string, string> localesCache = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(Paths.localesFile)) ?? new();
            foreach (var entry in localesCache.Where(o => questValues.Any(qv => o.Key.EndsWith(qv))))
            {
                string[] split = entry.Key.Split(" ");
                if (entry.Value == null || split.Length < 2) continue;
                string id = split[0];
                AddToQuestEntry(id, split[1], entry.Value);
            }*/
            questCache = JsonConvert.DeserializeObject<Dictionary<string, CachedQuest>>(File.ReadAllText($"{Paths.databasePath}/templates/quests.json")) ?? new();
        }
        private static void AddToEntry(string id, string key, string value)
        {
            if (!tarkovCache.ContainsKey(id)) tarkovCache.Add(id, new(id));
            CacheItem item = tarkovCache[id];
            switch (key)
            {
                case "ShortName": item.ShortName = value; break;
                case "Name": item.Name = value; break;
                case "Description": item.Description = value; break;
            }
        }
/*        public static void AddToQuestEntry(string id, string key, string value)
        {
            if (!questCache.ContainsKey(id)) questCache.Add(id, new(id));
            CacheQuest quest = questCache[id];
            switch(key)
            {
                case "name": quest.name = value; break;
                case "description": quest.description = value; break;
                case "acceptPlayerMessage": quest.acceptPlayerMessage = value; break;
                case "completePlayerMessage": quest.completePlayerMessage = value; break;
                case "declinePlayerMessage": quest.declinePlayerMessage = value; break;
                case "successMessageText": quest.successMessageText = value; break;
                case "failMessageText": quest.failMessageText = value; break;
            }
        }*/
        public static string GetReadableQuestName(string id)
        {
            return questCache[id].Name ?? $"Quest: {id}";
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
        internal static CacheEntry GetItemEntry(string id) => ItemDictionary[id];
        internal static CachedQuest GetQuestEntry(string questID) => questCache[questID];
        private static Random random = new();
        public static CacheEntry GetRandomCacheItem() => ItemDictionary.Values.ToList()[random.Next(0, ItemDictionary.Count)];
        public static string GetRandomItemID() => GetRandomCacheItem().ID;
        public static CacheEntry? GetReferenceFromID(string id) => ReferenceNodes[id];
        public static Dictionary<string, object> GetNecessaryProp(string id) => ReferenceNodes[id].Props;

    }

    public enum EntryType
    {
        Quest, Item
    }
    public interface CacheEnt
    {
        public EntryType type { get; }
        public string ID { get; set; }
    }
    public class CacheItem : CacheEnt 
    {
        public EntryType type => EntryType.Item;
        public string ID { get; set; }
        public string? Name { get; set; }
        public string? ShortName { get; set; }
        public string? Description { get; set; }

        public CacheItem(string ID)
        {
            this.ID = ID;
        }

        public override string ToString() => Name ?? TarkovCache.GetReadableNameFromID(ID);
    }

    public class CacheQuest : CacheEnt
    {
        public EntryType type => EntryType.Quest;
        public string ID { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public string? successMessageText { get; set; }
        public string? failMessageText { get; set; }
        public string? acceptPlayerMessage { get; set; }
        public string? completePlayerMessage { get; set; }
        public string? declinePlayerMessage { get; set; }

        public CacheQuest(string ID)
        {
            this.ID = ID;
        }
        public override string ToString() => name ?? ID;
    }
}
