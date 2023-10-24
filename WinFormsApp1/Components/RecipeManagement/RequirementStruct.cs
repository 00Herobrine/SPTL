namespace SPTLauncher.Components.RecipeManagement
{
    public interface RequirementStruct
    {
        string type { get; }
        public bool isArea => type == "Area";
        public bool isItem => type == "Item";
        public bool isTool => type == "Tool";
        public bool isResource => type == "Resource";
        public bool isQuest => type == "QuestComplete";
        public RequirementType GetType() => (RequirementType)Enum.Parse(typeof(RequirementType), type);
    }

    public struct AreaStruct : RequirementStruct
    {
        public int areaType { get; set; }
        public int requiredLevel { get; set; }
        public readonly string type => "Area";
        public override readonly string ToString() => ((Module) areaType).ToString();
    }

    public struct ItemStruct : RequirementStruct
    {
        public int count { get; set; }
        public bool isEncoded { get; set; }
        public bool isFunctional { get; set; }
        [JsonProperty("templateId")]
        public string templateId { get; set; }
        public readonly string type => "Item";
        public override readonly string ToString() => TarkovCache.GetReadableName(templateId).ToString();
    }

    public struct ResourceStruct : RequirementStruct
    {
        public int resource { get; set; }
        public string templateId { get; set; }
        public readonly string type => "Resource";
        public override readonly string ToString() => TarkovCache.GetReadableName(templateId).ToString();
    }
    public struct ToolStruct : RequirementStruct
    {
        public string templateId { get; set; }
        public readonly string type => "Tool";
        public override readonly string ToString() => TarkovCache.GetReadableName(templateId).ToString();
    }
    public struct QuestStruct : RequirementStruct
    {
        public string questId { get; set; }
        public readonly string type => "QuestComplete";
        public override readonly string ToString() => "Quest: " + questId;
    }

    public class RequirementStructConverter : JsonConverter<RequirementStruct>
    {
        public override RequirementStruct? ReadJson(JsonReader reader, Type objectType, RequirementStruct? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            var type = jObject["type"]?.Value<string>();
            return type switch
            {
                "Area" => jObject.ToObject<AreaStruct>(),
                "Item" => jObject.ToObject<ItemStruct>(),
                "Resource" => jObject.ToObject<ResourceStruct>(),
                "Tool" => jObject.ToObject<ToolStruct>(),
                "QuestComplete" => jObject.ToObject<QuestStruct>(),
                _ => throw new InvalidOperationException($"Unknown RequirementStruct type: {type}"),
            };
        }

        public override void WriteJson(JsonWriter writer, RequirementStruct? value, JsonSerializer serializer)
        {
            //throw new NotImplementedException();
        }
    }
}
