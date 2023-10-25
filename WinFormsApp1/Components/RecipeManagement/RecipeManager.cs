using Newtonsoft.Json;

namespace SPTLauncher.Components.RecipeManagement
{
    public class RecipeManager
    {
        public static Dictionary<string, Recipe> recipes = new();
        public static void Initialize()
        {
            CacheRecipes();
        }

        public static void CacheRecipes()
        {
            recipes = JsonConvert.DeserializeObject<List<Recipe>>(ReadProductionFile(), new RequirementStructConverter())?.ToDictionary(o => o.id, o => o) ?? new();
        }
        public static void Save()
        {
            //File.WriteAllText(Paths.productionPath, JsonConvert.SerializeObject<List<Recipe>>(recipes.Values.ToList());
        }

        private static string ReadProductionFile() => File.ReadAllText(Paths.productionPath);

        public static Recipe NewRecipe(Module module = Module.WORKBENCH)
        {
            return new Recipe();
        }
        public static void AddRecipe(Recipe recipe)
        {
            
        }
        public static void RemoveRecipe(Recipe recipe) 
        {

        }
        public static void UpdateRecipe(Recipe recipe)
        {

        }
        public Recipe GetRecipe(string id)
        {
            return recipes[id];
        }

        public static RecipeRequirement GenerateRequirementStruct(RequirementType type)
        {
            switch(type)
            {
                case RequirementType.Area: return new AreaRequirement();
                case RequirementType.Item: return new ItemRequirement();
                case RequirementType.Resource: return new ResourceRequirement();
                case RequirementType.Tool: return new ToolRequirement();
                case RequirementType.QuestComplete: return new QuestRequirement();
                default: return new ItemRequirement();
            }
        }
    }
}
