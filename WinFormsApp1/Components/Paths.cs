using System.Runtime.CompilerServices;
using WinFormsApp1;

namespace SPTLauncher.Components
{
    internal class Paths
    {
        public static string gameFolder, profilesFolder, modManagerFolder, configPath, cachePath, itemCache, akiData, productionPath,
            gatoPath, backupsPath, modsFolder, pluginsFolder, downloadingPath, disabledModsPath, localesFile, databasePath, serverPath, serverConfigsPath;

        public static void Initialize(bool debug = false)
        {
            gameFolder = debug ? "F:/SPT-3.6.1-2" : new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName;
            profilesFolder = $"{gameFolder}/user/profiles";
            cachePath = $"{gameFolder}/Launcher-Cache";
            modManagerFolder = $"{cachePath}/ModManager";
            modsFolder = $"{gameFolder}/user/mods";
            pluginsFolder = $"{gameFolder}/bepinex/plugins";
            akiData = $"{gameFolder}/Aki_Data";
            serverPath = $"{akiData}/server";
            configPath = $"{cachePath}/config.json";
            itemCache = $"{cachePath}/items";
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
