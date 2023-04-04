using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SPTLauncher.Constructors
{
    public enum Module
    {
        [Description("Air Filtering Unit")]
        AIRFILTER,
        [Description("Bitcoin")]
        BTC,
        [Description("Booze Generator")]
        BOOZEGENERATOR,
        [Description("Generator")]
        GENERATOR,
        [Description("Gym")]
        GYM,
        [Description("Heating")]
        HEATING,
        [Description("Illumination")]
        LIGHTING,
        [Description("Intelligence Center")]
        INTELLIGENCE,
        [Description("Lavoratory")]
        LAVORATORY,
        [Description("Library")]
        LIBRARY,
        [Description("Medstation")]
        MEDICAL,
        [Description("Nutrition Unit")]
        NUTRITION,
        [Description("Rest Space")]
        RESTSPACE,
        [Description("Scav Case")]
        SCAVBOX,
        [Description("Security")]
        SECURITY,
        [Description("Shooting Range")]
        SHOOTINGRANGE,
        [Description("Solar Power")]
        SOLAR,
        [Description("Stash")]
        STASH,
        [Description("Vents")]
        VENTS,
        [Description("Water Collector")]
        WATER,
        [Description("Workbench")]
        WORKBENCH = 10,
        [Description("Christmas Tree")]
        CHRISTMAS
    }

    public class Recipe
    {
        private string _id;
        private Module module;
        private Dictionary<string, RecipeRequirement> requirements = new Dictionary<string, RecipeRequirement>();
        //private List<RecipeRequirement> requirements = new List<RecipeRequirement>();
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
                if (req["areaType"] == null && req["questId"] == null)
                {
                    requirements[_id] = new RecipeRequirement(req);
                }
                //requirements.Add(new(req));
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
        public Dictionary<string, RecipeRequirement> GetRecipeRequirements()
        {
            return requirements;
        }
        public bool isPowerNeeded()
        {
            return powerNeeded;
        }
        public Module getModule()
        {
            return module;
        }

        public static string GetEnumDescription(Enum value)
        {
            // Get the Description attribute value for the enum value
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public RecipeRequirement? GetRecipeRequirement(string id)
        {
            if (requirements.ContainsKey(id)) return GetRecipeRequirements()["rid"];
            return null;
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

                itemID = jToken["templateId"].ToString();
                Debug.Write("\nCaching requirement " + itemID);
                if (jToken["count"] == null) count = 1;
                else count = (int)jToken["count"];
                returnOnCraft = jToken["type"].ToString().Equals("Tool");
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
