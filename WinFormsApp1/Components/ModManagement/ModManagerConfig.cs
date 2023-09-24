using Newtonsoft.Json;

namespace SPTLauncher.Components.ModManagement
{
    public class ModManagerConfig
    {
        public static ModManagerConfigStruct file;
        private static Dictionary<string, ModType> DisabledMods = new();

        public static void Initialize()
        {
            DisabledMods.Clear();
            LoadConfig();
/*            if (Config["ModStuff"] == null) return;
            mods = JsonConvert.DeserializeObject<List<ModConfig>>(Config["ModStuff"].ToString());
            if (mods == null) return; 
            foreach(ModConfig conf in mods)
            {
                if (conf.Type == null) continue;
                DisabledMods.Add(conf.Name, (ModType)conf.Type);
            }*/
            //Form1.form.log($"Loaded: {mods.Count} M and {DisabledMods.Count} D");
        }

        public static ConfigStruct LoadConfig()
        {
            if (File.Exists(Paths.configPath))
            {
                try
                {
                    string json = File.ReadAllText(Paths.configPath);
                    return JsonConvert.DeserializeObject<ConfigStruct>(json);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading config: {ex.Message}");
                }
            }

            // If the file doesn't exist or there was an error, return a new instance with default values.
            return new ConfigStruct();
        }
    }
}
