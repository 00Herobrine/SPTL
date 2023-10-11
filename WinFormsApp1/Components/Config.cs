using Newtonsoft.Json;
using SPTLauncher.Components.ModManagement;
using SPTLauncher.Constructors.Enums;
using System.Diagnostics;

namespace SPTLauncher.Components
{
    public class Config
    {
        private static DateTime lastBackupTime;
        public static ConfigStruct file;

        public static void Load()
        {
            LoadFile();
            Debug.WriteLine(JsonConvert.SerializeObject(file));
            if (string.IsNullOrWhiteSpace(file.LastBackup.ToString())) SetLastBackUpTime(DateTime.Now);
            int interval = file.BackupInterval;
            if(interval < 0) SetBackupInterval(1440);
            else SetBackupInterval(interval);
        }
        public static void SetLang(LANG Lang, bool saveFile = false)
        {
            file.Lang = Lang;
            Paths.localesFile = $"{Paths.databasePath}/locales/global/{Lang}.json";
            TarkovCache.UpdateNameCache();
            if (saveFile) save(); 
        }
        public static void LoadFile()
        {
            try
            {
                if (!File.Exists(Paths.configPath)) {
                    ConfigStruct defaultStruct = new();
                    string json = JsonConvert.SerializeObject(defaultStruct);
                    File.WriteAllText(Paths.configPath, json);
                    file = defaultStruct;
                return;
            }
                if (File.Exists(Paths.configPath))
                {
                    string json = File.ReadAllText(Paths.configPath);
                    file = JsonConvert.DeserializeObject<ConfigStruct>(json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading config: {ex.Message}");
            }
        }

        public static string ReadCoreFile()
        {
            return File.ReadAllText($"{Paths.serverConfigsPath}/core.json");
        }

        public static void SetApiKey(string key, bool saveFile = false)
        {
            file.apiKey = key;
            if (saveFile) save();
        }
        public static string GetApiKey()
        {
            return file.apiKey;
        }
        public static void SetLastBackUpTime(DateTime time, bool saveFile = false)
        {
            lastBackupTime = time;
            file.LastBackup = lastBackupTime;
            if(saveFile) save();
            //jObject["LastBackup"] = time;
        }
        public static DateTime GetLastBackupTime()
        {
            return lastBackupTime;
        }

        public static int GetBackupInterval()
        {
            return file.BackupInterval;
        }
        public static void SetBackupInterval(int interval, bool saveFile = false)
        {
            file.BackupInterval = interval;
            if (saveFile) save();
        }

        public static void save()
        {
            File.WriteAllText(Paths.configPath, JsonConvert.SerializeObject(file));
        }

        public static void DisableMod(Mod mod)
        {
            Directory.Move($"{mod.Path}", $"{Paths.disabledModsPath}/{mod.Name}");
            file.DisabledMods.Add(mod.Name, mod.OriginalPath);
            save();
        }

        public static void EnableMod(Mod mod)
        {
            Directory.Move($"{mod.Path}", $"{mod.OriginalPath}");
            file.DisabledMods.Remove(mod.Name);
            save();
        }

        public static bool ToggleBackups()
        {
            bool backup = !file.Backups;
            file.Backups = backup;
            return backup;
        }

        public static void SetImageCache(bool state)
        {
            file.ImageCaching = state;
            save();
        }
        public static bool GetImageCaching()
        {
            return file.ImageCaching;
        }

        public static bool BackupState()
        {
            return file.Backups;
        }

        public static string GetDisabledModPath(string name)
        {
            return file.DisabledMods[name];
        }

    }
}
