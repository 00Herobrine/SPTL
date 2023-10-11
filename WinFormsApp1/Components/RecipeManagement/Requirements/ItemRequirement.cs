using SPTLauncher.Components.RecipeManagement.Requirements.Interfaces;

namespace SPTLauncher.Components.RecipeManagement.Requirements
{
    internal class ItemRequirement : IItemRequirement
    {
        public RequirementType Type { get; set; }
        public int Count { get; set; }
        public bool IsEncoded {  get; set; }
        public bool IsFunctional { get; set; }
        public string ItemID { get; set; }

        public ItemRequirement(string ItemID)
        {
            this.ItemID = ItemID;
        }
    }
}
