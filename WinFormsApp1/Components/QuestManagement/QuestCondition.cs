using Newtonsoft.Json;

namespace SPTLauncher.Components.QuestManagement
{
    internal struct QuestCondition
    {
        [JsonProperty("AvailableForStart")]
        public StartProps StartRequirements { get; set; }
        [JsonProperty("AvailableForFinish")]
        public FinishProps FinishRequirements { get; set; }
    }
    internal struct FinishProps
    {

    }
    internal struct StartProps
    {
        public string id { get; set; }
        public int index { get; set; }
        public string parentId { get; set; }
        public bool dynamicLocale { get; set; }
        public string target { get; set; }
        public List<int> status { get; set; }
        public int availableAfter { get; set; }
        public List<object> visibilityConditions { get; set; }
    }
}
