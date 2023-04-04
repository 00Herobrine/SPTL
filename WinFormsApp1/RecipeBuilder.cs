using Newtonsoft.Json.Linq;
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
            foreach(JToken recipe in production)
            {
                Form1.form.log("Checking ID " + recipe["_id"]);
                if (recipe["requirements"] != null)
                {
                    listBox1.Items.Add(recipe["_id"]);
                    Form1.form.log("Has Requirements");
                }
            }
        }

        private void RecipeBuilder_Load(object sender, EventArgs e)
        {
            LoadRecipes();
        }
    }
}
