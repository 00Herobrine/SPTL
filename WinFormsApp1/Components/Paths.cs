using System.Diagnostics;

namespace SPTLauncher.Components
{
    internal static class Paths
    {
        public static string gameFolder = Debugger.IsAttached ? "F:/SPT-3.6.1-2" : Environment.CurrentDirectory;
        public static string profilesFolder = $"{gameFolder}/user/profiles";
        public static string cachePath = $"{gameFolder}/Launcher-Cache";
        public static string temp = $"{cachePath}/temp";
        public static string modManagerFolder = $"{cachePath}/ModManager";
        public static string modManagerConfigPath = $"{modManagerFolder}/config.json";
        public static string modsFolder = $"{gameFolder}/user/mods";
        public static string pluginsFolder = $"{gameFolder}/BepInEx/plugins";
        public static string akiData = $"{gameFolder}/Aki_Data";
        public static string serverPath = $"{akiData}/Server";
        public static string configPath = $"{cachePath}/config.json";
        public static string itemCache = $"{cachePath}/items";
        public static string iconsPath = $"{cachePath}/icons";
        public static string iconsCachePath = $"{modManagerFolder}/icons";
        public static string gatoPath = $"{cachePath}/gato";
        public static string backupsPath = $"{cachePath}/backups";
        public static string databasePath = $"{serverPath}/database";
        public static string itemsPath = $"{databasePath}/templates/items.json";
        public static string downloadedPath = $"{modManagerFolder}/downloaded"; // maybe move this to %appdata% or %temp% as a shared cache
        public static string installedPath = $"{modManagerFolder}/installed"; // unzipped mods for symlinking which will save space if multiple SPTs are installed
        public static string disabledModsPath = $"{modManagerFolder}/disabled"; // won't be needed once symlinking is setup (if all mods are compatible)
        public static string serverConfigsPath = $"{serverPath}/configs";
        public static string productionPath = $"{databasePath}/hideout/production.json"; // - aki json file, should exist already nor should I make it
        public static string localesFile = $"{databasePath}/locales/global/{Config.file.Lang}.json";
        public static Image bug => GetImage("bug");
        public static Image donate => GetImage("donate");
        public static Image down => GetImage("down");
        public static Image folder => GetImage("folder32px");
        public static Image settings => GetImage("gear32px");
        public static Image NotFound => GetImage("NotFound");
        public static Image Roller => GetImage("roller144", "gif");
        public static Image starEmpty => GetImage("starEmpty");
        public static Image starFilled => GetImage("starFilled");

        public static Image GetImage(string imageName, string extension = "png") => Image.FromFile($"{iconsPath}/{imageName}.{extension}");

        public static void PathCheck()
        {
            List<string> paths = new List<string>
            {
                Paths.cachePath,
                //Paths.akiData,
                Paths.gatoPath,
                Paths.backupsPath,
                Paths.modsFolder,
                Paths.modManagerFolder,
                Paths.downloadedPath,
                Paths.disabledModsPath,
                Paths.iconsPath,
                Paths.iconsCachePath,
                Paths.pluginsFolder
            };
            foreach (var path in paths)
            {
                if (path == null) continue;
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            }
        }
    }
}
