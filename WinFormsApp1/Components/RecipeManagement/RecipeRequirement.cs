using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SPTLauncher.Components.Caching;

namespace SPTLauncher.Components.RecipeManagement
{
    public interface RecipeRequirement
    {
        [JsonProperty("type")]
        string type { get; }
        public bool isArea => type == "Area";
        public bool isItem => type == "Item";
        public bool isTool => type == "Tool";
        public bool isResource => type == "Resource";
        public bool isQuest => type == "QuestComplete";
        public RequirementType GetType() => (RequirementType)Enum.Parse(typeof(RequirementType), type);
    }

    public struct AreaRequirement : RecipeRequirement
    {
        public int areaType { get; set; }
        public int requiredLevel { get; set; }
        public readonly string type => "Area";
       
        public override readonly string ToString() => ((Module) areaType).ToString();
    }

    public struct ItemRequirement : RecipeRequirement
    {
        public int count { get; set; }
        public bool isEncoded { get; set; }
        public bool isFunctional { get; set; }
        [JsonProperty("templateId")]
        public string templateId { get; set; }
        public readonly string type => "Item";
        public override readonly string ToString() => TarkovCache.GetReadableNameFromID(templateId).ToString();

        public ItemRequirement()
        {
            templateId = TarkovCache.GetRandomItemID();
            count = 1;
        }
    }

    public struct ResourceRequirement : RecipeRequirement
    {
        public int resource { get; set; }
        public string templateId { get; set; }
        public readonly string type => "Resource";
        public override readonly string ToString() => TarkovCache.GetReadableNameFromID(templateId).ToString();
    }
    public struct ToolRequirement : RecipeRequirement
    {
        public string templateId { get; set; }
        public readonly string type => "Tool";
        public override readonly string ToString() => TarkovCache.GetReadableNameFromID(templateId).ToString();
    }
    public struct QuestRequirement : RecipeRequirement
    {
        public string questId { get; set; }
        public readonly string type => "QuestComplete";
        public override readonly string ToString() => TarkovCache.GetReadableQuestName(questId);
    }

    public class RequirementStructConverter : JsonConverter<RecipeRequirement>
    {
        public override RecipeRequirement? ReadJson(JsonReader reader, Type objectType, RecipeRequirement? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            var type = jObject["type"]?.Value<string>();
            return type switch
            {
                "Area" => jObject.ToObject<AreaRequirement>(),
                "Item" => jObject.ToObject<ItemRequirement>(),
                "Resource" => jObject.ToObject<ResourceRequirement>(),
                "Tool" => jObject.ToObject<ToolRequirement>(),
                "QuestComplete" => jObject.ToObject<QuestRequirement>(),
                _ => throw new InvalidOperationException($"Unknown RequirementStruct type: {type}"),
            };
        }

        public override void WriteJson(JsonWriter writer, RecipeRequirement? value, JsonSerializer serializer)
        {
            //throw new NotImplementedException();
        }
    }
}
