using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WinFormsApp1;

namespace SPTLauncher.Components.ModManagement
{
    public class ModManagerConfig
    {
        private static JObject Config = new();
        private static List<ModConfig>? mods = new();
        private static Dictionary<string, ModType> DisabledMods = new();

        public static void Initialize()
        {
            DisabledMods.Clear();
            ReadConfig();
            if (Config["ModStuff"] == null) return;
            mods = JsonConvert.DeserializeObject<List<ModConfig>>(Config["ModStuff"].ToString());
            if (mods == null) return; 
            foreach(ModConfig conf in mods)
            {
                if (conf.Type == null) continue;
                DisabledMods.Add(conf.Name, (ModType)conf.Type);
            }
            //Form1.form.log($"Loaded: {mods.Count} M and {DisabledMods.Count} D");
        }

        public static string ReadConfig()
        {
            string config = File.ReadAllText(Paths.modManagerConfigPath);
            Config = JObject.Parse(config);
            return config;
        }


    }
}
