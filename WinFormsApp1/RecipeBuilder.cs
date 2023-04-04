using Newtonsoft.Json.Linq;
using SPTLauncher.Constructors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1;

namespace SPTLauncher
{
    public partial class RecipeBuilder : Form
    {
        Dictionary<string, Recipe> _recipes = new Dictionary<string, Recipe>();
        public RecipeBuilder()
        {
            InitializeComponent();
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
                    listBox1.Items.Add(recipe2.getID()/*recipe["_id"]*/);
                    _recipes[recipe2.getID()] = recipe2;
                    Form1.form.log("Has Requirements");
                }
            }
        }

        private void RecipeBuilder_Load(object sender, EventArgs e)
        {
            LoadRecipes();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = listBox1.SelectedItem.ToString();
            Recipe recipe = _recipes[id];
            LoadShit(recipe);
            if (requirementList.Items.Count > 0) requirementList.SelectedIndex = 0;
        }

        public void LoadShit(Recipe recipe)
        {
            nameTextBox.Text = recipe.getID();
            ModuleComboBox.Text = Recipe.GetEnumDescription(recipe.getModule());
            endProductBox.Text = recipe.getEndProduct();
            CraftAmount.Value = recipe.getCount();
            PowerRequirement.Checked = recipe.isPowerNeeded();
            requirementList.Items.Clear();
            foreach (RecipeRequirement requirement in recipe.GetRecipeRequirements().Values)
            {
                string id = requirement.getID();
                if (id != null) requirementList.Items.Add(id);
                //if(requirement!= null) requirementList.Items.Add(requirement.getID());
            }
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
            return _recipes[listBox1.SelectedItem.ToString()];
        }

        public void LoadRequirement(RecipeRequirement requirement)
        {
            if (requirement != null)
            {
                Recipe recipe = _recipes[listBox1.SelectedItem.ToString()];
                requirementID.Text = requirement.getID();
                RequiredAmount.Value = requirement.getCount();
            }
        }
    }
}
