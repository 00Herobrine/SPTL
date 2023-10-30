 namespace SPTLauncher.Components
{
    internal class Paths
    {
        public static string gameFolder, profilesFolder, modManagerFolder, modManagerConfigPath, configPath, cachePath, itemCache, akiData, productionPath, itemsPath,
            gatoPath, backupsPath, modsFolder, pluginsFolder, temp, downloadedPath, installedPath, disabledModsPath, iconsPath, iconsCachePath, localesFile, databasePath, serverPath, serverConfigsPath;

        public static void Initialize(bool debug = false)
        {
            gameFolder = debug ? "F:/SPT-3.6.1-2" : new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).FullName.TrimEnd(Path.DirectorySeparatorChar);
            profilesFolder = $"{gameFolder}/user/profiles";
            cachePath = $"{gameFolder}/Launcher-Cache";
            temp = $"{cachePath}/temp";
            modManagerFolder = $"{cachePath}/ModManager";
            modManagerConfigPath = $"{modManagerFolder}/config.json";
            modsFolder = $"{gameFolder}/user/mods";
            pluginsFolder = $"{gameFolder}/BepInEx/plugins";
            akiData = $"{gameFolder}/Aki_Data";
            serverPath = $"{akiData}/Server";
            configPath = $"{cachePath}/config.json";
            itemCache = $"{cachePath}/items";
            iconsPath = $"{cachePath}/icons";
            iconsCachePath = $"{modManagerFolder}/icons";
            gatoPath = $"{cachePath}/gato";
            backupsPath = $"{cachePath}/backups";
            databasePath = $"{serverPath}/database";
            itemsPath = $"{databasePath}/templates/items.json";
            downloadedPath = $"{modManagerFolder}/downloaded"; // maybe move this to %appdata% or %temp% as a shared cache
            installedPath = $"{modManagerFolder}/installed"; // unzipped mods for symlinking which will save space if multiple SPTs are installed
            disabledModsPath = $"{modManagerFolder}/disabled"; // won't be needed once symlinking is setup (if all mods are compatible)
            serverConfigsPath = $"{serverPath}/configs";
            productionPath = $"{databasePath}/hideout/production.json"; // - aki json file, should exist already nor should I make it
            localesFile = $"{databasePath}/locales/global/{Config.file.Lang}.json";
            PathCheck();
        }

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
