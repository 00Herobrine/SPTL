namespace SPTLauncher.Components.RecipeManagement.Requirements.Interfaces
{
    internal interface IAreaRequirement : IRequirement
    {
        int RequiredLevel { get; }
        Module AreaType { get; }
    }
}
