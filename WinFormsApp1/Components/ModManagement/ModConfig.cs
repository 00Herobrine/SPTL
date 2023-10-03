using Newtonsoft.Json;

namespace SPTLauncher.Components.ModManagement
{
    public struct ModConfig
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public string AkiVersion { get; set; }
        [JsonProperty("URL")]
        public string URL { get; set; }
        public bool AutoUpdate { get; set; }
        public ModType? Type { get; set; }
    }
}
