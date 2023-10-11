namespace SPTLauncher.Components.RecipeManagement.Requirements.Interfaces
{
    interface IItemRequirement : IRequirement
    {
        int Count { get; }
        bool IsEncoded { get; }
        bool IsFunctional { get; }
        string ItemID { get; }
    }
}
