﻿using Newtonsoft.Json;
using SPTLauncher.Components.Caching;
using SPTLauncher.Components.ModManagement;
using SPTLauncher.Constructors.Enums;
using System.Diagnostics;

namespace SPTLauncher.Components
{
    public static class Config
    {
        private static DateTime lastBackupTime;
        public static ConfigStruct file;

        public static void Load()
        {
            LoadFile();
            if (string.IsNullOrWhiteSpace(file.LastBackup.ToString())) SetLastBackUpTime(DateTime.Now);
            int interval = file.BackupInterval;
            if(interval < 0) SetBackupInterval(1440);
            else SetBackupInterval(interval);
            SetLang(file.Lang);
        }
        public static void SetLang(LANG Lang, bool saveFile = false)
        {
            file.Lang = Lang;
            Paths.localesFile = $"{Paths.databasePath}/locales/global/{Lang}.json";
            TarkovCache.StoreLocaleNames();
            LauncherSettings.language = Lang;
            if (saveFile) save(); 
        }
        public static void LoadFile()
        {
            try
            {
                if (!File.Exists(Paths.configPath)) {
                    ConfigStruct defaultStruct = new();
                    string json = JsonConvert.SerializeObject(defaultStruct, Formatting.Indented);
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
                Debug.WriteLine($"Error loading config: {ex.Message}");
            }
        }

        public static string ReadCoreFile() => File.ReadAllText($"{Paths.serverConfigsPath}/core.json");
        public static void SetApiKey(string key, bool saveFile = false)
        {
            file.apiKey = key;
            if (saveFile) save();
        }
        public static string GetApiKey() => file.apiKey;
        public static void SetLastBackUpTime(DateTime time, bool saveFile = false)
        {
            lastBackupTime = time;
            file.LastBackup = lastBackupTime;
            if(saveFile) save();
            //jObject["LastBackup"] = time;
        }
        public static DateTime GetLastBackupTime() => lastBackupTime;

        public static int GetBackupInterval() => file.BackupInterval;
        public static void SetBackupInterval(int interval, bool saveFile = false)
        {
            file.BackupInterval = interval;
            if (saveFile) save();
        }

        public static void save() => File.WriteAllText(Paths.configPath, JsonConvert.SerializeObject(file, Formatting.Indented));

        public static void DisableMod(Mod mod)
        {
            Directory.Move($"{mod.FilePath}", $"{Paths.disabledModsPath}/{mod.Name}");
            file.DisabledMods.Add(mod.Name, mod.OriginalPath);
            save();
        }

        public static void EnableMod(Mod mod)
        {
            Directory.Move($"{mod.FilePath}", $"{mod.OriginalPath}");
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
        public static bool GetImageCaching() => file.ImageCaching;
        public static bool BackupState() => file.Backups;
        public static string GetDisabledModPath(string name) => file.DisabledMods[name];

    }
}
