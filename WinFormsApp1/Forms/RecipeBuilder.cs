using Newtonsoft.Json;
using SPTLauncher.Components;
using SPTLauncher.Components.Caching;
using SPTLauncher.Components.QuestManagement;
using SPTLauncher.Components.RecipeManagement;
using SPTLauncher.Utils;
using System.ComponentModel;

namespace SPTLauncher
{
    public partial class RecipeBuilder : Form
    {
        public static RecipeBuilder rb;
        private List<Module> acceptableModules = new List<Module>();
        //JArray production = JArray.Parse(File.ReadAllText(Paths.productionPath));
        public RecipeBuilder()
        {
            acceptableModules.Add(Module.WORKBENCH);
            acceptableModules.Add(Module.MEDICAL);
            acceptableModules.Add(Module.NUTRITION);
            acceptableModules.Add(Module.LAVORATORY);
            acceptableModules.Add(Module.WATER);
            acceptableModules.Add(Module.BOOZEGENERATOR);
            InitializeComponent();
            LoadPossibleRequirements();

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
            listBox1.Items.Clear();
            ModuleComboBox.Items.Clear();
            foreach (Module module in acceptableModules) ModuleComboBox.Items.Add(module.GetDescription());
            Dictionary<Recipe, string> recipes = RecipeManager.recipes.ToDictionary(pair => pair.Value, pair => pair.Key);
            listBox1.DataSource = new BindingList<KeyValuePair<Recipe, string>>(recipes.ToList());
            listBox1.DisplayMember = "Value";
            listBox1.ValueMember = "Key";
            //foreach (Recipe recipe in RecipeManager.recipes.Values) listBox1.Items.Add(recipe);
        }

        public void ResetRequirementType()
        {
            ItemCheckBox.Checked = true;
            ResourceCheckBox.Checked = false;
            ToolCheckBox.Checked = false;
            QuestCheckBox.Checked = false;
        }

        private void RecipeBuilder_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadRecipes();
        }
        private void LoadProducts()
        {
            Dictionary<CacheEntry, string> productsDisplay = TarkovCache.ItemDictionary.Values
            .ToDictionary(
                value => value,
                value => value.ToString()
            );

            productBox.DataSource = new BindingSource(productsDisplay, null);
            productBox.DisplayMember = "Value";
            productBox.ValueMember = "Key";
        }

        private void LoadPossibleRequirements()
        {
            Dictionary<CacheEntry, string> productsDisplay = TarkovCache.ItemDictionary.Values
                    .ToDictionary(
                        value => value,
                        value => value.ToString()
                    );
            BindingSource productSource = new(productsDisplay, null);
            requirementID.DataSource = productSource;
            requirementID.DisplayMember = "Value";
            requirementID.ValueMember = "Key";
            Dictionary<CachedQuest, string> questsDisplay = TarkovCache.questCache.Values
                    .ToDictionary(
                        value => value,
                        value => value.Name
                    );
            BindingSource questSource = new(questsDisplay, null);
            QuestRequirementID.DataSource = questSource;
            QuestRequirementID.DisplayMember = "Value";
            QuestRequirementID.ValueMember = "Key";
        }

        private void TogglePossibleRequirements(RecipeRequirement requirement)
        {
            RequirementType type = requirement.GetType();
            label3.Text = $"{type} ID:";
            switch (type)
            {
                case RequirementType.Area:
                    break;
                case RequirementType.QuestComplete:
                    requirementID.Visible = false;
                    QuestRequirementID.Visible = true;
                    break;
                case RequirementType.Tool:
                case RequirementType.Resource:
                case RequirementType.Item:
                    requirementID.Visible = true;
                    QuestRequirementID.Visible = false;
                    break;
                default:
                    requirementID.Visible = true;
                    QuestRequirementID.Visible = false;
                    break;
            }
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedValue == null) return;
            Recipe recipe = ((KeyValuePair<Recipe, string>)listBox1.SelectedItem).Key;
            string id = recipe.id;
            //Recipe recipe = _recipes[id];
            LoadShit(recipe);
            if (requirementList.Items.Count > 0) requirementList.SelectedIndex = 0;
        }

        public void LoadRecipeInfo(Recipe recipe)
        {
            nameTextBox.Text = recipe.name;
            if (recipe.HasRequiredModule()) requiredModuleBox.SelectedItem = recipe.GetModule();
            else requiredModuleBox.SelectedIndex = -1;
        }

        public void LoadShit(Recipe recipe)
        {
            nameTextBox.Text = recipe.ToString();
            ModuleComboBox.Text = recipe.GetModule().GetDescription();
            endProductBox.Text = recipe.endProduct;
            CraftAmount.Value = recipe.count;
            PowerRequirement.Checked = recipe.isPowerNeeded;
            requirementList.Items.Clear();
            productionTime.Value = recipe.productionTime;
            Module? module = recipe.GetModule();
            if (recipe.HasRequirements()) foreach (RecipeRequirement requirement in recipe.requirements.Where(o => !o.isArea)) requirementList.Items.Add(requirement);
            if (module != null)
            {
                Module requiredModule = (Module)module;
                requiredModuleBox.Text = requiredModule.GetDescription();
                requiredModuleLvl.Minimum = int.Parse(requiredModule.GetMinMax()[0]);
                requiredModuleLvl.Maximum = int.Parse(requiredModule.GetMinMax()[1]);
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

        private void requirementList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //setRequirement(requirementList.SelectedIndex);
            if (requirementList.SelectedItem == null) return;
            RecipeRequirement requirement = (RecipeRequirement)requirementList.SelectedItem;
            LoadRequirementInfo(requirement);
        }

        public void LoadRequirementInfo(RecipeRequirement requirement)
        {
            ToolCheckBox.Checked = false;
            RequiredAmount.Value = 1;
            TogglePossibleRequirements(requirement);
            switch (requirement.GetType())
            {
                case RequirementType.Item:
                    ItemRequirement item = (ItemRequirement)requirement;
                    RequiredAmount.Value = item.count;
                    RequiredAmount.Enabled = true;
                    requirementID.SelectedValue = TarkovCache.GetItemEntry(item.templateId);
                    ItemCheckBox.Checked = true;
                    break;
                case RequirementType.Tool:
                    ToolRequirement tool = (ToolRequirement)requirement;
                    RequiredAmount.Value = 1;
                    RequiredAmount.Enabled = false;
                    requirementID.SelectedValue = TarkovCache.GetItemEntry(tool.templateId);
                    ToolCheckBox.Checked = true;
                    break;
                case RequirementType.QuestComplete:
                    QuestRequirement quest = (QuestRequirement)requirement;
                    RequiredAmount.Value = 1;
                    RequiredAmount.Enabled = false;
                    QuestRequirementID.SelectedItem = TarkovCache.GetQuestEntry(quest.questId);
                    QuestCheckBox.Checked = true;
                    break;
                case RequirementType.Resource:
                    ResourceRequirement resource = (ResourceRequirement)requirement;
                    RequiredAmount.Value = 1;
                    RequiredAmount.Enabled = false;
                    requirementID.SelectedValue = TarkovCache.GetItemEntry(resource.templateId);
                    ResourceCheckBox.Checked = true;
                    break;
                default:
                    break;
            }
            //requirementID.Text = requirement.ToString();
        }

        public Recipe GetSelectedRecipe()
        {
            return (Recipe)listBox1.SelectedValue;
        }


        private void SaveRecipeButton_Click(object sender, EventArgs e)
        {

        }

        private void ItemCheckBox_CheckedChanged(object sender, EventArgs e) => typeToggle(ItemCheckBox);
        private void ResourceCheckBox_CheckedChanged(object sender, EventArgs e) => typeToggle(ResourceCheckBox);
        private void ToolCheckBox_CheckedChanged(object sender, EventArgs e) => typeToggle(ToolCheckBox);
        private void QuestCheckBox_CheckedChanged(object sender, EventArgs e) => typeToggle(QuestCheckBox);
        public CheckBox? activeCheckBox;
        public void typeToggle(CheckBox checkBox)
        {
            if (checkBox == activeCheckBox) { activeCheckBox = null; return; }
            if (activeCheckBox != null) activeCheckBox.Checked = false;
            activeCheckBox = checkBox;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedValue == null) return;
            int index = requirementList.Items.Add(GetSelectedRecipe().NewRequirement());
            requirementList.SelectedIndex = index;
        }

        private void DeleteRecipeButton_Click(object sender, EventArgs e)
        {

        }

        private void requirementID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ((char)Keys.Enter))
            {
                //GetSelectedRequirement().setID(requirementID.Text);
                e.Handled = true;
            }
        }

        private RecipeRequirement GetSelectedRequirement()
        {
            return (RecipeRequirement)requirementList.SelectedItem;
        }

        private void requirementID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (requirementID.SelectedItem == null || requirementList.SelectedItem == null) return;
            RecipeRequirement requirement = (RecipeRequirement)requirementList.SelectedItem;
            RequirementType type = requirement.GetType();
            //Debug.WriteLine("ID: " + item.ID);
            requirementID.Text = requirement.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetSelectedRecipe().RemoveRequirement(GetSelectedRequirement());
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
                //productBox.Items.AddRange(Filter(productBox.Text));
            }
        }

        private void requiredModuleLvl_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
