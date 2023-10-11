using SPTLauncher.Components.RecipeManagement.Requirements.Interfaces;

namespace SPTLauncher.Components.RecipeManagement.Requirements
{
    internal struct ToolRequirement : IToolRequirement
    {
        public RequirementType Type { get; set; }
        public string ItemID {  get; set; }
        
        public ToolRequirement(string ItemID)
        {
            Type = RequirementType.Tool;
            this.ItemID = ItemID;
        }
    }
}
