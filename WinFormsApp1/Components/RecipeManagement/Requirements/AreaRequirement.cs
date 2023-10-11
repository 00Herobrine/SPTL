using SPTLauncher.Components.RecipeManagement.Requirements.Interfaces;

namespace SPTLauncher.Components.RecipeManagement.Requirements
{
    internal struct AreaRequirement : IAreaRequirement
    {
        public RequirementType Type { get; set; }
        public int RequiredLevel { get; set; }
        public Module AreaType { get; set; }
        public AreaRequirement(Module AreaType, int RequiredLevel)
        {
            this.AreaType = AreaType;
            this.RequiredLevel = RequiredLevel;
        }
    }
}
