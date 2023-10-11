using System.Runtime.Serialization;

namespace SPTLauncher.Components.RecipeManagement.Requirements.Interfaces
{
    internal interface IToolRequirement : IRequirement
    {
        [DataMember(Name = "templateId")]
        string ItemID { get; }
    }
}
