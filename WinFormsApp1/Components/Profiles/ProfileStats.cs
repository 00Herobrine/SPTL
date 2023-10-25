using Newtonsoft.Json;

namespace SPTLauncher.Components.Profiles
{
    public struct ProfileStats
    {
        public SessionCounter SessionCounters { get; set; }
        public SessionCounter OverallCounters { get; set; }
        [JsonProperty("SessionExperienceMult")]
        public float SessionExperienceMultiplier { get; set; }
        public float ExperienceBonusMultiplier { get; set; }
        public int TotalSessionExperience { get; }
        public List<object> DroppedItems { get; }
        public List<object> FoundInRaidItems { get; }
        public List<Victim> Victims { get; }
        public DamageHistory DamageHistroy { get; }
    }

    public struct CounterItem
    {
        public List<string> Key { get; set; } // triggerName, eventName or StatCountName
        public int Value { get; set; } // returns ints depending on triggers or the statCount
    }

    public struct SessionCounter
    {
        public List<CounterItem> Items { get; set; }
    }

    public struct DamageHistory
    {
        public string LethalDamagePart { get; set; }
        public LethalDamage LethalDamage { get; set; }
        public List<BodyPartDamage> BodyParts { get; }
    }
    public struct LethalDamage
    {
        public double Amount { get; set; }
        public string Type { get; set; }
        public string SourceId { get; set; }
        public object OverDamageFrom { get; set; }
        public bool Blunt { get; set; }
        public int ImpactsCount { get; set; }
    }

    public struct BodyPartDamage
    {
        public double Amount { get; set; }
        public string Type { get; set; }
        public string SourceId { get; set; }
        public object OverDamageFrom { get; set; }
        public bool Blunt { get; set; }
        public int ImpactsCount { get; set; }
    }
    public struct DeathCause
    {
        public string DamageType { get; set; }
        public string Side { get; set; }
        public string Role { get; set; }
        public string WeaponId { get; set; }
    }
    public struct Victim
    {
        public string AccountId { get; set; }
        public string ProfileId { get; set; }
        public string Name { get; set; }
        public string Side { get; set; }
        public string Time { get; set; }
        public int Level { get; set; }
        public string BodyPart { get; set; }
        public string Weapon { get; set; }
        public double Distance { get; set; }
        public string Role { get; set; }
    }

}
