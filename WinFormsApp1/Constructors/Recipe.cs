using Aki.Launcher.Attributes;
using Newtonsoft.Json.Linq;
using SPTLauncher.Components;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Reflection;
using WinFormsApp1;

namespace SPTLauncher.Constructors
{
    public enum Module
    {
        [Description("Vents"), Range(1, 3)]
        VENTS = 0,
        [Description("Security"), Range(1, 3)]
        SECURITY = 1,
        [Description("Lavoratory"), Range(1, 3)]
        LAVORATORY = 2,
        [Description("Stash"), Range(1, 4)]
        STASH = 3,
        [Description("Generator"), Range(1, 3)]
        GENERATOR = 4,
        [Description("Heating"), Range(1, 3)]
        HEATING = 5,
        [Description("Water Collector"), Range(1, 3)]
        WATER = 6,
        [Description("Medstation"), Range(1, 3)]
        MEDICAL = 7,
        [Description("Nutrition Unit"), Range(1, 3)]
        NUTRITION = 8,
        [Description("Rest Space"), Range(1, 3)]
        RESTSPACE = 9,
        [Description("Workbench"), Range(1, 3)]
        WORKBENCH = 10,
        [Description("Intelligence Center"), Range(1, 3)]
        INTELLIGENCE = 11,
        [Description("Shooting Range"), Range(1, 3)]
        SHOOTINGRANGE = 12,
        [Description("Library"), Range(1, 1)]
        LIBRARY = 13,
        [Description("Scav Case"), Range(1, 1)]
        SCAVBOX = 14,
        [Description("Illumination"), Range(1, 3)]
        LIGHTING = 15,
/*        [Description("Place of Fame"), Range(1, 1)]
        FAME = 16,*/
        [Description("Air Filtering Unit"), Range(1, 1)]
        AIRFILTER = 17,
        [Description("Solar Power"), Range(1, 1)]
        SOLAR = 18,
        [Description("Booze Generator"), Range(1, 1)]
        BOOZEGENERATOR = 19,
        [Description("Bitcoin Farm"), Range(1, 3)]
        BTC = 20,
        [Description("Christmas Tree"), Range(1, 1)]
        CHRISTMAS = 21,
        [Description("Broken Wall"), Range(1, 6)]
        BROKENWALL = 22,
        [Description("Gym"), Range(1, 2)]
        GYM = 23
    }

    public class Recipe
    {
        private string _id;
        private string name;
        private Module module;
        private RecipeRequirement requiredModule;
        public Dictionary<string, RecipeRequirement> requirements = new Dictionary<string, RecipeRequirement>(); // itemId, requirement
        private int productionTime = 0;
        private bool powerNeeded = false;
        private string endProduct;
        private int count = 1;
        private int requiredModuleLevel;
        public JToken jToken; // the little section of the JSON it's in
        //public JArray reqs; // requirements

        // types are Item, Tool and Resource
        // Item is pretty basic
        // Tool is like a toolset that gets returned after the craft
        // Resource is a water filter that gets used over time.
        public Recipe(Module module = Module.WORKBENCH)
        {
            _id = Guid.NewGuid().ToString().Replace("-", ""); // recipe id, generate something
            this.module = module;
            string des = GetEnumDescription(module);
            JArray production = JArray.Parse(File.ReadAllText(Paths.productionPath));
            //production.Add(toke);
            jToken = production.Descendants().Where(x => x.Type == JTokenType.Property && ((JProperty)x).Value.ToString().Equals(_id)).FirstOrDefault();
            //jToken = production[""];
        }

        public Recipe(JToken token)
        {
            jToken = token;
            _id = jToken["_id"].ToString();
            //areaType = module;
            name = "";
            module = RecipeBuilder.GetModuleByID((int)jToken["areaType"]);
            if (jToken["name"] != null) name = jToken["name"].ToString();
            //reqs = JArray.Parse(jToken["requirements"].ToString());
            foreach(JToken req in GetRequirementsArray())
            {
                if (req["areaType"] != null) requiredModule = new RecipeRequirement(req, this);
                //Debug.Write("\nIterating " + req);
                else if (req["questId"] == null && req["templateId"] != null)
                {
                    requirements[req["templateId"].ToString()] = new RecipeRequirement(req, this);
                }
                //requirements.Add(new(req));
            }
            powerNeeded = (bool)jToken["needFuelForAllProductionTime"];
            productionTime = (int)jToken["productionTime"];
            endProduct = jToken["endProduct"].ToString();
            count = (int)jToken["count"];
        }
        public string getID()
        {
            return _id;
        }
        public string getName(bool format = false)
        {
            if ((name == null || name == "") && format) return _id;
            return name;
        }

        public JArray GetRequirementsArray()
        {
            return JArray.Parse(jToken["requirements"].ToString());
        }
        public JToken GetJToken()
        {
            return jToken;
        }
        public void setName(string name)
        {
            jToken["name"] = name;
            this.name = name;
        }
        public int getProductionTime()
        {
            return productionTime;
        }
        public void setProductionTime(int productionTime)
        {
            jToken["productionTime"] = productionTime;
            this.productionTime = productionTime;
        }

        public string getEndProduct()
        {
            return endProduct;
        }
        public void setEndProduct(string id)
        {
            endProduct = id;
            jToken["endProduct"] = id;
        }

        public int getCount()
        {
            return count;
        }
        public void setCount(int count)
        {
            this.count = count;
            jToken["count"] = count;
        }

        public RecipeRequirement AddRequirement(string id = "Item ID HERE", int count = 1, bool isReturned = false)
        {
            JObject jobject = new JObject();
            jobject["templateId"] = id;
            jobject["count"] = count;
            JArray updatedArray = JArray.Parse(jToken["requirements"].ToString());
            updatedArray.Add(jobject);
            jToken["requirements"] = updatedArray;
            if (isReturned) jToken["type"] = "Tool";
            else jToken["type"] = "Item";
            updateSettings();
            RecipeRequirement requirement = new(this, id, jobject, count, isReturned);
            requirements.Add(id, requirement);
            return requirement;
        }

        public void RemoveRequirement(RecipeRequirement requirement)
        {
            RemoveRequirement(requirement.getID());
        }
        public void RemoveRequirement(string id)
        {
            RecipeRequirement requirement = requirements[id];
            requirements.Remove(id);
            JArray array = JArray.Parse(jToken["requirements"].ToString());
            array.SelectToken(requirement.GetJToken().Path).Remove();
            Debug.WriteLine(requirement.GetJToken().ToString());
            Debug.WriteLine(array);
            jToken["requirements"] = array;
            Form1.form.log($"Removed {requirement} requirement for {requirement.parent}");
            updateSettings();
        }
        public Dictionary<string, RecipeRequirement> GetRecipeRequirements()
        {
            return requirements;
        }
        public bool isPowerNeeded()
        {
            return powerNeeded;
        }
        public void setPowerNeeded(bool powerNeeded = false)
        {
            this.powerNeeded = powerNeeded;
            JObject jobject = new JObject();
            jobject["needFuelForAllProductionTime"] = powerNeeded;
            //jToken["needFuelForAllProductionTime"] = powerNeeded;
        }

        public Module getModule()
        {
            return module;
        }
        public void setModule(Module module)
        {
            this.module = module;
            jToken["areaType"] = (int)module;
        }

        public RecipeRequirement getModuleRequirement()
        {
            return requiredModule;
        }
        public Module getRequiredModule()
        {
            return requiredModule.getRequiredModule();
        }
        public int getRequiredModuleLevel()
        {
            return requiredModule.getRequiredModuleLvl();
        }
        public bool hasRequiredModule()
        {
            return requiredModule != null;
        }

        public void updateSettings()
        {
            RecipeBuilder.UpdateRecipesFile(jToken);
        }

        override
        public string ToString()
        {
            return name.Equals("") ? TarkovCache.GetReadableName(endProduct) : getName(true);
            //return getName(true);
        }

        public static string GetEnumDescription(Enum value)
        {
            // Get the Description attribute value for the enum value
            FieldInfo fi = value.GetType().GetField(value.ToString());
            if (fi == null) return "NULL";
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public static string[] GetEnumMinMax(Enum value)
        {
            Debug.Write("\nChecking for enum " + value);
            Enum myEnumValue = value;
            FieldInfo fi = value.GetType().GetField(value.ToString());
            if (fi == null) return null;
            RangeAttribute rangeAttribute = (RangeAttribute)fi.GetCustomAttribute(typeof(RangeAttribute), false);
            List<string> values = new List<string>
            {
                rangeAttribute.Minimum.ToString(),
                rangeAttribute.Maximum.ToString()
            };
            return values.ToArray();
        }

        public RecipeRequirement? GetRecipeRequirement(string id)
        {
            if (requirements.ContainsKey(id))
            {
                Debug.Write("\nGetting Requirements for " + id + " questID " + getID());
                return requirements[id];
            }
            return null;
        }
    }

    public class RecipeRequirement
    {
        private string itemID;
        private int count;
        private bool returnOnCraft;

        private Module requiredModule;
        private int requiredModuleLvl = -1;
        public Recipe parent;
        private JToken jToken; // little part of Json it's in

        public RecipeRequirement(Recipe recipe, string itemID, JToken token, int count = 1, bool returnOnCraft = false)
        {
            parent = recipe;
            jToken = token;
            this.itemID = itemID;
            this.count = count;
            this.returnOnCraft = returnOnCraft;
        } 
        
        public RecipeRequirement(JToken token, Recipe parent)
        {
            this.parent = parent;
            jToken = token;
            if (jToken["areaType"] != null)
            {
                requiredModule = RecipeBuilder.GetModuleByID((int)jToken["areaType"]);
                requiredModuleLvl = (int)jToken["requiredLevel"];
            }
            else
            {
                itemID = jToken["templateId"].ToString();
                if (jToken["count"] == null) count = 1;
                else count = (int)jToken["count"];
                bool temp = false;
                if (jToken["type"] != null && jToken["type"].ToString().Equals("Tool")) temp = true;
                returnOnCraft = temp;
            }
        }

        public string getID()
        {
            return itemID;
        }
        public void setID(string id)
        {
            parent.requirements.Remove(itemID);
            itemID = id;
            updateRequirements("templateId", id);
            parent.requirements.Add(id, this);
        }

        public int getCount()
        {
            return count;
        }
        public void setCount(int count)
        {
            jToken["count"] = count;
            this.count = count;
            updateRequirements("count", count);
        }

        public bool isReturnedOnCraft()
        {
            return returnOnCraft;
        }
        public void returnedOnCraft(bool returned)
        {
            returnOnCraft = returned;
            //setType to "Tool"
        }

        public Module getRequiredModule()
        {
            return requiredModule;
        }
        public void setRequiredModule(Module module)
        {
            requiredModule = module;
            updateRequirements("areaType", module.ToString());
        }
        public int getRequiredModuleLvl()
        {
            return requiredModuleLvl;
        }
        public void setRequiredModuleLvl(int level)
        {
            requiredModuleLvl = level;
            updateRequirements("requiredLevel", level);
        }

        public void updateRequirements(string name, int updated)
        {
            jToken[name] = updated;
            JToken token = jToken.Parent;
            parent.jToken["requirements"] = jToken.Parent;
            //Form1.form.log($"Updated requirement {name} for {parent}");
        }
        public void updateRequirements(string name, string updated)
        {
            jToken[name] = updated;
            JToken token = jToken.Parent;
            parent.jToken["requirements"] = jToken.Parent;
            Form1.form.log($"Updated requirement for {parent}");
        }

        public bool hasRequiredModule()
        {
            return requiredModuleLvl != -1;
        }

        public JToken GetJToken()
        {
            return jToken;
        }

        override
        public string ToString()
        {
            return TarkovCache.GetReadableName(itemID);
        }
    }
}
