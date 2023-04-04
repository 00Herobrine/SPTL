using Newtonsoft.Json.Linq;
using SPTLauncher.Constructors;
using System.Diagnostics;
using WinFormsApp1;

namespace SPTLauncher
{
    public partial class RecipeBuilder : Form
    {
        private Dictionary<string, Recipe> _recipes = new Dictionary<string, Recipe>();
        public static RecipeBuilder rb;
        public RecipeBuilder()
        {
            InitializeComponent();
            rb = this;
        }

        private void NewRecipeButton_Click(object sender, EventArgs e)
        {

        }

        public void NewRecipe()
        {

        }

        public void LoadRecipes()
        {
            Debug.Write("loading " + Form1.productionPath);
            Form1.form.log("loading " + Form1.productionPath);
            JArray production = JArray.Parse(File.ReadAllText(Form1.productionPath));
            foreach (JToken recipe in production)
            {
                Form1.form.log("Checking ID " + recipe["_id"]);
                if (recipe["requirements"] != null)
                {
                    Recipe recipe2 = new Recipe(recipe);
                    listBox1.Items.Add(recipe2.getName(true));
                    _recipes[recipe2.getID()] = recipe2;
                    //Form1.form.log("Has Requirements");
                }
            }
        }

        private void RecipeBuilder_Load(object sender, EventArgs e)
        {
            LoadRecipes();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = getSelectedRecipe().getID();
            Recipe recipe = _recipes[id];
            LoadShit(recipe);
            if (requirementList.Items.Count > 0) requirementList.SelectedIndex = 0;
        }

        public void LoadShit(Recipe recipe)
        {
            nameTextBox.Text = recipe.getName();
            ModuleComboBox.Text = Recipe.GetEnumDescription(recipe.getModule());
            endProductBox.Text = recipe.getEndProduct();
            CraftAmount.Value = recipe.getCount();
            PowerRequirement.Checked = recipe.isPowerNeeded();
            requirementList.Items.Clear();
            productionTime.Value = recipe.getProductionTime();
            foreach (RecipeRequirement requirement in recipe.GetRecipeRequirements().Values)
            {
                string id = requirement.getID();
                if (id != null) requirementList.Items.Add(id);
            }
            if (recipe.hasRequiredModule())
            {
                Module requiredModule = recipe.getRequiredModule();
                requiredModuleBox.Text = Recipe.GetEnumDescription(requiredModule);
                requiredModuleLvl.Minimum = int.Parse(Recipe.GetEnumMinMax(requiredModule)[0]);
                requiredModuleLvl.Maximum = int.Parse(Recipe.GetEnumMinMax(requiredModule)[1]);
                requiredModuleLvl.Value = recipe.getRequiredModuleLevel();
            }
            else
            {
                requiredModuleBox.Text = "";
                requiredModuleLvl.Value = 1;
                requiredModuleLvl.Minimum = 1;
                requiredModuleLvl.Maximum = 3;
            }
        }

        public static string GetModuleNameByID(int id)
        {
            return Recipe.GetEnumDescription(GetModuleByID(id));
        }

        public static Module GetModuleByID(int id)
        {
            return (Module)Enum.ToObject(typeof(Module), id);
        }

        private void requirementList_SelectedIndexChanged(object sender, EventArgs e)
        {
            setRequirement(requirementList.SelectedIndex);
            //LoadRequirement(requirement);
        }

        public void setRequirement(int index = 0)
        {
            //requirementList.SelectedIndex = index;
            RecipeRequirement requirement = getSelectedRecipe().GetRecipeRequirement(requirementList.SelectedItem.ToString());
            LoadRequirement(requirement);
        }

        public Recipe getSelectedRecipe()
        {
            List<Recipe> values = _recipes.Values.ToList();
            return _recipes[values[listBox1.SelectedIndex].getID()];
        }

        public void LoadRequirement(RecipeRequirement requirement)
        {
            if (requirement != null)
            {
                Recipe recipe = getSelectedRecipe();
                requirementID.Text = requirement.getID();
                RequiredAmount.Value = requirement.getCount();
                craftReturnCheckBox.Checked = requirement.isReturnedOnCraft();
            }
        }

        private void SaveRecipeButton_Click(object sender, EventArgs e)
        {
            Recipe r = getSelectedRecipe();
            r.setPowerNeeded(PowerRequirement.Checked);
            r.setName(nameTextBox.Text);
            r.setCount((int)CraftAmount.Value);
            r.setEndProduct(endProductBox.Text);
            r.setProductionTime((int)productionTime.Value);
            r.getModuleRequirement().setRequiredModuleLvl((int)requiredModuleLvl.Value);
            r.GetRecipeRequirement(requirementList.SelectedItem.ToString()).setCount((int)RequiredAmount.Value);
            string id = listBox1.SelectedItem.ToString();
            _recipes[id] = r;
            r.updateSettings();
            Form1.form.log("Updated recipe " + r.getName(true));
        }

        public static void UpdateRecipesFile(JToken token)
        {
            JArray jArray = JArray.Parse(File.ReadAllText(Form1.productionPath));
            jArray[rb.listBox1.SelectedIndex] = token;
            File.WriteAllText(Form1.productionPath, jArray.ToString());
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer", "https://db.sp-tarkov.com/search/");
        }
    }
}
