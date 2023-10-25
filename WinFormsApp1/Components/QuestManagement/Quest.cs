using Newtonsoft.Json;

namespace SPTLauncher.Components.QuestManagement
{
    internal struct Quest // updating quest stuff will need to update the appropriate locale files
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
        [JsonProperty("startedMessageText")]
        public string StartMessageID { get; set; }
        [JsonProperty("successMessageText")]
        public string SuccessMessageID { get; set; }
        [JsonProperty("failMessageText")]
        public string FailMessageID { get; set; }
        [JsonProperty("name")]
        public string LocaleName { get; set; }
        [JsonProperty("note")]
        public string Note { get; set; }
        [JsonProperty("traderId")]
        public string TraderID { get; set; }
        [JsonProperty("type")] // Merchant, Completion, WeaponAssembly
        public string Type { get; set; }
        [JsonProperty("restartable")]
        public bool Restartable { get; set; }
        [JsonProperty("instantComplete")]
        public bool InstantComplete { get; set; } // dunno what this does
        [JsonProperty("templateId")]
        public string TemplateID { get; set; }
        [JsonProperty("conditions")]
        public Condition Conditions { get; set; }
        [JsonProperty("rewards")]
        public Rewards Rewards { get; set; }
        [JsonProperty("side")]
        public string Side { get; set; } // "Pmc" seems to be the only thing
    }
}
