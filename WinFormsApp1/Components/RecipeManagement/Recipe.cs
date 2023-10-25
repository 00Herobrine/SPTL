using Newtonsoft.Json;
using SPTLauncher.Components.Caching;
using System.Text.Json;

namespace SPTLauncher.Components.RecipeManagement
{
    public struct Recipe
    {
        public string? name { get; set; }
        [JsonProperty("_id")]
        public string id { get; set; }
        public int areaType { get; set; } // module the recipe is made in
        public bool continuous { get; set; }
        public int count { get; set; }
        public string endProduct { get; set; }
        public bool isEncoded { get; set; }
        public bool locked { get; set; }
        [JsonProperty("needFuelForAllProductionTime")]
        public bool isPowerNeeded { get; set; }
        public int productionLimitCount { get; set; }
        public int productionTime { get; set; }
        public List<RecipeRequirement> requirements { get; set; }
        public override string ToString() => name ?? GetEndProduct();
        public readonly AreaRequirement? GetAreaStruct() => requirements.FirstOrDefault(r => r.isArea) as AreaRequirement?;
        public Module GetModule() => (Module)areaType;
        public int RequiredModuleLevel() => GetAreaStruct()?.requiredLevel ?? 1;
        public string GetEndProduct() => TarkovCache.GetReadableNameFromID(id);
        public bool HasRequiredModule() => requirements.Any(o => o.isArea);
        public bool HasRequirements() => requirements.Count > 0;
        public void AddRequirement(RecipeRequirement requirement) => requirements.Add(requirement);
        public void RemoveRequirement(RecipeRequirement requirement) => requirements.Remove(requirement);
        public RecipeRequirement NewRequirement(RequirementType? type = null)
        {
            type ??= HasRequiredModule() ? RequirementType.Item : RequirementType.Item;
            RecipeRequirement requirement = RecipeManager.GenerateRequirementStruct((RequirementType)type);
            requirements.Add(requirement);
            return requirement;
        }
        public RecipeRequirement NewRequirement(object[] args, RequirementType? type = null)
        {
            type ??= HasRequiredModule() ? RequirementType.Item : RequirementType.Item;
            RecipeRequirement requirement = RecipeManager.GenerateRequirementStruct((RequirementType)type);
            requirements.Add(requirement);
            return requirement;
        }


        public Recipe()
        {
            id = Guid.NewGuid().ToString().Replace("-", "");
            areaType = (int)Module.WORKBENCH;
            continuous = false;
            count = 1;
            endProduct = TarkovCache.GetRandomItemID();
            name = TarkovCache.GetReadableNameFromID(endProduct);
            isEncoded = false;
            locked = false;
            isPowerNeeded = true;
            productionLimitCount = 0;
            productionTime = 420;
            requirements = new();
        }
    }
}