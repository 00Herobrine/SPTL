using Newtonsoft.Json;

namespace SPTLauncher.Components.RecipeManagement
{
    public class RecipeManager
    {
        public static Dictionary<string, RecipeStruct> recipes = new();
        public static void Initialize()
        {
            CacheRecipes();
        }

        public static void CacheRecipes()
        {
            recipes = JsonConvert.DeserializeObject<List<RecipeStruct>>(ReadProductionFile(), new RequirementStructConverter())?.ToDictionary(o => o.id, o => o) ?? new();
        }

        private static string ReadProductionFile()
        {
            return File.ReadAllText(Paths.productionPath);
        }

        public static void AddRecipe()
        {

        }

        public static void RemoveRecipe() 
        {

        }

        public RecipeStruct GetRecipe(string id)
        {
            return recipes[id];
        }
    }
}
