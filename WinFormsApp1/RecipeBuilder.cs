using Newtonsoft.Json.Linq;
using SPTLauncher.Constructors;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using WinFormsApp1;

namespace SPTLauncher
{
    public partial class RecipeBuilder : Form
    {
        public static RecipeBuilder rb;
        private Dictionary<string, Recipe> _recipes = new Dictionary<string, Recipe>();
        private List<Module> acceptableModules = new List<Module>();
        public RecipeBuilder()
        {
            acceptableModules.Add(Module.WORKBENCH);
            acceptableModules.Add(Module.MEDICAL);
            acceptableModules.Add(Module.NUTRITION);
            acceptableModules.Add(Module.LAVORATORY);
            acceptableModules.Add(Module.WATER);
            acceptableModules.Add(Module.BOOZEGENERATOR);
            InitializeComponent();
            rb = this;
        }

        private void NewRecipeButton_Click(object sender, EventArgs e)
        {
            NewRecipe();
        }

        public void NewRecipe()
        {
            Recipe recipe = new Recipe();
            int index = listBox1.Items.Add(recipe.getName(true));
            _recipes[recipe.getID()] = recipe;
            listBox1.SelectedIndex = index;
        }

        public void LoadRecipes()
        {
            //activeCheckBox = ItemCheckBox;
            ItemCheckBox.Checked = true;
            JArray production = JArray.Parse(File.ReadAllText(Form1.productionPath));
            foreach (Module module in acceptableModules) ModuleComboBox.Items.Add(Recipe.GetEnumDescription(module));
            foreach (JToken recipe in production)
            {
                if (recipe["requirements"] != null)
                {
                    Recipe recipe2 = new Recipe(recipe);
                    listBox1.Items.Add(recipe2.getName(true));
                    _recipes[recipe2.getID()] = recipe2;
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
                requirementID.Text = "";
                RequiredAmount.Minimum = 0;
                RequiredAmount.Value = 0;
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
                ToolCheckBox.Checked = requirement.isReturnedOnCraft();
            }
        }

        private void SaveRecipeButton_Click(object sender, EventArgs e)
        {
            Recipe r = getSelectedRecipe();
            SaveRecipe(r);
        }

        public void SaveRecipe(Recipe recipe)
        {
            recipe.setPowerNeeded(PowerRequirement.Checked);
            recipe.setName(nameTextBox.Text);
            recipe.setCount((int)CraftAmount.Value);
            recipe.setEndProduct(endProductBox.Text);
            recipe.setProductionTime((int)productionTime.Value);
            recipe.getModuleRequirement().setRequiredModuleLvl((int)requiredModuleLvl.Value);
            recipe.GetRecipeRequirement(requirementList.SelectedItem.ToString()).setCount((int)RequiredAmount.Value);
            string id = listBox1.SelectedItem.ToString();
            _recipes[id] = recipe;
            recipe.updateSettings();
            Form1.form.log("Updated recipe " + recipe.getName(true));
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

        private void ItemCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            typeToggle(ItemCheckBox);
        }

        private void ResourceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            typeToggle(ResourceCheckBox);
        }

        private void ToolCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            typeToggle(ToolCheckBox);
        }

        public CheckBox activeCheckBox;
        public void typeToggle(CheckBox checkBox)
        {
            Debug.Write("\nToggle ran");
            if (activeCheckBox == null || activeCheckBox == checkBox)
            {
                activeCheckBox = activeCheckBox == checkBox && !activeCheckBox.Checked ? null : checkBox;
                if (activeCheckBox == null) ItemCheckBox.Checked = true;
            }
            else
            {
                activeCheckBox.Checked = false;
                activeCheckBox = checkBox;
            }
        }

    }
}
