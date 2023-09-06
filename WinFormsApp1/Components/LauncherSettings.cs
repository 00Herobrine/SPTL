using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPTLauncher.Constructors;

namespace SPTLauncher.Components
{
    internal class LauncherSettings
    {
        public static LANG language;
        public static Config config = new();
        public static AkiData akiData = new();
        private static List<Profile> cachedProfiles = new();
        private static List<Mod> cachedMods = new();
        //private static LauncherSettings? settings;

        public static void Load()
        {
            config = new Config();
            //akiData = new AkiData();
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
