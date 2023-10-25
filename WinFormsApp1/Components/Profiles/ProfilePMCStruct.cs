using Newtonsoft.Json;

namespace SPTLauncher.Components.Profiles
{
    public struct ProfilePMCStruct
    {
        public List<Dictionary<string, string>> Bonuses { get; set; } // stash size bonuses stored here 
        public HealthStruct Health { get; set; }
        public Dictionary<string, bool> Encyclopedia { get; set; }
        public ProfileCharacterInfo Info { get; set; }
        public ProfileInventory Inventory { get; set; }
        [JsonProperty("Skills")]
        public SkillStruct SkillsNode { get; set; }
        public ProfileStats Stats { get; set; }
        public Dictionary<string, string> Customization { get; private set; }
        public void SetCustom(string part, string id) => Customization[part] = id;
        public void SetBody(string id) => SetCustom("Body", id);
    }

    public struct SkillStruct
    {
        [JsonProperty("Common")]
        public List<Skill> Skills { get; set; }
        public List<Dictionary<string, object>> Mastering { get; set; }
        public int Points { get; set; }
    }
}
