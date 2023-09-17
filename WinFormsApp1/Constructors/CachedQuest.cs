using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SPTLauncher.Constructors
{
    internal enum RequirementType
    {
        LEVEL, QUEST
    }
    internal enum Location
    {
        woods, bigmap, interchange, tarkovstreets, shoreline, rezervbase, lighthouse, laboratory, factory4_day, factory4_night, any
    }
    internal struct ConditionProps
    {
        public string id { get; set; }
        public int index { get; set; }
        public string parentId { get; set; }
        public bool dynamicLocale { get; set; }
        public int value { get; set; }
        public string compareMethod { get; set; }
        //public JArray visibilityConditions { get; set; }

    }
    internal struct Rewards
    {
        [JsonProperty("Success")]
        public List<RewardItem> Success { get; set; }
    }
    internal struct RewardItem
    {
        [JsonProperty("value")]
        public string Amount { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public string? target { get; set; }
        [JsonProperty("findInRaid")]
        public bool foundInRaid { get; set; }
    }
        internal struct Condition
    {
        [JsonProperty("AvailableForStart")]
        public List<ConditionProps> StartRequirements { get; set; }
        [JsonProperty("AvailableForFinish")]
        public List<ConditionProps> FinishRequirements { get; set; }
    }
    internal struct CachedQuest
    {
        [JsonProperty("QuestName")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string DescriptionID { get; set; }
        [JsonProperty("_id")]
        public string ID { get; set; }
        [JsonProperty("image")]
        public string IconPath { get; set; }
        [JsonProperty("location")]
        public string Location { get; set; }
        [JsonProperty("canShowNotificationsInGame")]
        public bool CanShowNotificationsInGame { get; set; }
        [JsonProperty("acceptPlayerMessage")]
        public string AcceptPlayerMessage { get; set; }
        [JsonProperty("changeQuestMessageText")]
        public string ChangeQuestMessageText { get; set; }
        [JsonProperty("completePlayerMessage")]
        public string CompletePlayerMessage { get; set; }
        [JsonProperty("conditions")]
        public Condition Conditions { get; set; }
        public Rewards rewards { get; set; }
    }

}
