namespace SPTLauncher.Components.ModManagement
{
    public struct ModManagerConfigStruct
    {
        public List<ModConfig> ModConfigs { get; set; }
        public List<string> favorites { get; set; }
        public ModManagerConfigStruct()
        {
            ModConfigs = new List<ModConfig>();
            favorites = new List<string>();
        }
    }
}
