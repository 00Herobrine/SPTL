using Newtonsoft.Json;
using System.Diagnostics;
using WinFormsApp1;

namespace SPTLauncher.Components.Caching
{
    public class Cache
    {
        public Dictionary<string, string> TypeReference = new();
        public static Dictionary<string, CacheEntry> ReferenceNodes = new(); // id, ReferenceType
        public static Dictionary<string, CacheEntry> ItemDictionary = new();

        public static void Initialize()
        {
            string jsonData = File.ReadAllText(Paths.itemsPath);
            Dictionary<string, CacheEntry>? entries = JsonConvert.DeserializeObject<Dictionary<string, CacheEntry>>(jsonData);
            if (entries == null) { Debug.WriteLine("Null for items"); return; }
            ItemDictionary = entries.Values.Where(o => !o.Type.Equals("node", StringComparison.OrdinalIgnoreCase)).ToDictionary(item => item.ID, item => item);
            ReferenceNodes = entries.Values.Where(o => o.Type.Equals("node", StringComparison.OrdinalIgnoreCase)).ToDictionary(item => item.ID, item => item);
            Form1.log($"Cached {ReferenceNodes.Count} reference nodes and {ItemDictionary.Count} items.");
        }

        public static string GetReferenceNameFromID(string id)
        {
            CacheEntry? entry = GetReferenceFromID(id);
            return entry != null ? entry.Name : string.Empty;
        }
        public static CacheEntry? GetReferenceFromID(string id) => ReferenceNodes[id];
        public static Dictionary<string, object> GetNecessaryProp(string id) => ReferenceNodes[id].Props;
    }
}
