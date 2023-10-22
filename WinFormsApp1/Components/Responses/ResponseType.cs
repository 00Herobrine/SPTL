using System.ComponentModel;

namespace SPTLauncher.Components.Responses
{
    public enum ResponseType
    {
        [Description("Positive Player Death")] 
        Killer_Positive, // Player dies to AI
        [Description("Negative Player Death")] 
        Killer_Negative, // Player dies to AI
        [Description("Netural Player Death")]
        Killer_Plead, // Player dies to AI (Neutral Response)
        [Description("Positive AI Death")]
        Victim_Positive, // AI dies to Player
        [Description("Negative AI Death")]
        Victim_Negative, // AI dies to Player
        [Description("Netural AI Death")]
        Victim_Plead, // AI dies to Player (Neutral Response)
        [Description("Suffix")]
        Suffix,
    }
}
