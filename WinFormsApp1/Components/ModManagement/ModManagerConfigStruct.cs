namespace SPTLauncher.Components.ModManagement
{
    public struct ModManagerConfigStruct
    {
        public List<ModConfig> ModConfigs { get; set; }
        public ModManagerConfigStruct()
        {
            ModConfigs = new List<ModConfig>();
        }
    }
}
