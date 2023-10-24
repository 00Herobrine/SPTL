using SPTLauncher.Components.RecipeManagement;

namespace SPTLauncher.Constructors.Presets
{
    internal struct RecipesPreset
    {
        public PresetInfo Info { get; set; }
        public List<Recipe> Recipes { get; set; }

        public RecipesPreset(List<Recipe> recipes)
        {
            Info = new();
            Recipes = recipes;
        }
    }
}
