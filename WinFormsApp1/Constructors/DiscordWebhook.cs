﻿namespace SPTLauncher.Constructors
{
    public struct DiscordWebhook
    {
        public string username { get; set; }
        public string avatar_url { get; set; }
        public string? content { get; set; }
        public List<Embeds>? embeds { get; set; }
    }
    public struct Embeds
    {
        public Author? author { get; set; }
        public string title { get; set; }
        public string? url { get; set; }
        public string description { get; set; }
        public string color { get; set; }
        public DateTime timestamp { get; set; }
        public List<EmbedField> fields { get; set; }
        public ImageSect image { get; set; }
        public ImageSect thumbnail { get; set; }
        public Footer? footer { get; set; }
    }
    public struct ImageSect
    {
        string url { get; set; }
    }
    public struct EmbedField
    {
        public string name { get; set; }
        public string value { get; set; }
        public bool inline { get; set; }
    }
    public struct Author
    {
        public string name { get; set; }
        public string? url { get; set; }
        public string? icon_url { get; set; }
    }
    public struct Footer
    {
        public string text { get; set; }
        public string icon_url { get; set; }
    }
}
