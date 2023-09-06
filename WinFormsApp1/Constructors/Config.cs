using Microsoft.VisualBasic.Logging;
using Newtonsoft.Json.Linq;
using SPTLauncher.Components;
using System.Diagnostics;
using WinFormsApp1;

namespace SPTLauncher.Constructors
{
    public class Config
{
        private string path;
        //private string gamePath;
        private string apiKey = "";
        //private long lastBackupTime;
        private DateTime lastBackupTime;
        private int backupInterval;
        private JObject? jObject;
        private JArray? jArray;
        //public AkiData akiData;
        public Config()
        {
            this.path = Paths.configPath;
            Load();
        }
        public Config(string path) {
            this.path = path;
            Load();
        }

        public void Load()
        {
            string text = File.ReadAllText(path);
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

        public void setApiKey(string apiKey)
        {
            jObject["apiKey"] = apiKey;
            this.apiKey = apiKey;
            save();
        }
        public string getApiKey()
        {
            return apiKey;
        }
        public void SetLastBackUpTime(DateTime time)
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
        public void SetBackupInterval(int interval)
        {
            jObject["BackupInterval"] = interval;
            backupInterval = interval;
            save();
        }

        public void save()
        {
            File.WriteAllText(path, jObject.ToString());
        }

        public JObject getJObject()
        {
            return jObject;
        }

        public void DisableMod(Mod mod)
        {
            string path;
            if (mod.isEnabled())
            {
                path = Paths.disabledModsPath + "/" + mod.GetName();
                jObject["DisabledMods"][mod.GetName()] = mod.GetOriginalPath();
            }
            else
            {
                path = mod.GetOriginalPath();
                ((JObject) jObject["DisabledMods"]).Remove(mod.GetName());
            }
            Debug.Write($"path {path}");
            Directory.Move(mod.GetPath(), path);
            save();
        }

        public void EnableMod(Mod mod)
        {
            string path = mod.GetOriginalPath() + "/" + mod.GetName();
            Directory.Move(mod.GetPath(), path);
            jArray[mod.GetName()] = null;
            jObject["DisabledMods"] = jArray;
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
