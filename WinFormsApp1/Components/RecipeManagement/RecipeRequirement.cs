using Newtonsoft.Json.Linq;
using SPTLauncher.Components.Caching;
using WinFormsApp1;

namespace SPTLauncher.Components.RecipeManagement
{
    public class RecipeRequirement
    {
        private string? itemID;
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

        public string? getID()
        {
            return itemID;
        }
        public bool IsModule()
        {
            return requiredModule != null;
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
            Form1.log($"Updated requirement for {parent}");
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
            return TarkovCache.GetReadableNameFromID(itemID);
        }
    }
}
