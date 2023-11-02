namespace SPTLauncher.Components.ModManagement
{
    public struct ModManagerConfigStruct
    {
        public List<ModConfig> ModConfigs { get; set; }
        public List<ModFavorite> favorites { get; set; }
        public ModManagerConfigStruct()
        {
            ModConfigs = new List<ModConfig>();
            favorites = new List<ModFavorite>();
        }
    }

    public struct ModFavorite
    {
        public string name;
        public string URL;
        public ModFavorite(string url, string name)
        {
            this.URL = url;
            this.name = name;
        }
    }
}
