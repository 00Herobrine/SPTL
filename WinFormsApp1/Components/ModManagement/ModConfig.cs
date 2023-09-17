namespace SPTLauncher.Components.ModManagement
{
    internal struct ModConfig
    {
        public string Name { get; set; }
        public string AkiVersion { get; set; }
        public string URL { get; set; }
        public bool AutoUpdate { get; set; }
        public ModType? Type { get; set; }
    }
}
