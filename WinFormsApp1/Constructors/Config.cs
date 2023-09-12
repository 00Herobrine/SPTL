using Microsoft.VisualBasic.Logging;
using Newtonsoft.Json.Linq;
using SPTLauncher.Components;
using System.Diagnostics;
using WinFormsApp1;

namespace SPTLauncher.Constructors
{
    public class Config
{
        private static string path;
        //private string gamePath;
        private static string apiKey = "";
        //private long lastBackupTime;
        private static DateTime lastBackupTime;
        private static int backupInterval;
        private static JObject? jObject;
        private static JArray? jArray;
        //public AkiData akiData;

        public static void Load()
        {
            string text = File.ReadAllText(Paths.configPath);
            path = Paths.configPath;
            jObject = JObject.Parse(text);
            if (jObject == null) return;
            if (jObject["DisabledMods"] != null)
            {
                // do shit
            } else
            {
                jObject["DisabledMods"] = new JObject();
            }
            //akiData = new AkiData(JObject.Parse(ReadCoreFile()));
            setApiKey(jObject["apiKey"].ToString());
            string time = jObject["LastBackup"].ToString();
            if (time == "" || time == null) SetLastBackUpTime(DateTime.Now);
            else SetLastBackUpTime(DateTime.Parse(jObject["LastBackup"].ToString()));
            var interval = jObject["BackupInterval"];
            if (interval == null) SetBackupInterval(1440);
            else SetBackupInterval((int)interval);
        }

        public static string ReadCoreFile() {
            return File.ReadAllText($"{Paths.serverConfigsPath}/core.json");
        }

        public static void setApiKey(string key)
        {
            jObject["apiKey"] = apiKey;
            apiKey = key;
            save();
        }
        public string getApiKey()
        {
            return apiKey;
        }
        public static void SetLastBackUpTime(DateTime time)
        {
            jObject["LastBackup"] = time;
            lastBackupTime = time;
            save();
        }
        public DateTime GetLastBackupTime()
        {
            return lastBackupTime;
        }

        public int GetBackupInterval()
        {
            return backupInterval;
        }
        public static void SetBackupInterval(int interval)
        {
            jObject["BackupInterval"] = interval;
            backupInterval = interval;
            save();
        }

        public static void save()
        {
            File.WriteAllText(Paths.configPath, jObject.ToString());
        }

        public JObject getJObject()
        {
            return jObject;
        }

        public static void DisableMod(Mod mod)
        {
            jObject["DisabledMods"][mod.GetName()] = mod.GetOriginalPath();
            Directory.Move($"{mod.GetPath()}", $"{Paths.disabledModsPath}/{mod.GetName()}");
            save();
        }

        public static void EnableMod(Mod mod)
        {
            Directory.Move($"{mod.GetPath()}", $"{mod.GetOriginalPath()}");
            ((JObject)jObject["DisabledMods"]).Remove(mod.GetName());
            save();
        }

        public bool ToggleBackups(string id)
        {
            bool backup = jArray.Contains(id)  && !(bool)jArray[id];
            jArray[id] = backup;
            save();
            return backup;
        }

        public bool BackupState(string id)
        {
            return jArray != null && jArray[id] != null && !(bool)jArray[id];
        }

        public string GetDisabledModPath(string name)
        {
            return jObject["DisabledMods"][name].ToString();
        }

}
}
