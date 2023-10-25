using Newtonsoft.Json;
using SPTLauncher.Components.Caching;
using System.Text.Json;

namespace SPTLauncher.Components.RecipeManagement
{
    public struct RecipeStruct
    {
        public string? name { get; set; }
        [JsonProperty("_id")]
        public string id { get; set; }
        public int areaType { get; set; }
        public bool continuous { get; set; }
        public int count { get; set; }
        public string endProduct { get; set; }
        public bool isEncoded { get; set; }
        public bool locked { get; set; }
        [JsonProperty("needFuelForAllProductionTime")]
        public bool isPowerNeeded { get; set; }
        public int productionLimitCount { get; set; }
        public int productionTime { get; set; }
        public List<RequirementStruct> requirements { get; set; }
        public override string ToString() => name ?? TarkovCache.GetReadableNameFromID(id);
        public AreaStruct GetAreaStruct() => (AreaStruct) requirements.Where(o => o.isArea).First();
        public Module GetModule() => (Module) GetAreaStruct().areaType;
        public int RequiredModuleLevel() => HasRequiredModule() ? GetAreaStruct().requiredLevel : 0;
        public bool HasRequiredModule() => requirements.Any(o => o.isArea);
        public bool HasRequirements() => requirements.Count > 0;
    }
}
