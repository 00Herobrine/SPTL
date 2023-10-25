using SPTLauncher.Components.RecipeManagement;

namespace SPTLauncher.Components.Presets
{
    internal struct RecipesPreset : Preset
    {
        public readonly string type => "Recipe";
        public bool replace { get; set; }
        public List<Recipe> Recipes { get; set; }

        public RecipesPreset(List<Recipe> recipes)
        {
            Recipes = recipes;
        }
    }
}
