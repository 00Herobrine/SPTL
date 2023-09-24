using Newtonsoft.Json;
using SPTLauncher.Components.ModManagement;
using SPTLauncher.Constructors;
using SPTLauncher.Constructors.Enums;

namespace SPTLauncher.Components
{
    internal class LauncherSettings
    {
        public static LANG language;
        public static Config config = new();
        public static AkiData akiData;
        private static List<Profile> cachedProfiles = new();
        private static List<Mod> cachedMods = new();

        public static void Load()
        {
            config = new Config();
            akiData = JsonConvert.DeserializeObject<AkiData>(Config.ReadCoreFile());
        }

        public static List<Profile> GetProfiles()
        {
            return cachedProfiles;
        }

        public static List<Mod> GetMods()
        {
            return cachedMods;
        }

        public static AkiData GetAkiData()
        {
            return akiData;
        }

    }
}
