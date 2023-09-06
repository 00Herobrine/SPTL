using WinFormsApp1;

namespace SPTLauncher.Components
{
    internal class Paths
    {
        public static string gameFolder, profilesFolder, configPath, cachePath, itemCache, akiData, productionPath,
            gatoPath, backupsPath, modsFolder, pluginsFolder, disabledModsPath, localesFile, databasePath, serverPath, serverConfigsPath;

        public static void Initialize(bool debug = false)
        {
            gameFolder = debug ? "F:/SPT-3.6.1-2" : Environment.CurrentDirectory;
            profilesFolder = $"{gameFolder}/user/profiles";
            cachePath = $"{gameFolder}/Launcher-Cache";
            modsFolder = $"{gameFolder}/user/mods";
            pluginsFolder = $"{gameFolder}/bepinex/plugins";
            akiData = $"{gameFolder}/Aki_Data";
            serverPath = $"{akiData}/server";
            configPath = $"{cachePath}/config.json";
            itemCache = $"{cachePath}/items";
            gatoPath = $"{cachePath}/gato";
            backupsPath = $"{cachePath}/backups";
            disabledModsPath = $"{cachePath}/DisabledMods";
            databasePath = $"{serverPath}/database";
            serverConfigsPath = $"{serverPath}/configs";
            productionPath = $"{databasePath}/hideout/production.json"; // - aki json file, should exist already nor should I make it
            localesFile = $"{databasePath}/locales/global/{Form1.language}.json";
        }
    }
}
