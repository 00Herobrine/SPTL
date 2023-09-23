using Newtonsoft.Json;
using SPTLauncher.Constructors;
using System.Diagnostics;
using WinFormsApp1;

namespace SPTLauncher.Components
{
    public class Config
    {
        private static string apiKey = "";
        private static DateTime lastBackupTime;
        private static int backupInterval;
        public static ConfigStruct file;

        public static void Load()
        {
            string text = File.ReadAllText(Paths.configPath ?? "");
            file = JsonConvert.DeserializeObject<ConfigStruct>(text);
            Debug.WriteLine(file);
            SetApiKey(file.apiKey);
            string time = file.LastBackup.ToString();
            if (time == "" || time == null) SetLastBackUpTime(DateTime.Now);
            else SetLastBackUpTime(file.LastBackup);
            int interval = file.BackupInterval;
            if(interval < 0) SetBackupInterval(1440);
            else SetBackupInterval(interval);
        }

        public static string ReadCoreFile()
        {
            return File.ReadAllText($"{Paths.serverConfigsPath}/core.json");
        }

        public static void SetApiKey(string key, bool saveFile = false)
        {
            apiKey = key;
            file.apiKey = key;
            if (saveFile) save();
        }
        public static string GetApiKey()
        {
            return apiKey;
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
            return backupInterval;
        }
        public static void SetBackupInterval(int interval, bool saveFile = false)
        {
            backupInterval = interval;
            file.BackupInterval = interval;
            if (saveFile) save();
        }

        public static void save()
        {
            File.WriteAllText(Paths.configPath, JsonConvert.SerializeObject(file));
        }

        public static void DisableMod(Mod mod)
        {
            Directory.Move($"{mod.GetPath()}", $"{Paths.disabledModsPath}/{mod.GetName()}");
            file.DisabledMods.Add(mod.GetName(), mod.GetOriginalPath());
            save();
        }

        public static void EnableMod(Mod mod)
        {
            Directory.Move($"{mod.GetPath()}", $"{mod.GetOriginalPath()}");
            file.DisabledMods.Remove(mod.GetName());
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
