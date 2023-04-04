using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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

    internal class Recipe
    {
        private int _id;
        private Module module;
        private List<RecipeRequirement> requirements;
        private int productionTime;
        private bool powerNeeded;
        private string endProduct;
        private int craftAmount;
        private int requiredModuleLevel;
        private int requiredModule;

        public Recipe(Module module)
        {
            this.module = module;
            string des = GetEnumDescription(module);
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
    }
}
