using Newtonsoft.Json;
using SPTLauncher.Components.Profiles;
using SPTLauncher.Constructors;
using SPTLauncher.Constructors.Enums;
using System.Reflection;

namespace SPTLauncher.Components
{
    internal class LauncherSettings
    {
        public static LANG language;
        public static AkiData akiData { get; set; }
        private static List<Profile> cachedProfiles = new();

        public static void Load()
        {
            akiData = JsonConvert.DeserializeObject<AkiData>(Config.ReadCoreFile());
        }

        public static List<Profile> GetProfiles() => cachedProfiles;
        public static string AkiVersion => akiData.akiVersion;
        public static Version Version => Assembly.GetExecutingAssembly().GetName().Version;

    }
}
