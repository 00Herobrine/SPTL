using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Reflection;
using WinFormsApp1;

namespace SPTLauncher.Components.RecipeManagement
{
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
            foreach (JToken req in GetRequirementsArray())
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
            Form1.log($"Removed {requirement} requirement for {requirement.parent}");
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

        public RecipeRequirement GetRecipeRequirement(string id)
        {
            if (requirements.ContainsKey(id))
            {
                Debug.Write("\nGetting Requirements for " + id + " questID " + getID());
                return requirements[id];
            }
            return null;
        }
    }
}
