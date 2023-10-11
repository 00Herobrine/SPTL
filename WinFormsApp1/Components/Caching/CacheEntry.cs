using Newtonsoft.Json;

namespace SPTLauncher.Components.Caching
{
    public class CacheEntry
    {
        [JsonProperty("_id")]
        public string ID { get; set; }
        [JsonProperty("_name")]
        public string Name { get; set; }
        [JsonProperty("_parent")]
        public string Parent { get; set; } // Parent Category ex. Magazine, ChargingHandle, Receiver, LootContainer, Stash, Etc (Goes deep as sub-parents are referenced ffs)
        [JsonProperty("_props")]
        public Dictionary<string, object> Props { get; set; }
        [JsonProperty("_type")]
        public string Type { get; set; } // should be the entry type but BSG is stupid so a loot spawn is an "Item" in their eyes

        public override string ToString() => $"{Name}{Suffix}";
        public string GetParent() => Parent;
        public CacheEntry? GetParentEntry() => Cache.GetReferenceFromID(Parent);
        public string? GetPropsValue(string key) => Props?.GetValueOrDefault(key)?.ToString();
        public string? ShortName
        {
            get
            {
                if (Props != null && Props.ContainsKey("ShortName"))
                {
                    return Props["ShortName"]?.ToString();
                }
                return null;
            }
        }
        private string Suffix => !string.IsNullOrWhiteSpace(Parent) ? $" | {Cache.GetReferenceNameFromID(Parent)}" : "";
    }
}
