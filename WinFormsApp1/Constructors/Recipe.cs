using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SPTLauncher.Constructors
{
    public enum Module
    {
        [Description("Bitcoin")]
        BTC,
        [Description("Scav Case")]
        SCAVBOX,
        [Description("Generator")]
        GENERATOR,
        [Description("Workbench")]
        WORKBENCH = 10,
    }

    public class Recipe
    {
        private string _id;
        private Module module;
        private List<RecipeRequirement> requirements = new List<RecipeRequirement>();
        private int productionTime;
        private bool powerNeeded;
        private string endProduct;
        private int count;
        private int requiredModuleLevel;
        private int requiredModule;

        //types are Item, Tool and Resource
        // Item is pretty basic
        // Tool is like a toolset that gets returned after the craft
        // Resource is a water filter that gets used over time.
        public Recipe(Module module)
        {
            this.module = module;
            string des = GetEnumDescription(module);
        }

        public Recipe(JToken jToken)
        {
            _id = jToken["_id"].ToString();
            //areaType = module;
            JArray reqs = JArray.Parse(jToken["requirements"].ToString());
            foreach(JToken req in reqs)
            {
                //Debug.Write("\nIterating " + req);
                RecipeRequirement rr = new RecipeRequirement(req);
                requirements.Add(rr);
            }
            productionTime = (int)jToken["productionTime"];
            endProduct = jToken["endProduct"].ToString();
            count = (int)jToken["count"];
        }

        public string getID()
        {
            return _id;
        }

        public int getProductionTime()
        {
            return productionTime;
        }

        public string getEndProduct()
        {
            return endProduct;
        }

        public int getCount()
        {
            return count;
        }

        public List<RecipeRequirement> GetRecipeRequirements()
        {
            return requirements;
        }

        public bool isPowerNeeded()
        {
            return powerNeeded;
        }

        private string GetEnumDescription(Enum value)
        {
            // Get the Description attribute value for the enum value
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }

    public class RecipeRequirement
    {
        private string itemID;
        private int count;
        private bool returnOnCraft;

        public RecipeRequirement(string itemID, int count = 1, bool returnOnCraft = false)
        {
            this.itemID = itemID;
            this.count = count;
            this.returnOnCraft = returnOnCraft;
        } 
        
        public RecipeRequirement(JToken jToken)
        {
            if (jToken["areaType"] == null && jToken["questId"] == null)
            {
                itemID = jToken["templateId"].ToString();
                if (jToken["count"] == null) count = 1;
                else count = (int)jToken["count"];
                returnOnCraft = jToken["type"].ToString().Equals("Tool");
            }
        }

        public string getID()
        {
            return itemID;
        }

        public int getCount()
        {
            return count;
        }

        public bool getReturnOnCraft()
        {
            return returnOnCraft;
        }
    }
}
