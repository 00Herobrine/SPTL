using Newtonsoft.Json.Linq;
using SPTLauncher.Components;
using SPTLauncher.Components.Caching;
using SPTLauncher.Components.RecipeManagement;
using System.Diagnostics;
using WinFormsApp1;

namespace SPTLauncher
{
    public partial class RecipeBuilder : Form
    {
        public static RecipeBuilder rb;
        private List<Module> acceptableModules = new List<Module>();
        JArray production = JArray.Parse(File.ReadAllText(Paths.productionPath));
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
            int index = listBox1.Items.Add(recipe);
            listBox1.SelectedIndex = index;
        }

        public void LoadRecipes()
        {
            ItemCheckBox.Checked = true;
            listBox1.Items.Clear();
            ModuleComboBox.Items.Clear();
            foreach (Module module in acceptableModules) ModuleComboBox.Items.Add(Recipe.GetEnumDescription(module));
            foreach (RecipeStruct recipe in RecipeManager.recipes.Values) listBox1.Items.Add(recipe);
        }

        public void ResetRequirementType()
        {
            ItemCheckBox.Checked = true;
            ResourceCheckBox.Checked = false;
            ToolCheckBox.Checked = false;
        }

        private void RecipeBuilder_Load(object sender, EventArgs e)
        {
            LoadRecipes();
            StoreValidItems();
            foreach (CacheItem item in TarkovCache.tarkovCache.Values) requirementID.Items.Add(item);
        }

        private void StoreValidItems()
        {
            productBox.Items.Clear();
            productBox.Items.AddRange(TarkovCache.tarkovCache.Values.ToArray());
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;
            RecipeStruct recipe = (RecipeStruct)listBox1.SelectedItem;
            string id = recipe.id;
            //Recipe recipe = _recipes[id];
            LoadShit(recipe);
            if (requirementList.Items.Count > 0) requirementList.SelectedIndex = 0;
        }

        public void LoadRecipeInfo(RecipeStruct recipe)
        {
            nameTextBox.Text = recipe.name;
            if (recipe.HasRequiredModule()) requiredModuleBox.SelectedItem = recipe.GetModule();
            else requiredModuleBox.SelectedIndex = -1;
            //productBox.SelectedItem = 
        }

        public void LoadShit(RecipeStruct recipe)
        {
            string name = recipe.name ?? TarkovCache.GetReadableNameFromID(recipe.endProduct);
            nameTextBox.Text = name;
            ModuleComboBox.Text = recipe.HasRequiredModule() ? Recipe.GetEnumDescription(recipe.GetModule()) : "";
            endProductBox.Text = recipe.endProduct;
            CraftAmount.Value = recipe.count;
            PowerRequirement.Checked = recipe.isPowerNeeded;
            requirementList.Items.Clear();
            productionTime.Value = recipe.productionTime;
            if (recipe.HasRequirements()) foreach (RequirementStruct requirement in recipe.requirements.Where(o => !o.isArea)) requirementList.Items.Add(requirement);
            if (requirementList.Items.Count > 0) requirementList.SelectedIndex = 0;
            if (recipe.HasRequiredModule())
            {
                Module requiredModule = recipe.GetModule();
                requiredModuleBox.Text = Recipe.GetEnumDescription(requiredModule);
                requiredModuleLvl.Minimum = int.Parse(Recipe.GetEnumMinMax(requiredModule)[0]);
                requiredModuleLvl.Maximum = int.Parse(Recipe.GetEnumMinMax(requiredModule)[1]);
                requiredModuleLvl.Value = recipe.RequiredModuleLevel();
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
            //setRequirement(requirementList.SelectedIndex);
            LoadRequirementInfo((RequirementStruct)requirementList.SelectedItem);
        }

        public void LoadRequirementInfo(RequirementStruct requirement)
        {
            ToolCheckBox.Checked = false;
            switch (requirement.GetType())
            {
                case RequirementType.Item:
                    ItemStruct item = (ItemStruct)requirement;
                    RequiredAmount.Value = item.count;
                    break;
                case RequirementType.Tool:
                    ToolCheckBox.Checked = true;
                    break;
                default:
                    break;
            }
            requirementID.Text = requirement.ToString();
        }

        public void setRequirement(int index = 0)
        {
            //requirementList.SelectedIndex = index;
            if (requirementList.SelectedIndex == -1) if (requirementList.Items.Count > 0) requirementList.SelectedIndex = 0;
                else return; // no requirements left, should clear boxes
            RecipeRequirement? requirement = getSelectedRecipe().GetRecipeRequirement(((RecipeRequirement)requirementList.SelectedItem).getID());
            if (requirement == null) return;
            LoadRequirement(requirement);
        }

        public Recipe getSelectedRecipe()
        {
            return (Recipe)listBox1.SelectedItem;
        }

        public void LoadRequirement(RecipeRequirement requirement)
        {
            if (requirement != null)
            {
                requirementID.Text = TarkovCache.GetReadableNameFromID(requirement.getID());
                RequiredAmount.Value = requirement.getCount();
                ToolCheckBox.Checked = requirement.isReturnedOnCraft();
            }
            else { Form1.log("Error loading requirement"); }
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
            RecipeRequirement selectedItem = (RecipeRequirement)requirementList.SelectedItem;
            if (selectedItem.getID() != null) recipe.GetRecipeRequirement(selectedItem.getID()).setCount((int)RequiredAmount.Value);
            string id = listBox1.SelectedItem.ToString();
            //_recipes[id] = recipe;
            recipe.updateSettings();
            Form1.log("Updated recipe " + recipe.getName(true));
        }

        public static void UpdateRecipesFile(JToken token)
        {
            JArray jArray = JArray.Parse(File.ReadAllText(Paths.productionPath));
            jArray[rb.listBox1.SelectedIndex] = token;
            File.WriteAllText(Paths.productionPath, jArray.ToString());
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

        public CheckBox? activeCheckBox;
        public void typeToggle(CheckBox checkBox)
        {
            //Debug.WriteLine("Toggle ran");
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

        private void button2_Click(object sender, EventArgs e)
        {
            requirementList.Items.Add(getSelectedRecipe().AddRequirement());
        }

        public void NewRequirement()
        {
            NewRequirement(getSelectedRecipe());
        }
        public void NewRequirement(Recipe recipe)
        {

        }

        private void DeleteRecipeButton_Click(object sender, EventArgs e)
        {
            Recipe recipe = getSelectedRecipe();
            listBox1.Items.Remove(recipe);
            production[recipe.GetJToken].Remove();
            Save();
        }

        public void Save()
        {
            File.WriteAllText(Paths.productionPath, File.ReadAllText(production.ToString()));
        }

        private void requirementID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ((char)Keys.Enter))
            {
                GetSelectedRequirement().setID(requirementID.Text);
                e.Handled = true;
            }
        }

        private RecipeRequirement GetSelectedRequirement()
        {
            return (RecipeRequirement)requirementList.SelectedItem;
        }

        private void requirementID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (requirementID.SelectedIndex == -1) return;
            CacheItem item = (CacheItem)requirementID.SelectedItem;
            //Debug.WriteLine("ID: " + item.ID);
            requirementID.Text = item.ID;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            getSelectedRecipe().RemoveRequirement(GetSelectedRequirement());
            requirementList.Items.Remove(requirementList.SelectedItem);
        }

        private void RecipeBuilder_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void productBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private CacheItem[] Filter(string input)
        {
            if (input == "") return TarkovCache.tarkovCache.Values.ToArray();
            return TarkovCache.tarkovCache.Values.Where(o => o.ID.Contains(input, StringComparison.OrdinalIgnoreCase)
            || (o.Name != null && o.Name.Contains(input, StringComparison.OrdinalIgnoreCase))
            || (o.ShortName != null && o.ShortName.Contains(input, StringComparison.OrdinalIgnoreCase))).ToArray();
        }

        private void productBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                productBox.Items.Clear();
                productBox.Items.AddRange(Filter(productBox.Text));
            }
        }
    }
}
