using WinFormsApp1;

namespace SPTLauncher.Components
{
    internal class Paths
    {
        public static string gameFolder, profilesFolder, modManagerFolder, modManagerConfigPath, configPath, cachePath, itemCache, akiData, productionPath,
            gatoPath, backupsPath, modsFolder, pluginsFolder, downloadingPath, disabledModsPath, iconsPath, iconsCachePath, localesFile, databasePath, serverPath, serverConfigsPath;

        public static void Initialize(bool debug = false)
        {
            gameFolder = debug ? "F:/SPT" : new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName;
            profilesFolder = $"{gameFolder}/user/profiles";
            cachePath = $"{gameFolder}/Launcher-Cache";
            modManagerFolder = $"{cachePath}/ModManager";
            modManagerConfigPath = $"{modManagerFolder}/config.json";
            modsFolder = $"{gameFolder}/user/mods";
            pluginsFolder = $"{gameFolder}/bepinex/plugins";
            akiData = $"{gameFolder}/Aki_Data";
            serverPath = $"{akiData}/Server";
            configPath = $"{cachePath}/config.json";
            itemCache = $"{cachePath}/items";
            iconsPath = $"{cachePath}/icons";
            iconsCachePath = $"{modManagerFolder}/icons";
            gatoPath = $"{cachePath}/gato";
            backupsPath = $"{cachePath}/backups";
            databasePath = $"{serverPath}/database";
            downloadingPath = $"{modManagerFolder}/downloading";
            disabledModsPath = $"{modManagerFolder}/disabled";
            serverConfigsPath = $"{serverPath}/configs";
            productionPath = $"{databasePath}/hideout/production.json"; // - aki json file, should exist already nor should I make it
            localesFile = $"{databasePath}/locales/global/{Form1.language}.json";
            PathCheck();
        }

        public static void PathCheck()
        {
            List<string> paths = new List<string>
            {
                Paths.cachePath,
                Paths.itemCache,
                Paths.akiData,
                Paths.gatoPath,
                Paths.backupsPath,
                Paths.modsFolder,
                Paths.modManagerFolder,
                Paths.downloadingPath,
                Paths.disabledModsPath,
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
